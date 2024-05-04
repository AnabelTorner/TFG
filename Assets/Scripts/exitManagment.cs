using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitManagment : MonoBehaviour
{
    public CitySpawnManager citySpawnManager;

    private void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E)) // Comprueba que se pulsa la tecla E
        {
            citySpawnManager.LoadCityScene(); // Carga la escena indicada
        }
    }
}
