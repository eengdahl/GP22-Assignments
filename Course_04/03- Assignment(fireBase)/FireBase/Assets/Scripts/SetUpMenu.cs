using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase.Database;
using System;
using UnityEngine.SceneManagement;

public class SetUpMenu : MonoBehaviour
{
    public TMP_InputField playerName;
    public Image spriteImage;
    public Slider colorSlider;
    public Slider spriteSlider;
    public Sprite[] sprites;
    public Button playButton;
    // Start is called before the first frame update
    void Start()
    {
        colorSlider.onValueChanged.AddListener(ColorUpdate);
        spriteSlider.onValueChanged.AddListener(SpriteUpdate);
        playButton.onClick.AddListener(ButtonClick);

        FirebaseSaveManager.Instance.LoadData("users/" + SignInScript.Instance.GetUserID, UserLoaded);

    }

    private void UserLoaded(DataSnapshot snapshot)
    {
        var loadeduser = JsonUtility.FromJson<UserInfo>(snapshot.GetRawJsonValue());
        colorSlider.value = loadeduser.color;
        spriteSlider.value = loadeduser.sprite;
        playerName.text = loadeduser.name;
    }


    public void ButtonClick()
    {
        var user = new UserInfo();
        user.color = colorSlider.value;
        user.sprite = (int)spriteSlider.value;
        user.name = playerName.text;

        string jsonString = JsonUtility.ToJson(user);
        string path = "users/" + SignInScript.Instance.GetUserID;
        FirebaseSaveManager.Instance.SaveData(path, jsonString);
        SceneManager.LoadScene(2);
    }
    private void ColorUpdate(float arg0)
    {
        spriteImage.color = Color.HSVToRGB(arg0, 1f, 1f);
    }

    private void SpriteUpdate(float arg0)
    {
        int index = (int)arg0;
        spriteImage.sprite = sprites[index];
    }
}
