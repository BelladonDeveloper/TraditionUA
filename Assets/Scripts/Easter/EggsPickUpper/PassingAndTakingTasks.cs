using System;
using UnityEngine;

public class PassingAndTakingTasks : MonoBehaviour
{
    public static PassingAndTakingTasks SingleTon;

    public static event Action OnTakenFirstTask;
    public static event Action OnTakenSecondTask;
    public static event Action OnTakenThirdTask;

    #region Tasks

    public void Start()
    {
        SingleTon = this;
    }

    public void TakeFirstTask() //We can use it with buttons in UI
    {
        Debug.Log("1");
        OnTakenFirstTask?.Invoke();
    }

    public void TakeSecondTask() //We can use it with buttons in UI
    {
        Debug.Log("2");
        OnTakenSecondTask?.Invoke();
    }

    public void TakeThirdTask() //We can use it with buttons in UI
    {
        Debug.Log("3");
        OnTakenThirdTask?.Invoke();
    }

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TakeFirstTask();
        }
    }
}
