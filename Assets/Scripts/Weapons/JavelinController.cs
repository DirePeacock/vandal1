using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedJavelin = Instantiate(weaponData.Prefab);
        spawnedJavelin.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedJavelin.GetComponent<JavelinBehaviour>().DirectionChecker(pm.lastMovedVector);   //Reference and set the direction
    }
}
