using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickingFlowers : MonoBehaviour
{
    public int PlayerRan;
    public int PlayerRan1;
    public int PlayerRan2;
    public string PlayerTag = "Player";
    public string PlayerTag1 = "Player";
    public string PlayerTag2 = "Player";

    public void random()  {PlayerRan = Random.Range(1, 3);}
    public void random1() {PlayerRan1 = Random.Range(1, 3);}
    public void random2() {PlayerRan2 = Random.Range(1, 3);}
    private void OnTriggerEnter(Collider other)
    {
        if (tag == PlayerTag)  {random();}
        if (tag == PlayerTag1) {random1();}
        if (tag == PlayerTag2) {random2();}
    }
}