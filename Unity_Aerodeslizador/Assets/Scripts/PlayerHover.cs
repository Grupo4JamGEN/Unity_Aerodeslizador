using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHover : MonoBehaviour
{
    // Variables públicas que se pueden configurar en el Inspector de Unity
    public float maxSpeed = 10f;                    // Velocidad máxima de movimiento del jugador
    public float distanceFromGround = 2f;           // Distancia desde el suelo para mantener al jugador
    public float angleSpeed = 15f;                  // Velocidad de rotación en los ángulos de inclinación y rotación horizontal
    public float maxTiltAngle = 45f;                // Ángulo máximo de inclinación de la nave
    public float tiltSpeed = 15f;                   // Velocidad de inclinación de la nave
    public float maxHorizontalRotation = 15f;       // Ángulo máximo de rotación horizontal de la nave

    // Variables privadas que se utilizan dentro de la clase
    private Vector3 deskUp = Vector3.zero;          // Vector que indica hacia arriba desde la superficie en la que está el jugador
    private float tiltAngle = 0f;                   // Ángulo actual de inclinación de la nave

    // El método Update se llama una vez por cada frame del juego
    void Update()
    {
        // Obtener la entrada de los ejes vertical y horizontal
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        // Calcular la nueva posición del jugador
        Vector3 newPos = transform.position;
        newPos += transform.forward * vertical * maxSpeed * Time.deltaTime;
        newPos += transform.right * horizontal * maxSpeed * Time.deltaTime;

        // Realizar un raycast hacia abajo desde la posición del jugador para determinar la altura y la normal de la superficie debajo de él
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            // Establecer la posición del jugador en la superficie debajo de él, ajustando la altura según la distanciaFromGround
            newPos.y = (hit.point + Vector3.up * distanceFromGround).y;
            // Establecer el vector de dirección hacia arriba desde la superficie debajo del jugador
            deskUp = hit.normal;
        }

        // Establecer la nueva posición del jugador
        transform.position = newPos;

        // Controlar la inclinación de la nave
        float yAngle = transform.eulerAngles.y;
        float zAngle = transform.eulerAngles.z;

        // Calcular el ángulo de inclinación deseado en función del movimiento horizontal del jugador
        float targetTiltAngle = -horizontal * maxTiltAngle;

        // Interpolar suavemente el ángulo de inclinación actual hacia el ángulo de inclinación deseado
        tiltAngle = Mathf.Lerp(tiltAngle, targetTiltAngle, tiltSpeed * Time.deltaTime);

        // Rotar la nave en el eje Y y Z, utilizando la normal de la superficie donde se encuentra
        transform.rotation = Quaternion.Euler(deskUp) * Quaternion.Euler(0f, 0f, tiltAngle);

        // Calcular la cantidad de rotación a aplicar en el eje horizontal
        float rotationAmount = -horizontal * maxHorizontalRotation;

        // Calcular la rotación objetivo
        Quaternion targetRotation = Quaternion.Euler(0f, yAngle + rotationAmount, zAngle);

        // Interpolar suavemente la rotación actual hacia la rotación objetivo, a una velocidad determinada por angleSpeed
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, angleSpeed * Time.deltaTime);

        // Rotar la nave en el eje X, utilizando la normal de la superficie donde se encuentra
        transform.up = Vector3.Slerp(transform.up, deskUp, angleSpeed * Time.deltaTime);

        // El script controla la posición, rotación e inclinación de una nave espacial en Unity.
        // Los parámetros públicos permiten ajustar la velocidad, la distancia de elevación,
        // la velocidad de inclinación y el ángulo máximo de inclinación de la nave.
        // El método Update se llama una vez por cuadro y recoge la entrada del usuario
        // para mover la nave hacia adelante, hacia atrás y hacia los lados. Luego,
        // utiliza un Raycast para determinar la posición de la nave sobre la superficie
        // y la orientación de la nave con respecto a la superficie.
        // Finalmente, aplica rotaciones al objeto para simular la inclinación y el movimiento de la nave.
    }
}

