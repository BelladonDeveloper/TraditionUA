using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatTrigger : MonoBehaviour
{
    [SerializeField] private bool _canTriggerCat = false;
    private bool playerInside;
    private float timer;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            timer = 0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            timer = 0f;
        }
    }

    void Update()
    {
        if (_canTriggerCat == true)
        {
            if (playerInside)
            {
                timer += Time.deltaTime;
                if (timer >= 2f)
                {
                    // Вызываем ваш метод здесь
                    Jump();
                    // Сбрасываем таймер и флаг
                    timer = 0f;
                    playerInside = false;
                }
            }
        }
    }

    void Jump()
    {
        Debug.Log("Jump");
    }

    public void StartHide()
    {
        Debug.Log(781273981237);
        _canTriggerCat = true;
    }
}
