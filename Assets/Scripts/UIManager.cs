using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Displays and updates stats in the UI.
/// </summary>
public class UIManager : MonoBehaviour
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


    private void Update()
    {
        UpdateUI();
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
                if (playerStats.level < SceneManager.sceneCountInBuildSettings - 1)
                {
                    playerStats.level++;
                }
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
                if (playerStats.level > 0)
                    playerStats.level--;
                break;
            default:
                Debug.LogWarning("Stat not found: " + statName);
                return;
        }
        UpdateUI();
    }
}
