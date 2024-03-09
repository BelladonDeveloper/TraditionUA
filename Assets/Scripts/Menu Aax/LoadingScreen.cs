using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private bool Load;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Image image;
    [SerializeField] private GameObject loadingScreen;
    
    void Start()
    {
        Sequence Tween = DOTween.Sequence();
        Tween.Append(rectTransform.DOAnchorPosX(0f, Load ?  0.5f : 0f));
        Tween.Append(image.DOFade(0f, 1f));
        Tween.OnComplete(() => 
        {
            loadingScreen.SetActive(false);
            Register.Get<SoundManager>().PlayMusic(Music.MainMenu, false);
        });
        Tween.Play();
        
    }
}
