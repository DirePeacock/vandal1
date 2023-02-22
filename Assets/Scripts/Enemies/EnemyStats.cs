using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : ActorStats
{
    // public EnemyScriptableObject actorData;
    //Current stats
    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;

    public override void Awake()
    {
        base.Awake();
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        Debug.Log("enemy has " + currentHealth + " health left");
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
