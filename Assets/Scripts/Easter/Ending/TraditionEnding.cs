using System.Collections;
using DG.Tweening;
using UnityEngine;

public class TraditionEnding : MonoBehaviour
{
    [SerializeField] private GameObject _goldCarrot;
    [SerializeField] private GameObject _timelineTraditionEnding;

    [SerializeField] private Transform _centerOfMap;

    private Quaternion _defaultRotation;

    private const float _timeToIncrease = 1;

    private const float _timeToDecrease = 4;

    public void Start()
    {
        _defaultRotation = Quaternion.Euler(0f, 0f, 60f);
    }

    public void OnFinishTradition()
    {
        StartCoroutine(FinishTraditionRoutine());
    }

    private IEnumerator FinishTraditionRoutine()
    {
        Sequence sequence = DOTween.Sequence();

        _timelineTraditionEnding.SetActive(true);

        GameObject newGoldCarrot = Instantiate(_goldCarrot, _centerOfMap.position, _defaultRotation);

        //Todo:
        //Add sound 
        //Add particles 

        yield return new WaitForSeconds(10);

        sequence.Append(newGoldCarrot.transform.DOScale(Vector3.one * 13, _timeToIncrease));
        sequence.Append(newGoldCarrot.transform.DOScale(Vector3.one * 3, _timeToDecrease));
        newGoldCarrot.GetComponent<PingPongMovement>().enabled = false;
        sequence.Append(newGoldCarrot.transform.DOMoveY(5f, _timeToDecrease - _timeToIncrease)); //3

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

