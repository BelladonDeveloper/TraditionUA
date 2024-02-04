using UnityEngine;
using Cinemachine;
using Input = UnityEngine.Input;

public class CinemachineCamerasChangingByPriority : MonoBehaviour
{
    public static CinemachineCamerasChangingByPriority Singleton;

    [SerializeField] private CinemachineVirtualCamera[] _virtualCameras;

    private int _currentCameraIndex;

    public void Start()
    {
        Singleton = this;
    }

    public void SwitchCamera()
    {
        _virtualCameras[_currentCameraIndex].Priority = 0;
        _currentCameraIndex++;

        if (_currentCameraIndex >= _virtualCameras.Length)
        {
            _currentCameraIndex = 0;
        }

        _virtualCameras[_currentCameraIndex].Priority = 1;

        //PassingAndTakingTasks.SingleTon.TakeSecondTask(); //Need to remove
    }
}
