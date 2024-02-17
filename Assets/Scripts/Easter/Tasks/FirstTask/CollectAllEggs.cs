using System;
using System.Collections;
using UnityEngine;

public class CollectAllEggs : MonoBehaviour
{
    public static event Action OnFinishedTask;

    [SerializeField] private GameObject _finishTaskTimeLine;

    public void OnCollectEggs()
    {
        _finishTaskTimeLine.SetActive(true);

        StartCoroutine(FinishTask());
    }

    private IEnumerator FinishTask()
    {
        yield return new WaitForSeconds(5f);

        OnFinishedTask?.Invoke();
    }

    private void OnEnable() => CountCollectedEggs.OnCollectedAllEggs += OnCollectEggs;
    private void OnDisable() => CountCollectedEggs.OnCollectedAllEggs -= OnCollectEggs;
}
