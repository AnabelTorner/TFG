using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floatingImage : MonoBehaviour
{
    public GameObject floatImg; // Referencia al objeto FloatingImage

    private void Start()
    {
        floatImg.SetActive(false); // Desactiva la imagen flotante al inicio
    }

    private void OnTriggerEnter()
    {
        floatImg.SetActive(true); // Activa la imagen flotante
    }

    private void OnTriggerExit()
    {
        floatImg.SetActive(false); // Desactiva la imagen flotante
    }
}
