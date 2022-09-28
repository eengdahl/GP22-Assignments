using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement03 : ProcessingLite.GP21
{
    public int speed = 5;
    public int diameter = 2;
    Vector2 input;
    public Vector2 acceleration;
    Vector2 velocity;
    public Vector2 velocity2;
    public Vector2 cirkelPosition;
    public Vector2 cirkelPosition2;
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

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        acceleration = input;

        if (input.x == 1 || input.x == -1)
        {
            acceleration.x = 5;
        }
        if (input.y == 1 || input.y == -1)
        {
            acceleration.y = 5;
        }
   

        velocity = input.normalized * speed;
        cirkelPosition += velocity * Time.deltaTime;
        Circle(cirkelPosition.x, cirkelPosition.y, diameter);

        velocity2 = input.normalized * speed;

        cirkelPosition2 += velocity2 * Time.deltaTime * acceleration;



        Circle(cirkelPosition2.x, cirkelPosition2.y, diameter);

    }
}
