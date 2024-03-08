using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTimer : MonoBehaviour
{
    [SerializeField] private CameraFollow _camFollow;

    [SerializeField] private Transform destination;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject _car;
    [SerializeField] private GameObject _woll;

    public float targetPositionZ = 10f; 

    public float countdownTime; 
    private bool timerActive = false;
    private bool isFirstTime = false;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (isFirstTime == false)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _camFollow.Fade();
                Player = collision.gameObject;
                StartCoroutine(WaitForFade());
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

    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(2f);
        _car.transform.position = destination.position;
        _car.transform.rotation = destination.rotation;
        Player.transform.position = new Vector3(destination.position.x, destination.position.y, destination.position.z + 4);
        _camFollow.Light();
        isFirstTime = true;
        yield return new WaitForSeconds(0.5f);
        transform.DOMoveX(-70, 2).SetEase(Ease.Linear);
    }
}
