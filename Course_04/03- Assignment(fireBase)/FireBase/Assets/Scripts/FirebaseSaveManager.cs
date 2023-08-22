using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;
using Firebase.Database;
using Unity.VisualScripting;

public class FirebaseSaveManager : MonoBehaviour
{

    private static FirebaseSaveManager _instance;
    public static FirebaseSaveManager Instance { get { return _instance; } }

    public delegate void OnLoadedDelegate(DataSnapshot snapshot);
    // public delegate void OnLoadedDelegate<T>(List<T> dataList);
    public delegate void OnSaveDelegate();

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

        db = FirebaseDatabase.DefaultInstance;
        db.SetPersistenceEnabled(false);
    }

    public void LoadData(string path, OnLoadedDelegate onLoadDelegate)
    {
        db.RootReference.Child(path).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogWarning(task.Exception);
            }
            onLoadDelegate(task.Result);

        });
    }

    public void SaveData(string path, string data, OnSaveDelegate onSaveDelegate = null)
    {
        db.RootReference.Child(path).SetRawJsonValueAsync(data).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogWarning(task.Exception);

            //Call our delegate if it's not null
            onSaveDelegate?.Invoke();
        });
    }


}
