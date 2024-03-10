using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToysTask : MonoBehaviour
{
    public GameObject villager;
    public GameObject home;
    public GameObject home1;
    public GameObject home2;
    public Sprite openHome;
    public int counter = 0;
    public string lvlName;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Villager")
        {
            collision.gameObject.GetComponent<VDDialogue>().start = true;
        }
        if (collision.gameObject.name == "Villager2")
        {
            collision.gameObject.GetComponent<VDDialogue>().start = true;
        }
        if (collision.gameObject.name == "hatka1")
        {
            SceneManager.LoadScene("NeedleFinding");
        }
    }
    
    private void Update()
    {
        if (counter == 3)
        {
            VDDialogue.meeting += 1;
            SceneManager.LoadScene("Василів_День_Основа");
        }
    }
}