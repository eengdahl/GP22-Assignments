using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float timer;
    Rigidbody2D rb;
    float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0 && timer < 2)
        {
            rb.velocity = Vector2.left * speed;

        }
        if (timer > 2)
        {
            rb.velocity = Vector2.right * speed;
        }
        if (timer > 4)
        {
            timer = 0;
        }
    }
}
