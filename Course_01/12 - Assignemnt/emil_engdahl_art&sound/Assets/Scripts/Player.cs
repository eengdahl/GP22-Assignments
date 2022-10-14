using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    Vector2 playerInput;
    Vector2 movement;
    float playerSpeed = 5;
    Rigidbody2D rb2d;
    // public GameObject Axe;
    public Projectiles projectiles;


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            projectiles.ActiveProjectile(Projectiles.Weapons.Axe);
        }

    }


    public void FixedUpdate()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        movement = playerInput * playerSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

}
