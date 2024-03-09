using System.Collections;
using UnityEngine;

public class TeleporterForCVK : MonoBehaviour
{
    [SerializeField] private CameraFollow _camFollow;
    [SerializeField] private GameObject destination;
    private GameObject Player;


    public float FadeDelay = 1f;

    private bool isFirsTime = true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(isFirsTime == true)
            {
                isFirsTime =false;
            }
            else
            {
                Player = other.gameObject;
                _camFollow.Fade();
                StartCoroutine(WaitForFade());
            }
        }
    }

    private void Teleport(GameObject objectToTeleport)
    {
        _camFollow.Light();
        objectToTeleport.transform.position = destination.transform.position;
    }

    private void SwichCam()
    {
        _camFollow.SetFloatToOut();
    }

    IEnumerator WaitForFade()
    {
        yield return new WaitForSeconds(1f);
        SwichCam();
        Teleport(Player);
    }
}
