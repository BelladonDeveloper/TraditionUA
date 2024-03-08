using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Base;
using Unity.VisualScripting;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private Sprite[] IconPrefs;
    [SerializeField] private Slider slider;
    
    private float PreviousValue = -1f;
    private SoundManager soundManager;

    private void Awake() 
    {
        soundManager = Register.Get<SoundManager>();
        soundManager.SetVolume();
        if(gameObject.name == "SoundSlider")
        {
            slider.value = soundManager.Settings_SoundVolume;
        }
        else if(gameObject.name == "MusicSlider")
        {
            slider.value = soundManager.Settings_MusicVolume;
        }
        
    }

    public void ChangeVolume()
    {
        if(slider.value != PreviousValue)
        {
            PreviousValue = slider.value;
            int val;
            val = 0;
            val = (slider.value > 0 && slider.value < 25) ? 1 : val;
            val = (slider.value >= 25 && slider.value < 50) ? 2 : val;
            val = (slider.value >= 50 && slider.value < 75) ? 3 : val;
            val = (slider.value >= 75) ? 4 : val;
            iconImage.sprite = IconPrefs[val];

            if(gameObject.name == "SoundSlider")
            {
                float volume = (float)Math.Floor(slider.value);
                soundManager.Settings_SetSoundVolume(Mathf.RoundToInt(volume));
            }
            else if(gameObject.name == "MusicSlider")
            {
                float volume = (float)Math.Floor(slider.value);
                soundManager.Settings_SetMusicVolume(Mathf.RoundToInt(volume));
            }
        }
    }
}
