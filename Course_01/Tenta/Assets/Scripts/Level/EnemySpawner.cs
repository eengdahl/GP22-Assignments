using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyTank;
    int initialSpawns = 6;
    Vector3 randomPosition;

    float width;
    float height;


    void Start()
    {
        width = Camera.main.orthographicSize * Camera.main.aspect;
        height = Camera.main.orthographicSize;
        SpawnWave(initialSpawns);
    }

    public void SpawnWave(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (i == 0)
            {
                randomPosition.y = Random.Range(width, width * 2);
                randomPosition.x = Random.Range(height, height * 2);
            }
            if (i == 1)
            {
                randomPosition.y = Random.Range(-width, -width * 2);
                randomPosition.x = Random.Range(height, height * 2);
            }
            if (i == 2)
            {
                randomPosition.y = Random.Range(-width, -width * 2);
                randomPosition.x = Random.Range(-height, -height * 2);
            }
            if (i == 3)
            {
                randomPosition.y = Random.Range(width, width * 2);
                randomPosition.x = Random.Range(-height, -height * 2);
            }
            if (i == 4)
            {
                randomPosition.y = Random.Range(width, width * 2);
                randomPosition.x = Random.Range(height, height * 2);
            }
            if (i == 5)
            {
                randomPosition.y = Random.Range(-width, -width * 2);
                randomPosition.x = Random.Range(height, height * 2);
            }
            if (i == 6)
            {
                randomPosition.y = Random.Range(width, width * 2);
                randomPosition.x = Random.Range(-height, -height * 2);
            }


            Instantiate(enemyTank, randomPosition, Quaternion.Euler(0, 0, Random.Range(0, 360f)));
        }

    }
}
