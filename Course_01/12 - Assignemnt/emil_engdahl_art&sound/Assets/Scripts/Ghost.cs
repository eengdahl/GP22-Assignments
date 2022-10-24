using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    int health = 5;
    Rigidbody2D rb2d;
    Vector2 movement;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Random.Range(-1, 2), Random.Range(-2, 3));
        rb2d.velocity = movement;
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            health--;
            Debug.Log("Ajj!");
            Destroy(other.gameObject);
            if (health <= 0)
            {
                Debug.Log("DEAD");
                Destroy(gameObject);
            }
        }

    }
}
