using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDemo : ProcessingLite.GP21
{
    Ball myBall;
    CollisionCalc ballcalc;

    void Start()
    {
        myBall = new Ball(5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        myBall.UpdatePos();
        myBall.Draw();
        ballcalc.BallCalc(5, 5, 5);
    }
}
