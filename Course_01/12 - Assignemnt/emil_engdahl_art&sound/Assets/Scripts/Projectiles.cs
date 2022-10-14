using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public enum Weapons
    {
        Axe,
        Fire,
        Earth,
        //Water,
        //BasicMagic,
        //EpicPink,
        //EpicFire
    }
    public GameObject Axe;

    public void ActiveProjectile(Weapons activeProjectile)
    {

        switch (activeProjectile)
        {
            case Weapons.Axe:
                Debug.Log("0");
               Instantiate(Axe, transform.position, transform.rotation);
                break;

            //case Weapons.Fire:
            //    Debug.Log("1");
            //    break;

                //case Weapons.Earth:
                //    Debug.Log("2");
                //    break;

        }
    }
}
