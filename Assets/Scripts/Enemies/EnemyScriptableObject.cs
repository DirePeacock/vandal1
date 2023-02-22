using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ActorScriptableObject
{
    [SerializeField]
    float damage;
    public float Damage { get => damage; private set => damage = value; }
    
    [SerializeField]
    float experieceReward;
    public float ExperieceReward { get => experieceReward; private set => experieceReward = value; }
}

