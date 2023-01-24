using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayer : MonoBehaviour
{

    BoardCalculator boardCalculator;
    BetCalculator betCalculator;
    public void Start()
    {
        boardCalculator = GetComponent<BoardCalculator>();
        betCalculator = GetComponent<BetCalculator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var dice = GameObject.FindGameObjectsWithTag("Dice");
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i].GetComponent<Dice>().RollMe();

                if (i == dice.Length - 1)
                {
                    boardCalculator.FindDiceOnBoard();
                    betCalculator.lastBetNr = 1;
                    betCalculator.lastBetDigit = 1;
                }
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    var dice = GameObject.FindGameObjectsWithTag("Dice");
        //    for (int i = 0; i < dice.Length; i++)
        //    {
        //        dice[i].GetComponent<Dice>().RollMe();

        //        if (i == dice.Length - 1)
        //        {
        //            boardCalculator.FindDiceOnBoard();
        //        }
        //    }
        //}

    }
}
