using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class VDDialogue : MonoBehaviour
{
    public GameObject player;
    public Text dialogueText;
    public GameObject bubble;
    public Image joystick;
    private string script;
    public bool start = false;
    public bool end = false;
    public Button next;
    public string phrase1;
    public string phrase2;
    public string phrase3;
    public string phrase4;
    public string phrase5;
    public string phrase6;
    public string phrase7;
    public string phrase8;
    public int phrasesCount = 0;
    public string phrase11;
    public string phrase12;
    public string phrase13;
    public string phrase14;
    public string phrase15;
    public string phrase16;
    public string phrase17;
    public string phrase18;
    public static int meeting = 0;
    public string lvl;

    public void Start()
    {
        Debug.Log(meeting);
        start = false;
        next.onClick.AddListener(Dialoguing);
        if (phrase1 == "k") { } else { phrasesCount++; }
        if (phrase2 == "k") { } else { phrasesCount++; }
        if (phrase3 == "k") { } else { phrasesCount++; }
        if (phrase4 == "k") { } else { phrasesCount++; }
        if (phrase5 == "k") { } else { phrasesCount++; }
        if (phrase6 == "k") { } else { phrasesCount++; }
        if (phrase7 == "k") { } else { phrasesCount++; }
        if (phrase8 == "k") { } else { phrasesCount++; }
    }
    public void Update()
    {

        if (dialogueText.text != script)
        {
            dialogueText.text = script;
        }
        if (start)
        {
            bubble.GetComponent<CanvasGroup>().alpha = 1;
            joystick.GetComponent<CanvasGroup>().alpha = 0;
            Time.timeScale = 0;
        }
    }
    public void Dialoguing()
    {
        Debug.Log(meeting);
        if (phrasesCount > 0)
        {
            if (meeting == 0)
            {
                if (phrasesCount == 1) { script = phrase1; }
                if (phrasesCount == 2) { script = phrase2; }
                if (phrasesCount == 3) { script = phrase3; }
                if (phrasesCount == 4) { script = phrase4; }
                if (phrasesCount == 5) { script = phrase5; }
                if (phrasesCount == 6) { script = phrase6; }
                if (phrasesCount == 7) { script = phrase7; }
                if (phrasesCount == 8) { script = phrase8; }
                phrasesCount--;
            }
            else
            {
                if (phrasesCount == 1) { script = phrase11; }
                if (phrasesCount == 2) { script = phrase12; }
                if (phrasesCount == 3) { script = phrase13; }
                if (phrasesCount == 4) { script = phrase14; }
                if (phrasesCount == 5) { script = phrase15; }
                if (phrasesCount == 6) { script = phrase16; }
                if (phrasesCount == 7) { script = phrase17; }
                if (phrasesCount == 8) { script = phrase18; }
                phrasesCount--;
            }
        }
        else
        {
                start = false;
                meeting++;
                Time.timeScale = 1;
                bubble.GetComponent<CanvasGroup>().alpha = 0;
                joystick.GetComponent<CanvasGroup>().alpha = 1;
                end = true;   
            if (meeting == 0)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                Destroy(bubble);
            }
            else
            {
                if(meeting == 1)
                {
                    SceneManager.LoadScene(lvl);
                }
            }
        }
    }
}