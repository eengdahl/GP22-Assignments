using Packages.Rider.Editor.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CollisionCalc : ProcessingLite.GP21
{
    public float playerX1;
    public float playerY1;
    public float playerSize;
    public float ballX2;
    public float ballY2;
    public float ballsieze;

    public Array BallCalc(float x1, float y1, float size1)
    {
        Debug.Log("Test");
        ballX2 = x1;
        ballY2 = y1;
        ballsieze = size1;
    }

    public float PlayerCalc(float x2, float y2, float size2)
    {
        Debug.Log("Test");
        x2 = playerX1;
        y2 = playerY1;
        playerSize = size2;
        return playerX1;
    }

    public float Test(PlayerCalc)
    {
        return 0;
    }



    public bool CircleCollision(float x1, float y1, float size1, float x2, float y2, float size2)
    {
        float maxDistance = size1 + size2;

        //first a quick check to see if we are too far away in x or y direction
        //if we are far away we don't collide so just return false and be done.
        if (Mathf.Abs(x1 - x2) > maxDistance || Mathf.Abs(y1 - y2) > maxDistance)
        {
            return false;
        }
        //we then run the slower distance calculation
        //Distance uses Pythagoras to get exact distance, if we still are to far away we are not colliding.
        else if (Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2)) > maxDistance)
        {
            return false;
        }
        //We now know the points are closer then the distance so we are colliding!
        else
        {
            return true;

        }
    }
}
// A better way to do this is to have a circle object and pass the objects in to the function,
//then we just have to pass 2 objects instead of 6 different values.
