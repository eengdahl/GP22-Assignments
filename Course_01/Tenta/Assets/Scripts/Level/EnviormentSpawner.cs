using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviormentSpawner : MonoBehaviour
{
    public GameObject[] enviormentObjects;

    public float area = 30;
    public float amount = 300;

	List<Vector2> points = new List<Vector2>();


    int ammocreates = 5;
    public GameObject ammo;

    Vector3 randomPosition;



    void Start()
    {


        for (int i = 0; i < ammocreates; i++)
        {
            randomPosition = new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), 0);

            Instantiate(ammo, randomPosition, Quaternion.Euler(0, 0, Random.Range(0, 360f)));
        }






        for (int i = 0; i < amount; i++)
		{
            Vector2 randomPoint = Random.insideUnitCircle * area;
			bool found = false;
			while (!found)
			{
				found = true;

				//Get a random point in two directions
				randomPoint = Random.insideUnitCircle * area;

				foreach (var point in points)
				{
					if (Vector2.Distance(point, randomPoint) < 0.5f)
					{
						found = false;
						break;
					}
				}
			}

			points.Add(randomPoint);

            int randomIndex = Random.Range(0, enviormentObjects.Length);
            Instantiate(enviormentObjects[randomIndex], randomPoint, Quaternion.identity, transform);
		}
    }
}
