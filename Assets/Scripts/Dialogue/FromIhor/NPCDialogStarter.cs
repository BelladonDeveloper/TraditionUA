using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

public class NPCDialogStarter : MonoBehaviour
{
    private const string PLAYER = "Player";
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER))
        {
            ShowButton();
        }
    }

    private void ShowButton()
    {
        Register.Get<UIManager>().Show(UIPopupType.DialogueButton);
    }
}
