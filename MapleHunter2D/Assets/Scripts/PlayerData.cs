using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public void SaveGame()
    {
        SaveSystem.SavePlayerData(this);
    }
    public void LoadGame()
    {
        PlayerSaveData data = SaveSystem.LoadPlayerData();

        if (data != null) //savefile exists
        {
            //set variables
        }
        else //savefile does not exist
        {
            /* Autosave system?
            //create save file
            SaveGame();
            */
        }
    }
    private void Awake()
    {
        KeepPersistentStatus();
    }
    private void Start()
    {
        //LoadGame();
        //input all loaded variables
        
    }
    private void KeepPersistentStatus()
    {
        int gameStatusCount = FindObjectsOfType<PlayerData>().Length;
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
