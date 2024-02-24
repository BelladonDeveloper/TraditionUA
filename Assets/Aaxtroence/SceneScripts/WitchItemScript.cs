using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchItemScript : MonoBehaviour
{
    [SerializeField] private Witch WitchScript;
    [SerializeField] private bool BerryOrCone;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && WitchScript.Task == true)
        {
            if(BerryOrCone && WitchScript.CollectedBerries < WitchScript.TotalBerries)
            {
                WitchScript.CollectedItem(BerryOrCone);
                Destroy(gameObject);
            }
            if(!BerryOrCone && WitchScript.CollectedCones < WitchScript.TotalCones)
            {
                WitchScript.CollectedItem(BerryOrCone);
                Destroy(gameObject);
            }
        }
    }
}
