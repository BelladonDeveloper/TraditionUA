using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private TransparencyController transparencyController;
    [SerializeField] private Transform target;  
    [SerializeField] private float distance = 5f;  
    [SerializeField] private float height = 2f;  

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 offset = new Vector3(0f, height, -distance);
            Quaternion rotation = Quaternion.Euler(45f, 0f, 0f);
            Vector3 desiredPosition = target.position + rotation * offset;

            float currentDistance = Vector3.Distance(transform.position, desiredPosition);

            transform.position = desiredPosition;

            transform.rotation = rotation;
        }
    }

    public void Fade()
    {
        transparencyController.Darken();
    }  
    public void Light()
    {
        transparencyController.Lighten();
    }

    public void SetFloatToOut()
    {
        distance = 10f;
        height = 1f;
    }
}