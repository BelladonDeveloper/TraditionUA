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
        if (other.tag == WeedTag) { Debags();}
    }

    void Debags()
    {
        Debug.Log("Weed"); 
    }
}
