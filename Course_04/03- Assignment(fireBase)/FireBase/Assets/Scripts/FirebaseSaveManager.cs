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
    public delegate void OnMultipleLoadedDelegate<T>(List<T> dataList);
    public delegate void OnSaveDelegate();
    public delegate void OnPushDelegate();
    public delegate void OnCleanDelegate();



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

    public void LoadMultipleData<T>(string path, OnMultipleLoadedDelegate<T> onLoadedDelegate)
    {
        db.RootReference.Child(path).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogWarning(task.Exception);

            var child = new List<T>();

            foreach (var item in task.Result.Children)
                child.Add(JsonUtility.FromJson<T>(item.GetRawJsonValue()));

            onLoadedDelegate(child);
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

    public void CleanData(string path, OnCleanDelegate onCleanDelegate = null)
    {
        db.RootReference.Child(path).RemoveValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogWarning(task.Exception);

            //Call our delegate if it's not null
            onCleanDelegate?.Invoke();
        });
    }

    public void PushData(string path, string data, OnPushDelegate onPushDelegate = null)
    {

        db.RootReference.Child(path).Push().SetRawJsonValueAsync(data).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogWarning(task.Exception);

            //Call our delegate if it's not null
            onPushDelegate?.Invoke();
        });
    }


}
