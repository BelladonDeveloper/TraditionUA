using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWining : MonoBehaviour
{
    public int winingScore;
    public int score;
    public GameObject win;
    void Update()
    {
        if(score == winingScore)
        {
            win.GetComponent<CanvasGroup>().alpha = 1;
            Time.timeScale = 0;
        }
    }
}
