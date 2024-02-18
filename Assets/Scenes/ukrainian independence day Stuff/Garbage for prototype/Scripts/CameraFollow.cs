﻿using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;  // Объект, за которым следит камера
    [SerializeField] private float distance = 5f;  // Отдаление от объекта
    [SerializeField] private float height = 2f;  // Высота от объекта

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
}