using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTradition : MonoBehaviour
{
    [SerializeField] private MovementController _movementController;

    [SerializeField] private GameObject _stick;
    [SerializeField] private CanvasGroup _darkness;


    private const int _changeScene = 0;

    private const float _timeToDarkness = 5f;

    public void OnFinishedTradition()
    {
        Sequence fading = DOTween.Sequence();

        _movementController.enabled = false;

        _stick.SetActive(false);

        fading.Append(_darkness.DOFade(1f, _timeToDarkness));

        StartCoroutine(GoToMenu());
    }

    private IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(_changeScene); 
    }

    private void OnEnable()
    {
        PickingThingsUp.OnFinishedTradition += OnFinishedTradition;
    }

    private void OnDisable()
    {
        PickingThingsUp.OnFinishedTradition -= OnFinishedTradition;
    }

}