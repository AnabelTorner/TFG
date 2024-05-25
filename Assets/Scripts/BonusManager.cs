using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public static BonusManager instance;

    public GameObject invisibilityBonusCanvas;

    private string velocityKey = "VelocityBonus";
    private string invisibilityKey = "InvisibilityBonus";

    public bool velocidadComprada = false;
    public bool invisibilidadComprada = false;

    private void Awake()
    {
        // Verifica si ya existe una instancia del BonusManager
        if (instance == null)
        {
            // Si no existe, establece esta instancia como la instancia única
            instance = this;
            // Marca este GameObject como no destruible al cargar una nueva escena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya existe una instancia, destruye este GameObject para evitar duplicados
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadPlayerBonus();
        BonusInvisibilityActive();
    }

    private void SavePlayerBonus()
    {
        PlayerPrefs.SetInt(velocityKey, velocidadComprada ? 1 : 0);
        PlayerPrefs.SetInt(invisibilityKey, invisibilidadComprada ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void LoadPlayerBonus()
    {
        velocidadComprada = PlayerPrefs.GetInt(velocityKey, 0) == 1;
        invisibilidadComprada = PlayerPrefs.GetInt(invisibilityKey, 0) == 1;
    }

    // Método para acceder a la variable velocidadComprada desde otras clases si es necesario
    public bool GetVelocidadComprada()
    {
        return velocidadComprada;
    }

    // Método para acceder a la variable invisibilidadComprada desde otras clases si es necesario
    public bool GetInvisibilidadComprada()
    {
        return invisibilidadComprada;
    }

    public void VelocidadComprada()
    {
        velocidadComprada = true;
        SavePlayerBonus();
    }

    public void InvisibilidadComprada()
    {
        invisibilidadComprada = true;
        BonusInvisibilityActive();
        SavePlayerBonus();
    }

    private void BonusInvisibilityActive()
    {
        if (GetInvisibilidadComprada())
        {
            invisibilityBonusCanvas.SetActive(true);
        }
        else
        {
            invisibilityBonusCanvas.SetActive(false);
        }
    }

    public void RestartBonus()
    {
        velocidadComprada = false;
        invisibilidadComprada = false;
        SavePlayerBonus();
    }
}
