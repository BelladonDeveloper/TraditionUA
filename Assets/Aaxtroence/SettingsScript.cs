using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public float SoundVolume;
    private float previousSoundVolume = -1;
    public float MusicVolume;
    private float previousMusicVolume = -1;


    [SerializeField] private InitialController initialController;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    void Update()
    {
        if(previousSoundVolume != SoundVolume)
        {
            previousSoundVolume = SoundVolume;
            initialController.soundManager.Settings_SetSoundVolume(Mathf.RoundToInt(SoundVolume));
        }
        if(previousMusicVolume != MusicVolume)
        {
            previousMusicVolume = MusicVolume;
            initialController.soundManager.Settings_SetMusicVolume(Mathf.RoundToInt(MusicVolume));
        }
    }
}
