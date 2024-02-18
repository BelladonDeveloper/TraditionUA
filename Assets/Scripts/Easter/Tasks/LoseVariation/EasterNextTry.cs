using UnityEngine;

public class EasterNextTry : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _spawnPoint;

    private IRestart _restart;

    public EasterNextTry(EasterRestartDIContainer diContainer)
    {
        SetRestart(diContainer.GetRestartInstance());
    }

    public void SetRestart(IRestart restart)
    {
        _restart = restart;
    }

    public void RestartTask()
    {
        _player.position = _spawnPoint.position;
        if (_restart != null)
        {
            _restart.RestartLevel();
        }
        else
        {
            Debug.LogError("_restart is null, unable to restart level.");
        }
    }

    public void GetDIContainer()
    {
        EasterRestartDIContainer diContainer = FindObjectOfType<EasterRestartDIContainer>();
        if (diContainer != null)
        {
            IRestart restart = diContainer.GetRestartInstance();
            if (restart != null)
            {
                SetRestart(restart);
            }
            else
            {
                Debug.LogError("Restart instance is null in DI container.");
            }
        }
        else
        {
            Debug.LogError("DI Container was not found!");
        }
    }


    private void OnEnable()
    {
        EasterLoseVariation.OnGotDIContainer += GetDIContainer;
        EasterLoseVariation.OnRestartedTask += RestartTask;
    }

    private void OnDisable()
    {
        EasterLoseVariation.OnGotDIContainer -= GetDIContainer;
        EasterLoseVariation.OnRestartedTask -= RestartTask;
    }
}