using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayerData(PlayerData playerData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + GameConstants.SAVEPATH;
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerSaveData data = new PlayerSaveData(playerData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerSaveData LoadPlayerData()
    {
        string path = Application.persistentDataPath + GameConstants.SAVEPATH;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerSaveData data = formatter.Deserialize(stream) as PlayerSaveData;
            stream.Close();

            return data;
        }
        else //save does not exist!
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
