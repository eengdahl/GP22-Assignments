using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    BetCalculator betCalculator;
    int betNr;
    int betDigit;

    int nrOfDice;
    GameObject dice;

    private void Awake()
    {
        betCalculator = GetComponent<BetCalculator>();
    }
    public void RollDice()
    {

    }

    public void Bet()
    {
        betCalculator.CheckIfInvalidBet(betNr, betDigit);

    }
    public void CallBet()
    {

    }
}
