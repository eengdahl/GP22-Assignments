using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOne : MonoBehaviour
{
    float speed = 5;
    Vector2 movement;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb2d.velocity = movement * speed;
    }
}
