using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreController : MonoBehaviour
{
    public Text text;
    public int score;

    void Start()
    {
        score = 0;
        AddScore(0);
    }
   

    public void AddScore(int points)
    {
        score += points;
        text.text = ("score: " + score);
    }

}