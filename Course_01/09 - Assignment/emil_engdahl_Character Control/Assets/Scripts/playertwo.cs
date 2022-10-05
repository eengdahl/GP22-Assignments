using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertwo : MonoBehaviour
{

    public float speed = 5;
    Rigidbody2D rb2d;
    Vector2 addForce;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        addForce = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb2d.AddForce(addForce * speed);

    }
}
