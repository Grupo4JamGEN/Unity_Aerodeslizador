using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform vehicle;
    public Vector3 cameraOffset;
    public float cameraRotationX;
    public float cameraRotationY;
    public float cameraRotationZ;

    void LateUpdate()
    {
        if (vehicle == null)
        {
            return;
        }

        transform.position = vehicle.position + vehicle.TransformVector(cameraOffset);
        transform.rotation = vehicle.rotation * Quaternion.Euler(cameraRotationX, cameraRotationY, cameraRotationZ);
    }
}


