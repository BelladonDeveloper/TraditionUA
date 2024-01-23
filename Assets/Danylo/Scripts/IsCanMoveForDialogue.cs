using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCanMoveForDialogue : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
         if(other.CompareTag("Player"))
         {
            if (other.TryGetComponent(out MovementController movementController))
            {
                movementController.BlockMovement();
            }
         }
    }
}
