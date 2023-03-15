using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] itemPos;
    public GameObject[] itemPrefabs;
    public Transform[] spawnPos;
    public GameObject[] enemyPrefabs;
    public Text enemyCountText;
    public Text enemyListCountText;
    private float timeVal = 5f;
    private float timer;
    private float timeValItem = 10f;
    private int enemyCount = 0;
    
    public List<GameObject> enemyList = new List<GameObject>();

    void Start()
    {

    }
    
    void Update()
    {
        timer += Time.deltaTime;
        InstEnemys();
    }

    private void InstEnemys()
    {
        if (timer >= timeVal)
        {
            int randomPos = Random.Range(0, spawnPos.Length);
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomEnemy], spawnPos[randomPos].position, Quaternion.identity);
            enemyList.Add(gameObject);
            enemyCount++;
            timer = 0;
        }
        
    }
}