using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

class Axe : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 mousePos2;
    Vector3 movement;
    Vector3 mouseDirection;

    private Rigidbody2D rb2d;

    AudioSource audioSource;

    public void Awake()
    {

        rb2d = GetComponent<Rigidbody2D>();
        mousePos = (Input.mousePosition);
        mousePos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = (mousePos2 - transform.position);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
    }


    public void Update()
    {
        movement = new Vector3(mouseDirection.x, mouseDirection.y, 0).normalized * 5;
        rb2d.velocity = movement;
    }


}
