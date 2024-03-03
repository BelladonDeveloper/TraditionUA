using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushScript : MonoBehaviour
{
    [SerializeField] private Witch witch;
    [SerializeField] private BushGenerator bushGenerator;
    [SerializeField] private Sprite[] BushSprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool HasBerry = false;
    
    private void PickUp()
    {
        spriteRenderer.sprite = BushSprites[0];
        witch.CollectedItem(true);
        HasBerry = false;
    }

    public void AddBerry()
    {
        spriteRenderer.sprite = BushSprites[1];
        HasBerry = true;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player") && HasBerry && witch.Task == true)
        {
            PickUp();
        }
    }

}