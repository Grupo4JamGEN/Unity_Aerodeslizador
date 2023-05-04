using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirObjeto : MonoBehaviour
{
    public Transform objetoASeguir;  // Objeto a seguir
    public float distancia = 10.0f; // Distancia de la cámara al objeto
    public float altura = 5.0f;     // Altura de la cámara respecto al objeto

    void LateUpdate()
    {
        // Obtener la posición del objeto a seguir
        Vector3 posicionObjeto = objetoASeguir.position;

        // Calcular la nueva posición de la cámara
        Vector3 nuevaPosicion = new Vector3(posicionObjeto.x, posicionObjeto.y + altura, posicionObjeto.z - distancia);

        // Actualizar la posición de la cámara
        transform.position = nuevaPosicion;

        // Hacer que la cámara mire al objeto a seguir
        transform.LookAt(objetoASeguir);
    }
}
