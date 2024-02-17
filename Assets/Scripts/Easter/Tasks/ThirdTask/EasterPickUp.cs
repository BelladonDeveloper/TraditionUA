using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EasterPickUp : MonoBehaviour
{
    public static event Action OnFinishedTask;
    public static event Action OnLost;

    public static bool IsStoppedGame;

    [SerializeField] private ThirdTask _thirdTask;
    [SerializeField] private MovementController _mController;

    [SerializeField] private NavMeshAgent _bunnyAgent;
    [SerializeField] private GameObject _bunny;

    [SerializeField] private Transform _lastPosition;
    [SerializeField] private Transform _lastRotation;

    [SerializeField] private TextMeshProUGUI _playerPointsTMP;
    [SerializeField] private TextMeshProUGUI _bunnyPointsTMP;

    //[SerializeField] private float _defaultBunnySpeed;
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

    public void RestartConfig()
    {
        _playerPoints = 0;
        _bunnyPoints = 0;

        _playerPointsTMP.text = _playerPoints.ToString();
        _bunnyPointsTMP.text = _bunnyPoints.ToString();
    }

    private IEnumerator PickedUpByPlayer()
    {
        _mController.ChangeSpeed(0);
        //Play Animation of Pick Up

        yield return new WaitForSeconds(1f);

        _mController.ChangeSpeed(_defaultPlayerSpeed);

        if (_playerPoints >= 10)
        {
            IsStoppedGame = true;

            OnFinishedTask?.Invoke();

            _bunnyAgent.SetDestination(_lastPosition.position);

            _bunny.gameObject.transform.LookAt(_lastRotation);

            _thirdTask.FadeUI();

            // Change Bunny Rotation to goldCarrot;

            //ChangeAnimation to lose bunny animation or happy animation 
            //ChangeAnimation to win player animation 

            //Play Sound May be 
        }
    }

    private IEnumerator PickedUpByBunny()
    {
        _bunnyAgent.speed = 0;

        //Play Animation of Pick Up

        yield return new WaitForSeconds(1f);

        _bunnyAgent.speed = ThirdTask.StartSpeed + _bunnyPoints; // Todo or * 4"

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
        RestartThirdTask.OnRestarted += RestartConfig;
    }

    private void OnDisable()
    {
        PickingThingsUp.OnPickedUpByPlayer -= OnPickedUpByPlayer;
        PickingThingsUp.OnPickedUpByBunny -= OnPickedUpByBunny;
        RestartThirdTask.OnRestarted -= RestartConfig;
    }
}
