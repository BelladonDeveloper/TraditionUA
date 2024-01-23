using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfToys { get; private set; }

    public UnityEvent<PlayerInventory> OnToysCollected;

    public void ToysCollected()
    {
        NumberOfToys++;
        OnToysCollected.Invoke(this);
    }
}
