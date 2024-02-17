using System.Collections;
using UnityEngine;
using Cinemachine;

public class CinemachineCamerasChangingByPriority : MonoBehaviour
{
    public static CinemachineCamerasChangingByPriority Singleton;

    public static bool IsStartedTask;

    [SerializeField] private CinemachineVirtualCamera[] _virtualCameras;
    [SerializeField] private CinemachineVirtualCamera _playerCamera;

    private int _currentCameraIndex;

    public void Start()
    {
        Singleton = this;
    }

    public void SwitchCamera()
    {
        IsStartedTask = false;
        _currentCameraIndex = 0; // Це можна видалити

        _virtualCameras[_currentCameraIndex].Priority = 0;
        _currentCameraIndex++;

        if (_currentCameraIndex >= _virtualCameras.Length)
        {
            _currentCameraIndex = 0;
        }

        _virtualCameras[_currentCameraIndex].Priority = 1;

        StartCoroutine(ChengeIsStartedTask());
    }

    private IEnumerator ChengeIsStartedTask()
    {
        yield return new WaitForSeconds(5);

        IsStartedTask = true;
    }

    public void Restart()
    {
        _playerCamera.Priority = 10;
    }


    private void OnEnable()
    {
        RestartSecondTask.OnRestarted += Restart;
    }

    private void OnDisable()
    {
        RestartSecondTask.OnRestarted -= Restart;
    }
}
