using System;
using UnityEngine;

public class Camera1 : MonoBehaviour
{
    public static Transform target;
    private float distance = 12f;

    public static float heights = 2f;
    public static float Quaternions = 45f;
    public Transform PlayerTarges;
    
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 offset = new Vector3(0f, heights, -distance);
            Quaternion rotation = Quaternion.Euler(Quaternions, 0f, 0f);  
            Vector3 desiredPosition = target.position + rotation * offset;

            float currentDistance = Vector3.Distance(transform.position, desiredPosition);

            transform.position = desiredPosition;

            transform.rotation = rotation;
        }
    }
    public void Start()
    {
        target = PlayerTarges;
    }
}
