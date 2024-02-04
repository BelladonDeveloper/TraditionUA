using System;
using UnityEngine;

public class EggsPickUpper : MonoBehaviour
{
    public event Action<GameObject> OnPickedUp;
    private bool _isDone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_isDone == false)
            {
                OnPickedUp?.Invoke(this.gameObject);
            }

            _isDone = true;
        }
    }
}
