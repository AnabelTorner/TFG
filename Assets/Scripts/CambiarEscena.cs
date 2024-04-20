using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{

    public string SceneName;

    public void CerrarJuego()
    {
        Application.Quit(); // Cierra el juego
        Debug.Log("Salir"); // Comprobación por consola para Unity
    }

    public void CambioEscena()
    {
        SceneManager.LoadScene(SceneName); // Carga la escena indicada
    }

    private void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E)) // Comprueba que se pulsa la tecla E
        {
            CambioEscena(); // Carga la escena indicada
        }
    }
}
