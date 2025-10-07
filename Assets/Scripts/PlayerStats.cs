using UnityEngine;

/// <summary>
/// Holds player stats at runtime.
/// </summary>
public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int dexterity;
    public int intelligence;
    public int strength;
    public int xp;
    public int score;
    public int level;

    public void Reset()
    {
        health = 100;
        dexterity = 0;
        intelligence = 0;
        strength = 0;
        xp = 0;
        score = 0;
        level = 0;
    }
}
