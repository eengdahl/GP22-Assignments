using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Database;
using System.Data;
using Firebase;
using Firebase.Extensions;

public class PlayerSetup : MonoBehaviour
{

    public List<Sprite> playerSprites;
    SpriteRenderer playerSR;
    FirebaseDatabase db;
    FirebaseAuth auth;
    // Start is called before the first frame update
    void Start()
    {
        playerSR = GetComponent<SpriteRenderer>();

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogError(task.Exception);

            auth = FirebaseAuth.DefaultInstance;
            FirebaseSaveManager.Instance.LoadData("users/" + SignInScript.Instance.GetUserID, playerSprite);

        });

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playerSprite(DataSnapshot snapshot)
    {
        var loadeduser = JsonUtility.FromJson<UserInfo>(snapshot.GetRawJsonValue());
        float tempcolor = loadeduser.color;
        int temp = loadeduser.sprite;
        playerSR.sprite = playerSprites[temp];
        playerSR.color = Color.HSVToRGB(tempcolor, 1f, 1f);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gas"))
        {
            Debug.Log("Gas");
            Destroy(other.gameObject);
        }
    }

}
