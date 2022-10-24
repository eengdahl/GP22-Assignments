using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class shieldMovement : MonoBehaviour
{
    public GameObject player;
    public Vector2 movement;


    //public void Update()
    //{
    //    player.GetComponent<Transform>();
    //    transform.position = player.transform.position;
    //}

    public void UpdatePositionSheild(float positionX, float positionY)
    {
        movement = new Vector2(positionX, positionY);
        transform.position = movement;
    }
}
    



