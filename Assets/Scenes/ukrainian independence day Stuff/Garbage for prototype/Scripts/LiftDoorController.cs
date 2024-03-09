using DG.Tweening;
using UnityEngine;

public class LiftDoorController : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public float openingDistance = 2f; 
    public float animationDuration = 1f; 

    private Vector3 originalLeftPos;
    private Vector3 originalRightPos;
    private bool doorsOpened = false;

    void Start()
    {
        originalLeftPos = leftDoor.position;
        originalRightPos = rightDoor.position;
    }

    public void OpenDoors()
    {
        Vector3 leftOffset = Quaternion.Euler(0, -270, -45) * Vector3.forward * openingDistance;
        Vector3 rightOffset = Quaternion.Euler(0, 270, 45) * Vector3.forward * openingDistance;

        Vector3 leftTargetPos = originalLeftPos + leftOffset;
        Vector3 rightTargetPos = originalRightPos + rightOffset;

        leftDoor.DOMove(leftTargetPos, animationDuration);
        rightDoor.DOMove(rightTargetPos, animationDuration);

        doorsOpened = true;
    }

    public void CloseDoors()
    {
        leftDoor.DOMove(originalLeftPos, animationDuration);
        rightDoor.DOMove(originalRightPos, animationDuration);

        doorsOpened = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CloseDoors();
        }
    }
}
