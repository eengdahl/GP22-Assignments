using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{

    public GameObject gas;
    Vector3 spawnposition;
    float screenWidt;
    // Start is called before the first frame update
    void Start()
    {
        screenWidt = Screen.width / 2;
        InvokeRepeating("SpawnGas", 1, 100);
        spawnposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnGas()
    {
        spawnposition.x = Random.Range(0 - screenWidt, 0 + screenWidt);
        Instantiate(gas);
        gas.transform.position = spawnposition;

        Invoke("SpawnGas", 1);
    }
}
