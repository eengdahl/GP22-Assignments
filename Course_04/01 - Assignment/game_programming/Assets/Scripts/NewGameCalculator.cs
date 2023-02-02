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
    public int one, two, three, four, five, six;

    MyRolledDice myRolledDice;
    DataSnapshot snapshot;
    int buffer = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        //Invoke("LoadDataFromFB", 2);
    }
    void Start()
    {

        FireBaseSaver.Instance.LoadData("1111", LoadState);

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void LoadDataFromFB()
    //{
    //    var db = FirebaseDatabase.DefaultInstance;

    //    db.RootReference.Child("games").Child(FireBaseSaver.Instance.seed).GetValueAsync().ContinueWithOnMainThread(task =>
    //    {
    //        if (task.Exception != null)
    //        {
    //            Debug.LogError(task.Exception);
    //        }

    //        //here we get the result from our database.
    //        DataSnapshot snap = task.Result;

    //        //And send the json data to a function that can update our game.
    //        LoadState(snap.GetRawJsonValue());
    //    });
    //}



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
