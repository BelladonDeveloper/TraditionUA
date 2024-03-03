using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BushGenerator : MonoBehaviour
{
    public List<BushScript> BushesList;
    [SerializeField] private Witch witch;

    private void Awake() 
    {
        BushesList = new List<BushScript>();
    }

    private void Start() 
    {
        foreach (BushScript bush in FindObjectsOfType<BushScript>())
        {
            BushesList.Add(bush);
        }
        
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        yield return new WaitForSeconds(0.01f);
        if (witch.TotalBerries > BushesList.Count)
        {
            Debug.LogWarning("Error.");
            yield break;
        }

        for (int i = 0; i < witch.TotalBerries; i++)
        {
            int randomIndex = Random.Range(0, BushesList.Count);
            BushesList[randomIndex].AddBerry();
            BushesList.Remove(BushesList[randomIndex]);
        }
    }
}
