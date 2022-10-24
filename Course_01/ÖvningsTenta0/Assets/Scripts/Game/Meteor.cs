using System.Text;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.SocialPlatforms.Impl;

public class Meteor : MonoBehaviour
{
    public float speed = 1;
    public int asteroidLife;
    public float invincebility = 0.1f;
    public float timer = 0;
    public bool wasDestroyed = false;
    public GameObject split;
    public GameObject Hit;
    public GameObject Explosion;
    GameObject gameControllers;

    public SpriteRenderer spriteRenderer;
    string meteorName = "null";



    void Start()
    {
        //Set a start speed
        // GetComponent<Rigidbody2D>().velocity = -transform.up * speed;

        var spawner = FindObjectOfType<MeteorSpawner>();


        //Set asteroidlife for all meteor
        gameControllers = GameObject.FindWithTag("GameController");
        meteorName = spriteRenderer.name;

        if (meteorName == "MeteorBig(Clone)")
        {
            asteroidLife = 5;
        }
        if (meteorName == "MeteorMedium(Clone)")
        {
            asteroidLife = 3;
        }
        if (meteorName == "MeteorSmall(Clonse)")
        {
            asteroidLife = 1;
        }

    }

    public void Update()
    {
        //Make asteroid invinceble for the first 0.1s
        timer += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //bullet hit the asteroid
        if (other.gameObject.CompareTag("Bullet"))
        {

            //Spawn hit effect
            Vector3 hitPoint = (other.transform.position + transform.position) / 2;
            var newHit = Instantiate(Hit, hitPoint, Quaternion.identity);
            Destroy(newHit, 0.5f);

            //Remove bullet
            Destroy(other.gameObject);

            //Bullet dont hurt Asteroid until invincebility is finished
            while (timer < invincebility)
            {
                return;
            }

            //asteroid health system
            asteroidLife--;
            if (asteroidLife > 0)
            {
                return;
            }

            //Add score
            gameControllers.GetComponent<ScoreController>().AddScore(100);

            //Asteroid was destroyed


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

            //gameControllers.GetComponent<MeteorSpawner>().MeteorCounter();

            if (meteorName == "MeteorMedium(Clone)")
            {
                gameControllers.GetComponent<PowerUp>().SpawnPowerUp(transform.position.x, transform.position.y);

            }


        }
    }
}
