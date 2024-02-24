using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogueScriptAax : MonoBehaviour
{
    [SerializeField] private GameObject Triangle;
    [SerializeField] private GameObject _Joystick;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text CharName;
    [SerializeField] private TMP_Text Msg;
    [SerializeField] private Image CharFace;
    [SerializeField] private Button dialogueButton;
    [SerializeField] private Sprite[] Faces;
    [SerializeField] private string[] CharNames;
    [SerializeField] private Rigidbody PlayerRB;
    [SerializeField] private Transform JoystickParent;

    private GameObject prevJoystick;
    
    private Action _action;

    private void Start() 
    {
        DialoguePanel.SetActive(false);
        Subscribe();
    }
    private void OnDestroy()
    {
        UnSubscribe();
    }
    private IEnumerator _WriteText(string _messageText)
    {
        string MsgText = _messageText;
        Msg.text = "";
        yield return new WaitForSeconds(0.5f);
        foreach (char letter in MsgText)
        {
            Msg.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(0.025f);
        Triangle.SetActive(true);
        dialogueButton.gameObject.SetActive(true);
    }

    private void SetFace(Characters character)
    {
        CharFace.sprite = Faces[(int)character];
    }
    public void Dialogue(Characters character,string DialogueText)
    {
        SetFace(character);
        CharName.text = CharNames[(int)character];
        DialoguePanel.SetActive(true);
        StartCoroutine(_WriteText(DialogueText));
        Triangle.SetActive(false);
        dialogueButton.gameObject.SetActive(false);
        _action = null;
        Joystick(false);
    }

    public void Dialogue(Characters character,string DialogueText,Action action)
    {
        SetFace(character);
        CharName.text = CharNames[(int)character];
        DialoguePanel.SetActive(true);
        StartCoroutine(_WriteText(DialogueText));
        Triangle.SetActive(false);
        dialogueButton.gameObject.SetActive(false);
        _action = action;
        Joystick(false);
    }

    private void DialogueButton()
    {
        DialoguePanel.SetActive(false);
        Joystick(true);
        _action?.Invoke();
    }

    private void Joystick(bool TF)
    {
        if (TF)
        {
            prevJoystick = Instantiate(_Joystick,JoystickParent);
            prevJoystick.SetActive(true);
            PlayerRB.constraints &= ~RigidbodyConstraints.FreezePositionX;
            PlayerRB.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        }
        else
        {
            Destroy(prevJoystick);
            PlayerRB.constraints |= RigidbodyConstraints.FreezePositionX;
            PlayerRB.constraints |= RigidbodyConstraints.FreezePositionZ;
        }
    }

    private void Subscribe()
    {
        dialogueButton.onClick.AddListener(DialogueButton);
    }
    private void UnSubscribe()
    {
        dialogueButton.onClick.RemoveListener(DialogueButton);
    }
}

public enum Characters
{
    Main,
    SaintNicolas,
    Witch,
    Krampus,
    Unknown
}