using UnityEngine;
using UnityEngine.UIElements;

public class Meteor : MonoBehaviour
{
    public float speed = 1;
    public int health;
    public float timer = 0;
    public GameObject split;
    public GameObject Hit;
    public GameObject Explosion;
    ScoreController scoreController;
    PowerUp powerUp;
    Vector2 positionDeath;

    void Start()
    {

        //Set a start speed
        GetComponent<Rigidbody2D>().velocity = -transform.up * speed;

        //Set health of diffrent meteor
        if (gameObject.name == ("MeteorBig(Clone)"))
        {
            health = 5;
        }
        if (gameObject.name == ("MeteorMedium(Clone)"))
        {
            health = 3;
        }
        if (gameObject.name == ("MeteorSmall(Clone)"))
        {
            health = 1;
        }

        //Accesing scoreController for adding score 
        scoreController = FindObjectOfType<ScoreController>();

        //Accesing PowerUp for spawning powerups
        powerUp = FindObjectOfType<PowerUp>();
    }


    private void Update()
    {
        //Set timer for each Meteor
        timer += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //bullet hit the asteroid
        if (other.gameObject.CompareTag("Bullet"))
        {
            //Remove bullet
            Destroy(other.gameObject);

            //Make asteroid invincible first 0.1 secounds
            if (timer < 0.1f)
            {
                return;
            }

            //Spawn hit effect
            Vector3 hitPoint = (other.transform.position + transform.position) / 2;
            var newHit = Instantiate(Hit, hitPoint, Quaternion.identity);
            Destroy(newHit, 0.5f);

            //updating asteroid health
            health--;

            //return if not on last healthpoint
            if (health > 0)
            {
                return;
            }

            //Medium asteroid was destroyed 
            if (gameObject.name == ("MeteorSmall(Clone)"))
            {
                positionDeath = new Vector2(transform.position.x, transform.position.y);
                powerUp.SpawnPowerUp(positionDeath);
            }

            //Add score for each destroyed Asteroid
            scoreController.AddScore(100);

            //Spawn new asteroids
            if (split != null)
            {
                Instantiate(split, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 30));
                Instantiate(split, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 30));
            }

            //Spawn explostion effect
            var newExplosion = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(newExplosion, 0.5f);

            //Destroy asteroid
            Destroy(gameObject);
        }
    }
}
