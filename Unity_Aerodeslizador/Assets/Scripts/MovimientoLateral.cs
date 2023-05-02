using UnityEngine;

public class MovimientoLateral : MonoBehaviour
{
    public float velocidad = 5f;
    public float limiteIzquierdo = -5f;
    public float limiteDerecho = 5f;
    
    private bool moverDerecha = true;
    
    void Update()
    {
        if (transform.position.x <= limiteIzquierdo)
        {
            moverDerecha = true;
        }
        else if (transform.position.x >= limiteDerecho)
        {
            moverDerecha = false;
        }
        
        if (moverDerecha)
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }
    }
}
