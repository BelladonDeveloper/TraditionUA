using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _animator;
    private bool _isMove;
    private bool _canMove;
    private Vector3 _moveDirectionZ;

    public bool CutSceneBool = false;

    private void Start()
    {
        PermitMovement();
    }

    public void MoveCharacter(Vector3 moveDirection, float moveMagnitude)
    {
        if (_canMove == true)
        {
            _moveDirectionZ = moveDirection * _speed;
        }
        else
        {
            _moveDirectionZ = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if(!CutSceneBool)
        {
            Animation();
        }
        
        if (_canMove == false)
            return;

        _rb.MovePosition(_rb.position + _moveDirectionZ * Time.fixedDeltaTime);
        
        CheckMovement();
    }

    private void CheckMovement()
    {
        _isMove = _moveDirectionZ != Vector3.zero;
    }

    public void BlockMovement()
    {
        _canMove = false;
        _isMove = false;
    }

    public void PermitMovement()
    {
        _canMove = true;
    }

    public void ChangeSpeed(float speed)
    {
        _speed = speed;
    }

    private void Animation()
    {
        _animator.SetFloat("MovementX", _moveDirectionZ.x); 
        _animator.SetFloat("MovementY", _moveDirectionZ.z); 
        _animator.SetBool("IsMove", _isMove); 
    }
}
