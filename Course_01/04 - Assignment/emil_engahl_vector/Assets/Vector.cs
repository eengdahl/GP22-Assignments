using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class Vector : ProcessingLite.GP21
{

    public float diameter = 0.5f;
    public int x;
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

    public Vector2 movement;
    
  

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
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            mouseWasReleased = true;
        }


        Circle(cirkelPosition.x, cirkelPosition.y, diameter);

        if (cirkelPosition.x >= 17.79328 || cirkelPosition.x <= 0)
        {
            lineCalc.x *=-1;
        }

        if (cirkelPosition.y >= 10 || cirkelPosition.y <=0)
        {
            lineCalc.y *= -1;
        }

  
        magnitude = lineCalc.magnitude;


        if (magnitude > 10)
        {
            lineCalc *= speedLimit;
        }
          
        movement = cirkelPosition += lineCalc * Time.deltaTime;

        Circle(movement.x , movement.y, diameter);

    }

}
