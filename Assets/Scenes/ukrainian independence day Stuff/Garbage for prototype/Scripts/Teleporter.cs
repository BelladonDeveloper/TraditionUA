using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private CameraFollow _camFollow;
    [SerializeField] private CarTimer _carTimer;
    [SerializeField] private Transform destination;

    private GameObject player;

    public float teleportDelay = 3f; 
    public float FadeDelay = 1f; 

    private bool playerInRange = false;
    private float timer = 0f;

    private void Update()
    {
        if (playerInRange)
        {
            timer += Time.deltaTime;
            if(timer > FadeDelay) 
            {

            }

            if (timer >= teleportDelay)
            {
                Teleport(player);
            }
        }
        else
        {
            timer = 0f; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            _camFollow.Fade();
            StartCoroutine(WaitForFade());
            _carTimer.StartTimer();
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Teleport(GameObject objectToTeleport)
    {
        //objectToTeleport.transform.position = destination.position;
        Vector3 posToTp = destination.position;
        player.transform.DOMove(posToTp, 0.0001f).SetEase(Ease.OutQuad);
        _camFollow.Light();
    }

    private void SwichCam()
    {
        _camFollow.SetFloatToOut();
    }

    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(1f);
        SwichCam();
    }
}
