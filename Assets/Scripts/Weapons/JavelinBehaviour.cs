using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinBehaviour : ProjectileWeaponBehaviour
{

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        transform.position += direction * weaponData.Speed * Time.deltaTime;    //Set the movement of the knife
        
    }
}
