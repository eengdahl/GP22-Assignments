using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
 

    void Start()
    {
     

    }

    void Update()
    {

        //get mouse postion pixel vector
        Vector2 mousePos = Input.mousePosition;

        //Use the camera to convert pixel postion to world position
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //Set our position to the mouse world position
        // transform.position = mousePos;

        ////We don't need to multiply with Time.deltaTime since it's already the right unit.


        transform.up = (Vector3)mousePos - transform.position;
    }
}