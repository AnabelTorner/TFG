using UnityEngine;
using TMPro;

public class InvisibilityBonus : MonoBehaviour
{
    public TextMeshProUGUI cooldownTimer;
    public TextMeshProUGUI bonusTimer;

    private float cooldownTime = 30f;
    private float bonusTime = 5f;

    private bool cooldownActive = false;
    private bool bonusActive = false;

    public bool invisible = false;

    void Start()
    {
        // Desactivar los textos al inicio
        cooldownTimer.gameObject.SetActive(false);
        bonusTimer.gameObject.SetActive(false);

    }

    void Update()
    {
        // Verificar si se presiona la tecla F para iniciar el temporizador
        if (!cooldownActive && Input.GetKeyDown(KeyCode.F))
        {
            IniciarCooldown();
            IniciarBonusTimer();
            invisible = true;
        }

        if (cooldownActive)
        {
            ActualizarTemporizador(ref cooldownTime, cooldownTimer);

            if (cooldownTime <= 0)
            {
                cooldownTime = 0;
                cooldownActive = false;
                cooldownTimer.gameObject.SetActive(false);
                invisible = false;
            }
        }

        if (bonusActive)
        {
            ActualizarTemporizador(ref bonusTime, bonusTimer);

            if (bonusTime <= 0)
            {
                bonusTime = 0;
                bonusActive = false;
                bonusTimer.gameObject.SetActive(false);
            }
        }
    }

    // Función para iniciar el temporizador de cooldown
    void IniciarCooldown()
    {
        cooldownTime = 30f;
        cooldownActive = true;
        cooldownTimer.gameObject.SetActive(true);
    }

    // Función para iniciar el temporizador de bonificación
    void IniciarBonusTimer()
    {
        bonusTime = 5f;
        bonusActive = true;
        bonusTimer.gameObject.SetActive(true);
    }

    // Función para actualizar un temporizador
    void ActualizarTemporizador(ref float tiempoRestante, TextMeshProUGUI textoTemporizador)
    {
        tiempoRestante -= Time.deltaTime;
        textoTemporizador.text = Mathf.RoundToInt(tiempoRestante).ToString();
    }
}
