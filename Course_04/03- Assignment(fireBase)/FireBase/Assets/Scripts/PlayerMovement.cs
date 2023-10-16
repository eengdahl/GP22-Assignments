using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Touch theTouch;
    private Vector2 touchStartPos, touchEndPos;
    private string dir;
    pointListener points;
    GameObject player;
    Vector3 playerPosition;
    float speed = 5f;
    Rigidbody2D rb;
    public int score;
    public GameObject spawnTrace;


    public Button up, down, left, right, dropPoint;
    // Start is called before the first frame update
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
        Debug.Log("ping");
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
            // spawnTrace.GetComponent<ScoreTrace>().PlayerSpawned();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coin"))
        {
            score += 100;
            points.updateScore();

            // Destroy(other.gameObject);
        }
    }
}
//if (Input.touchCount > 0)
//{
//    theTouch = Input.GetTouch(0);
//    if (theTouch.phase == TouchPhase.Began)
//    {
//        touchStartPos = theTouch.position;
//    }

//}
//else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
//{
//    touchEndPos = theTouch.position;
//    float x = touchEndPos.x - touchStartPos.x;
//    float y = touchEndPos.y - touchStartPos.y;

//    if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
//    {
//        dir = "Tapped";
//    }
//    else if (Mathf.Abs(x) > Mathf.Abs(y))
//    {
//        dir = x > 0 ? "Up" : "Down";
//    }
//    //Set player x pos 

//}