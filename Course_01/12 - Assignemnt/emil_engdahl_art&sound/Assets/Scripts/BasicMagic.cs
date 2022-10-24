using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMagic : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 movement;
    Vector2 mouseDirection;

    Rigidbody2D rb2d;

    public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = (mousePosition - transform.position);
        
        transform.up = mouseDirection;

    }


   public void Update()
    {
        movement = new Vector3(mouseDirection.x, mouseDirection.y, 0).normalized * 25 ;
       // rb2d.transform.up = movement;
        rb2d.velocity = movement;
        
       
    }
}
