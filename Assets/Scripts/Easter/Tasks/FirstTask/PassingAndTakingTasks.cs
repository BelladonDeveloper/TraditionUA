using System;
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

    public void Start()
    {
        SingleTon = this;
    }

    #region Tasks

    public void TakeFirstTask() //We can use it with buttons in UI
    {
        OnTakenFirstTask?.Invoke();
    }

    public void TakeSecondTask() //We can use it with buttons in UI
    {
        SecondTask._isRestarted = false;
        OnTakenSecondTask?.Invoke();
    }

    public void TakeThirdTask() //We can use it with buttons in UI
    {
        if (IsDone == false)
        {
            OnTakenThirdTask?.Invoke();
            IsDone = true;
        }
    }

    #endregion

    private void Near()
    {
        if (SequenceOfTasks == 0)
        {
            Talk(0, 5, TakeFirstTask);
        }
        else if (SequenceOfTasks == 1)
        {
            Talk(6, 10, TakeSecondTask);
            //dialogueScript.Dialogue(characters[5], DialogueTexts[5]);
        }
        else if (SequenceOfTasks == 2)
        {
            Talk(11, 16, TakeThirdTask);
        }

        Debug.Log("Near ");
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Near();
        }
    }
}
