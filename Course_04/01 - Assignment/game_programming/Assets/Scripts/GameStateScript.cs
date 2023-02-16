using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    IsGameActive,
    HaveIContributed,
    RollDice,
    ShowRolledDice,
    MyTurn,
    NotMyTurn,
    Calling,
    NewRound,
    WinOrLose
}
public class GameStateScript : MonoBehaviour
{
    private static GameStateScript _instance;
    public static GameStateScript Instance { get { return _instance; } }
    public NewGameCalculator gameCalc;
    public MyDiceHandler myDiceHandler;
    bool hasChecked = false;
    public bool iHaveRolled = false;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        ChangeGameState(GameStates.IsGameActive);
    }

    public void ChangeGameState(GameStates newGameState)
    {
            Debug.Log("called");
        switch (newGameState)
        {
            case GameStates.IsGameActive:

                Debug.Log("IsGameActive");
                if (!hasChecked)
                {
                    FireBaseSaver.Instance.LoadSingelData("1111/gameStats", gameCalc.FirstRoundChecker);
                    hasChecked = true;
                }
                break;

            case GameStates.HaveIContributed:
                Debug.Log("HaveIContributed");
                if (hasChecked)
                {
                //HERE
                //Am i in playerList. 
                //Add me to playerList if empty? 
                //Players do not exist in the list yet. Roll or add ? 
              
                    FireBaseSaver.Instance.LoadData("1111/players", gameCalc.IsMyRollUploaded);
                    hasChecked = false;
                }
                //if (IHaveRolled)
                //{
                //    diceHandler.RollDice(diceHandler.startdice);

                //    var dice = GameObject.FindGameObjectsWithTag("Dice");
                //    for (int i = 0; i < dice.Length; i++)
                //    {
                //Change i to value collected from Server 
                //        dice[i].GetComponent<Dice>().ShowNewNrRolled(i);
                //    }
                //}


                break;
            case GameStates.RollDice:
                //See how many dice i have left
                //Roll Dice
                Debug.Log("inHere");

                if (!hasChecked)
                {
                    myDiceHandler.RollDice(myDiceHandler.diceLeft);
                    hasChecked = true;
                }
                //Upload DiceRoll
                break;
            case GameStates.ShowRolledDice:
                //Collect rolled Dice and instantiate them with nr (Virtual/Override?)
                break;
            case GameStates.MyTurn:
                //Check when it is my turn
                //Show last bet
                //Make Raise/Bullshit

                break;
            case GameStates.Calling:
                //Save called data and change playerturn 
                //Deactivate submit
                break;

            case GameStates.NotMyTurn:
                //Show whos Turn
                //Show New betting
                break;
            case GameStates.NewRound:
                //Collect win/lose
                //Adjust Dice Remaining
                //Reset Rolls in server, 
                //Revert player turn
                break;
            case GameStates.WinOrLose:
                //Leave game
                //Show victoryscreen
                break;

            default:
                break;

        }
    }
}
