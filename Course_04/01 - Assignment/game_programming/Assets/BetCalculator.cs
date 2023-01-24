using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using Newtonsoft.Json.Linq;
using System;

public class BetCalculator : MonoBehaviour
{
    public int lastBetNr;
    public int lastBetDigit;
    public int currentBetNr;
    public int currentBetDigit;
    public TextMeshProUGUI aboutToSubmit;
    public TextMeshProUGUI lastBet;
    public BoardCalculator boardCalculator;
    // BetCalculator betCalculator;




    private void Start()
    {
        lastBetNr = 0;
        lastBetDigit = 0;
        currentBetDigit = 2;
        currentBetNr = 1;
    }


    void InvalidBet()
    {
        currentBetDigit = 1;
        currentBetNr = 1;
    }


    public void UpNR()
    {
        currentBetNr++;
        aboutToSubmit.text = currentBetNr.ToString() + " " + currentBetDigit.ToString() + "큦";
    }


    public void DownNR()
    {
        currentBetNr--;
        if (currentBetNr < 1) currentBetNr = 1;

        aboutToSubmit.text = currentBetNr.ToString() + " " + currentBetDigit.ToString() + "큦";

    }
    public void UpDigit()
    {
        currentBetDigit++;
        if (currentBetDigit > 6) currentBetDigit = 6;

        aboutToSubmit.text = currentBetNr.ToString() + " " + currentBetDigit.ToString() + "큦";

    }
    public void DownDigit()
    {
        currentBetDigit--;
        if (currentBetDigit < 2) currentBetDigit = 2;

        aboutToSubmit.text = currentBetNr.ToString() + " " + currentBetDigit.ToString() + "큦";

    }
    public void Submit()
    {
        CheckIfInvalidBet(currentBetNr, currentBetDigit);
    }

    public void CheckIfInvalidBet(int nr, int digit)
    {
        if (nr < lastBetNr)
        {
            //Cant be lower then last nr
            InvalidBet();
            return;
        }
        if (nr == lastBetNr && digit <= lastBetDigit)
        {
            //Cant be lower but same digit
            InvalidBet();
            return;
        }
        else
        {
            aboutToSubmit.text = "";
            lastBet.text = currentBetNr.ToString() + " " + currentBetDigit.ToString() + "큦";
            currentBetNr = 1;
            currentBetDigit = 1;
            lastBetDigit = digit;
            lastBetNr = nr;
        }

    }


    public void CallBet()
    {
        int amountOnBoard = boardCalculator.ReturnDiceOnBoard(lastBetDigit);

        if (amountOnBoard >= lastBetNr)
        {
            Debug.Log("you lose");
        }
        if (amountOnBoard < lastBetNr)
        {
            Debug.Log("you win");
        }

    }

}
