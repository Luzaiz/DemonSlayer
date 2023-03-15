using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public void StartGameButton()
    {
        Debug.Log("开始游戏");
        SceneManager.LoadScene("Forest");
    }

    public void ExicGameButton()
    {
        Debug.Log("退出游戏");
        Application.Quit();
    }
    public void BackToStartButton()
    {
        SceneManager.LoadScene("Start");
    }
}
