using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentScript : MonoBehaviour
{
    [SerializeField] private SaintNicolas SNScript;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && SNScript.Task == true)
        {
            SNScript.CollectedPresent();
            Destroy(gameObject);
        }
    }
}
