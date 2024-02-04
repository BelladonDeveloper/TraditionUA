using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NameTextAnimationLoop : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;

    [SerializeField] private float _time;

    private bool _tweenRotate = true;
    private bool _tweenScale = true;
    
    private void Start() 
    {
        TweenRotate();
        TweenScale();
    }
    private void TweenRotate()
    {
        _tweenRotate = !_tweenRotate;

        Sequence tween1 = DOTween.Sequence();
        tween1.Append(rectTransform.DORotate(new Vector3(0, 0, _tweenRotate ? 2 : -2), _time));
        tween1.OnComplete(() => TweenRotate());
        tween1.SetEase(Ease.InQuad);
        tween1.Play();
    }

    private void TweenScale()
    {
        _tweenScale = !_tweenScale;

        Sequence tween2 = DOTween.Sequence();
        float _scale = _tweenScale ? 0.975f : 1.025f;
        tween2.Append(rectTransform.DOScale(new Vector3(_scale, _scale, _scale), _time / 2));
        tween2.OnComplete(() => TweenScale());
        tween2.SetEase(Ease.InQuad);
        tween2.Play();
    }

}
