using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerClass : MonoBehaviour
{
    public int playerLife = 3;
    public int playerHealth = 100;
    public GameObject healthBar;
    public Vector3 damage;
    public Vector3 fullHealth;
    public UIManager UI;
    public Menu menu;
    public PowerUp powerUp;
    public PlayerFire playerFire;
    bool shieldOn = false;


    void Start()
    {
        damage = new Vector3(-0.25f, 0, 0);
        fullHealth = new Vector3(1, 1, 1);
        //setting life to full life
        UI.UpdateLifeImage(playerLife);

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Meteor"))
        {
            //If shild is activated, destroy shield and dont take dmg
            if (shieldOn == true)
            {
                UI.Shield(false);
                shieldOn = false;
                return;
            }

            playerHealth = playerHealth - 25;
            healthBar.transform.localScale += damage;

            if (playerHealth <= 0)
            {
                LooseLife();
            }
        }


    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        //Adding PowerUp when player hits powerUp
        if (other.gameObject.name == ("PowerUpFireRate(Clone)"))
        {
            playerFire.fireRate = 0.2f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == ("PowerUpShield(Clone)"))
        {

            UI.Shield(true);
            shieldOn = true;
            Destroy(other.gameObject);
        }
    }



    public void LooseLife()
    {
        playerLife--;
        playerHealth = 100;
        healthBar.transform.localScale = fullHealth;

        UI.UpdateLifeImage(playerLife);

        if (playerLife == 0)
        {
            menu.LoadScene("GameOver");
        }
    }
}
