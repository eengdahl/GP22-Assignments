using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

class Axe : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 movement;
    Vector2 mouseDirection;

    int i;

    private Rigidbody2D rb2d;

    AudioSource audioSource;

    public void Awake()
    {

        rb2d = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = (mousePos - transform.position);
        transform.up = mouseDirection.normalized;


        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
    }


    public void Update()
    { //destroy on z 200ии
      
        transform.Rotate(0, 0, -1);



        if (transform.eulerAngles.z < 200)
        {
            Destroy(gameObject);
        }

        //for (int i = 0; i < 180; i++)
        //{

        //}
        //movement = new Vector3(mouseDirection.x, mouseDirection.y, 0).normalized * 5;
        //rb2d.velocity = movement;
    }


}
