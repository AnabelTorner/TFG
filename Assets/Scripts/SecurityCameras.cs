using UnityEngine;

public class SecurityCameras : MonoBehaviour
{
    // �ngulo m�nimo y m�ximo en el eje Y
    public float minYAngle = 0f;
    public float maxYAngle = 360f;

    // Velocidad de rotaci�n en grados por segundo
    public float rotationSpeed = 30f;

    void FixedUpdate()
    {
        // Calcular el �ngulo de rotaci�n en el eje Y basado en el tiempo
        float yAngle = Mathf.Lerp(minYAngle, maxYAngle, Mathf.PingPong(Time.time * rotationSpeed, 1f));

        // Aplicar la rotaci�n al objeto solo en el eje Y
        transform.rotation = Quaternion.Euler(0f, yAngle, 0f);
    }
}
