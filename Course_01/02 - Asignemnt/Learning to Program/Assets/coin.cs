using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float scoreCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        scoreCounter++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        Debug.Log(scoreCounter);
    }
  
}
