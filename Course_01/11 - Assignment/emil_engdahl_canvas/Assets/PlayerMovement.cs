using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float jumpPower = 10;
    public int score;
    public UIHandeler playerUIHandeler;
    Rigidbody2D rb2d;
    Vector2 movement = new Vector2();
    public bool grounded;
    public bool collisionPlayer;


    void Start()
    {
        //Find our Rigidbody2D
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        float x = Input.GetAxis("Horizontal");

        //Only update x direction
        movement.x = x * speed;


        if (Input.GetButtonDown("Jump") && grounded)
        {

            rb2d.velocity = new Vector2(rb2d.velocity.x, 0); //Reset our y speed before the jump
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        //Use our old y velocity, if movement.y = 0, then we mess with gravity
        movement.y = rb2d.velocity.y;

        //Update our movement
        rb2d.velocity = movement;


    }

    public void IsGrounded(bool input)
    {

        if (input)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            score++;
            playerUIHandeler.DisplayScore(score);
            Destroy(other.gameObject);
        }


    }

}
