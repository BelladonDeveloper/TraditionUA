using UnityEngine;

public class TransparentObjects : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    private void Start() 
    {
        spriteRenderer = transform.Find("TreeSprite").GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeAlpha(0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeAlpha(1f);
        }
    }

    private void ChangeAlpha(float alphaValue)
    {
        Color color = spriteRenderer.color;
        color.a = alphaValue;
        spriteRenderer.color = color;
    }
}