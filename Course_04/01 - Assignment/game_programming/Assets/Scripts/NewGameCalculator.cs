using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Google.MiniJSON;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;



public class NewGameCalculator : MonoBehaviour
{
    public List<int> diceOnBoard;
    public int one, two, three, four, five, six;

    MyRolledDice myRolledDice;

    // Start is called before the first frame update
    private void Awake()
    {
        Invoke("LoadDataFromFB", 2);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadDataFromFB()
    {
        var db = FirebaseDatabase.DefaultInstance;

        db.RootReference.Child("games").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogError(task.Exception);
            }

            //here we get the result from our database.
            DataSnapshot snap = task.Result;

            //And send the json data to a function that can update our game.
            LoadState(snap.GetRawJsonValue());
        });
    }

    public void LoadState(string test)
    {
        Debug.Log(JsonUtility.FromJson<MyRolledDice>(test));


        //MyRolledDice myRolled = new MyRolledDice();
        //var playerInfo = JsonUtility.FromJson<MyRolledDice>(test);


        //for (int i = 0; i < 5; i++)
        //{
        //    diceOnBoard[i] = playerInfo.playerRolls[i];

        //}
        //for (int i = 0; i < 5; i++)
        //{
        //    diceOnBoard[i] = myRolled.playerRolls[i];

        //}




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
}
