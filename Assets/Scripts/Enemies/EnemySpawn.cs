using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public Transform target;
    public Vector3 offset;
    
    private float halfViewportHeight;
    private float halfViewportWidth;
    private float spawn_timer = 0;
    
    // used to spawn enemies at the edge of the screen 
    // 0 will become a random number between -1 and 1
    private List<Vector3> spawn_offset_multipliers = new List<Vector3> {
        new Vector3( 0, 1, 0 ),
        new Vector3( 0, -1, 0 ),
        new Vector3( 1, 0, 0 ),
        new Vector3( -1, 0, 0 )
    };
    bool ShouldSpawn()
    {
        // check to see if it has been 5s since the last spawn
        // if so, return true
        // else return false
        bool retval = false;
        var current_time = Time.time;
        if ( current_time - spawn_timer > 5 )
        {
            spawn_timer = current_time;
            retval = true;
        }
        return retval;
    }
    void Start()
    {
        // get game unit size of the viewport
        halfViewportWidth = 2*Camera.main.orthographicSize * Camera.main.aspect;
        halfViewportHeight = 2*Camera.main.orthographicSize;
        // Debug.Log( "halfViewportWidth: " + halfViewportWidth + " halfViewportHeight: " + halfViewportHeight );
            
             
    }
    Vector3 GetSpawnPosition()
    {
        var spawn_offset_multiplier = spawn_offset_multipliers[Random.Range(0, spawn_offset_multipliers.Count)];
     
        if (spawn_offset_multiplier.x == 0)
        {
            spawn_offset_multiplier.x = Random.Range( -100, 100 )/100;
        }
        else
        {
            spawn_offset_multiplier.y = Random.Range( -100, 100 )/100;
        }

        var spawn_offset = new Vector3( halfViewportWidth * spawn_offset_multiplier.x , halfViewportHeight * spawn_offset_multiplier.y, 0 );
        
        Vector3 spawn_position = target.position + offset + spawn_offset;
        // Debug.Log( "spawn_offset_multiplier: " + spawn_offset_multiplier );
        // Debug.Log( "halfViewportWidth: " + halfViewportWidth + " halfViewportHeight: " + halfViewportHeight );
        Debug.Log( "target.position: " + target.position );
        Debug.Log( "spawn_offset: " + spawn_offset );

        
        return (spawn_position);
    }
        
    void UpdateSpawnEnemy()
    {
        if ( ShouldSpawn() )
        {
            var spawn_pos = GetSpawnPosition();
            int rand = Random.Range(0, enemyPrefabs.Count);
            GameObject enemy = Instantiate(enemyPrefabs[rand], spawn_pos, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        UpdateSpawnEnemy();
    }
}
