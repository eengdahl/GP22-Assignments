using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoinsScript : MonoBehaviour
{
    spawnerScript spawnerScript;
    // Start is called before the first frame update
    void Start()
    {
        spawnerScript = FindAnyObjectByType<spawnerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            spawnerScript.DestroyCoin(collision.gameObject);
        }
    }
}
