using System.Collections.Generic;
using Base;
using UnityEngine;

public class EasterProvider : MonoBehaviour, IEasterProvider
{
    private List<GameObject> _items = new List<GameObject>(); 

    private void OnEnable()
    {
        Register.Add(this);
    }

    public GameObject CreateItem(GameObject item, Vector3 position, Quaternion rotation)
    {
        GameObject newItem = Instantiate(item, position, rotation);

        _items.Add(newItem);

        return newItem;
    }

    public GameObject CreateItem(GameObject item, Vector3 position, Quaternion rotation, Transform parent)
    {
        GameObject newItem = Instantiate(item, position, rotation, parent);

        _items.Add(newItem);

        return newItem;
    }

    public void DestroyItem()
    {
        foreach (var item in _items.ToArray()) 
        {
            Destroy(item);
            _items.Remove(item);
        }
    }

    private void OnApplicationQuit()
    {
        Register.Remove(this);
    }
}