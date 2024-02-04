using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountCollectedEggs : MonoBehaviour
{
    public static CountCollectedEggs Singleton;

    public static event Action OnCollectedAllEggs;
    public static event Action OnEnded;
    public static List<GameObject> _eggs = new List<GameObject>();

    public TextMeshProUGUI CurrentCountOfEggsTMP;
    public TextMeshProUGUI NeddedCountOfEggsTMP;

    public int NeddedCountOfEggs;
    public int CollectedEggs;

    private bool _isDone;

    public void Start() => Singleton = this;

    public void Assign()
    {
        CurrentCountOfEggsTMP.text = CollectedEggs.ToString();
        NeddedCountOfEggsTMP.text = NeddedCountOfEggs.ToString();
    }

    public void FindAllEggs()
    {
        foreach (var egg in GameObject.FindGameObjectsWithTag("Egg"))
        {
            _eggs.Add(egg);

            NeddedCountOfEggs++;
        }

        foreach (var egg in GameObject.FindGameObjectsWithTag("Egg"))
        {
            egg.tag = "Untagged";
        }


        NeddedCountOfEggsTMP.text = NeddedCountOfEggs.ToString();

        ChangeCurrentNumberOfCollectedEggs();

        for (int i = 0; i < _eggs.Count; i++)
        {
            _eggs[i].GetComponent<EggsPickUpper>().OnPickedUp += CheckCollectedEggs;
        }
    }

    public void CheckCollectedEggs(GameObject currentGameObject)
    {
        if (_isDone)
            return;

        if (_eggs.Contains(currentGameObject))
        {
            StartCoroutine(DelayedDestroy(currentGameObject));
        }

        if (_eggs.Count == 0 && FirstTask._isDoneChecker == 3)
        {
            FinishFirstTask();
        }
    }

    private IEnumerator DelayedDestroy(GameObject obj)
    {
        yield return null;

        _eggs.Remove(obj);
        Destroy(obj);

        CollectedEggs++;
        ChangeCurrentNumberOfCollectedEggs();
        _isDone = true; 
        StartCoroutine(ChangeIsDone());
    }

    private IEnumerator ChangeIsDone()
    {
        yield return null;
        _isDone = false;
    }

    private void ChangeCurrentNumberOfCollectedEggs()
    {
        CurrentCountOfEggsTMP.text = CollectedEggs.ToString();
    }

    public void FinishFirstTask()
    {
        if (_eggs.Count == 0 && FirstTask._isDoneChecker == 3)
        {
            OnCollectedAllEggs?.Invoke();
            OnEnded?.Invoke();

            FirstTask._isDoneChecker = 4;

            PassingAndTakingTasks.SequenceOfTasks = 1;
        }

    }

    private void OnDestroy()
    {
        for (int i = 0; i < _eggs.Count; i++)
        {
            _eggs[i].GetComponent<EggsPickUpper>().OnPickedUp -= CheckCollectedEggs;
        }
    }
}
