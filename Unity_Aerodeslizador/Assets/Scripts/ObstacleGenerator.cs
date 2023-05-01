using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs; // Lista de prefabs de obstáculos
    public float generationRate = 2f; // Tasa de generación de obstáculos (segundos)
    public float generationRadius = 5f; // Radio de la zona de generación de obstáculos

    private float nextGenerationTime; // Tiempo de la siguiente generación de obstáculos
    private Transform playerTransform; // Transform del jugador

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Busca el objeto con tag "Player"
    }

    private void Update()
    {
        if (Time.time >= nextGenerationTime)
        {
            GenerateObstacle();
            nextGenerationTime = Time.time + generationRate;
        }
    }

    private void GenerateObstacle()
    {
        // Selecciona un punto aleatorio dentro del radio de la zona de generación
        Vector3 randomPosition = Random.insideUnitSphere * generationRadius;
        randomPosition.z = playerTransform.position.z + generationRadius; // Asegura que el obstáculo se genere adelante del jugador

        // Selecciona un obstáculo aleatorio de la lista de prefabs
        GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

        // Obtiene un objeto de la pool de obstáculos (si existe)
        GameObject obstacle = ObjectPooler.Instance.GetPooledObject(obstaclePrefab.tag);

        if (obstacle != null) // Si se encuentra un objeto disponible en la pool
        {
            obstacle.transform.position = randomPosition; // Lo mueve a la posición aleatoria generada
            obstacle.SetActive(true); // Activa el objeto para que sea visible
        }
        else // Si no se encuentra ningún objeto disponible en la pool
        {
            obstacle = Instantiate(obstaclePrefab, randomPosition, Quaternion.identity); // Crea un nuevo objeto
            ObjectPooler.Instance.AddToPool(obstacle, obstacle.tag); // Lo agrega a la pool
        }
    }
}

