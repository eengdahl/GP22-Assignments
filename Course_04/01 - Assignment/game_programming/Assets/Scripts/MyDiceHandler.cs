using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;


[Serializable]
public class MyRolledDice
{
    public int[] playerRolls;
    public string playerID;
}



public class MyDiceHandler : MonoBehaviour
{
    int startdice;
    int diceLeft;
    int[] buffer;
    int i;

    int myPlayerIndex;
    public string playerName;
    public bool itIsMyTurn;

    public GameObject[] startPositions;
    public GameObject player;
    public GameObject dice;

    MyRolledDice myRolledDice;
    SignInScript signInScript;
    public NewGameCalculator gameCalculator;


    private void Awake()
    {
        playerName = FireBaseSaver.Instance.GetActivePlayerName();

        i = 0;
        player = this.gameObject;
        startdice = 3;
        diceLeft = startdice;
    }

    void Start()
    {
        Invoke("IsItMyTurn", 2);
        signInScript = FindObjectOfType<SignInScript>();
        RollDice(diceLeft);
        // myPlayerIndex = FireBaseSaver.Instance.AddPlayerToGame(this.gameObject);
        //FireBaseSaver.Instance.Subscribe("1111", "gameStats");
    }


    void RollDice(int NrOfDiceRolled)
    {
        for (int i = 0; i < NrOfDiceRolled; i++)
        {
            Instantiate(dice, startPositions[i].transform.position, Quaternion.identity, player.transform);
        }
    }

    public void CollectDiceRolls(int nrRolled)
    {

        if (i == 0)
        {
            buffer = new int[diceLeft];
        }
        buffer[i] = nrRolled;
        i++;

        if (buffer[diceLeft - 1] != 0)
        {
            MyRolledDice myRolledDice = new MyRolledDice();
            myRolledDice.playerRolls = new int[diceLeft];
            myRolledDice.playerID = playerName;


            for (int i = 0; i < buffer.Length; i++)
            {
                myRolledDice.playerRolls[i] = buffer[i];
            }
            i = 0;


            string jsonString = JsonUtility.ToJson(myRolledDice);
            FireBaseSaver.Instance.PushData("1111/players", jsonString);
        }
    }

    public void IsItMyTurn()
    {
        FireBaseSaver.Instance.LoadSingelData("1111/gameStats", gameCalculator.PlayerFirstTurnProvider);
        if (gameCalculator.activePlayers[gameCalculator.playerTurn] == playerName)
        {
            itIsMyTurn = true;

        }
        else
        {
            itIsMyTurn= false;
        }
        Invoke("IsItMyTurn", 2);
    }

}
