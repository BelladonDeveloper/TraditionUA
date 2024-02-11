using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowrsAndWeed : MonoBehaviour
{
    private float speed = -6; // Швидкість руху об'єкта
    private void Update()
    {
        Vector3 currentPosition = transform.position;
        // Обчислюємо нову позицію об'єкта (постійно рухаємо його по осі Y)
        float newPositionY = currentPosition.y + speed * Time.deltaTime;
        // Створюємо новий вектор позиції
        Vector3 newPosition = new Vector3(currentPosition.x, newPositionY, currentPosition.z);
        // Зміщуємо позицію об'єкта
        transform.position = newPosition;
    }
}
