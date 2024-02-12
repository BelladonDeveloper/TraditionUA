using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ThirdTask : MonoBehaviour
{
    public static int AddNewCarrotsCount;

    [SerializeField] private GameObject _carrot;

    [SerializeField] private List<Transform> _positions = new List<Transform>();

    [SerializeField] private NavMeshAgent bunnyAgent;

    private List<GameObject> _carrots = new List<GameObject>();

    private List<int> usedIndices = new List<int>();

    private const int Default = 10;

    private const float QuaternionRotation = 15.0f;

    public void OnThirdTask()
    {
        AddNewCarrotsCount = Default;
        StartCoroutine(CarrotSpawner());
    }

    public void RemoveCarrotFromList(GameObject carrot)
    {
        if (_carrots.Contains(carrot))
            _carrots.Remove(carrot);
    }


    private void Update()
    {
        GameObject nearestCarrot = FindNearestCarrot();

        if (nearestCarrot != null)
        {
            bunnyAgent.transform.localRotation.SetLookRotation(nearestCarrot.transform.position);
            bunnyAgent.SetDestination(nearestCarrot.transform.position);
        }
    }

    private IEnumerator CarrotSpawner()
    {
        Quaternion rototationX = Quaternion.Euler(QuaternionRotation, 0, 0);

        for (int i = 0; i < AddNewCarrotsCount; i++)
        {
            yield return new WaitForSeconds(1f);

            int randomIndex = GetRandomIndex();

            usedIndices.Add(randomIndex);

            GameObject newCarrot = Instantiate(_carrot, _positions[randomIndex].position, rototationX);

            _carrots.Add(newCarrot);
        }
    }

    private int GetRandomIndex()
    {
        int randomIndex = Random.Range(0, _positions.Count);

        while (usedIndices.Contains(randomIndex))
        {
            randomIndex = Random.Range(0, _positions.Count);
        }

        return randomIndex;
    }

    private GameObject FindNearestCarrot()
    {

        GameObject nearest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject carrot in _carrots)
        {
            float dist = Vector3.Distance(bunnyAgent.transform.position, carrot.transform.position);

            if (dist < minDist)
            {
                nearest = carrot;
                minDist = dist;
            }
        }

        return nearest;

    }

    private void OnEnable()
    {
        PassingAndTakingTasks.OnTakenThirdTask += OnThirdTask;
        PickingThingsUp.OnRemovedCarrot += RemoveCarrotFromList;
    }

    private void OnDisable()
    {
        PassingAndTakingTasks.OnTakenThirdTask -= OnThirdTask;
        PickingThingsUp.OnRemovedCarrot -= RemoveCarrotFromList;
    }
}