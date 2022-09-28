using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

class PlayerClass : ProcessingLite.GP21
{
    Vector2 position;
    Vector2 velocity;
    Vector2 input;
    public float direction;
    public float speed = 5;
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

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        velocity = input * speed;
        position += velocity * Time.deltaTime;
    }




}
