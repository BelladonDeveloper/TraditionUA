using Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuSettings : UIPopup
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Slider _musicSlider;

    private void Start()
    {
        if (_volumeSlider && _backButton != null)
        {
            _volumeSlider.onValueChanged.AddListener(ChangeVolume);
            _musicSlider.onValueChanged.AddListener(ChangeSound);
            _backButton.onClick.AddListener(QuitSettingsMenu);
        }
    }

    private void OnDestroy()
    {
        _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
        _musicSlider.onValueChanged.AddListener(ChangeSound);
        _backButton.onClick.RemoveListener(QuitSettingsMenu);
    }

    private void ChangeVolume(float musicvolume)
    {
        float realvolume = (float)Math.Floor(musicvolume);
        Register.Get<SoundManager>().Settings_SetSoundVolume(Mathf.RoundToInt(realvolume));
    }
    private void ChangeSound(float soundvolume)
    {
        float realvolume = (float)Math.Floor(soundvolume);
        Register.Get<SoundManager>().Settings_SetMusicVolume(Mathf.RoundToInt(realvolume));
    }

    private void QuitSettingsMenu()
    {
        Register.Get<UIManager>().Show(UIPopupType.PauseMenu);
        Register.Get<UIManager>().Hide(UIPopupType.PauseMenuSettings);
    }
}
