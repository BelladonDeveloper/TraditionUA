using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class AndrePlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    public static float _moveSpeed = 6;
    
    

    public static int flowers;
    public static int weed;

    public TMP_Text WeedText;
    public TMP_Text FlowersText;
    
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
       WeedText.text = weed.ToString();
       FlowersText.text = flowers.ToString();
    }
}
