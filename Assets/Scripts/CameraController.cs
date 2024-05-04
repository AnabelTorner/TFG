using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Referencia al jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado
    public Vector3 locationOffset; // Desplazamiento de posición
    public Vector3 rotationOffset; // Desplazamiento de rotación

    void FixedUpdate()
    {
        // Calcula la posición deseada de la cámara
        Vector3 desiredPosition = target.position + target.rotation * locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Calcula la rotación deseada de la cámara
        Quaternion desiredRotation = target.rotation * Quaternion.Euler(rotationOffset);
        Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
        transform.rotation = smoothedRotation;
    }
}
