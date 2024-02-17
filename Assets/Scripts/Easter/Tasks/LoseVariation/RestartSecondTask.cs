using System;
using UnityEngine;

public class RestartSecondTask : MonoBehaviour, IRestart
{
    public static event Action OnRestarted;

    public void RestartLevel()
    {
        OnRestarted?.Invoke();
    }
}
