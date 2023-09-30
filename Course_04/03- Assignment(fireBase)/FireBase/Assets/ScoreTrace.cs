using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Firebase;
using Firebase.Auth;
using Firebase.Database;

[Serializable]
public class RecordedStats
{
    public Vector2 position;
    public string name;
    public int points;
}
public class ScoreTrace : MonoBehaviour
{

    public TextMeshProUGUI textMeshPro;
    private pointListener _pointListener;


    // Start is called before the first frame update
    void Start()
    {
        _pointListener = FindAnyObjectByType<pointListener>();
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        textMeshPro.text = "gerg" + _pointListener.points;
        RecordMyStats();
    }
    public void RecordMyStats()
    {
        var newStats = new RecordedStats();
        newStats.position = this.transform.position;
        
       // newStats.name=
    }

    public void GetMyStats()
    {

    }
}
