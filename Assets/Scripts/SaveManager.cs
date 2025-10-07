using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Responsible for saving and loading game data.
/// </summary>
public class SaveManager : Singleton<SaveManager>
{
    PlayerStats stats;
    public void Awake()
    {
        base.Awake();
        // Obtain stats object to save data to it.
        stats = FindFirstObjectByType<PlayerStats>();
    }
    public void SaveGame()
    {
        if (stats == null) return;

        // Create binary formatter.
        BinaryFormatter BF = new BinaryFormatter();
        // Create file at path to save to.
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        // Create data object and pass stats to data.
        PlayerData data = new PlayerData 
        {
            health = stats.health,
            dexterity = stats.dexterity,
            intelligence = stats.intelligence,
            strength = stats.strength,
            xp = stats.xp,
            score = stats.score,
            level = stats.level
        };

        // Serialize data to file and close it.
        BF.Serialize(file, data);
        file.Close();
    }

    public void LoadGame()
    {
        // Check if a file already exists.
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            // Create binary formatter.
            BinaryFormatter BF = new BinaryFormatter();
            // Open existing file.
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            // Deserialize file and cast to data.
            PlayerData data = (PlayerData)BF.Deserialize(file);
            file.Close();

            if (stats == null) return;
            
            stats.health = data.health;
            stats.dexterity = data.dexterity;
            stats.intelligence = data.intelligence;
            stats.strength = data.strength;
            stats.xp = data.xp;
            stats.score = data.score;
            stats.level = data.level;
        }
        else
        {
            PlayerStats stats = FindFirstObjectByType<PlayerStats>();
            if (stats == null) return;

            // No save file exists to load. Start a new game.
            BinaryFormatter BF = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
            PlayerData data = new PlayerData();
            data.health = stats.health;
            data.dexterity = stats.dexterity;
            data.intelligence = stats.intelligence;
            data.strength = stats.strength;
            data.xp = stats.xp;
            data.score = stats.score;
            data.level = stats.level;

            BF.Serialize(file, data);
            file.Close();
        }
        SceneManager.LoadScene(1);
    }

    public void DeleteSave()
    {
        // Deletes an existing save file.
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            File.Delete(Application.persistentDataPath + "/playerInfo.dat");
            stats.Reset();
        }
    }
}

/// <summary>
/// Holds player stats for saving and loading. Serializable for binary formatting.
/// </summary>
[Serializable]
class PlayerData
{
    public int health;
    public int dexterity;
    public int intelligence;
    public int strength;
    public int xp;
    public int score;
    public int level;
}
