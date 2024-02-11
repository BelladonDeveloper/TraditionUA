using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PickingFlowers : MonoBehaviour
{
    string PlayerTag = "Player";
    public Transform targets;
    public Transform targes;
    public GameObject _joysticks;
    public GameObject MiniGame1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PlayerTag)  {Randoom(); Camera1Changs();}
    }

    private void Camera1Changs()
    {
        Camera1.Quaternions = 0;
        //Camera1.heights = 10;
    }
    
    public void Randoom()
    {
        MiniGame1.SetActive(true);
        _joysticks.SetActive(false);
        AndrePlayerController._moveSpeed = 0;
        Camera1.target = targets;
    }
    
}