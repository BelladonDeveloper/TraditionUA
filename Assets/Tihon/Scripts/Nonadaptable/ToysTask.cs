using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
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
        if(collision.gameObject.name == "Villager")
        {
            collision.gameObject.GetComponent<VDDialogue>().start = true;
        }
        if (collision.gameObject.name == "Villager1")
        {
            home1.GetComponent<SpriteRenderer>().sprite = openHome;
        }
        if (collision.gameObject.name == "Villager2")
        {
            home2.GetComponent<SpriteRenderer>().sprite = openHome;
        }
        if (collision.gameObject.name == "hatka")
        {
            if(villager.GetComponent<VDDialogue>().end == true)
            {
                home.GetComponent<SpriteRenderer>().sprite = openHome;
                SceneManager.LoadScene("FindAToy");
            }
        }
        if (collision.gameObject.name == "hatka1")
        {
            SceneManager.LoadScene("NeedleFinding");
        }
        if (collision.gameObject.name == "hatka2")
        {
            SceneManager.LoadScene("Василів_День_Раннер");
        }
    }
    private void Update()
    {
        if(counter == 3) 
        {
            SceneManager.LoadScene("Василів_День_Основа");
        }
    }
}
