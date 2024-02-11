using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pongs : MonoBehaviour
{
    public float speed = 5f;
    public string Left = "a";
    public string right = "d";
    
    string FlowersTag = "Flowers";
    string WeedTag = "Weed";
    public GameObject _joysticks;
    public GameObject MiniGame1;
    public Transform targes;
    
    public GameObject WeedT;
    public GameObject FlowersT;

    void Update()
    {
        if (Input.GetKey(Left))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(right))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == WeedTag) { СlosingWeed(); }
        if (other.tag == FlowersTag) { СlosingFlowers(); }
    }

    void СlosingWeed()
    {
        _joysticks.SetActive(true);
        AndrePlayerController._moveSpeed = 6;
        Camera1.target = targes;
        Camera1.Quaternions = 45;
        MiniGame1.SetActive(false);
        AndrePlayerController.weed = +1;
        WeedT.SetActive(true);
        FlowersT.SetActive(true);
    }
    void СlosingFlowers()
    {
        WeedT.SetActive(true);
        FlowersT.SetActive(true);
        _joysticks.SetActive(true);
        AndrePlayerController._moveSpeed = 6;
        Camera1.target = targes;
        Camera1.Quaternions = 45;
        MiniGame1.SetActive(false);
        AndrePlayerController.flowers = +1;
    }
}
