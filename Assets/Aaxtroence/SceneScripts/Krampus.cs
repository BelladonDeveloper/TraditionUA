using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Krampus : MonoBehaviour
{
    [SerializeField] private DialogueScriptAax dialogueScript;
    [SerializeField] private string[] DialogueTexts;
    [SerializeField] private Characters[] characters;
    [SerializeField] private SaintNicolas saintNicolas;
    [SerializeField] private TransitionScript Transition;
    [SerializeField] private GameObject KrampusMinigame;
    [SerializeField] private GameObject KrampusCanvas;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject MainCanvas;


    public int DialogueNum = 0;
    public void Near()
    {
        if(DialogueNum == 0)
        {
            Talk(0, 2, ClaimTask);
        }
        else if(DialogueNum == 1)
        {
            
        }
    }
    

    private void ClaimTask()
    {
        Transition.DoTransition(TransitionFunction);
    }

    private void TransitionFunction()
    {
        KrampusMinigame.SetActive(true);
        KrampusCanvas.SetActive(true);
        MainCamera.SetActive(false);
        MainCanvas.SetActive(false);
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
