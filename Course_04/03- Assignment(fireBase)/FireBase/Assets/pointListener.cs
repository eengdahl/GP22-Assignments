using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class pointListener : MonoBehaviour
{

    public TMP_Text scoreText;
    public int points;

    public void updateScore(int score = 100)
    {
        points += score;
        scoreText.text = points.ToString();
    }
}
