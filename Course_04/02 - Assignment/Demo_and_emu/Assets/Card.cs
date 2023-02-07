using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// The CreateAssetMenu attribute makes adds the "Card" option
// In the "Create" menu in the Unity Editor
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite artwork;
    public int manaCost;
    public int attack;
    public int health;
    [SerializeField] private Card testCard;
    [SerializeField] private UnityEvent<int> test;

}


