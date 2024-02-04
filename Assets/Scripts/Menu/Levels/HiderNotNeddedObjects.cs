using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderNotNeddedObjects : MonoBehaviour
{
    private List<GameObject> objects = new List<GameObject>();

    private void Awake()
    {
        GameObject[] uiObjectsArray = GameObject.FindGameObjectsWithTag("UIObjects");
        foreach (GameObject uiObject in uiObjectsArray)
        {
            objects.Add(uiObject);
        }
    }

    public void Hide()
    {   
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(false);
        }

    }

    public void Show()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(true);
        }
    }
}
