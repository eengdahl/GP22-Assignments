using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform player;
    Vector3 playerPosition;

    void Update()
    {
        playerPosition = new Vector3(player.position.x, player.position.y, -10);
        transform.position = playerPosition;
    }
}
