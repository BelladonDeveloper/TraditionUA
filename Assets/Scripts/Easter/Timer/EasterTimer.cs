using System;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class EasterTimer : MonoBehaviour
{
    public static event Action OnLost;
    public static EasterTimer Singleton;

    public static bool IsNextLevel;

    public TextMeshProUGUI TimerText;

    public const float TIME_TO_FADE = 1.0f;

    private float _currentTime;

    public void Start()
    {
        Singleton = this;
    }

    public void OnTimerStarted()
    {
        Sequence fade = DOTween.Sequence();

        fade.Append(TimerText.DOFade(1, 1f));

        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            UpdateTimerText();

            if (_currentTime <= 1 && CountCollectedEggs.Singleton.CollectedEggs != CountCollectedEggs.Singleton.NeddedCountOfEggs)
            {
                _currentTime = 0;
                OnLost?.Invoke();
            }

        }
    }

    void UpdateTimerText()
    {
        int seconds = Mathf.FloorToInt(_currentTime % 60);
        TimerText.text = seconds.ToString();
    }

    public void MoreTime(float time)
    {
        _currentTime = time;
    }

    public void OnEnded()
    {
        Sequence fade = DOTween.Sequence();

        fade.Append(TimerText.DOFade(0, TIME_TO_FADE));

        TimerText.text = "";
    }

    private void OnEnable()
    {
        FirstTask.OnStartedTimer += OnTimerStarted;
        FirstTask.OnGivenMoreTime += MoreTime;
        CountCollectedEggs.OnEnded += OnEnded;
        RestartFirstTask.OnRestarted += OnEnded;
    }

    private void OnDisable()
    {
        FirstTask.OnStartedTimer -= OnTimerStarted;
        FirstTask.OnGivenMoreTime -= MoreTime;
        CountCollectedEggs.OnEnded -= OnEnded;
        RestartFirstTask.OnRestarted -= OnEnded;
    }

}
