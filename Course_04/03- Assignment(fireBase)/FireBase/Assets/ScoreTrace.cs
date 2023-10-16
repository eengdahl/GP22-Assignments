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


    void PushToFireBase(string stats, string _path)
    {
        FirebaseSaveManager.Instance.PushData(_path, stats);
    }


}
