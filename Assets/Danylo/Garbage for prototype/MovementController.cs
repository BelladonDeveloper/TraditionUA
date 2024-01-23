using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private bool _canMove;
    private Vector3 moveDirectionZ;

    private void Start()
    {
        PermitMovement();
    }

    public void MoveCharacter(Vector3 moveDirection, float moveMagnitude)
    {
        moveDirectionZ = moveDirection * _speed;
    }

    private void FixedUpdate()
    {
        if (_canMove == false)
            return;

        _rb.MovePosition(_rb.position + moveDirectionZ * Time.fixedDeltaTime);
    }

    public void BlockMovement()
    {
        _canMove = false;
    }

    public void PermitMovement()
    {
        _canMove = true;
    }
}
