using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveSettingsData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + GameConstants.SETTINGSFILE;
        FileStream stream = new FileStream(path, FileMode.Create);

        SettingsData data = new SettingsData();

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static SettingsData LoadSettingsData()
    {
        string path = Application.persistentDataPath + "/" + GameConstants.SETTINGSFILE;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SettingsData settings = formatter.Deserialize(stream) as SettingsData;
            stream.Close();

            return settings;
        }
        else //settings does not exist!
        {
            return null;
        }
    }
    public static void DeletePlayerData(int saveNumber)
    {
        string path = Application.persistentDataPath + "/" + saveNumber + GameConstants.SAVEFILE;
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
    public static void SavePlayerData(int saveNumber)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + saveNumber + GameConstants.SAVEFILE;
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData();

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
            //Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
    public static bool CheckSaveNumber(int saveNumber)
    {
        if (saveNumber < 0)
        {
            return false;
        }
        return true;
    }
}
