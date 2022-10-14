using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIHandeler : MonoBehaviour
{
    SceneHandler sceneHandler;

    [SerializeField] public TMP_Text scoreOutput;
    public PlayerMovement playerMovement;


    public void OnStartButtonPressed()
    {
        Debug.Log("Start");
    }

    public void OnSettingsButtonPressed()
    {
        Debug.Log("Settings");
    }

    public void OnQuitButtonPressed()
    {
        Debug.Log("Quit");
    }

    public void DisplayScore(int s)
    {
        scoreOutput.text = "Score: "+s;
    }

}
