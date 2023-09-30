using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{

    public GameObject coinPrefab;
    Vector3 spawnposition;
    public LinkedList<GameObject> _freeCoin = new LinkedList<GameObject>();

    public int maxCoins = 10;
    void Start()
    {

        InvokeRepeating("SpawnCoin", 1, 100);
        spawnposition = this.transform.position;
        spawnposition.z = 1;
    }

    private void OnDisable()
    {
        foreach (var coin in _freeCoin)
            Destroy(coin);

        _freeCoin.Clear();
    }

    public GameObject CreateCoin()
    {
        //if we don't have any free bullets, create a new bullet instead.
        if (_freeCoin.Count == 0)
            return Instantiate(coinPrefab);

        //return the first free bullet from our list
        var freeCoinNode = _freeCoin.First;
        var coin = freeCoinNode.Value;
        _freeCoin.Remove(freeCoinNode);
        coinPrefab.SetActive(true);
        return coinPrefab;
    }

    public void SpawnCoin()
    {
        Debug.Log(_freeCoin.Count);
        CreateCoin();
        spawnposition.x = Random.Range(-10, 10);

        coinPrefab.transform.position = spawnposition;
        Invoke("SpawnCoin", 0.4f);

    }
    public void DestroyCoin(GameObject coin)
    {
        if (_freeCoin.Count == maxCoins)
        {
            Destroy(coin);
            return;
        }

        coin.transform.parent = null;
        coin.SetActive(false);
        _freeCoin.AddFirst(coin);
    }
}






