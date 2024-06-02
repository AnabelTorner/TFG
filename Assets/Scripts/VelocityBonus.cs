using UnityEngine;
using UnityEngine.SceneManagement;

public class VelocityBonus : MonoBehaviour
{
    public BonusManager bonusManager;

    public float newMoveSpeed = 3.45f;
    public float initialMoveSpeed = 3f;

    void Start()
    {
        // Registrar el callback cuando se carga una nueva escena
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Comprueba si ya se compró la velocidad al iniciar
        if (bonusManager.GetVelocidadComprada())
        {
            UpdateVelocity();
        }
    }

    void OnDestroy()
    {
        // Desregistrar el callback cuando el objeto se destruye
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Método que se llama cuando una nueva escena se carga
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (bonusManager.GetVelocidadComprada())
        {
            UpdateVelocity();
        }
    }

    public void UpdateVelocity()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement playerMovement = playerGameObject.GetComponent<PlayerMovement>();
        playerMovement.moveSpeed = newMoveSpeed;
    }

    public void restartVelocity()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement playerMovement = playerGameObject.GetComponent<PlayerMovement>();
        playerMovement.moveSpeed = initialMoveSpeed;
    }
}
