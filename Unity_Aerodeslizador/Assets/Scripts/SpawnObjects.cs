
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    private float spawnRangeX = 6f;
    private float minSpawnPosZ = -4000f;
    private float maxSpawnPosZ = -3500;
    private float startDelay = 1;
    private float startIntervalMin = 0.5f;
    private float startIntervalMax = 1.0f;
    
    [SerializeField] private GameObject [] objectsPrefabs;
    
    void Start()
    {
        InvokeRepeating("SpawnerObjects", startDelay, Random.Range(startIntervalMin, startIntervalMax));
        
    }

    void  Update()
    {
        
        if(transform.position.y < -2)
        {
           Destroy(gameObject);

        }
        
        
    }

    void SpawnerObjects()
    {
        int obcjetindex = Random.Range( 0 , objectsPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range (-spawnRangeX, spawnRangeX), 200f,Random.Range(minSpawnPosZ , maxSpawnPosZ));
        Instantiate(objectsPrefabs[obcjetindex], spawnPos, objectsPrefabs[obcjetindex].transform.rotation);
    }

     

    
}
