using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    public float turningSpeed = 90;
    private Rigidbody2D rb2d;
    private float angel;
    private float speed = 5;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

        angel -= Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;

        rb2d.MoveRotation(angel);

        float y = Input.GetAxis("Vertical");

        rb2d.velocity = rb2d.transform.up * y * speed;


    }
}
