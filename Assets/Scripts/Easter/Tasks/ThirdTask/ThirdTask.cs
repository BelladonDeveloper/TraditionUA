using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ThirdTask : MonoBehaviour
{
    [SerializeField] private GameObject _carrot;

    private const float _POSITION_Y = 1.0f;
    private const float _QUATERNION_ROTATION = 15.0f;
    private const float _TIME_TO_CARROT_GAME = 1.0f;

    private float _randomX;
    private float _randomZ;

    private IEnumerator Start()
    {


        yield return new WaitForSeconds(1f);
        PassingAndTakingTasks.SingleTon.TakeThirdTask();    
    }

    public void OnThirdTask()
    {
        for (int i = 0; i < 10; i++)
        {
            CarrotSpawner();
        }

        StartCoroutine(MoreCarrots());

    }

    private IEnumerator MoreCarrots()
    {
        yield return new WaitForSeconds(5f);

        int i = 0;

        while (i < 10)
        {
            CarrotSpawner();

            yield return new WaitForSeconds(_TIME_TO_CARROT_GAME);
        }
    }

    public void CarrotSpawner()
    {
        _randomX = Random.Range(-10.0f, 2.0f);
        _randomZ = Random.Range(-8.0f, 10.0f);

        Quaternion rototationX = Quaternion.Euler(_QUATERNION_ROTATION, 0, 0);

        Vector3 randomPositions = new Vector3(_randomX, _POSITION_Y, _randomZ);
        Instantiate(_carrot, randomPositions, rototationX);
    }

    private void OnEnable() => PassingAndTakingTasks.OnTakenThirdTask += OnThirdTask;

    private void OnDisable() => PassingAndTakingTasks.OnTakenThirdTask -= OnThirdTask;
}
