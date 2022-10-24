using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteor;
    public GameObject player;
    public GameObject meteorMedium;

    int amount = 5;
    float width, height;
    int randomSize;



    void Start()
    {
        //Get screen size
        width = Camera.main.orthographicSize * Camera.main.aspect;
        height = Camera.main.orthographicSize;

        //Spawn the first wave
        SpawnWave(amount);
    }

    private void Update()
    {
        MeteorCounter();
    }

    public void MeteorCounter()
    {
        if (GameObject.FindGameObjectWithTag("Meteor") == null)
        {
            Debug.Log("Ping");
            SpawnWave(5);
            amount = amount + 5;
        }
    }


    public void SpawnWave(int numberOfAsteroids)
    {
        //Spawn meteors
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            SpawnMeteor();
        }
    }

    private void SpawnMeteor()
    {
        Vector2 randomPosition = new Vector2();
        randomPosition.x = Random.Range(-width, width);
        randomPosition.y = Random.Range(-height, height);

        //Meteor cant spawn on player
        if (Mathf.RoundToInt(randomPosition.x) == Mathf.RoundToInt(player.transform.position.x) || Mathf.RoundToInt(randomPosition.y) == Mathf.RoundToInt(player.transform.position.y))
        {
            return;
        }


        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360f));

        //randomizing size of meteor
        if (randomSize % 5 == 1)
        {
            Instantiate(meteorMedium, randomPosition, randomRotation, transform);
        }
        else
        {
            Instantiate(meteor, randomPosition, randomRotation, transform);
        }

        randomSize++;
    }
}
