using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Google.MiniJSON;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;



public class NewGameCalculator : MonoBehaviour
{
    public List<int> diceOnBoard;
    List<string> activePlayers;
    public int one, two, three, four, five, six;

    MyRolledDice myRolledDice;
    DataSnapshot snapshot;
    int buffer = 0;
    int returner;

 
    void Start()
    {
        FireBaseSaver.Instance.LoadData("1111", LoadState);
    }

   
    public void LoadState(DataSnapshot test)
    {
        var playerInfo = JsonUtility.FromJson<MyRolledDice>(test.GetRawJsonValue());
        diceOnBoard.AddRange(playerInfo.playerRolls);
        activePlayers.Add(playerInfo.playerID);

        for (int i = 0; i < playerInfo.playerRolls.Length; i++)
        {

            diceOnBoard[buffer] = playerInfo.playerRolls[i];
            buffer++;
        }
        CountDiceOnBoard();
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


    //public void PickPlayerOrder()
    //{
    //   FireBaseSaver.Instance.SaveData()
    //}


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


    public void PlayerTurnProvider()
    {

    }


}
