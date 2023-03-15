using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPUI : MonoBehaviour
{
    public Slider EnemyHPUIShow;

    public Enemy Enemy;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().worldCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHPUIShow.value = (float) Enemy.EnemyInfo.EnemyHP / 100;
    }
}
