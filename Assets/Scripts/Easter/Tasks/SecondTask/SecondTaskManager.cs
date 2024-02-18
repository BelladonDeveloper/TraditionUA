using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private int _nextLevel;

    private bool _isDone;
    private bool _isStarted;
    private bool _isEmpty;

    private void Start()
    {
        _nextLevel = 0;

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

                                    StartCoroutine(DeleteReadyObjectsWithTime());
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

            if (_eggsFirstLevel.Count == 0 && _nextLevel == 0 && !SecondTask._isRestarted && CinemachineCamerasChangingByPriority.IsStartedTask && !_isEmpty)
            {
                StartCoroutine(FirstLevelCompleted());
            }

            if (_eggsFirstLevel.Count == 0 && _nextLevel == 1 && !SecondTask._isRestarted && CinemachineCamerasChangingByPriority.IsStartedTask && !_isEmpty)
            {
                StartCoroutine(SecondLevelCompleted());
            }

            if (_eggsFirstLevel.Count == 0 && _nextLevel == 2 && !SecondTask._isRestarted && CinemachineCamerasChangingByPriority.IsStartedTask && !_isEmpty && !_isDone)
            {
                OnFinishedTask?.Invoke();

                _isDone = true;

                Debug.Log("CheckFinish2Task");
            }
        }
    }

    private IEnumerator DeleteReadyObjectsWithTime()
    {
        yield return new WaitForSeconds(2f);

        if (_objectsToDelete.Count != 0)
        {
            bool allObjectsHaveNotBoxColliderEnabled = true;

            foreach (var obj in _objectsToDelete)
            {
                if (obj != null)
                {
                    BoxCollider boxCollider = obj.GetComponent<BoxCollider>();

                    if (boxCollider == null || boxCollider.enabled)
                    {
                        allObjectsHaveNotBoxColliderEnabled = false;
                        break;
                    }
                }
                
            }

            if (allObjectsHaveNotBoxColliderEnabled)
            {
                for (int i = 0; i < _objectsToDelete.Count; i++)
                {
                    Destroy(_objectsToDelete[i]);
                }

                _objectsToDelete.Clear();

                SecondTask._isRestarted = false;
            }
        }
    }


    private IEnumerator FirstLevelCompleted()
    {
        _isEmpty = true;
        yield return new WaitForSeconds(1f);

        if (SecondTask._isRestarted == false && CinemachineCamerasChangingByPriority.IsStartedTask)
        {
            SecondTask.Levels = 1;
            SecondTask.IsDone = false;


            yield return new WaitForSeconds(1f);

            _nextLevel = 1;

            PassingAndTakingTasks.SingleTon.TakeSecondTask();

            yield return new WaitForSeconds(2f);

            _isEmpty = false;
        }
    }

    private IEnumerator SecondLevelCompleted()
    {
        _isEmpty = true;
        yield return new WaitForSeconds(1f);

        if (SecondTask._isRestarted == false && CinemachineCamerasChangingByPriority.IsStartedTask)
        {
            SecondTask.Levels = 2;
            SecondTask.IsDone = false;
            _nextLevel = 2;

            PassingAndTakingTasks.SingleTon.TakeSecondTask();

            yield return new WaitForSeconds(2f);

            _isEmpty = false;
        }
    }

    public void ChangeRandomSprite(GameObject g, int randomSprite)
    {
        g.GetComponent<SpriteRenderer>().sprite = _eggsSprites[randomSprite];
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
        _eggsFirstLevel.Clear();
        foreach (GameObject egg in GameObject.FindGameObjectsWithTag("Egg"))
        {
            _eggsFirstLevel.Add(egg);
        }

        OnTimerStarted?.Invoke();
    }

    public void OnStart()
    {
        foreach (GameObject egg in _eggsFirstLevel)
        {
            egg.GetComponent<SpriteRenderer>().sprite = _defaultSprite;
        }
        _isStarted = true;
    }

    public void OnStop()
    {
        _isStarted = false;
    }

    public void Restart()
    {
        _eggsFirstLevel.Clear();

        _nextLevel = 0;

        _isStarted = false;
        _isEmpty = false;
        _isDone = false;
    }

    private void OnEnable()
    {
        SecondTask.OnStartedTask += OnStartTask;
        EasterMessageForSecondTaskMemory.OnTimeEnded += OnStart;
        RestartSecondTask.OnRestarted += Restart;
    }

    private void OnDisable()
    {
        SecondTask.OnStartedTask -= OnStartTask;
        EasterMessageForSecondTaskMemory.OnTimeEnded -= OnStart;
        RestartSecondTask.OnRestarted -= Restart;
    }
}
