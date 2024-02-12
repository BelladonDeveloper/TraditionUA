using System;
using UnityEngine;

public class PickingThingsUp : MonoBehaviour
{
    public static event Action OnPickedUpByPlayer;
    public static event Action OnPickedUpByBunny;
    public static event Action OnFinishedTradition;

    public static event Action<GameObject> OnRemovedCarrot;

    public string CarrotTag = "Currot";
    public string GoldCarrot = "GoldCarrot";

    private bool _isDone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == CarrotTag)
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

        if (other.gameObject.tag == GoldCarrot && !_isDone)
        {
            Debug.Log("Pick");

            OnFinishedTradition?.Invoke();

            _isDone = true;
        }
    }
}
