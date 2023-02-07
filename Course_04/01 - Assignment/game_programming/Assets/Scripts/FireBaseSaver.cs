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

    //Function that gets called after load or save
    public delegate void OnLoadedDelegate(DataSnapshot snapshot);
    public delegate void OnSaveDelegate();

    public List<GameObject> playerActive;
    public List<string> playersActive;
    public int playerCounter;
    public string seed;
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

        playersActive = new List<string>();




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

    public int AddPlayerToGame(string player)
    {

        playersActive.Add(player);
        playerCounter = playerActive.Count;
        return playerCounter;
    }

    public string GetActivePlayerName()
    {
        return playersActive[0];
    }


    public void LoadData(string path, OnLoadedDelegate onLoadedDelegate)
    {
        db.RootReference.Child("games").Child(path).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogWarning(task.Exception);

            foreach (var item in task.Result.Children)
            {
                //Send our result (datasnapshot) to whom asked for it.
                onLoadedDelegate(item);
            }
        });
    }

    //loads the data at "path" then returns json result to the delegate/callback function
    public void LoadSingelData(string path, OnLoadedDelegate onLoadedDelegate)
    {
        db.RootReference.Child("games").Child(path).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogWarning(task.Exception);

            //Send our result (datasnapshot) to whom asked for it.
            onLoadedDelegate(task.Result);
        });
    }



    //Save the data at the given path, save callback optional
    public void SaveData(string path, string data, OnSaveDelegate onSaveDelegate = null)
    {
        db.RootReference.Child("games").Child(path).SetRawJsonValueAsync(data).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogWarning(task.Exception);

            //Call our delegate if it's not null
            onSaveDelegate?.Invoke();
        });
    }

    //Save the data at the given path, save callback optional
    public void PushData(string path, string data, OnSaveDelegate onSaveDelegate = null)
    {
        db.RootReference.Child("games").Child(path).Push().SetRawJsonValueAsync(data).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogWarning(task.Exception);

            //Call our delegate if it's not null
            onSaveDelegate?.Invoke();
        });
    }

    public void RemoveData(string path)
    {
        db.RootReference.Child(path).RemoveValueAsync();
    }

}
