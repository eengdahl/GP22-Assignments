using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public bool myBool = false;
    public int myInt = 1;
    public float myFloat = 0.5f;
    public string myString =  "hello world";
    public string[] myStringArray = { "Hello wold", "hå", "Hej" };

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (myBool == false)
        {
            Debug.Log("myBool set False");
            myInt = 5;
        }

        if (myInt <= 5)
        {
            Debug.Log("myInt <= 5");
            myBool = true;
        }
    }

    int CountToFive()
    {
        for (int i = 0; i < 4; i++)
        {
            myInt++;   
        }

        foreach (var item in myStringArray)
        {

        }


        return myInt;


    }

    void myBoolIsTrue()   
    {
        while (myBool == true)
        {
            Debug.Log("MyBool Is True");
        }
   
    }
}
