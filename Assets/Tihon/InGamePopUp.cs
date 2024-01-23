using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tihon : MonoBehaviour
{
    public Button popUpButton;
    public GameObject popUp;
    public Canvas canvas;
    private bool isOpen = false;
    void Start() 
    {
        popUpButton.onClick.AddListener(PopUping);
    }
    private void Update()
    {
        if (canvas.GetComponent<TaskManager>().taskStarted) {
            canvas.GetComponent<TaskManager>().taskStarted = false;
            Debug.Log(1);
            canvas.GetComponent<TaskManager>().EndOfTask();
        }
    }
    void PopUping()
    {
        if(isOpen==false) {
            popUp.transform.position = new Vector2(((canvas.transform.position.x) - 65), canvas.transform.position.y);
            isOpen = true;
            Debug.Log(popUp.transform.position);
        }
        else
        {
            popUp.transform.position = new Vector2(-1331, 0);
            isOpen = false;
            Debug.Log(popUp.transform.position);
        }
    }
}
