using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TweekExample : MonoBehaviour
{
    
    public GameObject laserPrefab;
    public float x = 2;
    public float y = 3;
    public float size = 1;
    public float angle;
    public float fireRate = 0.2f;
    float timer; 
  

void Update()
    {

      if (Input.GetMouseButton(0) && timer > fireRate)
      {
            Instantiate(laserPrefab, transform.position, transform.rotation);
            Destroy(laserPrefab, 3);
            timer = 0;
      }

        timer += Time.deltaTime;

        x += Input.GetAxisRaw("Horizontal") * Time.deltaTime * 5;
        y += Input.GetAxisRaw("Vertical") * Time.deltaTime * 5;

        transform.position = new Vector3(x, y); //uppdaterar det som precis skedde 

        if (Input.GetKeyDown(KeyCode.E))
        {
            size++;
        }

        if (Input.GetKeyDown (KeyCode.Q))
        {
            size--;
        }
        transform.localScale = Vector2.one * size;  //uppdaterar det som precis skedde 

        Vector2 aim = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.up = aim;
    }


}
