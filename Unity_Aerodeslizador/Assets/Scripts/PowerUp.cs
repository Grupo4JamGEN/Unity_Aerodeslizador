using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Rigidbody playerRb;
    
    public float turbo = 3.5f;
    private bool accelerate = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && accelerate)
        {
            playerRb.AddForce(Vector3.forward * turbo, ForceMode.Impulse);
            accelerate = false;

        }
        
        
    }
}
