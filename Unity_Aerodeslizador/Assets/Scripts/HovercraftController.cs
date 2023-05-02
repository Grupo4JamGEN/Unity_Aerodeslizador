using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HovercraftController : MonoBehaviour
{
    public float forwardSpeed = 20.0f;
    public float rotationSpeed = 100.0f;
    public float hoverForce = 12.0f;
    public float hoverHeight = 3.5f;
    public GameObject[] hoverPoints;

    private float powerInput;
    private float turnInput;
    private Rigidbody hovercraftBody;

    void Start()
    {
        hovercraftBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // Apply forward force
        hovercraftBody.AddRelativeForce(Vector3.forward * powerInput * forwardSpeed);

        // Apply turning force
        hovercraftBody.AddRelativeTorque(Vector3.up * turnInput * rotationSpeed);

        // Adjust height of hovercraft using raycast
        foreach (GameObject hoverPoint in hoverPoints)
        {
            RaycastHit hit;
            if (Physics.Raycast(hoverPoint.transform.position, -Vector3.up, out hit, hoverHeight))
            {
                float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
                Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
                hovercraftBody.AddForceAtPosition(appliedHoverForce, hoverPoint.transform.position);
            }
            else
            {
                hovercraftBody.AddForceAtPosition(Vector3.up * hoverForce / 5f, hoverPoint.transform.position);
            }
        }
    }
}

