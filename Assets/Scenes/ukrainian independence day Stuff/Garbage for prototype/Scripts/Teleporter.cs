using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private CameraFollow _camFollow;
    [SerializeField] private CarTimer _carTimer;
    public Transform destination; 
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
                Teleport(GameObject.FindGameObjectWithTag("Player"));
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
        _camFollow.Light();
        objectToTeleport.transform.position = destination.position; 
    }

    private void SwichCam()
    {
        Camera.main.orthographic = false;
        _camFollow.SetFloatToOut();
    }

    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(1f);
        SwichCam();
    }
}
