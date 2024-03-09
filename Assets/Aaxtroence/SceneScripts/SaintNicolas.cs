using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SaintNicolas : MonoBehaviour
{
    public bool Task = false;
    [SerializeField] private RectTransform TaskUI;
    [SerializeField] private TMP_Text TaskText;
    [SerializeField] private int CollectedPresents = 0;
    [SerializeField] private int AdditionalPresents;
    private int TotalPresents;
    [SerializeField] private DialogueScriptAax dialogueScript;
    [SerializeField] private string[] DialogueTexts;
    [SerializeField] private Characters[] characters;
    private int DialogueNum = 0;
    [SerializeField] private TransitionScript Transition;

    private void Start() 
    {
        TotalPresents += AdditionalPresents;
        foreach (PresentScript presentScript in FindObjectsOfType<PresentScript>())
        {
            TotalPresents++;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            Near();
        }
    }

    private void Near()
    {
        if(DialogueNum == 0)
        {
            Talk(0, 4, ShowTask);
            Task = true;
            DialogueNum++;
        }
        else if(DialogueNum == 1)
        {
            dialogueScript.Dialogue(characters[5], DialogueTexts[5]);
        }
        else if(DialogueNum == 2)
        {
            Talk(6, 8, EndGame);
        }
    }
    private void EndGame()
    {
        Transition.DoTransition(OpenMenu);
    }
    private void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void ShowTask()
    {
        ResetPresentText();
        Sequence MoveTaskUI = DOTween.Sequence();
        MoveTaskUI.Append(TaskUI.DOAnchorPosY(60, 0.5f));
        MoveTaskUI.Play();
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

    public void CollectedPresent()
    {
        CollectedPresents++;
        ResetPresentText();
        if(CollectedPresents == TotalPresents)
        {
            DialogueNum = 2;
        }
    }

    private void ResetPresentText()
    {
        TaskText.text = CollectedPresents + "/" + TotalPresents;
    }
}
