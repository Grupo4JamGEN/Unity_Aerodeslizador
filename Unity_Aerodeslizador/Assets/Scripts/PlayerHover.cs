using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHover : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float distanceFromGround = 2f;
    public float angleSpeed = 15f;

    private Vector3 deskUp = Vector3.zero;

    void Update()
    {
        float Hor = Input.GetAxis("Vertical");
        float Ver = Input.GetAxis("Horizontal");

        Vector3 newPos = transform.position;
        newPos += transform.forward * Hor * maxSpeed * Time.deltaTime;
        newPos += transform.right * Ver * maxSpeed * Time.deltaTime;

        RaycastHit hit;
        
        if(Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            newPos.y = (hit.point + Vector3.up * distanceFromGround).y;
            deskUp = hit.normal;
        }

        transform.position = newPos;
        transform.up = Vector3.Slerp(transform.up, deskUp, angleSpeed * Time.deltaTime);
    }
}
