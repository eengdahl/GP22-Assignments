using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject ammo;
    EnemySpawner enemySpawner;
    int health = 4;

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();


    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Bullet"))
        {
            health--;
            if (health == 0)
            {
                Destroy(gameObject);

                Instantiate(ammo, transform.position, transform.rotation);
                enemySpawner.SpawnWave(2);
            }
        }
    }
}
