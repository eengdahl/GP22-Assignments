using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate = 0.4f;
    float timer;

    void Update()
    {

        timer += Time.deltaTime;

        if (Input.GetButton("Jump") && timer > fireRate)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timer = 0;
        }
    }

}
