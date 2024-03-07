using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTimer : MonoBehaviour
{
    [SerializeField] private GameObject _car;
    [SerializeField] private GameObject _woll;

    public float targetPositionZ = 10f; 

    public float countdownTime; 
    private bool timerActive = false;

    private void Update()
    {
        if (timerActive)
        {
            countdownTime -= Time.deltaTime; 

            if (countdownTime <= 0f)
            {
                TimerEnded(); 
                timerActive = false; 
            }
        }
    }

    
    private void TimerEnded()
    {
        transform.DOMoveZ(targetPositionZ, 4).SetEase(Ease.Linear).OnComplete(HideWoll);
    }

    private void HideWoll()
    {
        _woll.gameObject.SetActive(false);  
    }

    
    public void StartTimer()
    {
        timerActive = true; 
    }
}
