using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowrsAndWeed : MonoBehaviour
{
    private float speed = -6;
    private void Update()
    {
        Vector3 currentPosition = transform.position;
        float newPositionY = currentPosition.y + speed * Time.deltaTime;
        Vector3 newPosition = new Vector3(currentPosition.x, newPositionY, currentPosition.z);
        transform.position = newPosition;
    }
}
