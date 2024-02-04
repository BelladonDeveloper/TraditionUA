using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DnD : MonoBehaviour
{
    private Vector3 _mousePosition;

    private Vector3 Get_mousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }


    private void OnMouseDown()
    {
        _mousePosition = Input.mousePosition - Get_mousePosition();
    }
    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
    }
}
