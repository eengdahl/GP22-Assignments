using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float turningSpeed = 5;
    public float speed = 5;
    public bool disabled;

    private float angle;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        disabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (disabled)
        {
            return;
        }
        angle -= Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        rb2d.MoveRotation(angle);

        float y = Input.GetAxis("Vertical");
        rb2d.velocity = rb2d.transform.up * y * speed;
    }
}
