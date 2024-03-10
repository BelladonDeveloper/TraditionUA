using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;

    public EnemyWay enemyWay;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.SetDestination(Player.position);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyWay.increaseTargetInt();
        }
    }
}
