using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        //Use our rigidbody to move our bullet
        GetComponent<Rigidbody2D>().velocity = transform.up * 8;

        //Destroy bullet after 3s
        Destroy(gameObject, 3);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        Destroy(gameObject);
        var newExplosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(newExplosion, 1f);
	}
}
