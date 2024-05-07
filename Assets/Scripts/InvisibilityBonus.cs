using UnityEngine;
using TMPro;

public class InvisibilityBonus : MonoBehaviour
{
    public TextMeshProUGUI textoTimer;
    private float tiempoRestante = 30f;
    private bool temporizadorActivo = false;

    void Start()
    {
        // Desactivar el texto al inicio
        textoTimer.gameObject.SetActive(false);
    }

    void Update()
    {
        // Verificar si se presiona la tecla F para iniciar el temporizador
        if (!temporizadorActivo && Input.GetKeyDown(KeyCode.F))
        {
            IniciarTemporizador();
        }

        if (temporizadorActivo)
        {
            // Actualizar el temporizador
            tiempoRestante -= Time.deltaTime;

            // Mostrar el tiempo restante en el texto
            textoTimer.text = Mathf.RoundToInt(tiempoRestante).ToString();

            // Si el temporizador llega a cero, detener el temporizador y desactivar el texto
            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                temporizadorActivo = false;
                textoTimer.gameObject.SetActive(false);
            }
        }
    }

    // Función para iniciar el temporizador
    public void IniciarTemporizador()
    {
        tiempoRestante = 30f; // Reiniciar el temporizador
        temporizadorActivo = true; // Activar el temporizador
        textoTimer.gameObject.SetActive(true); // Activar el texto
    }
}
