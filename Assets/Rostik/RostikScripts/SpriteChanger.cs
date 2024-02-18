using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public GameObject toy1;
    public GameObject toy2;
    public GameObject toy3;
    public GameObject present;

    public Sprite presentSprite; 

    private int collectedToys = 0;

    private void OnTriggerEnter(Collider other)
    {
        // Перевірка, чи об'єкт, який потрапив в тригер, є предметом
        if (other.gameObject == toy1 || other.gameObject == toy1 || other.gameObject == toy3)
        {
            // Збільшуємо лічильник зібраних предметів
            collectedToys++;

            // Вимикаємо зібраний предмет
            other.gameObject.SetActive(false);

            // Перевірка, чи зібрані всі три предмети
            if (collectedToys == 3)
            {
                // Змінюємо спрайт третього об'єкта
                ChangeSprite();
            }
        }
    }

    private void ChangeSprite()
    {
        // Перевірка, чи є новий спрайт для зміни
        if (presentSprite != null)
        {
            // Змінюємо спрайт третього об'єкта
            SpriteRenderer spriteRenderer = present.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = presentSprite;
            }
            else
            {
                Debug.LogError("Об'єкт не має компонента SpriteRenderer!");
            }
        }
        else
        {
            Debug.LogError("Не вказаний новий спрайт!");
        }
    }
}
