using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject popy;
    public RectTransform rectTransfor;
    public static bool pope;

    private void Start()
    {
        rectTransfor = popy.GetComponent<RectTransform>();
        pope = false;
    }

    private void Update()
    {
        poppy();
    }

    void poppy()
    {
        if (pope == true)
        {
            rectTransfor.anchoredPosition = new Vector2(861.72f, 515.77f);
        }
    }
}
