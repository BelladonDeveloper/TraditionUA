using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Simple3SidesMovement : MonoBehaviour
{
    private int activeSide = 2;
    void Update()
    {
        if (activeSide == 1)
        {
            transform.DOMove(new Vector3(-17.4f, 141.92f, -8.985329f), 3, false);
        }
        if (activeSide == 2)
        {
            transform.DOMove(new Vector3(-8.280201f, 141.92f, -8.985329f), 3, false);
        }
        if (activeSide == 3)
        {
            transform.DOMove(new Vector3(6.4f, 141.92f, -8.985329f), 3, false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(activeSide != 3)
            {
                activeSide++;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (activeSide != 1)
            {
                activeSide -= 1;
            }
        }
    }
}
