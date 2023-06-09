using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioShipScript : MonoBehaviour
{
    public GameManagerUI gameManagerScript;
    PlayerControllerHD playerScript;
    AudioSource audioSource;
    private float minPitch = 0.1f;

    private float pitchFromCar;


    
     
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
        if(gameManagerScript.gamePaused){

            
            audioSource.Pause();
            
        }else{
            if(!audioSource.isPlaying){audioSource.Play();}
            
        }
        if(pitchFromCar < minPitch){
            audioSource.pitch = Mathf.Lerp(audioSource.pitch,minPitch,Time.deltaTime);
        }
            
        else {
            audioSource.pitch = Mathf.Lerp(audioSource.pitch,1,Time.deltaTime);
        }
            
            
    }
}
