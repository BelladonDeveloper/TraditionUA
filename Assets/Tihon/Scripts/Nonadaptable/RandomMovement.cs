using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
        StartCoroutine("Movement");
    }
    public IEnumerator Movement()
    {
        Vector3 ftarget = new Vector3(Random.Range(-20, 8), 137, -8.985329f);
        Vector3 starget = new Vector3(Random.Range(-20, 8), 137, -64.4f);
        transform.DOMove(ftarget, 14, false);
        yield return new WaitForSeconds(1);
        transform.DOMove(starget, 14, false);
        yield return new WaitForSeconds(7);
        Destroy(transform.gameObject);
    }
}
