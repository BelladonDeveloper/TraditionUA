using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class EasterMessageForSecondTaskMemory : MonoBehaviour
{
    public static event Action OnTimeEnded;

    [SerializeField] private TextMeshProUGUI _timerText;

    private bool _isDone;

    public void TimerStart()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        _timerText.text = "Remember";
        yield return new WaitForSeconds(3f);
        _timerText.text = "3";
        yield return new WaitForSeconds(1);
        _timerText.text = "2";
        yield return new WaitForSeconds(1);
        _timerText.text = "1";
        yield return new WaitForSeconds(1);
        _timerText.text = "Start!";

        OnTimeEnded?.Invoke();

        yield return new WaitForSeconds(3f);
        _timerText.text = "";
    }

    private void OnEnable() => SecondTaskManager.OnTimerStarted += TimerStart;

    private void OnDisable() => SecondTaskManager.OnTimerStarted -= TimerStart;
}
