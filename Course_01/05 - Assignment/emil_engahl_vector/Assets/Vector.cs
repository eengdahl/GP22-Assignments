using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class Vector : ProcessingLite.GP21
{

    public float diameter = 0.5f;
    public int x ;
    public int y = 5;
    public bool mouseWasPressed;
    public bool mouseWasReleased;
    public bool mouseWasDragged;
    public Vector2 cirkelPosition;
    public Vector2 line;
    public Vector2 lineCalc;
    private Vector2 mousePosition;
    public float speedLimit = 0.5f;
    public float magnitude;
    public float speed;
    public float cirkelStatsX;
    public float cirkelStatsY;
    public 
  

    // Start is called before the first frame update
    void Start()
    {
        Background(155);
        StrokeWeight(3);
        Fill(0, 101, 255);
    }

    // Update is called once per frame
    void Update()
    {

        Background(155);

    
        if (Input.GetMouseButtonDown(0))
        {
            mouseWasPressed = true;
            cirkelPosition.x = MouseX;
            cirkelPosition.y = MouseY;
        }

        if (Input.GetMouseButton(0))
        {
            mouseWasDragged = true;
            Line(cirkelPosition.x, cirkelPosition.y, MouseX, MouseY);

            mousePosition = new Vector2(MouseX, MouseY);
                
            lineCalc = mousePosition - cirkelPosition;
            magnitude = lineCalc.magnitude;

        }
        
        if (Input.GetMouseButtonUp(0))
        {
            mouseWasReleased = true;

        }

        if (magnitude > 8)
        {
            speed = magnitude * speedLimit;
            Debug.Log(magnitude);
        }

        Circle(cirkelPosition.x, cirkelPosition.y, diameter);

        if (cirkelPosition.x > Height)
        {
            Circle(cirkelPosition.x -= lineCalc.x * Time.deltaTime, cirkelPosition.y += lineCalc.y * Time.deltaTime, diameter);
        }
        else if (cirkelPosition.y > Width)

        {
            Circle(cirkelPosition.x += lineCalc.x * Time.deltaTime, cirkelPosition.y -= lineCalc.y * Time.deltaTime, diameter);
        }
        else
        {
            Circle(cirkelPosition.x += lineCalc.x * Time.deltaTime, cirkelPosition.y += lineCalc.y * Time.deltaTime, diameter);
        }


        
       




        //Height // Width



    }

}
