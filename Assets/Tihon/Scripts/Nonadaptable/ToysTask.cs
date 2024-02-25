using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToysTask : MonoBehaviour
{
    public GameObject home;
    public GameObject home1;
    public Sprite openHome;
    public int counter = 0;
    public string lvlName;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Villager")
        {
            home.GetComponent<SpriteRenderer>().sprite = openHome;
        }
        if (collision.gameObject.name == "Villager1")
        {
            home1.GetComponent<SpriteRenderer>().sprite = openHome;
        }
        if (collision.gameObject.name == "hatka")
        {
            SceneManager.LoadScene("FindAToy");
        }
        if (collision.gameObject.name == "hatka1")
        {
            SceneManager.LoadScene("NeedleFinding");
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
