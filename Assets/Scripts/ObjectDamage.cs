using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamage : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void TakeDamage(float dmg)
    {
    
        Kill();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
