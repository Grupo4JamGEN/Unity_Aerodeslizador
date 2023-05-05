using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioShipScript : MonoBehaviour
{
    PlayerControllerHD playerScript;
    AudioSource audioSource;
    private float minPitch = 0.2f;

    public Rigidbody shipRB;
    private float pitchFromCar;


    private float carCurrentSpeed=0;
     
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerScript = GetComponent<PlayerControllerHD>();
        audioSource.pitch = minPitch;
        
    }
 
    // Update is called once per frame
    void Update()
    {
        

        pitchFromCar = playerScript.currentSpeed/playerScript.speed; 
        
        if(pitchFromCar < minPitch)
            audioSource.pitch = Mathf.Lerp(audioSource.pitch,minPitch,Time.deltaTime);
        else 
            audioSource.pitch = Mathf.Lerp(audioSource.pitch,1,Time.deltaTime);
    }
}
