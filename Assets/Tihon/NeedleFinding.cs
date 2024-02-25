using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedleFinding : MonoBehaviour
{
    public int counter = 0;
    public int needles = 3;
    public Image gameOver;
    public Image youWin;

    private void Update()
    {
        if (needles == 0)
        {
            if (counter == 3)
            {
                youWin.GetComponent<CanvasGroup>().alpha = 1;
            }
            else
            {
                gameOver.GetComponent<CanvasGroup>().alpha = 1;
            }
        } 

        if (transform.GetComponent<PlayerWining>().score != counter)
        {
            transform.GetComponent<PlayerWining>().score = counter;
        }
    }
}
