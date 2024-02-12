using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EasterPickUp : MonoBehaviour
{
    public static event Action OnFinishedTask;
    public static event Action OnLost;

    [SerializeField] private MovementController _mController;

    [SerializeField] private NavMeshAgent _bunnyAgent;

    [SerializeField] private TextMeshProUGUI _playerPointsTMP;
    [SerializeField] private TextMeshProUGUI _bunnyPointsTMP;

    [SerializeField] private float _defaultBunnySpeed;
    [SerializeField] private float _defaultPlayerSpeed;

    private int _playerPoints;
    private int _bunnyPoints;


    public void OnPickedUpByPlayer()
    {
        StartCoroutine(PickedUpByPlayer());
        OnPickedUpByPlayerUI();
    }

    public void OnPickedUpByBunny()
    {
        StartCoroutine(PickedUpByBunny());
        OnPickedUpByBunnyUI();
    }

    private IEnumerator PickedUpByPlayer()
    {
        _mController.ChangeSpeed(0);
        //Play Animation of Pick Up

        yield return new WaitForSeconds(1f);

        _mController.ChangeSpeed(_defaultPlayerSpeed);

        if (_playerPoints >= 10)
        {
            OnFinishedTask?.Invoke();
        }
    }

    private IEnumerator PickedUpByBunny()
    {
        _bunnyAgent.speed = 0;

        //Play Animation of Pick Up

        yield return new WaitForSeconds(1f);

        _bunnyAgent.speed = _defaultBunnySpeed + _bunnyPoints; // or without "+ _bunnyPoints"

        if (_bunnyPoints >= 10)
        {
            OnLost?.Invoke();
        }
    }


    private void OnPickedUpByPlayerUI()
    {
        _playerPoints++;
        _playerPointsTMP.text = _playerPoints.ToString();
    }

    private void OnPickedUpByBunnyUI()
    {
        _bunnyPoints++;
        _bunnyPointsTMP.text = _bunnyPoints.ToString();
    }

    private void OnEnable()
    {
        PickingThingsUp.OnPickedUpByPlayer += OnPickedUpByPlayer;
        PickingThingsUp.OnPickedUpByBunny += OnPickedUpByBunny;
    }

    private void OnDisable()
    {
        PickingThingsUp.OnPickedUpByPlayer -= OnPickedUpByPlayer;
        PickingThingsUp.OnPickedUpByBunny -= OnPickedUpByBunny;
    }
}
