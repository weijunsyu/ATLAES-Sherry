using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem
{

    public static void SavePlayerData(MasterManager saveData, int saveNumber)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + saveNumber + GameConstants.SAVEFILE;
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(saveData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadPlayerData(int saveNumber)
    {
        string path = Application.persistentDataPath + "/" + saveNumber + GameConstants.SAVEFILE;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
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
