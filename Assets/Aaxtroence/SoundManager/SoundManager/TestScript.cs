using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            soundManager.PlayMusic(Music.None, true);
        }
        if (Input.GetKeyDown("2"))
        {
            soundManager.PlayMusic(Music.MainMenu, true);
        }
        if (Input.GetKeyDown("3"))
        {
            soundManager.PlayMusic(Music.None, false);
        }
        if (Input.GetKeyDown("4"))
        {
            soundManager.PlayMusic(Music.MainMenu, false);
        }
        if (Input.GetKeyDown("5"))
        {
            soundManager.Music_SetVolume(100);
        }
        if (Input.GetKeyDown("6"))
        {
            soundManager.Music_SetVolume(50);
        }
        if (Input.GetKeyDown("7"))
        {
            soundManager.Music_SetVolume(25);
        }
        if (Input.GetKeyDown("8"))
        {
            soundManager.Music_SetVolume(0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            soundManager.PlaySound(Sound.Click);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            soundManager.PlaySound(Sound.Click, 10);
        }
    }
}
