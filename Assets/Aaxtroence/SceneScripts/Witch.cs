using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Witch : MonoBehaviour
{
    public bool Task = false;
    [SerializeField] private RectTransform TaskUI;
    [SerializeField] private TMP_Text TaskText1;
    [SerializeField] private TMP_Text TaskText2;
    [SerializeField] private DialogueScriptAax dialogueScript;
    [SerializeField] private string[] DialogueTexts;
    [SerializeField] private Characters[] characters;
    [SerializeField] private SaintNicolas saintNicolas;

    public int CollectedBerries;
    public int CollectedCones;

    public int TotalBerries;
    public int TotalCones;
    
    private int DialogueNum = 0;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && saintNicolas.Task == true)
        {
            Near();
        }
    }

    private void Near()
    {
        if(DialogueNum == 0)
        {
            Talk(0, 2, ShowTask);
            Task = true;
            DialogueNum++;
        }
        else if(DialogueNum == 1)
        {
            dialogueScript.Dialogue(characters[3], DialogueTexts[3]);
        }
        else if(DialogueNum == 2)
        {
            Talk(4, 6, HideTask);
            DialogueNum = 3;
        }
        else if(DialogueNum == 3)
        {
            dialogueScript.Dialogue(characters[7], DialogueTexts[7]);
        }
    }

    private void ShowTask()
    {
        ResetTaskText();
        Sequence MoveTaskUI = DOTween.Sequence();
        MoveTaskUI.Append(TaskUI.DOAnchorPosY(-180, 0.5f));
        MoveTaskUI.Play();
    }

    private void HideTask()
    {
        Sequence MoveTaskUI = DOTween.Sequence();
        MoveTaskUI.Append(TaskUI.DOAnchorPosY(60, 0.5f));
        MoveTaskUI.Play();
        saintNicolas.CollectedPresent();
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

    public void CollectedItem(bool BerryOrCone)
    {
        if(BerryOrCone)
        {
            CollectedBerries++;
        }
        else
        {
            CollectedCones++;
        }
        ResetTaskText();
        if(CollectedBerries >= TotalBerries && CollectedCones >= TotalCones)
        {
            DialogueNum = 2;
        }
    }

    private void ResetTaskText()
    {
        TaskText1.text = CollectedBerries + "/" + TotalBerries;
        TaskText2.text = CollectedCones + "/" + TotalCones;
    }
}
