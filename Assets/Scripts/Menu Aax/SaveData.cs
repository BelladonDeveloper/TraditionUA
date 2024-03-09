using System.IO;
using UnityEngine;

public static class SaveData
{
    private static readonly string _path = Application.persistentDataPath + "/Saves/";
    private static string _dotJson = ".json";

    public static void Save(object data, string fileName)
    {
        string jsonData = JsonUtility.ToJson(data, true);

        CheckDirectory();
        File.WriteAllText(_path + fileName + _dotJson, jsonData);
    }

    public static T Load<T>(string fileName)
    {
        if(File.Exists(_path + fileName + _dotJson))
        {
            string loadedData = File.ReadAllText(_path + fileName + _dotJson);

            return JsonUtility.FromJson<T>(loadedData);
        }
        return default(T);
    }

    private static void CheckDirectory()
    {
        if(!Directory.Exists(_path))
        {
            Directory.CreateDirectory(_path);
        }
    }
}
