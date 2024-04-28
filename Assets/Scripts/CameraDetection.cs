using System;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    // Delegado para el evento de detección de jugador
    public static event Action<Vector3> OnPlayerDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Detectado");
            // Obtener la posición del jugador
            Vector3 playerPosition = other.transform.position;
            // Notificar a todos los suscriptores del evento
            OnPlayerDetected?.Invoke(playerPosition);
        }
    }
}
