using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FirstTask : MonoBehaviour
{
    [SerializeField] private GameObject _eggPrefab;
    [SerializeField] private List<Sprite> _eggsSpritesPrefabs = new();
    [SerializeField] private CountCollectedEggs _countCollectedEggs;

    public void TakeFirstTask()
    {
        StartCoroutine(TimerForStartingFirstTask(_eggsSpritesPrefabs));
    }

    private IEnumerator TimerForStartingFirstTask(List<Sprite> eggsSprites)
    {
        yield return new WaitForSeconds(1f);
        
        foreach (var egg in eggsSprites)
        {
            float randomX = Random.Range(8, -20);
            float positionY = 1.0f;
            float randomZ = Random.Range(-10, 19);

            Vector3 randomPositions = new Vector3(randomX, positionY, randomZ);

            GameObject newEgg = Instantiate(_eggPrefab, randomPositions,
                Quaternion.Euler(40.0f, 0.0f, 0.0f));
            newEgg.GetComponent<SpriteRenderer>().sprite = egg;
        }

        _countCollectedEggs.FindAllEggs();
    }

    private void OnEnable() => PassingAndTakingTasks.OnTakenFirstTask += TakeFirstTask;
    private void OnDisable() => PassingAndTakingTasks.OnTakenFirstTask -= TakeFirstTask;
}
