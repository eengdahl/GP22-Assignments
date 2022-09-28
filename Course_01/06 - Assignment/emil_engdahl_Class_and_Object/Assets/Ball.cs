using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Ball : ProcessingLite.GP21
{
    //Class variables
    Vector2 position;   //Ball position
    Vector2 velocity;   // Ball direction
    float size;
    int r;
    int g;
    int b;



    //Ball Constructor, called when we type new Ball(x, y);
    public Ball(float x, float y)
    {
        //Set our position when we create the code.
        position = new Vector2(x, y);

        //Create the velocity vector and give it a random direction.
        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;
        r = (Random.Range(0, 255));
        g = (Random.Range(0, 255));
        b = (Random.Range(0, 255));
        Fill(r, g, b);
        Stroke(r, g, b);
        
        size = Random.Range(0.3f, 3);
    }

    //Draw out ball
    public void Draw()
    {
        Circle(position.x, position.y, size);
        //Stroke(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
    }

    //Update our ball
    public void UpdatePos()
    {
        position += velocity * Time.deltaTime;

        if (position.x >= 17.79328 || position.x <= 0)
        {
            velocity.x *= -1;
        }

        if (position.y >= 10 || position.y <= 0)
        {
            velocity.y *= -1;
        }
    }

   

}
