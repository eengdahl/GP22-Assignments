using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : ProcessingLite.GP21
{
    public float speed = 9;
    PlayerClass player;
    public Vector2 position;
    public Vector2 input;
    Vector2 direction;
    Vector2 velocity;
    CollisionCalc playerCalc1;

    void Start()
    {
        StrokeWeight(5);


    }


    void Update()
    {
        Stroke(100, 100, 100);


        Background(0);
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction = input.normalized;
        velocity = direction * speed;
        position += velocity * Time.deltaTime;
        player = new PlayerClass(position.x, position.y);


        player.UpdatePos();
        player.Draw();

        playerCalc1 = new CollisionCalc();
        playerCalc1.PlayerCalc(position.x, position.y, 0.5f);   

       // player.CircleCollision(position.x, position.y, 0.5f, balls, float,float);

    }

    
}
















//public class PlayerMovement : ProcessingLite.GP21
//{
//    PlayerClass Player = new PlayerClass();
//    public float speed = 9;
//    public float diameter = 1;
//    Vector2 playerPosition;
//    Vector2 input;
//    Vector2 direction;
//    Vector2 velocity;

//    void Start()
//    {
//        playerPosition.x = Width / 2;
//        playerPosition.y = Height / 2;
//    }


//    void Update()
//    {
//        Background(0);
//        StrokeWeight(5);
//        Fill(100, 100, 100);

//        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
//        direction = input.normalized;
//        velocity = direction * speed;

//        playerPosition += velocity * Time.deltaTime;

//        Circle(playerPosition.x, playerPosition.y, diameter);

//    }
//}