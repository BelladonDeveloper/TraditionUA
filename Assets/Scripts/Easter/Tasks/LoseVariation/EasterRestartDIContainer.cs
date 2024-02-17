using UnityEngine;

public class EasterRestartDIContainer : MonoBehaviour
{
    private IRestart _restartInstance;

    public void RegisterRestart(IRestart restart)
    {
        _restartInstance = restart;
    }

    public IRestart GetRestartInstance()
    {
        return _restartInstance;
    }
}