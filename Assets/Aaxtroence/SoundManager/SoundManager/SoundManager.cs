using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour, IManager
{
    public AudioClip[] Music;
    public AudioClip[] Sounds;
    [SerializeField] private MusicSwitcher musicSwitcher;
    [SerializeField] private SoundScript soundScript;
    public bool pause = false;
    // Music
    public void PlayMusic(Music Index, bool Upscaling)
    {
        musicSwitcher.PlayMusic((int)Index, Upscaling);
    }

    public void PlayMusic(Music Index, bool Upscaling, int volume)
    {
        musicSwitcher.PlayMusic((int)Index, Upscaling);
        musicSwitcher.ChangeVolumeTarget(volume);
    }

    public void Music_SetVolume(int number)
    {
        musicSwitcher.ChangeVolumeTarget(number);
    }
    // Sound
    public void PlaySound(Sound Index)
    {
        soundScript.PlaySound((int)Index);
    }
    public void PlaySound(Sound Index, int volume)
    {
        soundScript.PlaySound((int)Index, volume);
    }
    
    // Settings
    public void Settings_SetMusicVolume(int volume)
    {
        musicSwitcher.SettingsMusicVolume = volume;
    }
    public void Settings_SetSoundVolume(int volume)
    {
        soundScript.SettingsSoundVolume = volume;
    }


    public void Init() { }
    public void Dispose() { }
}

public enum Music
{
    None,
    MainMenu,
    Game1,
    Game2,
    Game3
}

public enum Sound
{
    Click,
    Open,
    Close
}
