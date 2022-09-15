using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parabolicCurves: ProcessingLite.GP21
{
    public float spaceBetweenLines = 0.2f;
    public int Strokes = 10;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
 


    private void Update()
    {
        Stroke(64, 237, 72);
        StrokeWeight(1);


        for (int i = 0; i < Height / spaceBetweenLines; i++)
        {

            if (i % 3 == 0)
            {
                int r = Random.Range(0, 256);
                int g = Random.Range(0, 256);
                int b = Random.Range(0, 256);
                Stroke(r, g, b); // Set var tredje col
            }
            else
            {
                Stroke(64, 237, 72); // Set standard col
            }
            Line(0, Height - i * spaceBetweenLines, Width * i / (Height / spaceBetweenLines), 0);
        }


      //  Lek med att börja i höger top hörne
        for (int i = 0; i < Height / spaceBetweenLines; i++)
        {
            Line(Height, Height, Width - i, Height - i);
        }





        //for (int i = 0; i < Strokes + 1; i++)
        //{
        //    // goes pos1 -> pos2
        //    //               |
        //    //               V
        //    //              pos3

        //    //Take the first two positions find the diffrence then devide by the ammount of strokes wanted
        //    Vector3 diff1 = (pos2.position - pos1.position) / Strokes;

        //    Vector3 diff2 = (pos3.position - pos2.position) / Strokes;
        //    if (i < 0)
        //        i = 0;

        //    Vector3 startPos = pos1.position + diff1 * i;

        //    Vector3 endPos = pos2.position + diff2 * i;


        //    Line(startPos.x, startPos.y, endPos.x, endPos.y);
        //}

    }
    

}
