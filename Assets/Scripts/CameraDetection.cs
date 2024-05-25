using System;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    // Delegado para el evento de detecci�n de jugador
    public static event Action<Vector3> OnPlayerDetected;

    //Invisibility bonus
    public BonusManager bonusManager;
    public InvisibilityBonus invisibilityBonusCanvas;

    void Start()
    {
        //Invisibility bonus
        bonusManager = FindObjectOfType<BonusManager>();
        invisibilityBonusCanvas = bonusManager.GetComponent<InvisibilityBonus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !invisibilityBonusCanvas.GetInvisibility())
        {
            Debug.Log("Detectado");
            // Obtener la posici�n del jugador
            Vector3 playerPosition = other.transform.position;
            // Notificar a todos los suscriptores del evento
            OnPlayerDetected?.Invoke(playerPosition);
        }
    }
}
