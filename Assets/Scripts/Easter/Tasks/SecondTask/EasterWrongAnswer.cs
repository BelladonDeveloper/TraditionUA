using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EasterWrongAnswer : MonoBehaviour
{
    public static event Action OnLost;

    [SerializeField] private EasterProvider easterProvider;

    [SerializeField] private List<GameObject> _hearts;

    [SerializeField] private GameObject _heartParent;
    [SerializeField] private GameObject _heart;

    [SerializeField] private int _attemptsCount;

    private const float TimeToChangeAlphaState = 0.5f;

    public void AddHearts()
    {
        Sequence appear = DOTween.Sequence();

        for (int i = 0; i < _attemptsCount; i++)
        {
            easterProvider.CreateItem(_heart, Vector3.zero, Quaternion.identity, _heartParent.transform);
        }

        _heartParent.GetComponent<CanvasGroup>().alpha = 0;

        appear.Append(_heartParent.GetComponent<CanvasGroup>().DOFade(1, TimeToChangeAlphaState));
    }

    public void RemoveHeart()
    {
        Sequence fade = DOTween.Sequence();

        foreach (var heart in GameObject.FindGameObjectsWithTag("Heart"))
        {
            if (!_hearts.Contains(heart))
            {
                _hearts.Add(heart);
            }

            else
            {
                Debug.Log("You have already added heart in list");
            }

        }

        if (_hearts.Count != 0)
        {
            List<GameObject> sortedHearts = _hearts.Where(h => h != null)
                .OrderBy(e => e.transform.position.y)
                .ThenByDescending(e => e.transform.position.x)
                .ToList();

            GameObject lowestYElement = sortedHearts.FirstOrDefault();

            if (lowestYElement != null)
            {
                fade.Append(lowestYElement.GetComponent<CanvasGroup>().DOFade(0.2f, TimeToChangeAlphaState));
                fade.Append(lowestYElement.GetComponent<Image>().DOColor(Color.black, TimeToChangeAlphaState - 0.2f));
                fade.Join(lowestYElement.GetComponent<CanvasGroup>().DOFade(0f, TimeToChangeAlphaState + 0.2f));

                _hearts.Remove(lowestYElement);
                Destroy(lowestYElement, 3);
            }
        }

        if (_hearts.Count == 0)
        {
            _hearts.Clear();

            OnLost?.Invoke();
        }
    }

    public void ResetHearts()
    {
        _hearts.Clear();
    }

    private void OnEnable()
    {
        EasterCurrentSprite.OnDeletedHeart += RemoveHeart;
        SecondTask.OnSpawnedHearts += AddHearts;
        EasterLoseVariation.OnCleanedElements += ResetHearts;
    }

    private void OnDisable()
    {
        EasterCurrentSprite.OnDeletedHeart -= RemoveHeart;
        SecondTask.OnSpawnedHearts -= AddHearts;
        EasterLoseVariation.OnCleanedElements -= ResetHearts;
    }

}
