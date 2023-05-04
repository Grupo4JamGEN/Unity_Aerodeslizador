using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public  SideSpawn activate;
    public GameObject playerObject;

    private float limit = -3000f;
    // Start is called before the first frame update
    void Start()
    {
        //activate = GameObject.FindGameObjectWithTag("SideSpawn").GetComponent<SideSpawn>();
        //location = GameObject.FindGameObjectWithTag("MovePlayer").GetComponent<MovePlayer>();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerObject.transform.position.z == limit)
        {

           activate.SpawnObstacle(); 
           Debug.Log("limit");
        }       
        
    }
}
