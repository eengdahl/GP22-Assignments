using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameObject player;
    Vector3 playerPosition;
    float speed = 5f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPosition = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerPosition.x -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerPosition.x += speed * Time.deltaTime;
        }

        rb.transform.position = playerPosition;
    }
}
