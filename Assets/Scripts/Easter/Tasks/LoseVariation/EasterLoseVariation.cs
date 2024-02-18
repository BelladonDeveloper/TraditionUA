using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EasterLoseVariation : MonoBehaviour
{
    public static event Action OnGotDIContainer;
    public static event Action OnRestartedTask;
    public static event Action OnCleanedElements;

    [SerializeField] private EasterProvider _easterProvider;

    [SerializeField] private CanvasGroup _darkness;
    [SerializeField] private CanvasGroup _buttonAlpha;

    [SerializeField] private TextMeshProUGUI _lostTMP;

    [SerializeField] private Button _loseButton;

    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private EasterRestartDIContainer _diContainer;

    private const float TimeToAppearLight = 2.5f;
    private const float TimeToAppearText = 2;
    private const float TimeToAppearButton = 2;

    private bool _isDone;

    public void OnLost()
    {
        if (_isDone == false)
        {
            Sequence appear = DOTween.Sequence();

            _lostTMP.gameObject.SetActive(true);
            appear.Append(_darkness.DOFade(1, TimeToAppearLight));

            StartCoroutine(DestroyItemsWithTime());
            OnCleanedElements?.Invoke();
            StartCoroutine(StartAgainTaskWithTime());

            appear.Append(_lostTMP.DOFade(1, TimeToAppearText));
            appear.Append(_buttonAlpha.DOFade(1, TimeToAppearButton));

            _loseButton.onClick.RemoveAllListeners();
            _loseButton.onClick.AddListener(OnRestart);

            _isDone = true;
        }
    }

    private IEnumerator ResetIsDone()
    {
        yield return new WaitForSeconds(5f);

        _isDone = false;
    }

    public void OnRestart()
    {
        Sequence appear = DOTween.Sequence();

        _lostTMP.gameObject.SetActive(true);

        appear.Append(_darkness.DOFade(0, TimeToAppearText));
        appear.Join(_lostTMP.DOFade(0, TimeToAppearText));
        appear.Join(_buttonAlpha.DOFade(0, TimeToAppearText));
    }

    private IEnumerator DestroyItemsWithTime()
    {
        yield return new WaitForSeconds(3f);

        _easterProvider.DestroyItem();
    }

    private IEnumerator StartAgainTaskWithTime()
    {
        yield return new WaitForSeconds(3f);

        StartAgainTask();
    }

    private void StartAgainTask()
    {
        switch (PassingAndTakingTasks.SequenceOfTasks)
        {
            case 0:
                _diContainer.RegisterRestart(new RestartFirstTask());

                StartCoroutine(WaitFrame());
                break;

            case 1:
                _diContainer.RegisterRestart(new RestartSecondTask());

                StartCoroutine(WaitFrame());
                break;

            case 2:
                _diContainer.RegisterRestart(new RestartThirdTask());

                StartCoroutine(WaitFrame());
                break;

            default:
                Debug.Log("Something went wrong " + PassingAndTakingTasks.SequenceOfTasks);
                break;
        }

        StartCoroutine(ResetIsDone());
    }

    private IEnumerator WaitFrame()
    {
        yield return new WaitForSeconds(0.5f);

        OnGotDIContainer?.Invoke();
        yield return new WaitForSeconds(0.5f);
        OnRestartedTask?.Invoke();
    }

    private void OnEnable()
    {
        EasterTimer.OnLost += OnLost;
        EasterMessageForSecondTaskMemory.OnLost += OnLost;
        EasterWrongAnswer.OnLost += OnLost;
        EasterPickUp.OnLost += OnLost;
    }

    private void OnDisable()
    {
        EasterTimer.OnLost -= OnLost;
        EasterMessageForSecondTaskMemory.OnLost -= OnLost;
        EasterWrongAnswer.OnLost -= OnLost;
        EasterPickUp.OnLost -= OnLost;
    }
}
