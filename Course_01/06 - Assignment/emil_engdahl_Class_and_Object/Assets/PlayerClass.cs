using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

class PlayerClass : ProcessingLite.GP21
{
    public Vector2 position;
    Vector2 velocity;
    Vector2 input;
    public float direction;
    public float speed = 5;
    Output Output;

    public PlayerClass(float x, float y)
    {
        position = new Vector2(Width / 2, Height / 2);
    }

    public void Draw()
    {
        Circle(position.x, position.y, 0.5f);
    }

    public void UpdatePos()
    {

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        velocity = input * speed;
        if (position.x > Width - 0.5f || position.x < 0.5f || position.y > Height - 0.5f || position.y < 0.5f)
        {
            velocity *= 0.1f;
   
        }
        position += velocity * Time.deltaTime;


        if (position.x < -1 || position.x > Width + 1 || position.y < -1 || position.y > Height + 1)
        {
      
             Output.Endscreen();
        }


    }

}
