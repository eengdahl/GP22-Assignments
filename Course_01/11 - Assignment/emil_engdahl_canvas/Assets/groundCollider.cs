using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class groundCollider : MonoBehaviour
{
    public PlayerMovement playerMovement;



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            playerMovement.IsGrounded(true);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            playerMovement.IsGrounded(false);
        }
    }



    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerMovement.collisionPlayer = true;
        }
    }

}
