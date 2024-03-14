using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{

    public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CerrarJuego()
    {
        Application.Quit();
        Debug.Log("Salir");
    }

    public void CambioEscena()
    {
        SceneManager.LoadScene(SceneName);
    }
}
