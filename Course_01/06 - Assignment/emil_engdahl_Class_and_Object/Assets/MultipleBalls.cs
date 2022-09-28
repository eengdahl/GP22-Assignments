using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MultipleBalls : ProcessingLite.GP21
{
    public int numberOfBalls = 10;
    Ball[] balls = new Ball[10];

    PlayerClass player;
    public float speed = 9;
    public Vector2 position;
    public Vector2 input;
    Vector2 direction;
    Vector2 velocity;


    void Start()
    {
        StrokeWeight(5);
        Fill(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        for (int i = 0; i < numberOfBalls; i++)
        {
            balls[i] = new Ball(Width / 2, Height / 2);

        }
        player = new PlayerClass(position.x, position.y);
    }

    void Update()
    {
        Background(0);
        //  Stroke(100, 100, 100);

        for (int i = 0; i < numberOfBalls; i++)
        {

            balls[i].UpdatePos();
            balls[i].Draw();
        }
        player.UpdatePos();
        player.Draw();

    }
    //public void UpdatePlayerPosition()
    //{
    //    //input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    //    //direction = input.normalized;
    //    //velocity = direction * speed;
    //    //position += velocity * Time.deltaTime;
       


    //    player.UpdatePos();
    //    player.Draw();

    //}



}
