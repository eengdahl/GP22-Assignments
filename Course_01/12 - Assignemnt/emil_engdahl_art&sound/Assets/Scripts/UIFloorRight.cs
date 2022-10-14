using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIFloorRight : MonoBehaviour
{

    public bool startGame = false;
    Animator ClosedDoorRight;
    public void StartButtonWasPressed()
    {

        ClosedDoorRight = gameObject.GetComponent<Animator>();
        ClosedDoorRight.SetBool("startGame", true);
        Debug.Log("Test");
        startGame = true;
    }

    public void ChangeScen()
    {

        
    }
}
