using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private bool Load;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Image image;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private InitialController initialController;
    void Start()
    {
        Sequence Tween = DOTween.Sequence();
        Tween.Append(rectTransform.DOAnchorPosX(0f, Load ?  7.5f : 0f));
        Tween.Append(image.DOFade(0f, 1f));
        Tween.OnComplete(() => 
        {
            loadingScreen.SetActive(false);
            initialController.soundManager.PlayMusic(Music.MainMenu, false);
        });
        Tween.Play();
        
    }
}
