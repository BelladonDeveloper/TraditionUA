using UnityEngine;
using Cinemachine;
using Input = UnityEngine.Input;

public class CinemachineCamerasChangingByPriority : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] _virtualCameras;

    private int _currentCameraIndex;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        PassingAndTakingTasks passingAndTakingTasks = new PassingAndTakingTasks();

        _virtualCameras[_currentCameraIndex].Priority = 0;
        _currentCameraIndex++;

        if (_currentCameraIndex >= _virtualCameras.Length)
        {
            _currentCameraIndex = 0;
        }

        _virtualCameras[_currentCameraIndex].Priority = 1;

        //PassingAndTakingTasks.SingleTon.TakeSecondTask();
    }
}
