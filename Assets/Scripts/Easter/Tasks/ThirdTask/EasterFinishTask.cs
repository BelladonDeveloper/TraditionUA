using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EasterFinishTask : MonoBehaviour
{
    public static event Action OnFinishedTradition;

    [SerializeField] private CanvasGroup _easterWinMenu;
    [SerializeField] private List<CanvasGroup> _stars;

    private const float TimeToAppearing = 1.5f;

    public void FinishTask()
    {
        Sequence sequence = DOTween.Sequence();

        _easterWinMenu.gameObject.SetActive(true);

        sequence.Append(_easterWinMenu.DOFade(1, TimeToAppearing));
        //There we can play sound 
        sequence.Append(_stars[PassingAndTakingTasks.SequenceOfTasks].DOFade(1, TimeToAppearing));


        StartCoroutine(WaitBeforeExit());
    }

    private IEnumerator WaitBeforeExit()
    {
        Sequence sequence = DOTween.Sequence();

        yield return new WaitForSeconds(7f);

        sequence.Append(_easterWinMenu.DOFade(0, TimeToAppearing));

        yield return new WaitForSeconds(3);

        _easterWinMenu.gameObject.SetActive(false);

        PassingAndTakingTasks.SequenceOfTasks++;
        Debug.Log(PassingAndTakingTasks.SequenceOfTasks);

        if (PassingAndTakingTasks.SequenceOfTasks == 3)
        {
            OnFinishedTradition?.Invoke();
        }
    }

    private void OnEnable()
    {
        CollectAllEggs.OnFinishedTask += FinishTask;
        FinishSecondTask.OnFinishedTask += FinishTask;
        EasterPickUp.OnFinishedTask += FinishTask;
    }

    private void OnDisable()
    {
        CollectAllEggs.OnFinishedTask -= FinishTask;
        FinishSecondTask.OnFinishedTask -= FinishTask;
        EasterPickUp.OnFinishedTask -= FinishTask;
    }

}
