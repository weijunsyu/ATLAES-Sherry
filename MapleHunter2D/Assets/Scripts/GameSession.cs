using UnityEngine;

public class GameSession : MonoBehaviour
{
    private void Awake()
    {
        KeepPersistentStatus();
    }
    private void KeepPersistentStatus()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
