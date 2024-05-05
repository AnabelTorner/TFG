using UnityEngine;

public class exitManagment : MonoBehaviour
{
    public CitySpawnManager citySpawnManager;

    private void Start()
    {
        // Buscar automáticamente una instancia de CitySpawnManager en la escena actual
        citySpawnManager = FindObjectOfType<CitySpawnManager>();
    }

    private void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E)) // Comprueba que se pulsa la tecla E
        {
            citySpawnManager.LoadCityScene(); // Carga la escena indicada
        }
    }
}
