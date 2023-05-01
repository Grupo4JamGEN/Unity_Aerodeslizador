using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public ObstacleGenerator obstacleGenerator; // Referencia al componente ObstacleGenerator
    public GameObject spawnZone; // Zona de generación de obstáculos

    private bool activated = false; // Indica si el trigger ha sido activado

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated) // Si el trigger es activado por el jugador
        {
            obstacleGenerator.enabled = true; // Activa la generación de obstáculos
            spawnZone.SetActive(true); // Activa la zona de generación
            activated = true; // Indica que el trigger ha sido activado
        }
    }
}
