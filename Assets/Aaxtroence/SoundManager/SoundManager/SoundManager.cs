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
    public int Settings_SoundVolume = 100;
    public int Settings_MusicVolume = 100;
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

    public void PlayMusic(AudioClip Music, bool Upscaling)
    {
        musicSwitcher.PlayMusic(Music, Upscaling);
    }

    public void PlayMusic(AudioClip Music, bool Upscaling, int volume)
    {
        musicSwitcher.PlayMusic(Music, Upscaling);
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
    
    public void PlaySound(AudioClip Sound)
    {
        soundScript.PlaySound(Sound);
    }

    public void PlaySound(AudioClip Sound, int volume)
    {
        soundScript.PlaySound(Sound,volume);
    }

    // Settings
    public void Settings_SetMusicVolume(int volume)
    {
        musicSwitcher.SettingsMusicVolume = volume;
        Settings_MusicVolume = volume;
    }


    public void Settings_SetSoundVolume(int volume)
    {
        soundScript.SettingsSoundVolume = volume;
        Settings_SoundVolume = volume;
    }

    public void SetVolume()
    {
        Settings_MusicVolume = (int)musicSwitcher.SettingsMusicVolume;
        Settings_SoundVolume = (int)soundScript.SettingsSoundVolume;
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
    Game3,
    SaintNicolas1,
    SaintNicolas2
}

public enum Sound
{
    Click,
    Open,
    Close
}
