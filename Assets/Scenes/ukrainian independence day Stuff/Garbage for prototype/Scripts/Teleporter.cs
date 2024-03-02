using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private CameraFollow _camFollow;
    public Transform destination; // Пункт назначения, куда будет производиться телепортация
    public float teleportDelay = 3f; // Задержка перед телепортацией
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
            timer = 0f; // Сброс таймера, если игрок вышел из триггера
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _camFollow.Fade();
            StartCoroutine(WaitForFade());
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
        objectToTeleport.transform.position = destination.position; // Устанавливаем позицию объекта телепортирования равной позиции пункта назначения
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
