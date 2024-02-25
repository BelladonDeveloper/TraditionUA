using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Seeding : MonoBehaviour
{
    public Sprite open;
    public Sprite seeded;
    public Sprite closed;
    public GameObject player;
    void OnMouseDown()
    {
        if(transform.gameObject.GetComponent<SpriteRenderer>().sprite == open)
        {
            StartCoroutine("SeedingP");
        }
    }
    public IEnumerator SeedingP()
    {
        transform.gameObject.GetComponent<SpriteRenderer>().sprite = seeded;
        yield return new WaitForSeconds(1);
        transform.gameObject.GetComponent<SpriteRenderer>().sprite = closed;
        player.GetComponent<PlayerLosing>().seedCounter++;
    }
}