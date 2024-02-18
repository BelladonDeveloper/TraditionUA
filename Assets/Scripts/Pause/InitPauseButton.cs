using Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPauseButton : MonoBehaviour
{
    private void Start()
    {
        Register.Get<UIManager>().Show(UIPopupType.PauseButton);
    }
}