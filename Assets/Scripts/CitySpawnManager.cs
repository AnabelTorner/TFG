using UnityEngine;
using UnityEngine.SceneManagement;

public class CitySpawnManager : MonoBehaviour
{
    public Vector3 cityPlayerStartPosition; // Posici�n de inicio en la ciudad
    public Vector3 policePlayerStartPosition; // Posici�n de inicio en la oficina

    public static CitySpawnManager instance;

    private bool playerCaught = false;

    void Awake()
    {
        // Verifica si ya existe una instancia del GameManager
        if (instance == null)
        {
            // Si no existe, establece esta instancia como la instancia �nica
            instance = this;
            // Marca este GameObject como no destruible al cargar una nueva escena
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            // Si ya existe una instancia, destruye este GameObject para evitar duplicados
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Carga la posici�n de inicio dependiendo de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "City")
        {
            // Si el jugador fue capturado en la oficina, establece la posici�n de inicio de la oficina
            if (playerCaught)
            {
                SetPlayerStartPosition(policePlayerStartPosition);
                playerCaught = false;
            }
            else
            {
                SetPlayerStartPosition(cityPlayerStartPosition);
            }
        }
    }

    public void SetPlayerStartPosition(Vector3 position)
    {
        // Aseg�rate de que el jugador siempre comience en la posici�n especificada.
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = position;
        }
    }

    public void PlayerCaught()
    {
        playerCaught = true;
    }

    public void LoadCityScene()
    {
        SceneManager.LoadScene("City");
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
