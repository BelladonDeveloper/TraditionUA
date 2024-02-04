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
            win.transform.position = new Vector3(367.6667f, 147.6667f, 0);
            Time.timeScale = 0;
        }
    }
}
