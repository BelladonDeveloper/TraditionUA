using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToysFinding : MonoBehaviour
{
    public GameObject toysTask;
    private void Start()
    {

    }
    public Image x;
    public Sprite a;
    private void OnMouseDown()
    {
        Destroy(gameObject);
        x.sprite = a;
        toysTask.GetComponent<ToysTask>().counter++;
    }
}