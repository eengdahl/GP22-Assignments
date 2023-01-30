using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;


[Serializable]
public class MyRolledDice
{
    int playerID;
    public int[] playerRolls;
}



public class MyDiceHandler : MonoBehaviour
{
    int startdice;
    int diceLeft;

    public GameObject[] startPositions;
    public GameObject player;
    public GameObject dice;

    MyRolledDice myRolledDice;


    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;

        startdice = 3;
        diceLeft = startdice;
        RollDice(diceLeft);

        FireBaseSaver.Instance.AddPlayerToGame(this.gameObject);
    }



    // Update is called once per frame
    void Update()
    {

    }


    void RollDice(int NrOfDiceRolled)
    {

        for (int i = 0; i < NrOfDiceRolled; i++)
        {
            Instantiate(dice, startPositions[i].transform.position, Quaternion.identity, player.transform);

            //opens solution
            dbRef.Child("players").Child(playerID.ToString()).Child("rolls").Child(playerID.ToString()).SetValueAsync(roll);
        }
    }

}
