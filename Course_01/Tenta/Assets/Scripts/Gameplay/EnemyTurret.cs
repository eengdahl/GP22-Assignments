using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
	public GameObject enemyBullet;
	public Transform gunPoint;
    public bool aim = false; //Are we aiming at the player?
	public float aimTimeBeforeFire = 1;

    Transform target;
	float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
		//find our player
        target = FindObjectOfType<TankController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
		if (aim)
		{
            transform.up = target.position - transform.position;
			timer += Time.deltaTime;

			if (timer > aimTimeBeforeFire)
			{
				Fire();
				timer = 0;
			}
		}
		else
		{
			//We are not aiming at a target, reset aim forward.
            transform.up = transform.parent.up;
		}
    }

	private void Fire()
	{
		Instantiate(enemyBullet, gunPoint.position, gunPoint.rotation);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
            aim = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			aim = false;
		}
	}
}
