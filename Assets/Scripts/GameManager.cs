using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Game Manager manages game state. For the sake of this demo it only handles scene loading.
/// </summary>
public class GameManager : Singleton<GameManager>
{
    static int gameManagerCount;
    public TextMeshProUGUI debugText;


    protected override void Awake()
    {
        base.Awake();
        // For debug purposes. Ensure only one instance exists.
        gameManagerCount++;
        debugText.text = "GameManager Count: " + gameManagerCount;
    }
    private void Update()
    {
        // Handle loading scenes based on key presses.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene(3);
        }
    }
}
