using System;
using UnityEngine;

public class PickingThingsUp : MonoBehaviour
{
    public static event Action OnPickedUpByPlayer;
    public static event Action OnPickedUpByBunny;
    public static event Action<GameObject> OnRemovedCarrot;

    public string CurrentTag = "Currot";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == CurrentTag)
        {
            OnRemovedCarrot?.Invoke(other.gameObject);

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
