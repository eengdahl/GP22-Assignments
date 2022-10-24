using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerClass : MonoBehaviour
{

    public int playerLife = 3;
    public UImanager UImanager;
    public PlayerFire playerFire;
    public GameObject sheild;
    bool shieldOn = false;

    private void Awake()
    {
        UImanager.UpdateLives(playerLife);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Meteor"))
        {
            playerLife--;
            UImanager.UpdateLives(playerLife);

        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == ("PowerUpFireRate") || other.gameObject.name == ("PowerUpFireRate(Clone)"))
        {
            if (playerFire.fireRate < 0.0001f)
            {
                playerFire.fireRate += -0.1f;

            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == ("PowerUpSheild") || other.gameObject.name == ("PowerUpSheild(Clone)"))
        {
            Debug.Log("Test");

            if (shieldOn == false)
            {
                Instantiate(sheild, transform.position, transform.rotation);
               
            }
            Destroy(other.gameObject);
        }
    }


}
