using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorScriptableObject : ScriptableObject
{
    // Each actor has a scriptable object that holds their base stats for their archetype
    // they will be instantiated into objects that have instances of the actor stats mono behaviour


    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    
    [SerializeField]
    float armor;
    public float Armor { get => armor; private set => armor = value; }

}
