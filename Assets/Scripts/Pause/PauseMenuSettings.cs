using Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuSettings : UIPopup
{
    [SerializeField] private Button backButton;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle muteToggle;

    private void Start()
    {
        if (volumeSlider && muteToggle && backButton != null)
        {
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
            muteToggle.onValueChanged.AddListener(MuteSound);
            backButton.onClick.AddListener(QuitSettingsMenu);
        }
    }

    private void OnDestroy()
    {
        volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
        muteToggle.onValueChanged.RemoveListener(MuteSound);
        backButton.onClick.RemoveListener(QuitSettingsMenu);
    }

    private void ChangeVolume(float volume)
    {
        Debug.Log("I haven't AudioSourse" + volume);

    }
    private void MuteSound(bool isMute)
    {
        Debug.Log("Thought for my mute is" + isMute);
    }

    private void QuitSettingsMenu()
    {
        Register.Get<UIManager>().Show(UIPopupType.PauseMenu);
        Register.Get<UIManager>().Hide(UIPopupType.PauseMenuSettings);
    }
}
