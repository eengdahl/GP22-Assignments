using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAvNyaInputs : ProcessingLite.GP21
{
    public float speed = 5;
    public float speed2 = 2;
    public float diameter = 2f;

    public Vector2 acceleration;
    public Vector2 input;
    public Vector2 input2;
    public Vector2 velocity;
    public Vector2 velocity2;
    public Vector2 direction;
    public Vector2 direction2;
    public Vector2 circlePosition;
    public Vector2 circlePosition2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Background(255, 255, 255);
        StrokeWeight(5);
        Fill(255, 0, 0);


        //Circel
        input2 = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction2 = input2.normalized;

        velocity2 += direction2 * Time.deltaTime;

        circlePosition2 += velocity2 * speed2 * Time.deltaTime;

        Circle(circlePosition2.x, circlePosition2.y, diameter);




        //Circel2
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction = input.normalized;
        acceleration.x += direction.x;
        acceleration.y += direction.y;


        if (direction2.x ==0 || acceleration.x >10 || acceleration.x >-10)
        {
            acceleration.x *= 0.99f;
            if (acceleration.x < 0.1)
            {
                acceleration.x = 0;
            }
        }

        if (direction.y ==0 || acceleration.y > 10 || acceleration.y > -10)
        {
            acceleration.y *= 0.99f;

            if (acceleration.y < 0.1)
            {
                acceleration.y = 0;
            }
        }



        velocity += direction *speed * Time.deltaTime;

        circlePosition = velocity;

        Circle(circlePosition.x *= acceleration.x, circlePosition.y *= acceleration.y, diameter);




        // Råkade göra cirkel2
        //                  // input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //acceleration.x += input.x * Time.deltaTime;
        // acceleration.y += input.y * Time.deltaTime;
        // // direction = input.normalized;
        // //  velocity = direction * speed * Time.deltaTime;

        // //  circlePosition += velocity * Time.deltaTime;

        // Circle(circlePosition2.x += acceleration.x, circlePosition2.y += acceleration.y, diameter);




        //if (Input.getk)
        //{

        //}




        // input2 = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));



        //velocity2 = input * speed;
        //velocity2.y =+ accelaration;
        //velocity2.x =+ accelaration;
        ////speed2 = input *= velocity;

        //circlePosition2 += velocity2 * Time.deltaTime;


        //Circle(circlePosition2.x,circlePosition2.y, diameter);


    }
}
