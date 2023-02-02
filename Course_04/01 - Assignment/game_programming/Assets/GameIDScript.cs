using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameIDScript : MonoBehaviour
{
    public TMP_InputField me;
    public int seed = 1111;
    // Start is called before the first frame update
    void Start()
    {
        me = gameObject.GetComponent<TMP_InputField>();
        me.characterLimit = 4;
        me.text = "1111";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
