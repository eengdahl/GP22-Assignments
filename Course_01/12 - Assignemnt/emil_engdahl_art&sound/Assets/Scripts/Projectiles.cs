using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public enum Weapons
    {
        Axe,
       // Fire,
        Earth,
        //Water,
        BasicMagic
        //EpicPink,
        //EpicFire
    }
    public GameObject Axe;
    public GameObject BasicMagic;

    public void ActiveProjectile(Weapons activeProjectile)
    {

        switch (activeProjectile)
        {
            case Weapons.Axe:
             
               Instantiate(Axe, transform.position, transform.rotation);
                break;

            case Weapons.BasicMagic:

                Instantiate(BasicMagic, transform.position, transform.rotation);

                break;

                //case Weapons.Earth:
                //    Debug.Log("2");
                //    break;

        }
    }
}
