using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHover : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float distanceFromGround = 2f;
    public float angleSpeed = 15f;
    public float maxTiltAngle = 45f;
    public float tiltSpeed = 15f;
    public float maxHorizontalRotation = 15f;

    private Vector3 deskUp = Vector3.zero;
    private float tiltAngle = 0f;

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 newPos = transform.position;
        newPos += transform.forward * vertical * maxSpeed * Time.deltaTime;
        newPos += transform.right * horizontal * maxSpeed * Time.deltaTime;

        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            newPos.y = (hit.point + Vector3.up * distanceFromGround).y;
            deskUp = hit.normal;
        }

        transform.position = newPos;

        // Control de inclinación
        float yAngle = transform.eulerAngles.y;
        float zAngle = transform.eulerAngles.z;

        // Calcular el ángulo de inclinación deseado
        float targetTiltAngle = -horizontal * maxTiltAngle;

        // Calcular el ángulo actual de inclinación
        tiltAngle = Mathf.Lerp(tiltAngle, targetTiltAngle, tiltSpeed * Time.deltaTime);

        // Rotar la nave en el eje Y y Z
        transform.rotation = Quaternion.Euler(deskUp) * Quaternion.Euler(0f, 0f, tiltAngle);

        // Aplicar rotación correspondiente al movimiento horizontal
        float rotationAmount = -horizontal * maxHorizontalRotation;
        Quaternion targetRotation = Quaternion.Euler(0f, yAngle + rotationAmount, zAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, angleSpeed * Time.deltaTime);

        // Rotar la nave en el eje X
        transform.up = Vector3.Slerp(transform.up, deskUp, angleSpeed * Time.deltaTime);
    }
}


