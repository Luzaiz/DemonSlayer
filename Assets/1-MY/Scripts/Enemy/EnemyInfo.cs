using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyInfo
{
    public int EnemyHP=100;
    public int EnemyMaxHP=100;
    public int EnemyAttackNumber=10;
    public float EnemySpeed=0;
    public float EnemyAttackSpeed=3;
    public GameObject EnemyPrefab;
}
