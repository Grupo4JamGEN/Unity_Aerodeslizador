using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefab;
    [SerializeField] private int poolSize = 20;
    [SerializeField] private float spawnTime = 1.0f;
    private float timeElapsed;
    [SerializeField] private float minXPosition =3.68f;
    [SerializeField] private float maxXPosition =-3.68f;
    [SerializeField] private float minYPosition = 2f;
    [SerializeField] private float maxYPosition = 4f;
    [SerializeField] private float minZPosition = -3000f;
    [SerializeField] private float maxZPosition = 50f;
     
    private int obstacleCount;
    private GameObject[] obstacles;
    // Start is called before the first frame update
    void Start()
    {
        obstacles = new GameObject [poolSize];
        for(int i = 0 ; i< poolSize ; i++)
        {
            obstacles[i] = Instantiate (obstaclePrefab[Random.Range(0, obstaclePrefab.Length)]);
            obstacles[i].SetActive(false);

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
        float xSpawnPosition = Random.Range(minXPosition , maxXPosition);
        float ySpawnPosition = Random.Range(minYPosition , maxYPosition);
        float zSpawnPosition = Random.Range(minZPosition , maxZPosition);
        
        Vector3 spawnPosition = new Vector3(xSpawnPosition, ySpawnPosition ,zSpawnPosition);
        obstacles[obstacleCount].transform.position = spawnPosition;

        if(!obstacles[obstacleCount].activeSelf)
        {
            obstacles[obstacleCount].SetActive(true);


        }
        
        obstacleCount++;

        if(obstacleCount == poolSize)
        {
            obstacleCount = 0;

        }
    }
}
