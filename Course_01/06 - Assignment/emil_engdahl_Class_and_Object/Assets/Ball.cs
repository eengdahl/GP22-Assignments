using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Ball : ProcessingLite.GP21
{
    //Class variables
    public Vector2 position;
    public Vector2 velocity;
    public float size;
    int r;
    int g;
    int b;

    public float ballPositionX;
    public float ballPositionY;
   


    public Ball(float x, float y, float s)
    {
        position = new Vector2(x, y);

        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;

        r = (Random.Range(0, 255));
        g = (Random.Range(0, 255));
        b = (Random.Range(0, 255));
        Fill(r, g, b);
        Stroke(r, g, b);

  
        size = s;
    }

    public void Draw()
    {
        Circle(position.x, position.y, size);
    }

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
