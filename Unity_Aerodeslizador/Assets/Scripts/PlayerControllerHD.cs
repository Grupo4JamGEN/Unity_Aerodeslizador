using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerHD : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 75.0f;

    public float distanceFromGround = 2f;           // Distancia desde el suelo para mantener al jugador
    public float angleSpeed = 15f;                  // Velocidad de rotaci�n en los �ngulos de inclinaci�n y rotaci�n horizontal
    public float maxTiltAngle = 45f;                // �ngulo m�ximo de inclinaci�n de la nave
    public float tiltSpeed = 15f;                   // Velocidad de inclinaci�n de la nave
    public GameObject ship;
    public Rigidbody rb;

    private float horizontalInput;
    private float forwardInput;

    private Vector3 deskUp = Vector3.zero;          // Vector que indica hacia arriba desde la superficie en la que est� el jugador
    private float tiltAngle = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

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
        // Realizar un raycast hacia abajo desde la posici�n del jugador para determinar la altura y la normal de la superficie debajo de �l
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            // Establecer la posici�n del jugador en la superficie debajo de �l, ajustando la altura seg�n la distanciaFromGround
            newPos.y = (hit.point + Vector3.up * distanceFromGround).y;
            // Establecer el vector de direcci�n hacia arriba desde la superficie debajo del jugador
            deskUp = hit.normal;
            // Dibujar una l�nea desde la posici�n del jugador hasta la posici�n del impacto del raycast
            Debug.DrawLine(transform.position, hit.point, Color.green);
        }
        else
        {
            // Si el raycast no impacta con ninguna superficie, dibujar una l�nea hacia abajo desde la posici�n del jugador
            Debug.DrawLine(transform.position, transform.position + Vector3.down * 100f, Color.red);
            rb.useGravity = true;
        }
    

        // Establecer la nueva posici�n del jugador
        transform.position = newPos;

        float yAngle = transform.eulerAngles.y;
        float zAngle = transform.eulerAngles.z;

        float targetTiltAngle = -horizontalInput * maxTiltAngle;

        // Calcular el �ngulo actual de inclinaci�n
        tiltAngle = Mathf.Lerp(tiltAngle, targetTiltAngle, tiltSpeed * Time.deltaTime);

        // Rotar la nave en el eje Y y Z
        ship.transform.rotation = Quaternion.Euler(deskUp) * Quaternion.Euler(0f, yAngle, tiltAngle);

        // Rotar la nave en el eje X, utilizando la normal de la superficie donde se encuentra
        //transform.up = Vector3.Slerp(transform.up, deskUp, angleSpeed * Time.deltaTime);
    }
}
