using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TransparencyController : MonoBehaviour
{
    public float duration = 1.0f; // Длительность анимации изменения прозрачности

    public Image image; // Компонент Image объекта
    private Color originalColor; // Исходный цвет объекта

    void Start()
    {
        originalColor = image.color;
        image.gameObject.SetActive(true);
    }

    public void Darken()
    {
        image.gameObject.SetActive(true);
        image.DOColor(new Color(originalColor.r, originalColor.g, originalColor.b, 1f), duration);
    }

    public void Lighten()
    {
        image.DOColor(new Color(originalColor.r, originalColor.g, originalColor.b, 0f), duration)
            .OnComplete(() => image.gameObject.SetActive(false));
    }
}
