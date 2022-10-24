using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public UIHandeler handeler;
    float maxDistance = 35;
    float dist;
    Vector3 middle;
    Vector3 playerPosition;

    private void Start()
    {
        middle = new Vector3(1, 1, 1);
    }
    private void Update()
    {
        playerPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        dist = Vector3.Distance(middle, transform.position);


        if (Mathf.Abs(dist) >= 28)
        {
            Debug.Log("Warning, to close to edge");
        }

        if (Mathf.Abs(dist) >= maxDistance)
        {
            handeler.PreDeath();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Bullet"))
        {
            handeler.ShowPlayerHealth();
        }
    }


}
