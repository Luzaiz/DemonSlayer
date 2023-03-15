using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public Enemy enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            enemy.EnemyLogic.enemyState = EnemyState.Attack;
            enemy.EnemyLogic.PlayerObj = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            enemy.EnemyLogic.enemyState = EnemyState.Hunt;
            enemy.EnemyLogic.PlayerObj = other.gameObject;
        }
    }
}
