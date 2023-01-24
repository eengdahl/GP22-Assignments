using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System;


[Serializable]
public class TestDice
{
    public int nr;
}

public class FireBaseTest : MonoBehaviour
{
    FirebaseAuth auth;

    void Start()
    {
         
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogError(task.Exception);

            auth = FirebaseAuth.DefaultInstance;

            if (auth.CurrentUser ==null)
            {
                AnonymousSignIn();
            }
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            AnonymousSignIn();



        if (Input.GetKeyDown(KeyCode.D))
            DataTest(auth.CurrentUser.UserId, UnityEngine.Random.Range(0, 100).ToString());

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadFromFirebase();
        }
    }

    private void AnonymousSignIn()
    {
        auth.SignInAnonymouslyAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogWarning(task.Exception);
            }
            else
            {
                FirebaseUser newUser = task.Result;
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
            }
        });
    }

    private void DataTest(string userID, string data)
    {
        Debug.Log("Trying to write data...");
        var db = FirebaseDatabase.DefaultInstance;
        db.RootReference.Child("users").Child(userID).SetRawJsonValueAsync(data).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogWarning(task.Exception);
            else
                Debug.Log("DataTestWrite: Complete");
        });


    }
    private void LoadFromFirebase()
    {
        var db = FirebaseDatabase.DefaultInstance;
        var userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        db.RootReference.Child("users").Child(userId).GetValueAsync().ContinueWithOnMainThread(task =>
        {
        if (task.Exception != null)
        {
            Debug.LogError(task.Exception);
        }

        //here we get the result from our database.
        DataSnapshot snap = task.Result;

        //And send the json data to a function that can update our game.
        Debug.Log((snap.GetRawJsonValue()));

            //load json from server 
            //V�rde = JsonUtility.FromJson("n�gon int") > (snap.GetRawJsonValue()));
         
        });
    }
}