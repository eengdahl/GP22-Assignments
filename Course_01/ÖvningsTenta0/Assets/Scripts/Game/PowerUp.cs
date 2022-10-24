using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUpSheild;
    public GameObject powerUpFireRate;
    Vector3 newPosition;


    public void SpawnPowerUp(float x, float y)
    {
        newPosition = new Vector3(x, y, 0);

        int wichPowerUp = Random.Range(1, 3);

        if (wichPowerUp == 1)
        {
            Instantiate(powerUpSheild, newPosition, Quaternion.Euler(0, 0, Random.Range(0, 360f)));
        }
        if (wichPowerUp == 2)
        {
            Instantiate(powerUpFireRate, newPosition, Quaternion.Euler(0, 0, Random.Range(0, 360f)));
        }
    }


}
