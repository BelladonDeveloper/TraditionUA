using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToysTask : MonoBehaviour
{
    public GameObject villager;
    public GameObject buble;
    public GameObject buble1;
    public Sprite openHome;
    public int counter = 0;
    public string lvlName;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Villager")
        {
            collision.gameObject.GetComponent<VDDialogue>().start = true;
        }
        if (collision.gameObject.name == "Villager1")
        {
            Destroy(buble);
            VDDialogue.meeting = 0;
            collision.gameObject.GetComponent<VDDialogue>().start = true;
        }
        if (collision.gameObject.name == "Villager2")
        {
            VDDialogue.meeting = 0;
            collision.gameObject.GetComponent<VDDialogue>().start = true;
        }
    }
    
    private void Update()
    {
        if (counter == 3)
        {
            VDDialogue.meeting = 1;
            SceneManager.LoadScene("Василів_День_Основа");
        }
    }
}