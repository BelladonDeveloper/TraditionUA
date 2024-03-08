using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ThirdTask : MonoBehaviour
{
    public static int AddNewCarrotsCount;

    [SerializeField] private EasterProvider _easterProvider;

    [SerializeField] private GameObject _carrot;
    [SerializeField] private GameObject _bunny;
    [SerializeField] private GameObject _secondTaskLevel;
    [SerializeField] private Animator _animator;

    [SerializeField] private List<Transform> _positions = new List<Transform>();

    [SerializeField] private NavMeshAgent _bunnyAgent;

    [SerializeField] private CanvasGroup _thirdTask;

    private List<GameObject> _carrots = new List<GameObject>();

    private List<int> usedIndices = new List<int>();

    [SerializeField] private Transform _startPosition;
    private Quaternion _startRotation;

    public static float StartSpeed = 10;

    private const int Default = 19;
    private const float QuaternionRotation = 15.0f;

    private bool _isRestarted;

    public void Start()
    {
        _startPosition.position = _bunny.transform.position;
        _startRotation = _bunny.transform.rotation;

        _bunnyAgent.speed = StartSpeed;
    }

    public void OnThirdTask()
    {
        Sequence appear = DOTween.Sequence();

        appear.Append(_thirdTask.DOFade(1f, 2f));

        AddNewCarrotsCount = Default;
        StartCoroutine(CarrotSpawner());

        _isRestarted = false;
        _bunnyAgent.enabled = true;

        _secondTaskLevel.SetActive(false);
    }

    public void RemoveCarrotFromList(GameObject carrot)
    {
        if (_carrots.Contains(carrot))
            _carrots.Remove(carrot);
    }

    public void RestartedTask()
    {
        _bunnyAgent.enabled = false;

        PassingAndTakingTasks.IsDone = false;

        PassingAndTakingTasks._isDialogueDone = -1;

        _bunny.transform.position = _startPosition.position;
        _bunny.transform.rotation = _startRotation;

        _isRestarted = true;
        _bunnyAgent.enabled = false;

        _carrots.Clear();
        usedIndices.Clear();

        FadeUI();

        foreach (var carrot in _carrots)
        {
            if (carrot != null)
            {
                Destroy(carrot);
            }
        }

        _animator.SetBool("isWalking", false);
    }

    public void FadeUI()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_thirdTask.DOFade(0f, 2f));
    }

    private void Update()
    {
        if (!_isRestarted && _carrots.Count > 0 && _bunnyAgent != null && _bunnyAgent.enabled && EasterPickUp.IsStoppedGame == false)
        {
            GameObject nearestCarrot = FindNearestCarrot();

            if (nearestCarrot != null)
            {
                _bunnyAgent.SetDestination(nearestCarrot.transform.position);

                _animator.SetBool("isWalking", true);
            }
        }
    }

    private IEnumerator CarrotSpawner()
    {
        Quaternion rototationX = Quaternion.Euler(QuaternionRotation, 0, 0);

        for (int i = 0; i < AddNewCarrotsCount; i++)
        {
            yield return new WaitForSeconds(1f);

            int randomIndex = GetRandomIndex();

            usedIndices.Add(randomIndex);

            GameObject newCarrot = _easterProvider.CreateItem(_carrot, _positions[randomIndex].position, rototationX);
            _carrots.Add(newCarrot);
        }
    }

    private int GetRandomIndex()
    {
        int randomIndex = Random.Range(0, _positions.Count);

        while (usedIndices.Contains(randomIndex))
        {
            randomIndex = Random.Range(0, _positions.Count);
        }

        return randomIndex;
    }

    private GameObject FindNearestCarrot()
    {
        GameObject nearest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject carrot in _carrots)
        {
            if (carrot != null)
            {
                float dist = Vector3.Distance(_bunnyAgent.transform.position, carrot.transform.position);

                if (dist < minDist)
                {
                    nearest = carrot;
                    minDist = dist;
                }
            }
        }

        return nearest;
    }

    private void OnEnable()
    {
        PassingAndTakingTasks.OnTakenThirdTask += OnThirdTask;
        PickingThingsUp.OnRemovedCarrot += RemoveCarrotFromList;
        RestartThirdTask.OnRestarted += RestartedTask;
    }

    private void OnDisable()
    {
        PassingAndTakingTasks.OnTakenThirdTask -= OnThirdTask;
        PickingThingsUp.OnRemovedCarrot -= RemoveCarrotFromList;
        RestartThirdTask.OnRestarted -= RestartedTask;
    }
}
