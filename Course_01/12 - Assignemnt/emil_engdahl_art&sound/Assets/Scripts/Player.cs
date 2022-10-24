using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    Vector2 playerInput;
    Vector2 movement;
    float playerSpeed = 5;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    public Projectiles projectiles;



    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            projectiles.ActiveProjectile(Projectiles.Weapons.BasicMagic);
           // projectiles.ActiveProjectile(Projectiles.Weapons.Axe);
        }
        if (Input.GetKeyDown(KeyCode.F))
           {
            projectiles.ActiveProjectile(Projectiles.Weapons.Axe);
        }

    }


    public void FixedUpdate()
    {
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        ////Flip charachter
        //if (playerInput.x < 0)
        //{
        //    spriteRenderer.flipX = true;
        //}
        //else
        //{
        //    spriteRenderer.flipX = false;
        //}

        movement = playerInput * playerSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

}
