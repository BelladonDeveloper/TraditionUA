using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class FirstTask : MonoBehaviour
{
    public static event Action OnStartedTimer;
    public static event Action<float> OnGivenMoreTime;

    [SerializeField] private GameObject _eggPrefab;
    [SerializeField] private List<Sprite> _eggsSpritesPrefabs = new();
    [SerializeField] private List<GameObject> _eggsCounterChecker = new();
    [SerializeField] private CountCollectedEggs _countCollectedEggs;
    [SerializeField] private List<Transform> _randomPositions;

    public static int _isDoneChecker = 0;

    private Coroutine _timerCoroutine;
    private bool _isStarted;

    public void Update()
    {
        if (_isDoneChecker <= 3 && _isStarted)
            OnStartedTimer?.Invoke();
    }

    public void TakeFirstTask()
    {
        int number = 0;
        float time = 0;

        if (_isDoneChecker <= 2 && CountCollectedEggs._eggs.Count == 0)
        {
            if (_isDoneChecker == 0)
            {
                number = 34;
                time = 31;
            }


            if (_isDoneChecker == 1)
            {
                number = 22;
                time = 46;
            }


            if (_isDoneChecker == 2)
            {
                number = 0;
                time = 61;
            }

            if (_timerCoroutine == null)
            {
                _timerCoroutine = StartCoroutine(TimerForStartingFirstTask(_eggsSpritesPrefabs, number, time));
            }
        }

        if (_isDoneChecker == 3)
            CountCollectedEggs.Singleton.FinishFirstTask();

        _isStarted = true;
    }

    private IEnumerator TimerForStartingFirstTask(List<Sprite> eggsSprites, int number, float time)
    {
        //yield return new WaitForSeconds(1f);

        for (int i = 0; i < eggsSprites.Count - number; i++)
        {
            int randomSprite = Random.Range(1, eggsSprites.Count - number);
            int randomPosition = Random.Range(0, _randomPositions.Count);

            GameObject newEgg = Instantiate(_eggPrefab, _randomPositions[randomPosition].transform.position,
                Quaternion.Euler(40.0f, 0.0f, 0.0f));
            newEgg.GetComponent<SpriteRenderer>().sprite = eggsSprites[randomSprite];

            _eggsCounterChecker.Add(newEgg);
        }

        _isDoneChecker++;

        _countCollectedEggs.FindAllEggs();

        if (_isDoneChecker != 3)
        {
            PassingAndTakingTasks.SingleTon.TakeFirstTask();
        }

        OnGivenMoreTime?.Invoke(time);

        yield return new WaitForSeconds(1);

        OnStartedTimer?.Invoke();

        _timerCoroutine = null;
    }

    public void Lose()
    {
        Sequence fade = DOTween.Sequence();

        EasterTimer.Singleton.timerText.text = "Game Over";

        fade.Append(EasterTimer.Singleton.timerText.DOFade(1, 1f));
        fade.Append(EasterTimer.Singleton.timerText.DOFade(0, 1f));

        ResetFirstTask();
    }

    public void Win()
    {
        EasterTimer.Singleton.timerText.text = "Round Completed";
    }

    public void ResetFirstTask()
    {
        _isDoneChecker = 0;
        CountCollectedEggs._eggs.Clear();
        CountCollectedEggs.Singleton.CollectedEggs = 0;
        CountCollectedEggs.Singleton.NeddedCountOfEggs = 0;
        CountCollectedEggs.Singleton.Assign();

        for (int i = 0; i < _eggsCounterChecker.Count; i++)
        {
            Destroy(_eggsCounterChecker[i]);
        }
    }

    private void OnEnable()
    {
        PassingAndTakingTasks.OnTakenFirstTask += TakeFirstTask;
        EasterTimer.OnLost += Lose;
        EasterTimer.OnWin += Win;
    }

    private void OnDisable()
    {
        PassingAndTakingTasks.OnTakenFirstTask -= TakeFirstTask;
        EasterTimer.OnLost -= Lose;
        EasterTimer.OnWin -= Win;
    }
}
