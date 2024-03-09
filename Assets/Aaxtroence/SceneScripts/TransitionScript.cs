using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class TransitionScript : MonoBehaviour
{
    [SerializeField] private GameObject TransitionObject;
    private Image image;
    private void Start() 
    {
        image = TransitionObject.GetComponent<Image>();
    }

    public void DoTransition(Action _action)
    {
        TransitionObject.SetActive(true);
        Sequence _DoTransition = DOTween.Sequence();
        _DoTransition.Append(image.DOFade(1f, 0.5f));
        _DoTransition.OnComplete(() => 
        {
            Trans2();
            _action?.Invoke();
        });
        _DoTransition.Play();
    }
    private void Trans2()
    {
        Debug.Log("A");
        Sequence _DoTransition = DOTween.Sequence();
        _DoTransition.Append(image.DOFade(0f, 0.5f));
        _DoTransition.OnComplete(() => 
        {
            TransitionObject.SetActive(false);
        });
        _DoTransition.Play();
    }
}
