using UnityEngine;

public class SecurityCameras : MonoBehaviour
{
    // Ángulo mínimo y máximo en el eje Y
    public float minYAngle = 0f;
    public float maxYAngle = 360f;

    // Velocidad de rotación en grados por segundo
    public float rotationSpeed = 30f;

    void FixedUpdate()
    {
        // Calcular el ángulo de rotación en el eje Y basado en el tiempo
        float yAngle = Mathf.Lerp(minYAngle, maxYAngle, Mathf.PingPong(Time.time * rotationSpeed, 1f));

        // Aplicar la rotación al objeto solo en el eje Y
        transform.rotation = Quaternion.Euler(0f, yAngle, 0f);
    }
}
