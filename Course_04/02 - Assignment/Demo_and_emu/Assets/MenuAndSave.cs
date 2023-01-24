using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuAndSave : MonoBehaviour
{

    private const string SCORE_NAME_KEY = "SCORE_NAME_KEY";
    private const string COLOR_KEY = "COLOR_KEY";



    public Slider colorSlider;
    public TMP_InputField nameInput;
    public Button button;
    public SpriteRenderer player;

    string name;
    float color;

    void Start()
    {
        if (PlayerPrefs.HasKey(SCORE_NAME_KEY))
        {
            name = PlayerPrefs.GetString(SCORE_NAME_KEY);
            nameInput.text = name;

        }
        if (PlayerPrefs.HasKey(COLOR_KEY))
        {
            color = PlayerPrefs.GetFloat(COLOR_KEY);
            colorSlider.value = color;
            player.color = Color.HSVToRGB(PlayerPrefs.GetFloat(COLOR_KEY), 0.85f, 0.85f);


        }
        nameInput.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        colorSlider.onValueChanged.AddListener(delegate { SetNewColor(); });
    }

    void Update()
    {
        //Works if in gamemode, not simulator 

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("ping");
            PlayerPrefs.DeleteAll();
        }

    }


    private void SetNewColor()
    {
        player.color = Color.HSVToRGB(PlayerPrefs.GetFloat(COLOR_KEY), 0.85f, 0.85f);
        PlayerPrefs.SetFloat(COLOR_KEY, colorSlider.value);
    }
    public void ClickButton()
    {

    }

    public void ValueChangeCheck()
    {
        PlayerPrefs.SetString(SCORE_NAME_KEY, nameInput.text);
    }
}
