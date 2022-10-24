using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunPoint1;
    public Transform gunPoint2;
    public float fireRate = 0.5f;
    public UIHandeler handeler;
    public AmmoCounter ammoScript;

    public int ammo = 99;
    float timer;



    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0) && timer > fireRate && ammo > 0)
        {
            ammo--;
            ammoScript.AmmoDisplay(ammo);


            //TODO: Create a seccond gunPoint and fire every other bullet from that location instead.
            if (ammo % 2 == 1)
            {
                Instantiate(bulletPrefab, gunPoint1.position, gunPoint1.rotation);
            }
            else
            {
                Instantiate(bulletPrefab, gunPoint2.position, gunPoint1.rotation);
            }

            timer = 0;
        }
    }
}
