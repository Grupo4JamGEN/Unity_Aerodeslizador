using UnityEngine;

public class HoverController : MonoBehaviour
{
    public float speed = 10.0f; // Velocidad de movimiento del aerodeslizador.
    public float acceleration = 1.0f; // Aceleración del aerodeslizador.
    public float maxSpeed = 50.0f; // Velocidad máxima del aerodeslizador.
    public float hoverForce = 12.0f; // Fuerza de suspensión del aerodeslizador.
    public float hoverHeight = 3.5f; // Altura de suspensión del aerodeslizador.
    public float tiltAngle = 30.0f; // Ángulo de inclinación del aerodeslizador.
    public float frictionForce = 5.0f; // Fuerza de fricción del aerodeslizador.

    private Rigidbody rb; // Componente Rigidbody del aerodeslizador.
    private AudioSource audioSource; // Componente AudioSource del aerodeslizador.
    private bool isGrounded = false; // Indicador de si el aerodeslizador está en contacto con el suelo.

    private static HoverController instance; // Instancia Singleton de HoverController.

   // Propiedad para acceder a la instancia Singleton de HoverController.
    public static HoverController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HoverController>();
            }
            return instance;
        }
    }

    // Método que se llama al inicio de la ejecución.
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rb.centerOfMass = Vector3.down; // Mover el centro de masa del aerodeslizador hacia abajo para mejorar la estabilidad.
    }

    // Método que se llama en cada frame.
    private void FixedUpdate()
    {
        // Obtener los inputs de movimiento horizontal y vertical.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Aplicar una fuerza de suspensión hacia arriba para mantener el aerodeslizador a una altura constante.
        RaycastHit hit;
        //Debug.DrawLine(transform.position, hit.point, Color.red);
        //Debug.Log("Distancia del hit: " + hit.distance);
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, hoverHeight))
        {
            Debug.DrawLine(transform.position, hit.point, Color.blue);
            Debug.Log("Distancia del hit: " + hit.distance);
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            rb.AddForce(appliedHoverForce, ForceMode.Acceleration);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Aplicar una fuerza de aceleración hacia adelante en función del input vertical del usuario.
        if (moveVertical > 0 && rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.forward * moveVertical * acceleration, ForceMode.Acceleration);
        }

        // Girar el aerodeslizador en función del input horizontal del usuario.
        transform.Rotate(0, moveHorizontal * tiltAngle * Time.fixedDeltaTime, 0);

        // Actualizar el sonido del motor en función de la velocidad del aerodeslizador.
        audioSource.pitch = rb.velocity.magnitude / maxSpeed;

        // Descansar si el aerodeslizador no se mueve y está en contacto con el suelo.
        if (moveVertical == 0 && isGrounded)
        {
            rb.Sleep();
        }
    }
}


