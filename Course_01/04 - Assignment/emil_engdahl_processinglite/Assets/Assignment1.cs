using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{
    public float x ;
    public float y ;
    public float z ;
    public float w ;
    public float diameter = 0.2f;
    public float spaceBetweenLines = 0.1f;
    

    void Update()
    {
        Background(0, 120, 120); //Clears the background and sets the color to 0.

        Stroke(228, 228, 228);
        StrokeWeight(4);
        //First E
        Line(4, 7, 4, 1);   
        Line(4, 7, 7, 7);
        Line(4, 1, 7, 1);
        Line(4, 4, 6, 4);

        //Second E
        Line(10, 7, 10, 1);
        Line(10, 7, 13, 7);
        Line(10, 1, 13, 1);
        Line(10, 4, 12, 4);

        Stroke(128, 128, 0, 64);
        StrokeWeight(0.5f);

        for (int i = 0; i < Height / spaceBetweenLines; i++)
        {
            y = i * spaceBetweenLines;
            Line(0, y, Width, y);

        }




    }
}
