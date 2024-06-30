using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private SettingsScript settingsScript;
    [SerializeField] private Image iconImage;
    [SerializeField] private Sprite[] IconPrefs;
    [SerializeField] private Slider slider;
    private float PreviousValue = -1f;
    private void Start() 
    {
        if(gameObject.name == "SoundSlider")
        {
            slider.value = settingsScript.SoundVolume;
        }
        else if(gameObject.name == "MusicSlider")
        {
            slider.value = settingsScript.MusicVolume;
        }
    }

    void Update()
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
                settingsScript.SoundVolume = (float)Math.Floor(slider.value);
            }
            else if(gameObject.name == "MusicSlider")
            {
                settingsScript.MusicVolume = (float)Math.Floor(slider.value);
            }
        }
    }
}