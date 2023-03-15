using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //public static AudioManager Instance;
    [Header("BGM音乐源")]
    public AudioSource audioSource;
 
    [Header("BGM")]
    public AudioClip Forest;
    public AudioClip Death;
    public AudioClip Win;
    /**
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    
    private void Awake() {
        if (Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    **/

    private void Start() { 
        audioSource = GetComponent<AudioSource>();
        Scene scene = SceneManager.GetActiveScene();
        PlayBGM(scene.name);
        audioSource.Play();
    }
    public void PlayBGM(string sceneName)
    { 
        //Debug.Log("进入播放音乐方法  + " + sceneName);
        switch(sceneName) { 
            case    "Forest":
                audioSource.clip = Forest;
                audioSource.Play();
                break;
            case    "Death":
                audioSource.clip = Death;
                audioSource.Play();
                break;
            case    "Win":
                audioSource.clip = Win;
                audioSource.Play();
                break;
            default:
                break;
         }
     }
}