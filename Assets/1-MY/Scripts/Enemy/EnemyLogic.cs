using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Idle,
    Move,
    Hunt,
    Attack,
    Death
}

[System.Serializable]
public class EnemyLogic
{
    public EnemyState enemyState;
    public NavMeshAgent navMeshAgent;
    public EnemyInfo enemyInfo;
    public GameObject EnemyObj;
    public GameObject PlayerObj;
    public Transform[] EnemyMoveTargetPositions;
    public Vector3 TargetMovePos;
    public Player player;

    private float attackBuffer;
    private float IdleTime;
    private bool IsMove = false;

    public void EnemyStateControl()
    {
        switch (enemyState)
        {
            case EnemyState.Idle:
                EnemyIdle();
                break;
            case EnemyState.Move:
                EnemyMove();
                break;
            case EnemyState.Hunt:
                EnemyHunt();
                break;
            case EnemyState.Attack:
                EnemyAttack();
                break;
            case EnemyState.Death:
                EnemyDeath();
                break;
        }
    }
    
    public void EnemyIdle()
    {
        IdleTime -= Time.deltaTime;
        
        if (IdleTime < 0f)
        {
            enemyState = EnemyState.Move;
            IsMove = false;
        }
    }
    public void EnemyMove()
    {
        if (IsMove == false)
        {
            int posIndex = Random.Range(0, 8);
            TargetMovePos = EnemyMoveTargetPositions[posIndex].position;
            IsMove = true;
        }

        if (IsMove == true)
        {
            navMeshAgent.SetDestination(TargetMovePos);
            if (Vector3.Distance(EnemyObj.transform.position,TargetMovePos) <= 2f)
            {
                enemyState = EnemyState.Idle;
                IdleTime = Random.Range(0f, 7f);
            }
        }
    }
    public void EnemyHunt()
    {
        navMeshAgent.SetDestination(PlayerObj.transform.position);
        
    }
    public void EnemyAttack()
    {
        attackBuffer -= Time.deltaTime;//攻击缓冲
        
        navMeshAgent.SetDestination(PlayerObj.transform.position);
        if (attackBuffer<=0)
        {
            PlayerObj.transform.parent.gameObject.GetComponent<Player>().PlayerHP -= enemyInfo.EnemyAttackNumber;
            attackBuffer = enemyInfo.EnemyAttackSpeed;
        }
    }
    public void EnemyDeath()
    {
        //GameObject.FindObjectOfType<AudioSource>().Play();
        GameObject.Destroy(EnemyObj);
        player = GameObject.Find("MY_Player").GetComponent<Player>();
        player.killnum++;
    }
}
