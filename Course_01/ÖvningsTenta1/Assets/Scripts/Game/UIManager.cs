using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lifeSprite;
    public UnityEngine.UI.Image life;
    public UnityEngine.UI.Image shield;

    private void Start()
    {
        shield.enabled = false;
    }

    public void UpdateLifeImage(int currentLife)
    {
        life.sprite = lifeSprite[currentLife];
    }


    public void Shield(bool active)
    {
        shield.enabled = active;
    }
}
