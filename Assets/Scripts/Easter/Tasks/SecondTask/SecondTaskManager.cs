using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SecondTaskManager : MonoBehaviour
{
    public static SecondTaskManager Singleton;

    public static event Action OnTimerStarted;
    public static event Action OnFinishedTask;

    public List<Sprite> _eggsSprites = new List<Sprite>();
    public Button _checkMarkButton;

    [SerializeField] private LayerMask _eggSecondTask;

    [SerializeField] private Sprite _defaultSprite;

    private List<GameObject> _objectsToDelete = new List<GameObject>();
    public List<GameObject> _eggsFirstLevel = new List<GameObject>();

    private int _nextSprite;

    private bool _isStarted;
    private bool _isDone;
    private bool _isDone2;
    private bool _isDone3;
    private bool _isFinised;
    private bool _isStartedSecondTask;

    private void Start()
    {
        Singleton = this;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (_isStarted && _eggsSprites.Count > 0 && _defaultSprite != null)
        {
            if (Physics.Raycast(ray, out hit, 100, _eggSecondTask))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SpriteRenderer spriteRenderer = hit.transform.gameObject.GetComponent<SpriteRenderer>();
                    EasterCurrentSprite easterCurrentSprite = hit.transform.GetComponent<EasterCurrentSprite>();

                    if (spriteRenderer != null && easterCurrentSprite != null)
                    {
                        if (_nextSprite == _eggsSprites.Count)
                            _nextSprite = 0;

                        ChangeRandomSprite(hit.transform.gameObject, _nextSprite++);

                        if (_checkMarkButton != null)
                        {
                            _checkMarkButton.onClick.AddListener(() =>
                            {
                                if (hit.transform != null)
                                {
                                    easterCurrentSprite.CheckSprite(spriteRenderer, easterCurrentSprite.mySpriteType);

                                    DeleteReadyObjects();
                                }
                            });

                            _objectsToDelete.Add(hit.transform.gameObject);
                        }
                        else
                        {
                            Debug.LogWarning("CheckMarkButton is null. Cannot add listener.");
                        }
                    }
                    else
                    {
                        Debug.LogError("SpriteRenderer or EasterCurrentSprite component is null.");
                    }
                }
            }

            if (_eggsFirstLevel.Count == 0 && _isDone == false)
            {
                StartCoroutine(FirstLevelCompleted());

                _isDone = true;
            }

            if (_eggsFirstLevel.Count == 0 && _isStartedSecondTask == true && _isDone2 == false)
            {
                StartCoroutine(SecondLevelCompleted());

                _isDone2 = true;
            }

            if (_eggsFirstLevel.Count == 0 && _isStartedSecondTask == true && _isFinised == true && _isDone3 == false)
            {
                OnFinishedTask?.Invoke();

                _isDone3 = true;
            }
        }
    }

    public void DeleteReadyObjects()
    {
        StartCoroutine(DeleteReadyObjectsWithTime());
    }

    private IEnumerator DeleteReadyObjectsWithTime()
    {
        yield return new WaitForSeconds(2f);

        if (_objectsToDelete.Count != 0)
        {
            bool allObjectsHaveNotBoxColliderEnabled = true;

            foreach (var obj in _objectsToDelete)
            {
                BoxCollider boxCollider = obj.gameObject.GetComponent<BoxCollider>();

                if (boxCollider == null || boxCollider.enabled)
                {
                    allObjectsHaveNotBoxColliderEnabled = false;
                    break;
                }
            }

            if (allObjectsHaveNotBoxColliderEnabled)
            {
                for (int i = 0; i < _objectsToDelete.Count; i++)
                {
                    Destroy(_objectsToDelete[i]);
                }

                _objectsToDelete.Clear();
            }
        }
    }


    private IEnumerator FirstLevelCompleted()
    {
        yield return new WaitForSeconds(1f);

        SecondTask.Levels = 1;
        SecondTask.IsDone = false;

        PassingAndTakingTasks.SingleTon.TakeSecondTask();

        yield return new WaitForSeconds(10f);

        _isStartedSecondTask = true;
    }

    private IEnumerator SecondLevelCompleted()
    {
        yield return new WaitForSeconds(1f);

        SecondTask.Levels = 2;
        SecondTask.IsDone = false;

        PassingAndTakingTasks.SingleTon.TakeSecondTask();

        yield return new WaitForSeconds(8);

        _isFinised = true;
    }

    public void ChangeRandomSprite(GameObject g, int randomSprite)
    {
        g.transform.gameObject.GetComponent<SpriteRenderer>().sprite = _eggsSprites[randomSprite];
    }

    public void EggsRemover(GameObject egg)
    {
        if (_eggsFirstLevel.Contains(egg))
        {
            _eggsFirstLevel.Remove(egg);
        }
    }

    public void OnStartTask()
    {
        foreach (GameObject egg in GameObject.FindGameObjectsWithTag("Egg"))
        {
            _eggsFirstLevel.Add(egg);
        }

        OnTimerStarted?.Invoke();
    }

    public void OnStart()
    {
        for (int i = 0; i < _eggsFirstLevel.Count; i++)
        {
            _eggsFirstLevel[i].GetComponent<SpriteRenderer>().sprite = _defaultSprite;
        }
        _isStarted = true;
    }

    public void OnStop()
    {
        _isStarted = false;
    }

    private void OnEnable()
    {
        SecondTask.OnStartedTask += OnStartTask;
        EasterMessageForSecondTaskMemory.OnTimeEnded += OnStart;
    }

    private void OnDisable()
    {
        SecondTask.OnStartedTask -= OnStartTask;
        EasterMessageForSecondTaskMemory.OnTimeEnded -= OnStart;
    }
}
