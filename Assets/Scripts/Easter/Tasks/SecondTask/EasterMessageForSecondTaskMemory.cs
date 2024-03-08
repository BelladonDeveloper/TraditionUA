using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class EasterMessageForSecondTaskMemory : MonoBehaviour
{
    public static event Action OnLost;
    public static event Action OnTimeEnded;

    [SerializeField] private TextMeshProUGUI _timerText;

    private float _currentTime;

    private bool _isStarted;
    private bool _isDone;
    private bool _stopTimer;

    public void TimerStart()
    {
        StartCoroutine(Timer());
    }

    public void MoreTime(float time)
    {
        _currentTime = time;
    }

    public void StopTimer()
    {
        _stopTimer = true;

        _timerText.text = "";
    }

    public void OnTimerStarted()
    {
        if (_stopTimer == false)
        {
            Sequence fade = DOTween.Sequence();

            fade.Append(_timerText.DOFade(1, 1f));

            if (_currentTime > 1 && EasterCurrentSprite.IsDone == false)
            {
                _currentTime -= Time.deltaTime;
                UpdateTimerText();
            }


            if (_currentTime <= 1 && _isDone == false && EasterCurrentSprite.IsDone == false)
            {
                _isDone = true;

                OnLost?.Invoke();

                _currentTime = 0;
            }

            if (EasterCurrentSprite.IsDone == true)
            {
                _timerText.text = "";
            }
        }
    }

    public void ResetConfig()
    {
        _currentTime = Mathf.Infinity;
        _timerText.text = "";

        _isDone = false;
        _isStarted = false;
    }

    private void Update()
    {
        if (_isStarted)
        {
            OnTimerStarted();
        }
    }

    private IEnumerator Timer()
    {
        _timerText.text = "";

        _isStarted = false;

        SecondTaskManager.Singleton.OnStop();

        _timerText.text = "";
        yield return new WaitForSeconds(3f);

        for (int i = 0; i < 4; i++)
        {
            _timerText.text = (3 - i).ToString();

            yield return new WaitForSeconds(1);
        }

        _timerText.text = "";

        OnTimeEnded?.Invoke();

        yield return new WaitForSeconds(1f);

        switch (SecondTask.Levels)
        {
            case 0:
                MoreTime(15);
                break;
            case 1:
                MoreTime(30);
                break;
            case 2:
                MoreTime(45);
                break;

            default:
                Debug.Log($"I see there some problems because I can`t find this Level {SecondTask.Levels}");
                break;
        }

        _isStarted = true;
    }

    private void UpdateTimerText()
    {
        _timerText.text = _currentTime.ToString("F1");
    }

    private void OnEnable()
    {
        RestartSecondTask.OnRestarted += ResetConfig;
        SecondTaskManager.OnTimerStarted += TimerStart;
        FinishSecondTask.OnStoppedTimer += StopTimer;
    }

    private void OnDisable()
    {
        RestartSecondTask.OnRestarted -= ResetConfig;
        SecondTaskManager.OnTimerStarted -= TimerStart;
        FinishSecondTask.OnStoppedTimer -= StopTimer;
    }
}