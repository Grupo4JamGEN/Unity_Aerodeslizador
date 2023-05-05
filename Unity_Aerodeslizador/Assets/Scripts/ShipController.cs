using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float tiltAngle = 10.0f;
    private float rotation = 0.0f;
    //private float lastPressTime = 0.0f;
    //private float doublePressDelay = 0.25f;

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, translation, 0);

       // if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // if (Time.time - lastPressTime < doublePressDelay)
            {
              //  rotation = -360.0f;
            }
           // lastPressTime = Time.time;
        }

       // if (Input.GetKeyDown(KeyCode.RightArrow))
        {
           // if (Time.time - lastPressTime < doublePressDelay)
            {
             //   rotation = 360.0f;
            }
           // lastPressTime = Time.time;
        }

        transform.Rotate(0, 0, rotation * Time.deltaTime);
        rotation = Mathf.Lerp(rotation, 0, Time.deltaTime * rotationSpeed);

        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotationSpeed);
    }
}