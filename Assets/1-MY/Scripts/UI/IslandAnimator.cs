using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandAnimator : MonoBehaviour
{
    public float xStartPosition = -1.0f;
    public float xEndPosition = 0.5f;
    public float speed = 1.0f;
    private float startTime;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos =
            new Vector3(Mathf.Lerp(xStartPosition, xEndPosition, (Time.deltaTime - startTime) * speed),
                transform.position.y, transform.position.z);
        transform.position = pos;
    }
}
