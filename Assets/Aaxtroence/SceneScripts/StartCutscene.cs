using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class StartCutscene : MonoBehaviour
{
    [SerializeField] private string SNText;
    [SerializeField] private float WalkTime;
    [SerializeField] private DialogueScriptAax Dialogue;
    [SerializeField] private string _CenterText;
    [SerializeField] private TMP_Text CenterText;
    [SerializeField] private GameObject Transition;
    [SerializeField] private Transform PlayerTF;
    [SerializeField] private Transform Pos1;
    [SerializeField] private Animator _animator;
    [SerializeField] private MovementController movementController;

    void Start()
    {
        movementController.CutSceneBool = true;
        _animator.SetFloat("MovementX", 5); 
        _animator.SetBool("IsMove", true); 


        Transition.SetActive(true);
        DOTransition();
        MovePlayer1();
    }

    private void MovePlayer1()
    {
        Sequence _MovePlayer = DOTween.Sequence();
        _MovePlayer.Append(PlayerTF.DOMove(Pos1.position, WalkTime).SetEase(Ease.Linear));
        _MovePlayer.OnComplete(() => 
        {
            Dialogue.Dialogue(Characters.SaintNicolas,SNText);
            movementController.CutSceneBool = false;
        });
    }

    private void DOTransition()
    {
        Sequence DoTransition = DOTween.Sequence();
        DoTransition.Append(Transition.GetComponent<Image>().DOFade(0f, 0.5f));
        DoTransition.OnComplete(() => 
        {
            Transition.SetActive(false);
            StartCoroutine(WriteTextByLetter());

        });
        DoTransition.Play();
    }

    private IEnumerator WriteTextByLetter()
    {
        CenterText.text = "";
        foreach (char letter in _CenterText)
        {
            CenterText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2f);
        foreach (char letter in _CenterText)
        {
            CenterText.text = CenterText.text.Remove(CenterText.text.Length - 1);
            yield return new WaitForSeconds(0.025f);
        }
    }
}
