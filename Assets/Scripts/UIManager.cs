using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerStats playerStats;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI dexterityText;
    public TextMeshProUGUI intelligenceText;
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public Button loadButton;


    private void Update()
    {
        UpdateUI();
    }
    public void UpdateUI()
    {
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
