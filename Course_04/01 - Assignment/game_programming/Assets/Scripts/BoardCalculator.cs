using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BoardCalculator : MonoBehaviour
{
    public List<int> diceOnBoard;
    public int one;
    public int two;
    public int three;
    public int four;
    public int five;
    public int six;
    public int returner;

    public TestJson Json;

    public void Awake()
    {
        Invoke("FindDiceOnBoard", 0.1f);
    }
    public void FindDiceOnBoard()
    {
        diceOnBoard.Clear();
        var dice = GameObject.FindGameObjectsWithTag("Dice");
        for (int i = 0; i < dice.Length; i++)
        {
            diceOnBoard.Add(dice[i].GetComponent<Dice>().myNumber);


            if (i == dice.Length - 1)
            {
                Json.Save();
                CountDiceOnBoard();
                
            }
        }
    }

    public void CountDiceOnBoard()
    {
        one = diceOnBoard.Count(c => c == 1);

        two = diceOnBoard.Count(c => c == 2);
        three = diceOnBoard.Count(c => c == 3);
        four = diceOnBoard.Count(c => c == 4);
        five = diceOnBoard.Count(c => c == 5);
        six = diceOnBoard.Count(c => c == 6);
    }

    public int ReturnDiceOnBoard(int HowManyOnBoard)
    {
        returner = 0;

        for (int i = 0; i < diceOnBoard.Count; i++)
        {
            if (diceOnBoard[i] == HowManyOnBoard || diceOnBoard[i] == 1)
            {
                returner++;
            }
        }
        Debug.Log("returner" + returner);
        return returner;

    }
}
