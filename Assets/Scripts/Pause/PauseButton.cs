using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : UIPopup
{
    [SerializeField] private Button _pauseButton;

    private void Start()
    {
        _pauseButton.onClick.AddListener(ShowPauseMenu);
    }

    private void OnDestroy()
    {
        _pauseButton.onClick.RemoveListener(ShowPauseMenu);
    }

    private void ShowPauseMenu()
    {
        Register.Get<UIManager>().Show(UIPopupType.PauseMenu);
        Register.Get<UIManager>().Hide(UIPopupType.PauseButton);
    }
}
