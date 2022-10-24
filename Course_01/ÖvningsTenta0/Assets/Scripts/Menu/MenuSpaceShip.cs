using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class MenuSpaceShip : MonoBehaviour
{
    public GameObject spaceShip;
    public Vector2 spaceMovement;
    float speed = 0.8f;
    public float timer = 0;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        spaceMovement = new Vector2(0, 0);

        if (timer < 2)
        {
            spaceMovement.y = -speed * Time.deltaTime;
        }

        if (timer >2)
        {
            spaceMovement.y = +speed * Time.deltaTime;
        }
        if (timer > 4)
        {
            timer = 0;
        }

        transform.Translate(spaceMovement);
    }
}
