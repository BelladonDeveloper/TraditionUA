using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class MenuData : MonoBehaviour
{
    private string filePath = "Assets/Resources/MainMenuData/MainMenuData.txt";
    [SerializeField] private TMP_Text TimeText;

    public int level;

    public string dayTime;
    public int day;
    public string _time;

    private void Start()
    {
        ReadDataFromFile();
    }

    private void ReadDataFromFile()
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            string[] parts = lines[level].Split(',');
            
            dayTime = parts[0];
            day = int.Parse(parts[1]);
            _time = parts[2];
        }
        catch (IOException e)
        {
            Debug.LogError("Error reading the file: " + e.Message);
        }
        



        TimeText.text = _time;

        Debug.Log(dayTime + " " + day);
    }
}
