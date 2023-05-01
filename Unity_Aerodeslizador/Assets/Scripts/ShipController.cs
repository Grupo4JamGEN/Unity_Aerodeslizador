using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento del objeto
    private Rigidbody rb; // Componente Rigidbody del objeto

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Entrada horizontal del teclado
        float moveVertical = Input.GetAxis("Vertical"); // Entrada vertical del teclado

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // Vector de movimiento

        rb.AddForce(movement * speed); // Aplicar la fuerza de movimiento al objeto
    }
}




