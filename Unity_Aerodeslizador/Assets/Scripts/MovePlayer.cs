using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody playerRb;
    //private GameObject focalPoint;
    public float speed = 20.0f;
    private float xBound = 6;
    private float zBound = 45;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
        
        
    }

    void Update()
    {
        Movement();
        PlayerBounds();
    }

    // Update is called once per frame
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.left * horizontalInput * speed);
        playerRb.AddForce(Vector3.back * forwardInput * speed);
        
        
    }

    void PlayerBounds ()
    {
        if(transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound,transform.position.y ,  transform.position.z);

        }

        if(transform.position.x >xBound)
        {
            transform.position = new Vector3(xBound , transform.position.y , transform.position.z);

        }
        if(transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y , zBound);

        }

    }


}

