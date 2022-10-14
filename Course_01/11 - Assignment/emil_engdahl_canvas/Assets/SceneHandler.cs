using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
   public UIHandeler UIHandeler;

 public void StartGame()
    {
        Debug.Log("PING");
        SceneManager.LoadScene(1);
         
    }


    public void PausGame()
    {
        SceneManager.LoadScene(0);
    }

}
