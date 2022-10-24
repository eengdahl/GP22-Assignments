using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public Sprite[] ship;
    public Image displayLive;

    public void UpdateLives(int currentLives)
    {
        if (currentLives == 0)
        {
            SceneManager.LoadScene(2);
        }
        displayLive.sprite = ship[currentLives];
    }
}
