using UnityEngine;

public class RoofControl : MonoBehaviour
{
    private SpriteRenderer _objectForFade;
    private const float _normalState = 1f;
    private const float _halfFaded = 0.5f;

    private void Start()
    {
        _objectForFade = this.gameObject.GetComponent<SpriteRenderer>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Color spriteColor = _objectForFade.color;
            spriteColor.a = _halfFaded;
            _objectForFade.color = spriteColor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Color spriteColor = _objectForFade.color;
            spriteColor.a = _normalState;
            _objectForFade.color = spriteColor;
        }
    }

    // Додати плавність за допомогою DoTween
}