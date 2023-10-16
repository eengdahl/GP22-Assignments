using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase.Auth;
using Firebase;
using Firebase.Extensions;
using System.Diagnostics.SymbolStore;
using UnityEngine.SceneManagement;

public class SignInScript : MonoBehaviour
{
    private static SignInScript _instance;
    public static SignInScript Instance { get { return _instance; } }

    public TMP_InputField email;
    public TMP_InputField password;
    public TextMeshProUGUI status;

    public string playername;

    public Button playButton;

    FirebaseAuth auth;
    public string GetUserID { get { return auth.CurrentUser.UserId; } }

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
            return;
        }

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogError(task.Exception);

            auth = FirebaseAuth.DefaultInstance;



            if (auth.CurrentUser == null)
            {
              //  AnonymousSignIn();
                Debug.Log("anonym sign in0");
            }
            else
            {
                Debug.Log(auth.CurrentUser.Email + "is logged in");
                playButton.interactable = true;
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
                FirebaseUser newUser = task.Result.User;
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
                playButton.interactable = true;
            }
        });
    }

    public void SignInButton()
    {
        SignIn(email.text, password.text);
    }


    private void SignIn(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogWarning(task.Exception);
            }
            else
            {
                FirebaseUser newUser = task.Result.User;
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                  newUser.DisplayName, newUser.UserId);
                status.text = newUser.Email + "is signed in";
                playButton.interactable = true;
            }
        });
    }

    public void RegisterButton()
    {
        RegisterNewUser(email.text, password.text);
    }

    private void RegisterNewUser(string email, string password)
    {
        status.text = "Starting Registration";
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                status.text = "Registration Failed";
                Debug.LogWarning(task.Exception);
                return;
            }
            else
            {
                FirebaseUser newUser = task.Result.User;
                Debug.LogFormat("User Registerd: {0} ({1})",
                  newUser.DisplayName, newUser.UserId);
                status.text = "User Registerd";

                playButton.interactable = true;
            }
        });

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }


    public void debuglogin(int number)
    {
        SignIn("test" + number + "@test.test", "password");
    }
}
