using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class playerthree : MonoBehaviour
{

    public float speed = 5;
    public Vector2 velocity;
    Rigidbody2D rb2d;
    public Vector2 movement;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement = velocity * speed * Time.deltaTime;

        transform.Translate(movement);

    }
}
