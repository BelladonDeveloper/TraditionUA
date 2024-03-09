using UnityEngine;
using DG.Tweening;

public class MoveForwardOnTrigger : MonoBehaviour
{
    public float moveDistance = 5f; 

    private bool hasMoved = false; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !hasMoved)
        {
            
            other.transform.DOMove(transform.position + -transform.forward * moveDistance, 1.0f);
            hasMoved = true;
        }
    }
}
