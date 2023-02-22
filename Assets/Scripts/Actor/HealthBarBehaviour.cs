using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehaviour : MonoBehaviour
{
    private float displayPercentage;
    private Transform target;
    // private ActorObject actor;
    private float barDisplayWidth;
    // vector of target's position to the health bar's position
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Transform healthBar = transform.Find("HealthBar");

    }
    
    public void setSize()
    {
        // update offset based to be up half of the target's sprite height
        offset = new Vector3(0, 0.5f * target.GetComponent<SpriteRenderer>().bounds.size.y, 0);

        Vector3 localScale = new Vector3(0.5f, 0.5f, 0.5f);
        // healthBar.localScale = localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // update health bar's position to be above the target
        // 
    }
    void updatePosition()
    {
        Vector3 targetPosition = target.position;
        Vector3 healthBarPosition = targetPosition + offset;
        transform.position = healthBarPosition;
    }
}
