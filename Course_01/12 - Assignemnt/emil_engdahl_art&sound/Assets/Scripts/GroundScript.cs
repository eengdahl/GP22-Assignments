using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();

            Destroy(other.gameObject);
        }   
    }
}
