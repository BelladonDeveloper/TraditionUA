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
        
        if (other.gameObject == toy1 || other.gameObject == toy1 || other.gameObject == toy3)
        {
            
            collectedToys++;
            other.gameObject.SetActive(false);

            if (collectedToys == 3)
            {
                ChangeSprite();
            }
        }
    }

    private void ChangeSprite()
    {
        if (presentSprite != null)
        {
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
