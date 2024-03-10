using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerInTrigger;
    public GameObject[] objectsToActivate; // Масив об'єктів для активації після діалогу

    private bool dialogueCompleted = false;

    void Start()
    {
        dialogueText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInTrigger)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else if (dialogueText.text == dialogue[index])
            {
                NextLine();
            }

        }

        if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }

    }

    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);

    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            dialogueCompleted = true;
            RemoveText();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            RemoveText();
        }

        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true); // Активуємо кожен об'єкт з масиву
        }
    }

    //void ActivateObjects()
    //{
    //    foreach (GameObject obj in objectsToActivate)
    //    {
    //        obj.SetActive(true); // Активуємо кожен об'єкт з масиву
    //    }
    //}
}
