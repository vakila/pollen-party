using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance { get; private set; }

    public int flowersCollected = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
