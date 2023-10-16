using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;
using TMPro;
using Firebase.Database;

public class SetUpMap : MonoBehaviour
{
    public GameObject ScoreTrace;
    RecordedStats scoreStats;


    // Start is called before the first frame update
    void Start()
    {
        //spawn pointers
        FirebaseSaveManager.Instance.LoadMultipleData<RecordedStats>("/messages", InstantiateScoreTrace);

    }

    //void GetFromFirebase()
    //{
    //    foreach (var item in collection)
    //    {
    //        InstantiateScoreTrace();
    //    }
    //}


    void InstantiateScoreTrace(List<RecordedStats> Scores)
    {
        foreach (var item in Scores)
        {
            var newScoreTrace = Instantiate(ScoreTrace, item.position, transform.rotation);


            newScoreTrace.transform.localPosition = item.position;
            newScoreTrace.gameObject.GetComponent<ScoreTrace>().GameSpawned(item.name, item.points);
        }

        //var temp = JsonUtility.FromJson<RecordedStats>(Scores.GetRawJsonValue());
        //Debug.Log(temp.position);
        //Debug.Log(temp.name);
        //Debug.Log(temp.points);

        //Instantiate(ScoreTrace, temp.position, transform.rotation);
        //ScoreTrace.GetComponent<ScoreTrace>().GameSpawned(temp.name, temp.points);

    }
}
