using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickForMovement : JoystickHandler
{
    [SerializeField] private MovementController characterMovement;

    public bool Enable = true;

    private void Update()
    {
        if (Enable)
        {
            characterMovement.MoveCharacter(new Vector3(_inputVector.x, 0, _inputVector.y), _inputVector.magnitude);
        }
    }
}
