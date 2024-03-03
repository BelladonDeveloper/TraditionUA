using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class WitchItemScript : MonoBehaviour
{
    [SerializeField] private Witch WitchScript;
    [SerializeField] private AudioClip audioClip;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && WitchScript.Task == true && WitchScript.CollectedCones < WitchScript.TotalCones)
        {
            WitchScript.CollectedItem(false);
            Destroy(gameObject);
            Register.Get<SoundManager>().PlaySound(audioClip);
        }
    }
}
