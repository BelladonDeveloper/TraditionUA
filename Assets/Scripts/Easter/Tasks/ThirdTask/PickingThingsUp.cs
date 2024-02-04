using System;
using UnityEngine;

public class PickingThingsUp : MonoBehaviour
{
    public static event Action OnPickedUpByPlayer;
    public static event Action OnPickedUpByBunny;

    public string CurrentTag = "Currot";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == CurrentTag)
        {
            Destroy(other.gameObject);

            if (this.gameObject.tag == "Player")
            {
                OnPickedUpByPlayer?.Invoke();
            }

            else if (this.gameObject.tag == "Bunny")
            {
                OnPickedUpByBunny?.Invoke();
            }
        }
    }
}
