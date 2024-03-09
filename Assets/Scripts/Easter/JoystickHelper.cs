using UnityEngine;

public class JoystickHelper : MonoBehaviour
{
    [SerializeField] private Transform transformParent;
    [SerializeField] private GameObject objJoystick;

    private GameObject joystick;

    void Start()
    {
        joystick = Instantiate(objJoystick, transformParent);
        joystick.SetActive(true);

        joystick.tag = "Joystick";
    }

}
