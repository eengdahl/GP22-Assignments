using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    //Singleton structure variables
    private static SaveManager _instance;
    public static SaveManager Instance { get { return _instance; } }

    //Singleton data variables
    //Not part of the singleton structure
    public List<GameObject> Items = new List<GameObject>(); // Items are put here

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
    }
}
