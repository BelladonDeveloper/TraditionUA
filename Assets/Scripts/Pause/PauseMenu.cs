using Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : UIPopup
{
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _quitButton;

    private void Start()
    {
        Pause();
        settingsButton.onClick.AddListener(OpenSettings);
        _resumeButton.onClick.AddListener(Resume);
        _quitButton.onClick.AddListener(Quit);
    }

    private void OnDestroy()
    {
        settingsButton.onClick.RemoveListener(OpenSettings);
        _resumeButton.onClick.RemoveListener(Resume);
        _resumeButton.onClick.RemoveListener(Quit);
    }

    private void OpenSettings()
    {
        //Rewrite Later
        Register.Get<UIManager>().Show(UIPopupType.PauseMenuSettings);
        Register.Get<UIManager>().Hide(UIPopupType.PauseMenu);
        Register.Get<UIManager>().Hide(UIPopupType.PauseButton);
    }



    private void Quit()
    {
        Time.timeScale = 1f;

        //Rewrite Later
        Register.Get<UIManager>().Hide(UIPopupType.PauseMenuSettings);
        Register.Get<UIManager>().Hide(UIPopupType.PauseMenu);
        Register.Get<UIManager>().Hide(UIPopupType.PauseButton);

        SceneManager.LoadScene(0);
    }

    private void Pause()
    {
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        //Rewrite Later
        Register.Get<UIManager>().Hide(UIPopupType.PauseMenuSettings);
        Register.Get<UIManager>().Hide(UIPopupType.PauseMenu);
        Register.Get<UIManager>().Show(UIPopupType.PauseButton);
    }
}
