using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleBalls : ProcessingLite.GP21
{
    public int numberOfBalls = 10;
    Ball[] balls = new Ball[10];



    void Start()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            balls[i] = new Ball(Width / 2, Height / 2);
        }
    }

    void Update()
    {

        for (int i = 0; i < numberOfBalls; i++)
        {
            balls[i].UpdatePos();
            balls[i].Draw();
        }
    }
}
