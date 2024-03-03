using UnityEngine;
using System.IO;
using System.Linq;

public class SavingData : MonoBehaviour
{
    private string filePath;

    private void Start()
    {
        filePath = Application.persistentDataPath + "/data.json";

        if (!File.Exists(filePath))
        {
            CreateJsonFile();
        }
        else
        {
            DebugFirstLine();
        }
    }

    private void CreateJsonFile()
    {
        string jsonData = "{ \"name\": \"John\", \"age\": 30 }";

        // Write the JSON data to the file
        File.WriteAllText(filePath, jsonData);

        Debug.Log("JSON file created!");
    }

    private void DebugFirstLine()
    {
        // Read the first line of the file
        string firstLine = File.ReadLines(filePath).FirstOrDefault();

        if (!string.IsNullOrEmpty(firstLine))
        {
            Debug.Log("First line of JSON file: " + firstLine);
        }
        else
        {
            Debug.LogError("JSON file is empty!");
        }
    }
}
