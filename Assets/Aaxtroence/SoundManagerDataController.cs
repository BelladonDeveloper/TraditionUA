using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class SoundManagerDataController : MonoBehaviour
{
    private static SoundManagerDataController instance { get; set; }
    [SerializeField] private SoundManagerData _Data;

    private const string FILE_NAME = "SoundManagerData";

    [SerializeField] private SoundManager soundManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            CheckData();
            LoadData();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void LoadData()
    {
        soundManager.Settings_SetSoundVolume(_Data.SettingsSoundVolume);
        soundManager.Settings_SetMusicVolume(_Data.SettingsMusicVolume);
    }
    public void ReWriteData()
    {
        _Data.SettingsSoundVolume = soundManager.Settings_SoundVolume;
        _Data.SettingsMusicVolume = soundManager.Settings_MusicVolume;
    }
    private void CheckData()
    {
        _Data = SaveData.Load<SoundManagerData>(FILE_NAME);
        if (_Data == default)
        {
            _Data = new SoundManagerData();
            ReWriteData();
        }
    }
    private void OnApplicationQuit() 
    {
        ReWriteData();
        SaveData.Save(_Data,FILE_NAME);
    }
}
