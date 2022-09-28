using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;



public class PlayerMovement : ProcessingLite.GP21
{
    public Vector2 playerPosition;
    public Vector2 playerPosition2;
    public Vector2 acceleration2;
    public Vector2 velocity;

    float diameter = 2;
    public float maxSpeed = 10f;
    public float speed = 5f;
    public float magnitude2;
    public float magnitude;

    void Start()
    {
        playerPosition.x = Width / 2;
        playerPosition.y = Height / 2;
        playerPosition2.y = Height / 2;
        playerPosition2.x = Width / 2;
    }

    void Update()
    {
        Background(255, 255, 255);
        StrokeWeight(5);
        Fill(255, 0, 0);

        //add our new input to our x position
        playerPosition.x += Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        playerPosition.y += Input.GetAxisRaw("Vertical") * Time.deltaTime;
        velocity.x += Input.GetAxisRaw("Horizontal");
        velocity.y += Input.GetAxisRaw("Vertical");



        magnitude = velocity.magnitude;
        if (magnitude > 10)
        {
            velocity.x *= 0.5f;
            velocity.y *= 0.5f;
        }


        playerPosition += velocity *speed* Time.deltaTime;

        //Draw Circle 1
        Circle(playerPosition.x, playerPosition.y, diameter);


        //Set input to accelration for Circle2
        acceleration2.x += velocity.x * Time.deltaTime;
        acceleration2.y += velocity.y * Time.deltaTime;

        if (Input.GetAxis("Horizontal") == 0 || velocity.x != 0)
        {
            velocity.x = velocity.x * 0.9f * Time.deltaTime;
        }

        if (Input.GetAxis("Vertical") == 0 || velocity.y != 0)
        {
            velocity.y = velocity.y * 0.9f * Time.deltaTime;
        }
        // acceleration2.x += Input.GetAxis("Horizontal")/*/ * speed /*/ * Time.deltaTime;
        //acceleration2.y += Input.GetAxis("Vertical")/*/ * speed /*/* Time.deltaTime;



        //Calculate Circle1s vector+ the added speed of new acceleration
        playerPosition2 = new Vector2(playerPosition.x * acceleration2.x, playerPosition.y * acceleration2.y);
      

        // Draw Circle 2 
        Circle(playerPosition2.x, playerPosition2.y, diameter);



    }

}



// FUNGERANDE UTAN VELOCITY

//public class PlayerMovement : ProcessingLite.GP21
//{
//    public Vector2 playerPosition;
//    public Vector2 playerPosition2;
//    public Vector2 acceleration2;

//    float diameter = 2;
//    public float maxSpeed = 10f;
//    public float speed = 5f;
//    public float magnitude2;

//    void Start()
//    {
//        playerPosition.x = Width / 2;
//        playerPosition.y = Height / 2;
//        playerPosition2.y = Height / 2;
//        playerPosition2.x = Width / 2;
//    }

//    void Update()
//    {
//        Background(255, 255, 255);
//        StrokeWeight(5);
//        Fill(255, 0, 0);

//        //add our new input to our x position
//        playerPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
//        playerPosition.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;

//        //Draw Circle 1
//        Circle(playerPosition.x, playerPosition.y, diameter);


//        //Set input to accelration for Circle2
//        acceleration2.x += Input.GetAxis("Horizontal")/*/ * speed /*/ * Time.deltaTime;
//        acceleration2.y += Input.GetAxis("Vertical")/*/ * speed /*/* Time.deltaTime;



//        //Calculate Circle1s vector+ the added speed of new acceleration
//        playerPosition2 = new Vector2(playerPosition.x * acceleration2.x, playerPosition.y * acceleration2.y);

//        // Draw Circle 2 
//        Circle(playerPosition2.x, playerPosition2.y, diameter);

//        //Insert maxspeed via magnitude
//        magnitude2 = acceleration2.magnitude;

//        if (magnitude2 > 2)
//        {
//            acceleration2.x *= 0.5f;
//            acceleration2.y *= 0.5f;
//        }



//    }

//}
