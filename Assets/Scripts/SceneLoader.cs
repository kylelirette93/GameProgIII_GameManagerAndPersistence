using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Loads a persistent scene to maintain game state across scenes.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("PersistentScene", LoadSceneMode.Additive);
    }
}
