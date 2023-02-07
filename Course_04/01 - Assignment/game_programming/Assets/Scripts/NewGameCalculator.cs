using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Google.MiniJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


[Serializable]
public class GameStats
{
    public int playerTurn;
    public int currentBetNr;
    public int currentBetDigit;
}


public class NewGameCalculator : MonoBehaviour
{
    public List<int> diceOnBoard;
    public List<string> activePlayers;
    public int one, two, three, four, five, six;

    MyRolledDice myRolledDice;
    DataSnapshot snapshot;
    BetCalculator betCalculator;
    public MyDiceHandler diceHandler;
    int buffer = 0;
    int returner;
    public int playerTurn;


    void Start()
    {
        //Check dice on board
        FireBaseSaver.Instance.LoadData("1111/players", LoadState);

        betCalculator = FindObjectOfType<BetCalculator>();
        //PushFirstGameRules();
    }


    public void LoadState(DataSnapshot test)
    {
        var playerInfo = JsonUtility.FromJson<MyRolledDice>(test.GetRawJsonValue());
        diceOnBoard.AddRange(playerInfo.playerRolls);



        for (int i = 0; i < playerInfo.playerRolls.Length; i++)
        {

            diceOnBoard[buffer] = playerInfo.playerRolls[i];
            buffer++;
        }
        CountDiceOnBoard();
        if (!activePlayers.Contains(playerInfo.playerID.ToString()))
        {
            activePlayers.Add(playerInfo.playerID);
            Debug.Log("adding Player");
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

    public void PlayerFirstTurnProvider(DataSnapshot test)
    {
        var playerTurnInfo = JsonUtility.FromJson<GameStats>(test.GetRawJsonValue());

        if (playerTurnInfo == null)
        {
            PushFirstGameRules();
            Debug.Log("pushing First");
        }

        betCalculator.lastBetDigit = playerTurnInfo.currentBetDigit;
        betCalculator.lastBetNr = playerTurnInfo.currentBetNr;

        if (playerTurn > activePlayers.Count + 1)
        {
            playerTurn = playerTurnInfo.playerTurn - activePlayers.Count;
        }
        else
        {
            playerTurn = playerTurnInfo.playerTurn;
        }

        Debug.Log(playerTurn);
        if (activePlayers[playerTurn] == diceHandler.playerName)
        {
            diceHandler.itIsMyTurn = true;
        }
        else
        {
            diceHandler.itIsMyTurn = false;
        }
    }


    private void PushFirstGameRules()
    {
        GameStats gameStats = new GameStats();
        gameStats.playerTurn = 0;
        gameStats.currentBetDigit = 0;
        gameStats.currentBetNr = 0;

        string jsonString = JsonUtility.ToJson(gameStats);

        FireBaseSaver.Instance.SaveData("1111/gameStats", jsonString);
    }

}
