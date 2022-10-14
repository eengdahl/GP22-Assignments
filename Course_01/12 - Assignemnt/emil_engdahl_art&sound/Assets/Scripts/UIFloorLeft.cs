using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFloorLeft : MonoBehaviour
{
    Animator openDoorLeft;
    // Start is called before the first frame update
    public void StartWasPressed()
    {
        openDoorLeft = GetComponent<Animator>();
        openDoorLeft.SetBool("startGame", true);
    }
}
