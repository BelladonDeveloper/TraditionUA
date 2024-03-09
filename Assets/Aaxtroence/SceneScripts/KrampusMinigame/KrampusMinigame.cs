using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
using Base;

public class KrampusMinigame : MonoBehaviour
{
    private float TimeLeft = 45f;
    [SerializeField] private Transform ConesParent;
    [SerializeField] private GameObject ConesPrefab;
    [SerializeField] private TMP_Text TimerText;
    [SerializeField] private TransitionScript Transition;
    [SerializeField] private GameObject KrampusCanvas;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject MainCanvas;
    [SerializeField] private Krampus krampus;
    private float CD = 0f;
    private float SoundCD = 0f;
    private bool Working = true;
    private bool WinOrLose;
    private SoundManager soundManager;
    [SerializeField] private AudioClip ShakeSound;

    [SerializeField] private AudioClip GameMusic;
    private void Start() 
    {
        soundManager = Register.Get<SoundManager>();
    }
    void Update()
    {
        if(Working)
        {
            Tick();
            TimerText.text = TimeLeft.ToString("#0.00");
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
            }
            else 
            {
                TimeLeft = 0;
                Win();
                Working = false;
            }
        }
    }
    private void Tick()
    {
        if(CD <= 0)
        {
            Drop();
            Debug.Log("Drop");
            CD = Random.Range(0.2f,1.5f);
        }
        else
        {
            CD -= Time.deltaTime;
        }
        if(SoundCD <= 0)
        {
            soundManager.PlaySound(ShakeSound,20);
            SoundCD = 1.1f;
        }
        else
        {
            SoundCD -= Time.deltaTime;
        }
    }
    private void Drop()
    {
        GameObject cone = Instantiate(ConesPrefab, ConesParent);
        cone.SetActive(true);
    }
    private void Win()
    {
        WinOrLose = true;
        Transition.DoTransition(TransitionFunction);
    }
    public void Lose()
    {
        WinOrLose = false;
        Transition.DoTransition(TransitionFunction);
    }
    public void StartMinigame()
    {
        
        TimeLeft = 45f;
        Working = true;
    }


    private void TransitionFunction()
    {
        soundManager.PlayMusic(GameMusic,true,50);
        krampus.DialogueNum = WinOrLose ? 2 : 1;
        gameObject.SetActive(false);
        KrampusCanvas.SetActive(false);
        MainCamera.SetActive(true);
        MainCanvas.SetActive(true);
    }
}
