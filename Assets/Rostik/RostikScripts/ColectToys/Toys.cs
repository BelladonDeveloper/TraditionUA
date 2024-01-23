
using UnityEngine;

public class Toys : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.ToysCollected();
            gameObject.SetActive(false);
        }
    }
}
