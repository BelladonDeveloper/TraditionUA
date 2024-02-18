using System.Collections;
using DG.Tweening;
using UnityEngine;

public class TraditionEnding : MonoBehaviour
{
    [SerializeField] private GameObject _goldCarrot;
    [SerializeField] private GameObject _timelineTraditionEnding;

    [SerializeField] private Transform _centerOfMap;

    private const float _timeToIncrease = 1;

    private const float _timeToDecrease = 4;

    public void OnFinishTradition()
    {
        StartCoroutine(FinishTraditionRoutine());
    }

    private IEnumerator FinishTraditionRoutine()
    {
        Sequence sequence = DOTween.Sequence();

        _timelineTraditionEnding.SetActive(true);

        GameObject newGoldCarrot = Instantiate(_goldCarrot, _centerOfMap.position, Quaternion.identity);

        //Todo:
        //Add sound 
        //Add particles 

        yield return new WaitForSeconds(10);

        sequence.Append(newGoldCarrot.transform.DOScale(Vector3.one * 13, _timeToIncrease));
        sequence.Append(newGoldCarrot.transform.DOScale(Vector3.one * 3, _timeToDecrease));
        newGoldCarrot.GetComponent<PingPongMovement>().enabled = false;
        sequence.Append(newGoldCarrot.transform.DOMoveY(2.5f, _timeToDecrease - _timeToIncrease)); //3

    }

    private void OnEnable()
    {
        EasterFinishTask.OnFinishedTradition += OnFinishTradition;
    }

    private void OnDisable()
    {
        EasterFinishTask.OnFinishedTradition -= OnFinishTradition;
    }

}

