using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatTask : MonoBehaviour
{
    [SerializeField] private DialogueScriptAax dialogueScript;
    [SerializeField] private string[] DialogueTexts;
    [SerializeField] private Characters[] characters;
    private int DialogueNum = 0;
    [SerializeField] private CatTrigger _catTrigger;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Near();
            _catTrigger.StartHide();
        }
    }

    private void Near()
    {
        if (DialogueNum == 0)
        {
            Talk(0, 4, ShowTask);

            DialogueNum++;
        }
        else if (DialogueNum == 1)
        {
            dialogueScript.Dialogue(characters[5], DialogueTexts[5]);
        }
        else if (DialogueNum == 2)
        {
            //Когда собрал подарки
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

    private void ShowTask()
    {
       
    }
}
