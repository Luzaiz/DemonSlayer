using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int PlayerHP;
    public int killnum = 0;
    //public GameObject winObj;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDeath();
    }

    void PlayerDeath()
    {
        if (PlayerHP <= 0)
        {
            Debug.Log("游戏失败");
            //this.GetComponent<MoveController>().enabled = false;
            SceneManager.LoadScene("Death");
            //winObj.SendMessage("GameOver");
        }
    }
}
