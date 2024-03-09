using DG.Tweening;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Collections;
using Base;
using UnityEngine.SceneManagement;

public class FinalScreen : MonoBehaviour
{
    public TMP_Text FinalTextOne;
    public TMP_Text FinalTextTwo;
    public GameObject BlackScreen;
    public void StartFinal()
    {
        BlackScreen.gameObject.SetActive(true);
        StartCoroutine(FinalTextShow());
    }

    IEnumerator FinalTextShow()
    {
        FinalTextOne.DOFade(1f, 1f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(4f);
        FinalTextOne.DOFade(0f, 1f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(2f);
        FinalTextTwo.DOFade(1f, 1f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(4f);
        FinalTextTwo.DOFade(0f, 1f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(3f);

        Register.Get<UIManager>().Hide(UIPopupType.PauseMenuSettings);
        Register.Get<UIManager>().Hide(UIPopupType.PauseMenu);
        Register.Get<UIManager>().Hide(UIPopupType.PauseButton);

        SceneManager.LoadScene(0);
    }
}
