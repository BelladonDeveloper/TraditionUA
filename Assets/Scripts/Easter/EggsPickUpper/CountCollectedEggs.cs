using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountCollectedEggs : MonoBehaviour
{
    public static event Action OnCollectedAllEggs;
    public List<GameObject> _eggs = new List<GameObject>();

    [SerializeField] private TextMeshProUGUI _currentCountOfEggsTMP;
    [SerializeField] private TextMeshProUGUI _neddedCountOfEggsTMP;

    private int _neddedCountOfEggs;
    private int _collectedEggs;

    private bool _isDone;

    public void FindAllEggs()
    {
        foreach (var egg in GameObject.FindGameObjectsWithTag("Egg"))
        {
            _eggs.Add(egg);

            _neddedCountOfEggs ++;
        }

        foreach (var egg in GameObject.FindGameObjectsWithTag("Egg"))
        {
            egg.tag = "Untagged";
        }


        _neddedCountOfEggsTMP.text = _neddedCountOfEggs.ToString();

        ChangeCurrentNumberOfCollectedEggs();

        for (int i = 0; i < _eggs.Count; i++)
        {
            _eggs[i].GetComponent<EggsPickUpper>().OnPickedUp += CheckCollectedEggs;
        }
    }

    public void CheckCollectedEggs(GameObject currentGameObject)
    {
        _eggs.Remove(currentGameObject);
        Destroy(currentGameObject);
        
        if (!_eggs.Contains(currentGameObject) && _isDone == false)
        {
            _isDone = true;
            _collectedEggs++;
            ChangeCurrentNumberOfCollectedEggs();
            StartCoroutine(ChangeIsDone());
        }

        if (_eggs.Count == 0)
        {
            FinishFirstTask();
        }
    }

    private IEnumerator ChangeIsDone()
    {
        yield return null;
        _isDone = false;
    }

    private void ChangeCurrentNumberOfCollectedEggs()
    {
        _currentCountOfEggsTMP.text = _collectedEggs.ToString();
    }

    private void FinishFirstTask()
    {
        OnCollectedAllEggs?.Invoke();
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _eggs.Count; i++)
        {
            _eggs[i].GetComponent<EggsPickUpper>().OnPickedUp -= CheckCollectedEggs;
        }
    }
}
