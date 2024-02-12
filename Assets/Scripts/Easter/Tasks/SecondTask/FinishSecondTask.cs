using System;
using System.Collections;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class FinishSecondTask : MonoBehaviour
{
    public static event Action OnFinishedTask;

    [SerializeField] private CinemachineVirtualCamera _playerCamera;
    [SerializeField] private CanvasGroup _stick;
    [SerializeField] private CanvasGroup _checkMarkUI;

    public const float TIME_TO_FINISH = 1.5f;

    public void OnFinishSecondTask()
    {
        StartCoroutine(FinishWithTime());

    }

    private IEnumerator FinishWithTime()
    {
        Sequence appearing = DOTween.Sequence();

        yield return new WaitForSeconds(TIME_TO_FINISH);

        _playerCamera.Priority = 11;

        yield return new WaitForSeconds(0.5f);

        appearing.Append(_stick.DOFade(1, TIME_TO_FINISH));
        appearing.Join(_checkMarkUI.DOFade(0, TIME_TO_FINISH));

        yield return new WaitForSeconds(3f);

        OnFinishedTask?.Invoke();
    }


    private void OnEnable()
    {
        SecondTaskManager.OnFinishedTask += OnFinishSecondTask;
    }

    private void OnDisable()
    {
        SecondTaskManager.OnFinishedTask -= OnFinishSecondTask;
    }
}
