using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    [SerializeField] private bool PlayOnStart;
    [SerializeField] private bool ScaleOnStart;
    [SerializeField] private int StartMusicIndex;
    public float SettingsMusicVolume;
    [SerializeField] private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;
    private bool AudioPlayer1 = true;// true - audioSource1, false - audioSource2

    private int AS1VolumePercentage;
    private int AS2VolumePercentage = 0;

    private int VolumeTarget = 100;

    private float _tick = 0.05f;
    private float _time = 0;
    [SerializeField] private SoundManager soundManager;

    private bool _pause = false;

    void Start()
    {
        if (PlayOnStart)
        {
            audioSource1.clip = soundManager.Music[StartMusicIndex];
            audioSource1.Play();
            AS1VolumePercentage = ScaleOnStart ? 0 : VolumeTarget;
        }
    }

    void Update()
    {
        if (_time < _tick)
        {
            _time += Time.deltaTime;
        }
        else
        {
            _Tick();
            _time = 0f;
        }
        audioSource1.volume = SettingsMusicVolume / 10000 * AS1VolumePercentage;
        audioSource2.volume = SettingsMusicVolume / 10000 * AS2VolumePercentage;

        if (_pause != soundManager.pause)
        {
            _pause = soundManager.pause;
            if (_pause)
            {
                audioSource1.pitch = 0;
                audioSource2.pitch = 0;
            }
            else
            {
                audioSource1.pitch = 1;
                audioSource2.pitch = 1;
            }
        }
    }

    private void _Tick()
    {
        if (AudioPlayer1)
        {
            if (AS1VolumePercentage < VolumeTarget)
            {
                AS1VolumePercentage++;
            }
            else if (AS1VolumePercentage > VolumeTarget)
            {
                AS1VolumePercentage -= 1;
            }
            if (AS2VolumePercentage > 0)
            {
                AS2VolumePercentage -= 1;
            }
        }
        else
        {
            if (AS2VolumePercentage < VolumeTarget)
            {
                AS2VolumePercentage++;
            }
            else if (AS2VolumePercentage > VolumeTarget)
            {
                AS2VolumePercentage -= 1;
            }
            if (AS1VolumePercentage > 0)
            {
                AS1VolumePercentage -= 1;
            }
        }
    }
    public void PlayMusic(int MusicIndex, bool UpscalingMusic)
    {
        if (AudioPlayer1)
        {
            audioSource2.clip = soundManager.Music[MusicIndex];
            audioSource2.Play();
            if (UpscalingMusic == false)
            {
                AS2VolumePercentage = VolumeTarget;
                AS1VolumePercentage = 0;
            }
        }
        else
        {
            audioSource1.clip = soundManager.Music[MusicIndex];
            audioSource1.Play();
            if (UpscalingMusic == false)
            {
                AS1VolumePercentage = VolumeTarget;
                AS2VolumePercentage = 0;
            }
        }
        AudioPlayer1 = !AudioPlayer1;
    }

    public void PlayMusic(AudioClip Music, bool UpscalingMusic)
    {
        if (AudioPlayer1)
        {
            audioSource2.clip = Music;
            audioSource2.Play();
            if (UpscalingMusic == false)
            {
                AS2VolumePercentage = VolumeTarget;
                AS1VolumePercentage = 0;
            }
        }
        else
        {
            audioSource1.clip = Music;
            audioSource1.Play();
            if (UpscalingMusic == false)
            {
                AS1VolumePercentage = VolumeTarget;
                AS2VolumePercentage = 0;
            }
        }
        AudioPlayer1 = !AudioPlayer1;
    }

    
    public void ChangeVolumeTarget(int number)
    {
        VolumeTarget = number;
    }
}
