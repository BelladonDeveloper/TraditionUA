using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int minutes = 0;
    public int seconds = 0;
    public Text timer;

    public void Start()
    {
        StartCoroutine("Timerr");
    }

    public IEnumerator Timerr()
    {
        yield return new WaitForSeconds(1);
        seconds++;
    }
}
