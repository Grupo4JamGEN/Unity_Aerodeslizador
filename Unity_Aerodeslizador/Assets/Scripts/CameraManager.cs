using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex;

    void Start()
    {
        // Desactivar todas las cámaras excepto la primera
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        // Establecer la primera cámara como activa
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
            currentCameraIndex = 0;
        }
    }

    void Update()
    {
        // Cambiar a la siguiente cámara al presionar la tecla Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentCameraIndex++;
            if (currentCameraIndex < cameras.Length)
            {
                // Desactivar la cámara anterior y activar la nueva
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                cameras[currentCameraIndex].gameObject.SetActive(true);
            }
            else
            {
                // Si llegamos al final del arreglo, volver a la primera cámara
                cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                currentCameraIndex = 0;
                cameras[currentCameraIndex].gameObject.SetActive(true);
            }
        }
    }
}