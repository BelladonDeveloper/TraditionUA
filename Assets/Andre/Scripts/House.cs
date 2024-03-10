using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public Sprite newSprite;
    string PlayerTag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PlayerTag)  {PopyINhouse();}
    }

    void PopyINhouse()
    {
        if (Inventory.pope == true)
        {
            SpriteRenderer spriteRendere = GetComponent<SpriteRenderer>();
            spriteRendere.sprite = newSprite;
        }
    }
}
