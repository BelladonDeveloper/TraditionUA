using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.AI;

public class EnemyWay : MonoBehaviour
{

    public Transform[] patrolPoints;
    public int targetPoint;
    public NavMeshAgent navigation;


    void Start()
    {

        targetPoint = 0;
        navigation.SetDestination(patrolPoints[targetPoint].position);
    }

    void Update()
    {
        float disToTarget = Vector3.Distance(patrolPoints[targetPoint].position, transform.position);
        Debug.Log(disToTarget);
        if (2f >= disToTarget)
        {
           
            increaseTargetInt();
        }


    }
     public void increaseTargetInt()
    {
       
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
        navigation.SetDestination(patrolPoints[targetPoint].position);
    }
}

