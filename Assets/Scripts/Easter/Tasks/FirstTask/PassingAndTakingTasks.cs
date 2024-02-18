using System;
using UnityEngine;

public class PassingAndTakingTasks : MonoBehaviour
{
    public static PassingAndTakingTasks SingleTon;

    public static event Action OnTakenFirstTask;
    public static event Action OnTakenSecondTask;
    public static event Action OnTakenThirdTask;

    public static int SequenceOfTasks = 0;
    #region Tasks

    public static bool IsDone;

    public void Start()
    {
        SingleTon = this;
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (SequenceOfTasks == 0)
        {
            if (other.gameObject.tag == "Player")
            {
                TakeFirstTask();
            }
        }

        else if (SequenceOfTasks == 1)
        {
            if (other.gameObject.tag == "Player")
            {
                TakeSecondTask();
            }

        }

        else if (SequenceOfTasks == 2)
        {
            if (other.gameObject.tag == "Player")
            {
                TakeThirdTask();
            }
        }
    }
}
