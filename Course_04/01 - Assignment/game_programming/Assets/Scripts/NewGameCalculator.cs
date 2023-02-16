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


    public MyRolledDice myRolledDice;
    DataSnapshot snapshot;
    BetCalculator betCalculator;
    public MyDiceHandler diceHandler;
    int buffer = 0;
    int returner;
    public int playerTurn;
    public GameStates gameStates;

    long totalPlayers;
    int bufferForHaveIRolled = 0;
    public GameObject dice;


    void Start()
    {
        //Check dice on board
        // FireBaseSaver.Instance.LoadData("1111/players", LoadState);

        betCalculator = FindObjectOfType<BetCalculator>();
        //PushFirstGameRules();
    }


    public void LoadState(DataSnapshot test /*/,long buff=0/*/)
    {
        var playerInfo = JsonUtility.FromJson<MyRolledDice>(test.GetRawJsonValue());
        diceOnBoard.AddRange(playerInfo.playerRolls);


        if (!activePlayers.Contains(playerInfo.playerID.ToString()))
        {
            activePlayers.Add(playerInfo.playerID);
            Debug.Log("adding Player");
        }
        if (activePlayers.Contains(playerInfo.playerID.ToString()))
        {
            diceHandler.IHaveRolled = true;
        }

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

    public void IsMyRollUploaded(DataSnapshot playersInList, long total)
    {
        Debug.Log(playersInList);
        Debug.Log(total);
        Debug.Log("tttt");


        var loadActivePlayers = JsonUtility.FromJson<MyRolledDice>(playersInList.GetRawJsonValue());
        if (playersInList == null || total == 999)
        {
            GameStateScript.Instance.ChangeGameState(GameStates.RollDice);
        }
        totalPlayers = total;
        if (totalPlayers == 0)
        {
            Debug.Log(total);
            GameStateScript.Instance.ChangeGameState(GameStates.RollDice);
            return;
        }


        if (loadActivePlayers.playerID == FireBaseSaver.Instance.GetActivePlayerName())
        {
            //Roll dice and set diceRoll to what i prev rolled 
            bufferForHaveIRolled = 0;

            diceHandler.RollDice(diceHandler.diceLeft);

            //var dice = GameObject.FindGameObjectsWithTag("Dice");
            //for (int i = 0; i < dice.Length; i++)
            //{
            //    Debug.Log(i);
            //    // Change i to value collected from Server
            //    dice[i].GetComponent<Dice>().ShowNewNrRolled(i);
            //}


            return;
        }
        if (loadActivePlayers.playerID != FireBaseSaver.Instance.GetActivePlayerName())
        {
            bufferForHaveIRolled++;
        }
        if (bufferForHaveIRolled == ((int)totalPlayers))
        {
            GameStateScript.Instance.ChangeGameState(GameStates.RollDice);
            bufferForHaveIRolled = 0;
        }


    }

    public void FirstRoundChecker(DataSnapshot gameStats, long nullLong)
    {
        var playerTurnInfo = JsonUtility.FromJson<GameStats>(gameStats.GetRawJsonValue());

        if (playerTurnInfo == null)
        {
            PushFirstGameRules();
        }
        if (playerTurnInfo != null)
        {
            Debug.Log("Game Was active");
            GameStateScript.Instance.ChangeGameState(GameStates.HaveIContributed);
        }
    }

    public void PlayerFirstTurnProvider(DataSnapshot test, long nullLong)
    {
        var playerTurnInfo = JsonUtility.FromJson<GameStats>(test.GetRawJsonValue());

        if (playerTurnInfo == null)
        {
            PushFirstGameRules();
            Debug.Log("pushing first");
        }
        betCalculator.lastBetDigit = playerTurnInfo.currentBetDigit;
        betCalculator.lastBetNr = playerTurnInfo.currentBetNr;

        playerTurn = playerTurnInfo.playerTurn;
        if (playerTurn >= activePlayers.Count)
        {
            playerTurn = 0;
        }


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

        FireBaseSaver.Instance.SaveData("1111/gameStats", jsonString, FirstGameRulesISPushed);
    }

    public void FirstGameRulesISPushed()
    {
        //Should push player to playerList 
        //Should also push rolled dice 
        GameStateScript.Instance.ChangeGameState(GameStates.HaveIContributed);
        Debug.Log("pushing First Game");
    }

}
