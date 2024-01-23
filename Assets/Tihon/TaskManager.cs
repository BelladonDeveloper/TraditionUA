using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public string startEvent;
    public GameObject trigger;
    public KeyCode key;
    public bool taskStarted = false;
    public bool taskEnded = false;
    public Image prize;

    private void Start()
    {
        prize.transform.position = new Vector2(367, 251);
        prize.color = new Color(255,255, 255, 0);
    }
    void Update()
    {
        if (startEvent == "key")
        {
            if(Input.GetKeyDown(key)) {
                taskStarted = true;
            }
        }
    }
    void OnTriggerEnter(GameObject trigger)
    {
        if(startEvent == "trigger"){
            taskStarted = true;
        }
    }
    void OnTriggerEnter2D(GameObject trigger)
    {
        if (startEvent == "trigger")
        {
            taskStarted = true;
        }
    }
    public void EndOfTask()
    {
        taskEnded = true;
        if(taskEnded) {
            prize.color = new Color(255, 255, 255, 255);
        }  
    }
}
