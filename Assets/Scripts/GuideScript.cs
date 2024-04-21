using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideScript : MonoBehaviour
{
    public GameObject guia;
    public GameObject icono;

    private void Start()
    {
        // Desactivar la guía y activar el icono al incio
        guia.SetActive(false);
        icono.SetActive(true);
    }
    void Update()
    {
        // Verificar si se presiona o se suelta la tecla Tabulador
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Activar la guía y desactivar el icono al presionar la tecla Tabulador
            guia.SetActive(true);
            icono.SetActive(false);
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            // Desactivar la guía y activar el icono al soltar la tecla Tabulador
            guia.SetActive(false);
            icono.SetActive(true);
        }
    }
}
