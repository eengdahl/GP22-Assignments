using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteor;
	public GameObject player;
    public int amount = 10;

	float width, height;

    void Start()
	{
		//Get screen size
		width = Camera.main.orthographicSize * Camera.main.aspect;
		height = Camera.main.orthographicSize;

		//Spawn the first wave
		SpawnWave(amount);
	}

	private void SpawnWave(int numberOfAsteroids)
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
		if (Mathf.RoundToInt(randomPosition.y) == Mathf.RoundToInt(player.transform.position.y) || Mathf.RoundToInt(randomPosition.x) == Mathf.RoundToInt(player.transform.position.x))
		{
			return;
		}

		Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360f));

		Instantiate(meteor, randomPosition, randomRotation, transform);
	}
}
