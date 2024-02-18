using UnityEngine;

public interface IEasterProvider
{
    GameObject CreateItem(GameObject item, Vector3 position, Quaternion rotation);
    void DestroyItem();
}
