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

    public void ResetStats()
    {
        _eggs.Clear();
        CollectedEggs = 0;
        NeddedCountOfEggs = 0;
        Assign();
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
            EggsPickUpper eggsPickUpper = _eggs[i].GetComponent<EggsPickUpper>();
            if (eggsPickUpper != null)
            {
                eggsPickUpper.OnPickedUp += CheckCollectedEggs;
            }
            else
            {
                Debug.LogWarning("EggsPickUpper component not found on egg: " + _eggs[i].name);
            }
        }

    }

    public void CheckCollectedEggs(GameObject currentGameObject)
    {
        if (currentGameObject != null)
        {
            if (_eggs.Contains(currentGameObject))
            {
                StartCoroutine(DelayedDestroy(currentGameObject));
            }
            else
            {
                Debug.LogWarning("Attempted to collect an egg that is not in the list.");
            }

            if (_eggs.Count == 0 && FirstTask._isDoneChecker == 3)
            {
                FinishFirstTask();
            }
        }

        if (_eggs == null || !_isDone)
            return;

    }

    private IEnumerator DelayedDestroy(GameObject obj)
    {
        if (_eggs == null || obj == null || !_eggs.Contains(obj))
        {
            Debug.LogWarning("Attempted to destroy an egg that is not in the list or is null.");
            yield break;
        }

        yield return null;

        if (obj != null && _eggs.Contains(obj))
        {
            Destroy(obj);
        }
        _eggs.Remove(obj);
        

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
        if (_eggs.Count == 0 && FirstTask._isDoneChecker == 3 && _eggs != null)
        {
            OnCollectedAllEggs?.Invoke();
            OnEnded?.Invoke();

            FirstTask._isDoneChecker = 4;
        }

    }

    private void OnDestroy()
    {
        for (int i = 0; i < _eggs.Count; i++)
        {
            if (_eggs[i] != null)
            {
                _eggs[i].GetComponent<EggsPickUpper>().OnPickedUp -= CheckCollectedEggs;
            }
        }
    }

    private void OnEnable()
    {
        RestartFirstTask.OnRestarted += ResetStats;
    }

    private void OnDisable()
    {
        RestartFirstTask.OnRestarted -= ResetStats;
    }
}
