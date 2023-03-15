using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float[] TimePoints;
    public Vector3[] EnemyPosition;
    
    public GameObject EnemyPrefab;
    public float GameTime;

    public bool Level1;
    public bool Level2;
    public bool Level3;

    public int num1=2;
    public int num2=5;
    public int num3=10;

    private void Start()
    {
        Level1 = false;
        Level2 = false;
        Level3 = false;

        TimePoints = new float [3];
        TimePoints[0] = 10f;
        TimePoints[1] = 20f;
        TimePoints[2] = 30f;

        EnemyInfo enemyInfo = new EnemyInfo();

        //EnemyPrefab = (GameObject)Resources.Load("spider_brown");

    }

    void EnemyTime()
    {
        if (GameTime < TimePoints[0])
        {
            if (Level1 == false)
            {
                EnemyGenerate(num1);
                Level1 = true;
            }
        }
        if (GameTime > TimePoints[0] && GameTime < TimePoints[1])
        {
            if (Level2 == false)
            {
                EnemyGenerate(num2);
                Level2 = true;
            }
        }
        if (GameTime > TimePoints[1] && GameTime < TimePoints[2])
        {
            if (Level3 == false)
            {
                EnemyGenerate(num3);
                Level3 = true;
            }
        }
    }

    private void Update()
    {
        GameTime += Time.deltaTime;
        EnemyTime();
    }

    void EnemyGenerate(int number)
    {
        for (int i = 0; i < number; i++)
        {
            int temp = Random.Range(0, 4);
            Instantiate(EnemyPrefab, EnemyPosition[temp], this.gameObject.transform.rotation);
        }
        
    }
}
