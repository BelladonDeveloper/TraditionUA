using System;
using System.Collections;
using UnityEngine;

public class PassingAndTakingTasks : MonoBehaviour
{
    public static PassingAndTakingTasks SingleTon;

    public static event Action OnTakenFirstTask;
    public static event Action OnTakenSecondTask;
    public static event Action OnTakenThirdTask;

    public static int SequenceOfTasks = 0;

    public static bool IsDone;

    [SerializeField] private DialogueScriptAax dialogueScript;
    [SerializeField] private string[] DialogueTexts;
    [SerializeField] private Characters[] characters;

    public int _dialogueChecker;

    private bool _isCompletedTask;

    public static int _isDialogueDone;

    public void Start()
    {
        SingleTon = this;

        
    }

    #region Tasks

    public void TakeFirstTask()
    {
        OnTakenFirstTask?.Invoke();

        _isCompletedTask = true;

        _isDialogueDone = -1;

        StartCoroutine(ChangeDialogueNumber(false));
    }

    public void TakeSecondTask()
    {
        SecondTask._isRestarted = false;
        OnTakenSecondTask?.Invoke();

        _isDialogueDone = -1;
    }

    public void TakeThirdTask() 
    {
        if (IsDone == false)
        {
            OnTakenThirdTask?.Invoke();
            IsDone = true;
        }
    }

    #endregion

    public void ChangeIsDialogueDone(bool change)
    {
        _isCompletedTask = change;
    }

    private void Near()
    {
        if (SequenceOfTasks == 0)
        {
            NotCompletedVersionOfTaskDialogue(_dialogueChecker, 1);

            if (!_isCompletedTask && _dialogueChecker == 0)
                Talk(0, 5, TakeFirstTask);

            if (_isCompletedTask && _isDialogueDone == -1)
                TakeFirstTask();

            _dialogueChecker = 1;
        }

        else if (SequenceOfTasks == 1)
        {
            NotCompletedVersionOfTaskDialogue(_dialogueChecker, 2);

            if (_dialogueChecker == 1)
                Talk(6, 10, TakeSecondTask);

            if (_isDialogueDone == -1 && _dialogueChecker == 2)
                TakeSecondTask();

            _dialogueChecker = 2;
        }
        else if (SequenceOfTasks == 2)
        {
            NotCompletedVersionOfTaskDialogue(_dialogueChecker, 3);

            if (_dialogueChecker == 2 && _isCompletedTask)
                Talk(11, 15, TakeThirdTask);

            if (_isDialogueDone == -1 && _dialogueChecker == 3)
                TakeThirdTask();

            _dialogueChecker = 3;
        }

        Debug.Log(_isCompletedTask);
    }

    private void NotCompletedVersionOfTaskDialogue(int first, int second)
    {
        //if (_dialogueChecker == 1 || _dialogueChecker == 2 || _dialogueChecker == 3)
        //{
        //    if (_isCompletedTask == false && _isDialogueDone == -1)
        //    {
        //        NotCompletedTask(_dialogueChecker);
        //    }
        //}

        if (first == second)
        {
            if (_isCompletedTask == false)
            {
                NotCompletedTask(_dialogueChecker);
            }
        }
    }

    private void NotCompletedTask(int dialogueTester)
    {
        if (dialogueTester == 1)
        {
            dialogueScript.Dialogue(characters[16], DialogueTexts[16]);
        }

        else if (dialogueTester == 2)
        {
            dialogueScript.Dialogue(characters[17], DialogueTexts[17]);
        }

        else if (dialogueTester == 3)
        {
            dialogueScript.Dialogue(characters[18], DialogueTexts[18]);
        }
    }

    private void Talk(int from, int to, Action action)
    {
        if (from == to)
        {
            dialogueScript.Dialogue(characters[from], DialogueTexts[from], action);
        }

        else
        {
            dialogueScript.Dialogue(characters[from], DialogueTexts[from], () => Talk(from + 1, to, action));
        }
    }

    private IEnumerator ChangeDialogueNumber(bool change)
    {
        yield return new WaitForSeconds(2f);

        ChangeIsDialogueDone(change);

        _dialogueChecker = 1;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Near();
        }
    }
}
