using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcBasico : MonoBehaviour
{
    public GameObject[] objetosPosibles;
    [Range(0f, 1f)]
    public float pro = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0f, 1f) <= pro)
        {
            Instantiate(
            objetosPosibles[Random.Range(0, objetosPosibles.Length)],
            transform.position,
            Quaternion.Euler(Vector3.up*(Random.Range(0, 4)*90)
            ));
        }
        
        
    }

}
