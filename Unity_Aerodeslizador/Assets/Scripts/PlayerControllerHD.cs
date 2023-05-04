using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerHD : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 75.0f;

    public float distanceFromGround = 2f;           // Distancia desde el suelo para mantener al jugador
    public float angleSpeed = 15f;                  // Velocidad de rotación en los ángulos de inclinación y rotación horizontal
    public float maxTiltAngle = 45f;                // Ángulo máximo de inclinación de la nave
    public float tiltSpeed = 15f;                   // Velocidad de inclinación de la nave
    public GameObject ship;

    private float horizontalInput;
    private float forwardInput;

    private Vector3 deskUp = Vector3.zero;          // Vector que indica hacia arriba desde la superficie en la que está el jugador
    private float tiltAngle = 0f;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        Vector3 newPos = transform.position;
        // Realizar un raycast hacia abajo desde la posición del jugador para determinar la altura y la normal de la superficie debajo de él
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            // Establecer la posición del jugador en la superficie debajo de él, ajustando la altura según la distanciaFromGround
            newPos.y = (hit.point + Vector3.up * distanceFromGround).y;
            // Establecer el vector de dirección hacia arriba desde la superficie debajo del jugador
            deskUp = hit.normal;
        }

        float yAngle = transform.eulerAngles.y;
        float zAngle = transform.eulerAngles.z;

        float targetTiltAngle = -horizontalInput * maxTiltAngle;

        // Calcular el ángulo actual de inclinación
        tiltAngle = Mathf.Lerp(tiltAngle, targetTiltAngle, tiltSpeed * Time.deltaTime);

        // Rotar la nave en el eje Y y Z
        ship.transform.rotation = Quaternion.Euler(deskUp) * Quaternion.Euler(0f, yAngle, tiltAngle);

        // Rotar la nave en el eje X, utilizando la normal de la superficie donde se encuentra
        //transform.up = Vector3.Slerp(transform.up, deskUp, angleSpeed * Time.deltaTime);
    }
}
