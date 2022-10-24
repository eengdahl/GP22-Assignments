using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate =0.4f;
    public float maxFireRate = 0.1f;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (fireRate < maxFireRate)
        {
            Debug.Log(fireRate);
            fireRate = maxFireRate;
        }
        if (Input.GetButton("Jump") && timer > fireRate)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timer = 0;
        }
    }
}
