using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalkerTank : MonoBehaviour
{
    public float speed = 4;

    Vector2[] dirs = { Vector2.up, Vector2.down, Vector2.right, Vector2.left };
    Vector2 dir;
    Rigidbody2D rb2d;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        MoveNewDirection();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
		if (timer < 0)
		{
            MoveNewDirection();
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		MoveNewDirection();
	}

	private void MoveNewDirection()
	{
		var oldDir = dir;

        //Get a new random direction
        do
        {
            dir = dirs[Random.Range(0, dirs.Length)];
        }
        while (dir == oldDir);

        //Start moving in the new direction
        rb2d.velocity = dir * speed;
        transform.up = dir;

        //Time until new direction change.
        timer = Random.Range(0.5f, 2);
    }
}
