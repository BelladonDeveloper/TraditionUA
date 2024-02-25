using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnTarget;
    public int pauseTime;
    private bool isSpawning = true;
    void Update()
    {
        if (isSpawning)
        {
            isSpawning = false;
            StartCoroutine("Spawning");
        }
    }
    public IEnumerator Spawning()
    {
        for(int i = 0; i<5; i++)
        {
            int randomX = Random.Range(-6, 14);
            int randomZ = Random.Range(127, 142);
            Instantiate(spawnTarget, new Vector3(randomX, 148.58f, randomZ), Quaternion.identity);
        }
        yield return new WaitForSeconds(pauseTime);
        isSpawning = true;
    }
}
