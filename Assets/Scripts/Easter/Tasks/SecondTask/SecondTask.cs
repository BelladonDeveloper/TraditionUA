using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class SecondTask : MonoBehaviour
{
    public static event Action OnStartedTask;
    public static event Action OnSpawnedHearts;

    public static int Levels = 0;

    public static bool _isRestarted;
    public static bool IsSpawned;
    public static bool IsDone;

    [SerializeField] private EasterProvider easterProvider;

    [SerializeField] private List<Transform> _randomPositions;

    [SerializeField] private GameObject _eggPrefab;

    [SerializeField] private CanvasGroup _uICheckMark;
    [SerializeField] private CanvasGroup _stick;
    [SerializeField] private CanvasGroup _timerText;

    private const float TIME_TO_APPEARING = 1f;

    private int _randomSprite;
    private int _countOfEggs;

    private const int InitialEggCount = 4;
    private const int SecondLevelSpriteCount = 8;
    private const int ThirdLevelSpriteCount = 12;

    private List<Transform> _usedPositions = new List<Transform>();

    private bool _isStarted;

    public void OnSecondTask()
    {
        if (_isRestarted == false)
        {
            Sequence fade = DOTween.Sequence();

            fade.Append(EasterTimer.Singleton.TimerText.DOFade(1, 1f));

            if (!_isStarted)
            {
                CinemachineCamerasChangingByPriority.Singleton.SwitchCamera();

                _isStarted = true;
            }

            if (Levels == 0)
                _countOfEggs = InitialEggCount;

            else if (Levels == 1)
                _countOfEggs = SecondLevelSpriteCount;

            else if (Levels == 2)
                _countOfEggs = ThirdLevelSpriteCount;

            StartCoroutine(SecondTaskWaiter());
        }
    }

    public void RestartedSecond()
    {
        Levels = 0;
        IsSpawned = false;
        _isStarted = false;
        IsDone = false;
        _isRestarted = true;

        PassingAndTakingTasks._isDialogueDone = -1;

        RestartUI();
    }

    private void RestartUI()
    {
        Sequence sequence = DOTween.Sequence();

        _stick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<CanvasGroup>();

        sequence.Append(_stick.DOFade(1, TIME_TO_APPEARING).SetEase(Ease.Linear));
        sequence.Join(_uICheckMark.DOFade(0, TIME_TO_APPEARING).SetEase(Ease.Linear));
    }

    private IEnumerator SecondTaskWaiter()
    {
        Sequence appear = DOTween.Sequence();

        _stick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<CanvasGroup>();

        appear.Append(_stick.DOFade(0, TIME_TO_APPEARING).SetEase(Ease.Linear));

        yield return new WaitForSeconds(2f);

        appear.Append(_uICheckMark.DOFade(1, TIME_TO_APPEARING).SetEase(Ease.Linear));
        appear.Join(_timerText.DOFade(1, TIME_TO_APPEARING).SetEase(Ease.Linear));


        _usedPositions.Clear();

        if (SecondTaskManager.Singleton != null && SecondTaskManager.Singleton._eggsSprites.Count > 0 && IsDone == false)
        {
            for (int i = 0; i < _countOfEggs; i++)
            {
                _randomSprite = Random.Range(0, SecondTaskManager.Singleton._eggsSprites.Count);

                Transform randomPosition = GetRandomUnusedPosition();

                _usedPositions.Add(randomPosition);

                GameObject newEgg = easterProvider.CreateItem(_eggPrefab, randomPosition.position, Quaternion.identity);

                EasterCurrentSprite.IsDone = false;

                newEgg.GetComponent<SpriteRenderer>().sortingOrder = 1;
                SecondTaskManager.Singleton.ChangeRandomSprite(newEgg, _randomSprite);
                newEgg.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }

            OnStartedTask?.Invoke();

            if (IsSpawned == false)
                OnSpawnedHearts?.Invoke();


            IsSpawned = true;
            IsDone = true;
        }
    }

    private Transform GetRandomUnusedPosition()
    {
        List<Transform> availablePositions = _randomPositions.Except(_usedPositions).ToList();

        int randomIndex = Random.Range(0, availablePositions.Count);
        Transform randomPosition = availablePositions[randomIndex];

        return randomPosition;
    }


    private void OnEnable()
    {
        RestartSecondTask.OnRestarted += RestartedSecond;
        PassingAndTakingTasks.OnTakenSecondTask += OnSecondTask;
    }

    private void OnDisable()
    {
        RestartSecondTask.OnRestarted -= RestartedSecond;
        PassingAndTakingTasks.OnTakenSecondTask -= OnSecondTask;
    }
}
