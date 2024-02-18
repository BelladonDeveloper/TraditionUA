using System;
using UnityEngine;

public class RestartThirdTask : MonoBehaviour, IRestart
{
    public static event Action OnRestarted;

    public void RestartLevel()
    {
        OnRestarted?.Invoke();
    }
}
