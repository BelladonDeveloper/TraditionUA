using System;
using UnityEngine;

public class RestartFirstTask : MonoBehaviour, IRestart
{
    public static event Action OnRestarted;

    public void RestartLevel()
    {
        OnRestarted?.Invoke();
    }
}
