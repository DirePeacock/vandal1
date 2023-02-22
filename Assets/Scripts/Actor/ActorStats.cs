using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStats : MonoBehaviour
{
    // public ActorScriptableObject actorData;
    float currentHealth;
    float currentMoveSpeed;
    float currentArmor;

    public virtual void Awake()
    {
        HeroScriptableObject heroSO = GetComponent<HeroScriptableObject>();
        currentHealth = heroSO.MaxHealth;
        currentMoveSpeed = heroSO.MoveSpeed;
        currentArmor = heroSO.Armor;
    }
    
    
}
