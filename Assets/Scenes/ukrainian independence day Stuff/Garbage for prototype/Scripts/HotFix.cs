using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotFix : MonoBehaviour
{
    [SerializeField] private BoxCollider dialog;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialog.enabled = false;
        }
    }
}
