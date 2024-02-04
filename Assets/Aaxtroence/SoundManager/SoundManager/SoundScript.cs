using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject soundPrefab;
    [SerializeField] private SoundDestroyer soundDestroyer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Transform SoundParent;
    public int SettingsSoundVolume;


    public void PlaySound(int SoundIndex)
    {
        audioSource.clip = soundManager.Sounds[SoundIndex];
        soundDestroyer._volume = 100;
        CreateClone();
    }
    public void PlaySound(int SoundIndex,int volume)
    {
        audioSource.clip = soundManager.Sounds[SoundIndex];
        soundDestroyer._volume = volume;
        CreateClone();
    }
    private void CreateClone()
    {
        GameObject prefab = Instantiate(soundPrefab,SoundParent);
        prefab.SetActive(true);
    }
}
