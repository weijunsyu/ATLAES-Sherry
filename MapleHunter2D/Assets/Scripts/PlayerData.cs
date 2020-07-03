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
}
