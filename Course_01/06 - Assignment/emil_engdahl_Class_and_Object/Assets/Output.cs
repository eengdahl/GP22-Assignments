using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Output : ProcessingLite.GP21
{
    Ball[] balls = new Ball[10];
    PlayerClass player;

    public int numberOfBalls = 10;
    public Vector2 position;

    public Vector2 playerPosition;
    Vector2 ballPosition;
    public float size;

    float ballSize;

    void Start()
    {
        StrokeWeight(5);
        Fill(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));


        for (int i = 0; i < numberOfBalls; i++)
        {
            size = Random.Range(0.3f, 3);
            balls[i] = new Ball(Width / 2, Height / 2, size);
        }
        player = new PlayerClass(position.x, position.y);
    }

    void Update()
    {
        Background(0);

        player.UpdatePos();
        player.Draw();
        playerPosition = new Vector2(player.position.x, player.position.y);

        for (int i = 0; i < numberOfBalls; i++)
        {

            ballPosition = new Vector2(balls[i].position.x, balls[i].position.y);
            //  Något weird, den tar inte "rätt" size i CircleCollision
            ballSize = balls[i].size;
            balls[i].UpdatePos();
            balls[i].Draw();
            CircleCollision(playerPosition, ballPosition, ballSize);
        }
    }



    bool CircleCollision(Vector2 playerVector, Vector2 ballVector, float ballSize)
    {
        float maxDistance = 0.5f + ballSize ;
        float x1 = playerVector.x;
        float y1 = playerVector.y;
        float x2 = ballVector.x;
        float y2 = ballVector.y;

        if (Mathf.Abs(x1 - x2) > maxDistance || Mathf.Abs(y1 - y2) > maxDistance)
        {
            Debug.Log("False1");
            return false;
        }

        else if (Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2)) > maxDistance)
        {
            Debug.Log("False2");
            return false;
        }

        else
        {
            Debug.Log("GameOver");

            Endscreen();
            return true;
        }
    }

    public void Endscreen()
    {
        //background(255);

        Text("you lost!", Width / 2, Height / 2);
        return;
        //todo: paus game
    }
}

