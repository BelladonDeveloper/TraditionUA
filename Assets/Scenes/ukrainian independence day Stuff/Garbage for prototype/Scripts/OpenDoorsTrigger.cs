using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorsTrigger : MonoBehaviour
{
    [SerializeField] LiftDoorController controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            controller.OpenDoors();
        }
    }
}