using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;


public class SignInScript : MonoBehaviour
{
    public TMP_InputField password;
    public TMP_InputField email;
    public TextMeshProUGUI status;
    public string currentUser ;
    
    public FirebaseAuth auth;
    




    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogError(task.Exception);

            auth = FirebaseAuth.DefaultInstance;

            if (auth.CurrentUser == null)
            {
                AnonymousSignIn();
            }
        });
    }

    public void SignInButton()
    {
        SignInFirebase(email.text, password.text);
    }


    private void SignInFirebase(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogWarning(task.Exception);
                //might be a error, are we connecting with server?
                //AnonymousSignIn();
            }
            else
            {
                FirebaseUser newUser = task.Result;
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                  newUser.DisplayName, newUser.UserId);


                status.text = newUser.Email + "is signed in";

                currentUser = newUser.UserId.ToString();
                FireBaseSaver.Instance.AddPlayerToGame(currentUser);
            }
        });
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
                Debug.LogFormat("UserSugned In successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);

                currentUser = newUser.UserId.ToString();
                Debug.Log(currentUser);
            }
        });
    }
    
    public void RegisterButton()
    {
        RegisterNewUser(email.text, password.text);
    }

    private void RegisterNewUser(string email, string password)
    {
        Debug.Log("Starting Registration");
        status.text = "Starting Registration";
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogWarning(task.Exception);
            }
            else
            {
                FirebaseUser newUser = task.Result;
                Debug.LogFormat("User Registerd: {0} ({1})",
                  newUser.DisplayName, newUser.UserId);
            }
        });
    }

    public void DebugLogIn1(int nr)
    {
        SignInFirebase("test" + nr + "@test.test", "password");
    }

    public void PlayWasPressed()
    {
        FireBaseSaver.Instance.seed = "1111";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        


    }
}
