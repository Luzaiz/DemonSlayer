using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Diagnostics;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public EnemyInfo EnemyInfo;
    public EnemyLogic EnemyLogic;

    void Start()
    {
        EnemyInfo = new EnemyInfo();
        EnemyLogic = new EnemyLogic();

        EnemyLogic.EnemyMoveTargetPositions = new Transform[8];
        EnemyLogic.navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        EnemyLogic.EnemyObj = this.gameObject;
        EnemyLogic.enemyInfo = EnemyInfo;

        EnemyLogic.enemyState = EnemyState.Idle;
        EnemyInfo.EnemyMaxHP = 100;
        EnemyInfo.EnemyHP = 100;
        EnemyInfo.EnemyAttackNumber = 10;
        EnemyInfo.EnemyAttackSpeed = 3f;

        for (int x = 0; x < 8; x++)
        {
            string TargetName = "pos" + x;
            EnemyLogic.EnemyMoveTargetPositions[x] = GameObject.Find(TargetName).transform;
        }
    }

    private void Update()
    {
        EnemyLogic.EnemyStateControl();

        if (EnemyInfo.EnemyHP <= 0)
        {
            EnemyLogic.enemyState = EnemyState.Death;
        }
        
    }
}
