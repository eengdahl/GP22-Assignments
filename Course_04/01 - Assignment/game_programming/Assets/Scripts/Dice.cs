using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    TextMeshProUGUI myText;
    public int myNumber;
    private void Awake()
    {
        myText = GetComponentInChildren<TextMeshProUGUI>();
        RollMe();
    }

    public void RollMe()
    {
        ShowNewNrRolled(Random.Range(1, 7));
    }


    public void ShowNewNrRolled(int nrRolled)
    {
        myNumber = nrRolled;
        myText.text = nrRolled.ToString();

        GetComponentInParent<MyDiceHandler>().CollectDiceRolls(this.myNumber);
    }
}
