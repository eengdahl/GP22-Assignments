using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIHandeler : MonoBehaviour
{

    public Image healthBar;
    public Text gameOver;
    Vector3 damage;
    Vector3 fullHealth;
    public int health = 6;
    public TankController controller;
    public Turret turret;




    void Start()
    {
        FindObjectOfType<TankController>();
        damage = new Vector3(-0.17f, 0, 0);
        fullHealth = new Vector3(1, 1, 1);

        gameOver.enabled = false;
    }



    public void ShowPlayerHealth()
    {
        healthBar.transform.localScale += damage;
        health--;

        if (health == 0)
        {
            PreDeath();
        }
    }


    public void PreDeath()
    {
        gameOver.enabled = true;
        controller.disabled = true;
        turret.disabled = true;

        Invoke(nameof(LostMeny), 5);
    }

    private void LostMeny()
    {
        SceneManager.LoadScene("Menu");

    }
}
