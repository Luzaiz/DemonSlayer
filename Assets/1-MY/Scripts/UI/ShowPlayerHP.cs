using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerHP : MonoBehaviour
{
    public Player player;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MY_Player").GetComponent<Player>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = player.PlayerHP.ToString();
    }
}
