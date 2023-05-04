using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObjects : MonoBehaviour
{
    [SerializeField] private GameObject fallPrefab;
    [SerializeField] private int poolSize = 100;
    [SerializeField] private float spawnTime = 0.5f;
    private float timeElapsed;
    [SerializeField] private float minXPosition =-7.0f;
    [SerializeField] private float maxXPosition =7.0f;
    [SerializeField] private float minZPosition = -3000f;
    [SerializeField] private float maxZPosition = -9000f;
     
    private int obstacleCount;
    private GameObject[] fall;
    // Start is called before the first frame update
    void Start()
    {
        fall = new GameObject [poolSize];
         for(int i = 0 ; i< poolSize ; i++)
        {           
        
            fall[i] = Instantiate (fallPrefab);
            fall[i].SetActive(false);      
            

        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        timeElapsed += Time.deltaTime;
        
        if(timeElapsed > spawnTime)
        {
            SpawnObstacle();

        }
        
    }

    void SpawnObstacle()
    {
        timeElapsed = 0f;
        float zSpawnPosition = Random.Range(minZPosition , maxZPosition);
        float xSpawnPosition = Random.Range(minXPosition , maxXPosition);
        Vector3 spawnPosition = new Vector3(xSpawnPosition,20,zSpawnPosition);
        fall[obstacleCount].transform.position = spawnPosition;

        if(!fall[obstacleCount].activeSelf)
        {
            fall[obstacleCount].SetActive(true);


        }
        
        obstacleCount++;

        if(obstacleCount == poolSize)
        {
            obstacleCount = 0;

        }
    }
}
