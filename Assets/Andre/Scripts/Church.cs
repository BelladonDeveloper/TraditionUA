using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Church : MonoBehaviour
{
    string PlayerTag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PlayerTag) {Deebug();}
    }
    
    void Deebug()
    {
        if (AndrePlayerController.weed == 3 || AndrePlayerController.weed > 3)
        {
            Debug.Log(" З цього букет не вийде ");
        }
        if (AndrePlayerController.flowers == 3 || AndrePlayerController.flowers > 3)
        {
            Debug.Log(" Чудовий букет, Ось тримай Мак ");
            Inventory.pope = true;
        }
        if (AndrePlayerController.weed < 3 || AndrePlayerController.flowers < 3)
        {
            Debug.Log(" В тебе недостатньо квітів, повертайся коли назбираєш ");
        }
    }
}        
