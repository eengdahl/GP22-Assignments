using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUpShield;
    public GameObject powerUpFireRate;
    int randomPowerUp;
    public int spawnPowerUpCounter = 0;


    public void SpawnPowerUp(Vector2 spawnPosition)
    {
        //spawning a powerup after 10 small meteor was spawned (same as 5 medium was destroyed)
        spawnPowerUpCounter++;

        if (spawnPowerUpCounter == 10)
        {
            //Randomizing spawned poweruo
            randomPowerUp = Random.Range(1, 3);

            if (randomPowerUp == 1)
            { 
                Instantiate(powerUpFireRate, spawnPosition, Quaternion.Euler(0, 0, Random.Range(0, 360f)));
            }
            else
            {
                Instantiate(powerUpShield, spawnPosition, Quaternion.Euler(0, 0, Random.Range(0, 360f)));
            }

            spawnPowerUpCounter = 0;
        }

    }

    //public void PowerUpShield()
    //{

    //}

    //public void PowerUpFireRate()
    //{

    //}

}
