using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DnD_for_Baking : MonoBehaviour
{
    private Vector3 _mousePosition;
    private Vector3 _expectedPosition;

    private Vector3 Get_mousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }


    private void OnMouseDown()
    {
        _mousePosition = Input.mousePosition - Get_mousePosition();
        _expectedPosition = new Vector3(0, 0, _mousePosition.z);
    }
    private void OnMouseDrag()
    {
        Vector3 _actualPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - _expectedPosition);
        transform.position = _actualPosition;
    }
}
