using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Firebase.Database;

public class SetUpMap : MonoBehaviour
{
    public GameObject ScoreTrace;

    void Start()
    {
        FirebaseSaveManager.Instance.LoadMultipleData<RecordedStats>("/messages", InstantiateScoreTrace);
    }

    void InstantiateScoreTrace(List<RecordedStats> Scores)
    {
        foreach (var item in Scores)
        {
            var newScoreTrace = Instantiate(ScoreTrace, item.position, transform.rotation);
            newScoreTrace.transform.localPosition = item.position;
            newScoreTrace.gameObject.GetComponent<ScoreTrace>().GameSpawned(item.name, item.points);
        }


    }
}
