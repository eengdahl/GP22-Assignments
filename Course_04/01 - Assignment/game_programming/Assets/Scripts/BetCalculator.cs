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

    MyDiceHandler mDiceHandler;
    NewGameCalculator newGameCalculator;




    private void Start()
    {

        currentBetDigit = 2;
        currentBetNr = 1;
        mDiceHandler = FindObjectOfType<MyDiceHandler>();
        newGameCalculator = FindObjectOfType<NewGameCalculator>();
    }
    private void Update()
    {
        lastBet.text = lastBetNr.ToString() + " " + lastBetDigit.ToString() + "´s";
    }



    public void ActivateAllButtons()
    {

    }

    public void DeactivateAllButtons()
    {

    }


    void InvalidBet()
    {
        currentBetDigit = 1;
        currentBetNr = 1;
    }


    public void UpNR()
    {
        currentBetNr++;
        aboutToSubmit.text = currentBetNr.ToString() + " " + currentBetDigit.ToString() + "´s";
    }


    public void DownNR()
    {
        currentBetNr--;
        if (currentBetNr < 1) currentBetNr = 1;

        aboutToSubmit.text = currentBetNr.ToString() + " " + currentBetDigit.ToString() + "´s";

    }
    public void UpDigit()
    {
        currentBetDigit++;
        if (currentBetDigit > 6) currentBetDigit = 6;

        aboutToSubmit.text = currentBetNr.ToString() + " " + currentBetDigit.ToString() + "´s";

    }
    public void DownDigit()
    {
        currentBetDigit--;
        if (currentBetDigit < 2) currentBetDigit = 2;

        aboutToSubmit.text = currentBetNr.ToString() + " " + currentBetDigit.ToString() + "´s";

    }
    public void SubmitBet()
    {
        if (mDiceHandler.itIsMyTurn == false)
        {
            return;
        }
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

            if (newGameCalculator.playerTurn > newGameCalculator.activePlayers.Count)
            {
                newGameCalculator.playerTurn = 0;
            }
            else
            {
                newGameCalculator.playerTurn++;
            }

            //Playerturn synkar lokalt och sen på servern.
            //Det hinner laddas lokalt innan server-side och fuckar ordningen på playerTurn
            //TODO: gå aldrig till 0 utan dela playerorder på listan. 

            GameStats gameStats = new GameStats();
            gameStats.playerTurn = newGameCalculator.playerTurn;
            gameStats.currentBetDigit = currentBetDigit;
            gameStats.currentBetNr = currentBetNr;

            string jsonString = JsonUtility.ToJson(gameStats);

            Debug.Log("pushing");
            FireBaseSaver.Instance.SaveData("1111/gameStats", jsonString);


            currentBetNr = 1;
            currentBetDigit = 1;
            lastBetDigit = digit;
            lastBetNr = nr;
        }

    }


    public void CallBS()
    {
        if (mDiceHandler.itIsMyTurn == false)
        {
            return;
        }
        //int amountOnBoard = boardCalculator.ReturnDiceOnBoard(lastBetDigit);

        //if (amountOnBoard >= lastBetNr)
        //{
        //    Debug.Log("you lose");
        //}
        //if (amountOnBoard < lastBetNr)
        //{
        //    Debug.Log("you win");
        //}

    }

}
