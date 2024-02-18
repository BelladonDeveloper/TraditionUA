using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToPresent : MonoBehaviour
{
    public GameObject toy1;
    public GameObject toy2;
    public GameObject toy3;
    public GameObject objectSprite;

    public Sprite newSprite; 

    private int collectedItemsCount = 0;

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject == toy1 || other.gameObject == toy2 || other.gameObject == toy3)
        {
            collectedItemsCount++;

            other.gameObject.SetActive(false);

            
            if (collectedItemsCount == 3)
            {
                ChangeSprite();
            }
        }
    }

    private void ChangeSprite()
    {
        if (newSprite != null)
        {
            SpriteRenderer spriteRenderer = objectSprite.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = newSprite;
            }
            else
            {
                Debug.LogError("Об'єкт без SpriteRenderer!");
            }
        }
        else
        {
            Debug.LogError("Додай спрайт");
        }
    }
}
