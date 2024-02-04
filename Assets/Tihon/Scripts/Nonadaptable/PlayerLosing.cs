using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerLosing : MonoBehaviour
{
    public GameObject player;
    public Text lives;
    public Text seeds;
    public GameObject gameOver;
    private int livesCounter = 2;
    public int seedCounter = 0;

    private void Update()
    {
        if(transform.gameObject.GetComponent<PlayerWining>().score != seedCounter)
        {
            transform.gameObject.GetComponent<PlayerWining>().score = seedCounter;
        }
        seeds.text = seedCounter.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(livesCounter >= 0)
        {
            lives.text = livesCounter.ToString();
            livesCounter -= 1;
        }
        else
        {
            Destroy(player);
            gameOver.transform.position = new Vector3(367.6667f, 147.6667f, 0   );
            Time.timeScale = 0;
        }
    }
}