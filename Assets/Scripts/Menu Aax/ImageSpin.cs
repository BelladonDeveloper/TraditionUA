using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSpin : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;

    [SerializeField] private float Speed;

    private void FixedUpdate() 
    {
        rectTransform.localRotation *= Quaternion.Euler(0f, 0f, -Speed);
    }
}
