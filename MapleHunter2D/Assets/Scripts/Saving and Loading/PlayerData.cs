
public class PlayerData
{
    public void SaveGame(int saveNumber)
    {
        SaveSystem.SavePlayerData(this, saveNumber);
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
