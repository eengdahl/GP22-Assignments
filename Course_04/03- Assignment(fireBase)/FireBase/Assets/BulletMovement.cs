using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMovement : MonoBehaviour
{
    float timer;
    Rigidbody2D rb;
    public float velocity = 10;

    // Start is called before the first frame update
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * velocity;

        timer += Time.deltaTime;
        if (timer > 5)
        {
            DestroyMe();
        }
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }

}
