using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToysTask : MonoBehaviour
{
    public GameObject home;
    public Sprite openHome;
    public int counter = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Villager")
        {
            home.GetComponent<SpriteRenderer>().sprite = openHome;
        }
        if (collision.gameObject.name == "hatka")
        {
            SceneManager.LoadScene("FindAToys");
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
