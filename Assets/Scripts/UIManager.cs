using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Displays and updates stats in the UI.
/// </summary>
public class UIManager : Singleton<UIManager>
{
    public PlayerStats playerStats;
    public TextMeshProUGUI sceneText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI dexterityText;
    public TextMeshProUGUI intelligenceText;
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public Button LoadButton;
    public Button SaveButton;
    public Button DeleteSave;
    public Button QuitButton;

    private void Awake()
    {
        base.Awake();
        playerStats = FindFirstObjectByType<PlayerStats>();
        LoadButton.onClick.AddListener(SaveManager.Instance.LoadGame);
        SaveButton.onClick.AddListener(SaveManager.Instance.SaveGame);
        DeleteSave.onClick.AddListener(SaveManager.Instance.DeleteSave);
        QuitButton.onClick.AddListener(Application.Quit);
    }


    private void Update()
    {
        if (playerStats != null)
        {
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        // Update text based on stats.
        sceneText.text = SceneManager.GetActiveScene().name;
        healthText.text = "Health: " + playerStats.health;
        dexterityText.text = "Dexterity: " + playerStats.dexterity;
        intelligenceText.text = "Intelligence: " + playerStats.intelligence;
        strengthText.text = "Strength: " + playerStats.strength;
        xpText.text = "XP: " + playerStats.xp;
        scoreText.text = "Score: " + playerStats.score;
        levelText.text = "Level: " + playerStats.level;
    }

    public void IncreaseStat(string statName)
    {
        // Increases a stat by name.
        switch (statName.ToLower())
        {
            case "health":
                playerStats.health++;
                break;
            case "dexterity":
                playerStats.dexterity++;
                break;
            case "intelligence":
                playerStats.intelligence++;
                break;
            case "strength":
                playerStats.strength++;
                break;
            case "xp":
                playerStats.xp++;
                break;
            case "score":
                playerStats.score++;
                break;
            case "level":
                playerStats.level++;           
                break;
            default:
                Debug.LogWarning("Stat not found: " + statName);
                return;
        }
        UpdateUI();
    }

    public void DecreaseStat(string statName)
    {
        // Decreases a stat by name.
        switch (statName.ToLower())
        {
            case "health":
                playerStats.health--;
                break;
            case "dexterity":
                playerStats.dexterity--;
                break;
            case "intelligence":
                playerStats.intelligence--;
                break;
            case "strength":
                playerStats.strength--;
                break;
            case "xp":
                playerStats.xp--;
                break;
            case "score":
                playerStats.score--;
                break;
            case "level":
                playerStats.level--;
                break;
            default:
                Debug.LogWarning("Stat not found: " + statName);
                return;
        }
        UpdateUI();
    }
}
