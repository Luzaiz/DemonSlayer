using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.Object;

public class WinGame : MonoBehaviour
{
    public GameObject winSequence;
    public Image fader;
    public AudioClip winClip;

    IEnumerator GameOver()
    {
        AudioSource.PlayClipAtPoint(winClip,transform.position);
        Instantiate(winSequence, GameObject.Find("Canvas").transform);
        yield return new WaitForSeconds(5.0f);
        Instantiate(fader, GameObject.Find("Canvas").transform);
    }
}
