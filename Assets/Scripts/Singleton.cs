using UnityEngine;

/// <summary>
/// Generic singleton class. Any class that derrives from this will be a singleton.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Static entry point to access singleton instance.
    static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject singletonGO = new GameObject(typeof(T).Name);
                    instance = singletonGO.AddComponent<T>();
                }
            }
            return instance;
        }
    }
    
    protected virtual void Awake()
    {
        #region Singleton Pattern
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        #endregion
    }
}
