using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player Movement Speed
    public float speed = 5;
    //how high we can jump
    public float jumpPower = 10;

    //Our Rigidbody2D reference
    Rigidbody2D rb2d;
    //Current movement
    Vector2 movement = new Vector2();
    //If we are on the ground
    public bool grounded;
    public bool collisionPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //Find our Rigidbody2D
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get input from player
        float x = Input.GetAxis("Horizontal");

        //Only update x direction
        movement.x = x * speed;

        //If we press jump while grounded, then Jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            //velocity jump
            //rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);

            //impulse jump (same result)
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

}
