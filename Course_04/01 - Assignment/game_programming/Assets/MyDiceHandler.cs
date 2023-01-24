using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyDiceHandler : MonoBehaviour
{
    int startdice;
    int diceLeft;

    public Vector3 startposition;
    public Vector3 endposition;
    Vector3 direction;

    public GameObject dice;
    // Start is called before the first frame update
    void Start()
    {
        startposition = GameObject.FindGameObjectWithTag("StartPos").transform.position;
        endposition = GameObject.FindGameObjectWithTag("EndPos").transform.position;
        direction = (startposition - endposition).normalized;

        startdice = 3;
        diceLeft = startdice;
        RollDice(diceLeft);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void RollDice(int NrOfDiceRolled)
    {
        for (int i = 0; i < NrOfDiceRolled; i++)
        {
            direction.x++;
            Instantiate(dice, direction, Quaternion.identity);

        }
    }
}
