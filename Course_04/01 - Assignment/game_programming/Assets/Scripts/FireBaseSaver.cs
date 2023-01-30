using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBaseSaver : MonoBehaviour
{
    private static FireBaseSaver _instance;
    public static FireBaseSaver Instance { get { return _instance; } }


    public List<GameObject> playerActive;
    public int playerCounter;

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
    }

    public void AddPlayerToGame(GameObject player)
    {

        playerActive.Add(player);
        playerCounter = playerActive.Count;
    }

    public int GetActivePlayers()
    {
        return playerActive.Count;

    }
}
