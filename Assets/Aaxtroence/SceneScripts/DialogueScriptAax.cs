using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Base;

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
    [SerializeField] private AudioClip[] Voices;
    [SerializeField] private Rigidbody PlayerRB;
    [SerializeField] private Transform JoystickParent;
    [SerializeField] private Animator _animator;
    [SerializeField] private MovementController movementController;

    private bool ButtonTask_FasterOrClose;

    private GameObject prevJoystick;
    
    private Action _action;

    private float VoiceCooldown = 0.075f;
    private float VoiceCd = 0;
    private float LetterTime;
    private SoundManager soundManager;
    private int voiceIndex;

    private void Start() 
    {
        soundManager = Register.Get<SoundManager>();
        DialoguePanel.SetActive(false);
        Subscribe();
        dialogueButton.gameObject.SetActive(true);
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
        LetterTime = 0.025f;
        VoiceCd = 0f;
        foreach (char letter in MsgText)
        {
            VoiceCd += (LetterTime == 0.025f)? LetterTime : LetterTime * 2;
            if(VoiceCd >= VoiceCooldown)
            {
                VoiceCd = 0f;
                soundManager.PlaySound(Voices[voiceIndex]);
            }
            Msg.text += letter;
            yield return new WaitForSeconds(LetterTime);
        }
        yield return new WaitForSeconds(0.025f);
        Triangle.SetActive(true);

        ButtonTask_FasterOrClose = false;
    }

    private void SetFace(Characters character)
    {
        CharFace.sprite = Faces[(int)character];
    }
    public void Dialogue(Characters character,string DialogueText)
    {
        _action = null;
        voiceIndex = (int)character;
        SetFace(character);
        CharName.text = CharNames[(int)character];
        DialoguePanel.SetActive(true);
        StartCoroutine(_WriteText(DialogueText));
        Triangle.SetActive(false);
        ButtonTask_FasterOrClose = true;
        Joystick(false);
    }

    public void Dialogue(Characters character,string DialogueText,Action action)
    {
        Dialogue(character,DialogueText);
        _action = action;
    }

    private void DialogueButton()
    {
        if(ButtonTask_FasterOrClose)
        {
            LetterTime = 0.005f;
        }
        else
        {
            DialoguePanel.SetActive(false);
            Joystick(true);
            _action?.Invoke();
        }
        
    }

    private void Joystick(bool TF)
    {
        movementController.CutSceneBool = !TF;
        if (TF)
        {
            prevJoystick = Instantiate(_Joystick,JoystickParent);
            prevJoystick.SetActive(true);
            PlayerRB.constraints &= ~RigidbodyConstraints.FreezePositionX;
            PlayerRB.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        }
        else
        {
            _animator.SetBool("IsMove", false); 
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
    Unknown,
    Rabbit
}