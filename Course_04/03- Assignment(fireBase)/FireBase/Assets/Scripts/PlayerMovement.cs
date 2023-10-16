using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    pointListener points;
    Vector3 playerPosition;
    float speed = 5f;
    Rigidbody2D rb;
    public int score;
    public GameObject spawnTrace;


    public Button up, down, left, right, dropPoint;

    void Start()
    {
        points = FindObjectOfType<pointListener>();
        score = 0;
        rb = GetComponent<Rigidbody2D>();
        playerPosition = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z);

        up.onClick.AddListener(Up);
        down.onClick.AddListener(Down);
        left.onClick.AddListener(Left);
        right.onClick.AddListener(Right);
        dropPoint.onClick.AddListener(Drop);

    }
    void Left()
    {
        playerPosition.x -= speed * 2 * Time.deltaTime;
    }
    void Right()
    {
        playerPosition.x += speed * 2 * Time.deltaTime;
    }
    void Up()
    {
        playerPosition.y += speed * 2 * Time.deltaTime;
    }
    void Down()
    {
        playerPosition.y -= speed * 2 * Time.deltaTime;
    }
    void Drop()
    {
        Instantiate(spawnTrace, transform.position, transform.rotation);
        spawnTrace.GetComponent<ScoreTrace>().PlayerSpawned(this.transform.position);
    }

    private void Update()
    {


        if (Input.GetKey(KeyCode.A))
        {
            playerPosition.x -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerPosition.x += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            playerPosition.y += speed / 2 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerPosition.y -= speed / 2 * Time.deltaTime;
        }

        rb.transform.position = playerPosition;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(spawnTrace, transform.position, transform.rotation);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coin"))
        {
            score += 100;
            points.updateScore();

        }
    }
}
