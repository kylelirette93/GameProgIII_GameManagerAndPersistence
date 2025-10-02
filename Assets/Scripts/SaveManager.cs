using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void SaveGame()
    {
        // Create a new save file, after applying stats to data.
        PlayerStats stats = FindFirstObjectByType<PlayerStats>();
        if (stats == null) return;

        PlayerData data = new PlayerData();
        data.health = stats.health;
        data.dexterity = stats.dexterity;
        data.intelligence = stats.intelligence;
        data.strength = stats.strength;
        data.xp = stats.xp;
        data.score = stats.score;
        data.level = stats.level;
        BinaryFormatter BF = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        BF.Serialize(file, data);
        file.Close();
    }

    public void LoadGame()
    {
        // Open the file, get the data and assign stats to data.
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter BF = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)BF.Deserialize(file);
            file.Close();

            PlayerStats stats = FindFirstObjectByType<PlayerStats>();
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
            // Start a new game if no save exists.
            BinaryFormatter BF = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
            PlayerData data = new PlayerData();
            BF.Serialize(file, data);
            file.Close();
        }
    }
}


[System.Serializable]
public class PlayerData
{
    public int health;
    public int dexterity;
    public int intelligence;
    public int strength;
    public int xp;
    public int score;
    public int level;
}
