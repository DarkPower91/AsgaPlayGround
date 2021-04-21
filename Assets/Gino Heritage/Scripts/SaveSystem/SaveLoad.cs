using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad
{
    private static string persistentSavePath = Application.persistentDataPath + "/saves/";
    private static string saveFileExtention = ".sav";

    private static string GetPath(string key)
    {
        return persistentSavePath + key + saveFileExtention;
    }

    public static void Save<T>(object objectToBeSaved, string key)
    {
        Directory.CreateDirectory(persistentSavePath);
        BinaryFormatter formatter = new BinaryFormatter();
        using(FileStream stream = new FileStream(GetPath(key), FileMode.Create))
        {
            formatter.Serialize(stream, objectToBeSaved);
        }
    }

    public static T Load<T>(string key)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        T returnObject = default(T);
        using(FileStream stream = new FileStream(GetPath(key), FileMode.Open))
        {
            returnObject = (T)formatter.Deserialize(stream);
        }
        return returnObject;
    }

    public static bool SaveExist(string key)
    {
        return File.Exists(GetPath(key));        
    }

    public static void ClearAllSaves()
    {
        DirectoryInfo saveDirectory = new DirectoryInfo(persistentSavePath);
        saveDirectory.Delete(true);
        #if UNITY_EDITOR
        ;
        #else
        Directory.CreateDirectory(persistentSavePath);
        #endif
    }
}
