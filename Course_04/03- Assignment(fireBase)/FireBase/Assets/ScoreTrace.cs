using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

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

    private string resterPath;
    private string resterString;



    public void PlayerSpawned(Vector2 playerPosition)
    {
        _pointListener = FindAnyObjectByType<pointListener>();
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        textMeshPro.text = SignInScript.Instance.playername.ToString() + _pointListener.points;
        RecordMyStats( playerPosition);
    }
    public void GameSpawned(string name, int points)
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        textMeshPro.text = name + points;
    }

    public void RecordMyStats(Vector2 playerPosition)
    {
        var newStats = new RecordedStats();

        newStats.position = playerPosition;
        newStats.name = SignInScript.Instance.playername;
        newStats.points = _pointListener.points;

        string jsonString = JsonUtility.ToJson(newStats);

        PushToFireBase(jsonString, "/messages");

    }

    //void CleanFireBase(RecordedStats sendStats)
    //{
    //    //empty last message
    //    string path = /*/"users/" + SignInScript.Instance.GetUserID +/*/ "/messages";
    //    string jsonString = JsonUtility.ToJson(sendStats);

    //    resterPath = path;
    //    resterString = jsonString;

    //    FirebaseSaveManager.Instance.CleanData(path, Rester);

    //}
    //void Rester()
    //{
    //    Debug.Log("ping");

    //    PushToFireBase(resterString, resterPath);
    //}

    void PushToFireBase(string stats, string _path)
    {
        FirebaseSaveManager.Instance.PushData(_path, stats, GetMyStats);
    }

    public void GetMyStats()
    {
        Debug.Log("finalPing");
    }

    //Load messasges
    //Upload Messages 


    //  {"rules": { "users": { "$uid": {
    //      ".read": "$uid === auth.uid",
    //      ".write": "$uid === auth.uid" }
    //  },
    //  "games": {
    //    ".read": "auth != null",
    //    ".write": "auth != null" },
    //    "messages": {
    //     ".read": "auth != null",
    //    ".write": "auth != null" }
    //}
}
