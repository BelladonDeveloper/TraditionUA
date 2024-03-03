using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
                StartCoroutine("Wining");
            }
            else
            {
                StartCoroutine("Losing");
            }
        } 

        if (transform.GetComponent<PlayerWining>().score != counter)
        {
            transform.GetComponent<PlayerWining>().score = counter;
        }
    }
    public IEnumerator Wining()
    {
        youWin.GetComponent<CanvasGroup>().alpha = 1;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Василів_День_Основа");
    }
    public IEnumerator Losing()
    {
        gameOver.GetComponent<CanvasGroup>().alpha = 1;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("NeedleFinding");
    }
}
