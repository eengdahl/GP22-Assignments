using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    public Text ammoDisplay;

    private void Start()
    {
        AmmoDisplay(99);
    }

    public void AmmoDisplay(int Currentammo)
    {
        ammoDisplay.text = Currentammo.ToString();
    }


}
