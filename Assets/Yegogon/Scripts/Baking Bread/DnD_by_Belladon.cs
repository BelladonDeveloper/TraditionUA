using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DnD_by_Belladon : MonoBehaviour
{
    private Vector3 offset;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    break;
                case TouchPhase.Moved:
                    Vector3 newPos = touchPos + offset;
                    newPos.x = transform.position.x;
                    newPos.y = transform.position.y;
                    transform.position = newPos;
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    break;
            }
        }
    }
}