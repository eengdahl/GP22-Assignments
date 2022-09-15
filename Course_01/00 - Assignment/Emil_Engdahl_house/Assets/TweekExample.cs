using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweekExample : MonoBehaviour
{
    public float x = 2;
    public float y = 3;
    public float size = 1;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x, y);
        transform.localScale = Vector3.one * size;
    }
}
    