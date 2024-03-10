using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CVKTeleporter : MonoBehaviour
{
    [SerializeField] private CameraFollow _camFollow;
    
    private GameObject Player;

    [SerializeField] private Transform destination;
    public float teleportDelay = 3f;
    public float FadeDelay = 1f;

    private bool isFirsTime = true;


    private void OnTriggerEnter(Collider other)
    {
        if(isFirsTime == true)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _camFollow.Fade();
                Player = other.gameObject;
                StartCoroutine(WaitForFade());
                isFirsTime = false;
            }
        }
    }

    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(2f);
        Player.transform.position = new Vector3(destination.position.x, destination.position.y, destination.position.z);
        SwichCam();
        _camFollow.Light();
    }

    private void SwichCam()
    {
        _camFollow.SetFloatToIn();
    }
}
