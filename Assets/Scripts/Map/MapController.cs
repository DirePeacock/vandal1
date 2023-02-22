using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    public Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement pm;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDist; //Must be greater than the length and width of the tilemap
    float opDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;


    // Start is called before the first frame update
    void Start () {
        pm = FindObjectOfType<PlayerMovement> ();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        ChunkOptimzer();
    }

    void ChunkChecker()
    {
        if(!currentChunk)
        {
            // Debug.Log("No current chunk");
            return;
        }
        
        if (pm.movementDirection.x > 0 && pm.movementDirection.y == 0) {
            CheckChunk("East_CT");
        } else if (pm.movementDirection.x < 0 && pm.movementDirection.y == 0) {
            CheckChunk("West_CT");
        } else if (pm.movementDirection.y > 0 && pm.movementDirection.x == 0) {
            CheckChunk("North_CT");
        } else if (pm.movementDirection.y < 0 && pm.movementDirection.x == 0) {
            CheckChunk("South_CT");
        } else if (pm.movementDirection.x > 0 && pm.movementDirection.y > 0) {
            CheckChunk("NorthEast_CT");
        } else if (pm.movementDirection.x > 0 && pm.movementDirection.y < 0) {
            CheckChunk("SouthEast_CT");
        } else if (pm.movementDirection.x < 0 && pm.movementDirection.y > 0) {
            CheckChunk("NorthWest_CT");
        } else if (pm.movementDirection.x < 0 && pm.movementDirection.y < 0) {
            CheckChunk("SouthWest_CT");
        }
        // Debug.Log("Current chunk is " + currentChunk.transform.ToString());
    }
    void CheckChunk(string chunk_trigger_str)
    {
        if (!Physics2D.OverlapCircle (currentChunk.transform.Find(chunk_trigger_str).position, checkerRadius, terrainMask)) {
                noTerrainPosition = currentChunk.transform.Find(chunk_trigger_str).position; 
                SpawnChunk ();
                // Debug.Log("spawning " + chunk_trigger_str + " chunk at "  + noTerrainPosition.ToString());
            }
    }

    void SpawnChunk()
    {
        // spawn a random chunk at the noTerrainPosition
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
        // Debug.Log("Spawned chunk at " + noTerrainPosition.ToString());
        spawnedChunks.Add(latestChunk);
    }

    void ChunkOptimzer () {
        optimizerCooldown -= Time.deltaTime;

        if (optimizerCooldown <= 0f) {
            optimizerCooldown = optimizerCooldownDur; //Check every 1 second to save cost, change this value to lower to check more times
        } else {
            return;
        }

        foreach (GameObject chunk in spawnedChunks) {
            opDist = Vector3.Distance (player.transform.position, chunk.transform.position);
            
            if (opDist > maxOpDist) {
                chunk.SetActive (false);
                // Debug.Log("opDist is " + opDist.ToString());
            } else {
                chunk.SetActive (true);
            }
        }
    }
}