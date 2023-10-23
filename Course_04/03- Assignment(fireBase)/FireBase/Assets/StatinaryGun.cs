using System;
using System.Collections;
using UnityEngine;


public class StatinaryGun : MonoBehaviour
{

    public GameObject player;
    public GameObject bullet;
    private float timer;
    float turnInterval;

    bool minusSwap;

    public float rotationSpeed = 10.0f;

    private float targetRotation = -180.0f;
    private float rotationDirection;

    void Start()
    {
        minusSwap = true;
        rotationDirection = 1.0f;
        turnInterval = 3f;
        Invoke(nameof(Shoot), 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > turnInterval)
        {
            if (minusSwap)
            {
                rotationDirection = -1f;
                minusSwap = false;
                timer = 0;
                return;
            }

            if (!minusSwap)
            {
                rotationDirection = 1f;
                minusSwap = true;
                timer = 0;
                return;
            }

        }

        this.transform.Rotate(Vector3.forward * rotationSpeed * rotationDirection * Time.deltaTime);

    }
    public void Shoot()
    {
        var newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.up = this.transform.up.normalized;
        //newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, transform.rotation.z) * 50, ForceMode2D.Force);
        Invoke(nameof(Shoot), 1.5f);
    }


}
