using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.Object;

public class Fader : MonoBehaviour
{
    // Start is called before the first frame update
    public Image loadGUI;
    void Start()
    {
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        //Rect currentRes = new Rect(-Screen.width * 0.5f, -Screen.height * 0.5f, Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadAnim()
    {
        Instantiate(loadGUI, GameObject.Find("Canvas").transform);
    }
}
