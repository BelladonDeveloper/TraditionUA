using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using Base;

public class Krampus : MonoBehaviour
{
    [SerializeField] private DialogueScriptAax dialogueScript;
    [SerializeField] private string[] DialogueTexts;
    [SerializeField] private Characters[] characters;
    [SerializeField] private SaintNicolas saintNicolas;
    [SerializeField] private TransitionScript Transition;
    [SerializeField] private GameObject _KrampusMinigame;
    [SerializeField] private GameObject KrampusCanvas;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject MainCanvas;
    [SerializeField] private KrampusMinigame krampusMinigameScript;
    [SerializeField] private AudioClip KrampusMusic;

    public int DialogueNum = 0;
    public void Near()
    {
        if(DialogueNum == 0)
        {
            Talk(0, 4, ClaimTask);
        }
        else if(DialogueNum == 1)
        {
            Talk(5, 5, ClaimTask);
        }
        else if(DialogueNum == 2)
        {
            Talk(6, 7, GivePresent);
            DialogueNum++;
        }
        else if(DialogueNum == 3)
        {
            Talk(8, 8, null);
        }
    }
    
    private void GivePresent()
    {
        saintNicolas.CollectedPresent();
    }
    private void ClaimTask()
    {
        Transition.DoTransition(TransitionFunction);
    }

    private void TransitionFunction()
    {
        Register.Get<SoundManager>().PlayMusic(KrampusMusic,true,50);
        _KrampusMinigame.SetActive(true);
        KrampusCanvas.SetActive(true);
        MainCamera.SetActive(false);
        MainCanvas.SetActive(false);
        krampusMinigameScript.StartMinigame();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && saintNicolas.Task == true)
        {
            Near();
        }
    }

    private void Talk(int from, int to, Action action)
    {
        if (from == to)
        {
            dialogueScript.Dialogue(characters[from], DialogueTexts[from], action);
        }
        else
        {
            dialogueScript.Dialogue(characters[from], DialogueTexts[from], () => Talk(from + 1, to, action));
        }
    }
}
