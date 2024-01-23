using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SecondTask : MonoBehaviour
{
    [SerializeField] private GameObject _eggPrefab;

    private List<float> _positionY = new List<float>();

    public void Start()
    {
        _positionY.Add(15);
        _positionY.Add(13.3f);
        _positionY.Add(11.9f);
        _positionY.Add(10.5f);

        OnSecondTask();
    }

    public void OnSecondTask()
    {
        for (int i = 0; i < 10; i++)
        {
            float randomX = Random.Range(-10, -3);
            float positionZ = 37.6f;
            int randomY = Random.Range(0, 3);

            Vector3 randomPositions = new Vector3(randomX, _positionY[randomY], positionZ);
            GameObject newEgg = Instantiate(_eggPrefab, randomPositions, Quaternion.identity);
            newEgg.GetComponent<SpriteRenderer>().sortingOrder = 1;
            newEgg.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
    }

    private void OnEnable() => PassingAndTakingTasks.OnTakenSecondTask += OnSecondTask;

    private void OnDisable() => PassingAndTakingTasks.OnTakenSecondTask -= OnSecondTask;
}

//15, 13.33, 11.9, 10.5
