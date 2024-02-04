using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDestroyer : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private SoundScript soundScript;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject SoundObj;
    public int _volume;

    private void Awake() 
    {
        audioSource.Play();
    }
    void Update()
    {
        float vol = 0.01f * soundScript.SettingsSoundVolume/100 * _volume;
        audioSource.volume = vol;
        if (!audioSource.isPlaying)
        {
            Destroy(SoundObj);
        }
    }
}