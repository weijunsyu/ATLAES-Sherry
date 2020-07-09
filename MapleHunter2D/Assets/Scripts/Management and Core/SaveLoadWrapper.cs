using System.Collections.Generic;
using UnityEngine;

public class SaveLoadWrapper
{
    public void SaveGame(int saveNumber)
    {
        Dictionary<string, object> saveData = new Dictionary<string, object>();
        //populate dictionary with required parameters

        SaveSystem.SavePlayerData(saveData, saveNumber);
    }

    // Return true if load successful, false otherwise
    public bool LoadGame(int saveNumber)
    {
        PlayerSaveData data = SaveSystem.LoadPlayerData(saveNumber);

        if (data != null) //savefile exists
        {
            //set variables

            return true;
        }
        else //savefile does not exist
        {
            return false;
        }
    }
}
