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
    public GameObject _joysticks;
    public GameObject MiniGame1;
    public GameObject DestroyP;

    public GameObject WeedT;
    public GameObject FlowersT;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PlayerTag)  {Randoom(); Camera1Changs();}
    }

    private void Camera1Changs()
    {
        Camera1.Quaternions = 0;
    }
    
    public void Randoom()
    {
        WeedT.SetActive(false);
        FlowersT.SetActive(false);
        MiniGame1.SetActive(true);
        _joysticks.SetActive(false);
        AndrePlayerController._moveSpeed = 0;
        Camera1.target = targets;
        Destroy(DestroyP);
    }
    
}