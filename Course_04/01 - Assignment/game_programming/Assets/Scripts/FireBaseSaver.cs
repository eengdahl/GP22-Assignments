using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;

public class FireBaseSaver : MonoBehaviour
{
    private static FireBaseSaver _instance;
    public static FireBaseSaver Instance { get { return _instance; } }


    public List<GameObject> playerActive;
    public int playerCounter;
    FirebaseAuth auth;
    FirebaseDatabase db;

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
        playerCounter = 0;
        playerActive = new List<GameObject>();



        //Setup for talking to firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            //Log if we get any errors from the opperation
            if (task.Exception != null)
                Debug.LogError(task.Exception);

            //the database
            db = FirebaseDatabase.DefaultInstance;
        });

    }

    public int AddPlayerToGame(GameObject player)
    {
        playerActive.Add(player);
        playerCounter = playerActive.Count;
        return playerCounter;
    }

    public int GetActivePlayers()
    {
        return playerActive.Count;
    }

    public void PlayerToDatabas(string userID, string data)
    {

        db.RootReference.Child("games").Child(userID).SetRawJsonValueAsync(data).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogWarning(task.Exception);
            else
                Debug.Log("DataTestWrite: Complete");
        });
    }
}
