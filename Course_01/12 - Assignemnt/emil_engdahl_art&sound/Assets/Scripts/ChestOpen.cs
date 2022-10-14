using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestOpen : MonoBehaviour
{

    Animator animator;
    public void OnHoverEnter()
    {
        Debug.Log("Enter");
        animator = GetComponent<Animator>();
        animator.SetBool("mouseHover", true);
    }

    public void OnHoverExit()
    {
        Debug.Log("Exit");
        animator.SetBool("mouseHover", false);
    }
}
