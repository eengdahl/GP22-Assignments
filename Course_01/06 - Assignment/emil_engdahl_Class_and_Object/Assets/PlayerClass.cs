using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

class PlayerClass : ProcessingLite.GP21
{
    Vector2 position;
    Vector2 velocity;
    public Vector2 input;
    public PlayerClass(float x, float y)
    {
        position = new Vector2(x, y);

    }

    public void Draw()
    {
        Circle(position.x, position.y, 0.5f);
    }

    public void UpdatePos()
    {
      //  Stroke(100,100,100);
        position += velocity * Time.deltaTime;
      //  Stroke(0, 0, 0);

    }

   

 
}
