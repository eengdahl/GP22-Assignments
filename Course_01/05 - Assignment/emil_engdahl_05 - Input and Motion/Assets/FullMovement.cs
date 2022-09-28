using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMovement : ProcessingLite.GP21
{
    public float speed = 5;
    public float maxSpeed = 6;
    public float diameter = 2f;
    Vector2 input;
    public Vector2 direction;
    public Vector2 velocity;
    public Vector2 acceleration;
    public Vector2 circlePosition1;
    public Vector2 circlePosition2;
    void Start()
    {
        circlePosition1.x = Width / 2;
        circlePosition1.y = Height / 2;
        circlePosition2.y = Height / 2;
        circlePosition2.x = Width / 2;
    }


    void Update()
    {
        Background(255, 255, 255);
        StrokeWeight(5);
        Fill(255, 0, 0);


        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction = input.normalized;
        velocity = direction * speed;
        circlePosition1 += velocity * Time.deltaTime;

        Circle(circlePosition1.x, circlePosition1.y, diameter);

        acceleration += input.normalized * Time.deltaTime * 10;

        if (input.sqrMagnitude == 0)
        {
            acceleration *= 1 - Time.deltaTime * 3;
        }

        if (acceleration.magnitude >20)
        {
            acceleration.x *= 0.99f;
            acceleration.y *= 0.99f;
        }

        circlePosition2 += acceleration * Time.deltaTime;
        Circle(circlePosition2.x, circlePosition2.y, diameter);

    }
}

