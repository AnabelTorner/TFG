using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CitySpawnManager : MonoBehaviour
{
    public Vector3 cityPlayerStartPosition; // Posición de inicio en el último edificio al que se ha accedido
    public Vector3 policePlayerStartPosition; // Posición de inicio en la policia

    public static CitySpawnManager instance;
    public TextMeshProUGUI moneyMessage = null;
    public MoneyManager moneyManager;

    private bool playerCaught = false;
    private string previousScene;

    void Awake()
    {
        // Verifica si ya existe una instancia del CitySpawnManager
        if (instance == null)
        {
            // Si no existe, establece esta instancia como la instancia única
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
        // Carga la posición de inicio dependiendo de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "City" && previousScene != "Lair")
        {
            // Si el jugador fue capturado, establece la posición de inicio en la policia
            if (playerCaught)
            {
                SetPlayerStartPosition(policePlayerStartPosition);
                playerCaught = false;
            }
            else
            {
                SetPlayerStartPosition(cityPlayerStartPosition);
                FindMoneyMessage();
                MoneyMessage();
            }
        }
        else
        {
            previousScene = currentSceneName;
        }
    }

    public void SetPlayerStartPosition(Vector3 position)
    {
        // Mover al jugador a la posición especificada
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = position;
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

    private void FindMoneyMessage()
    {
        GameObject moneyMessageObject = GameObject.FindGameObjectWithTag("MoneyMessage");
        moneyMessage = moneyMessageObject.GetComponent<TextMeshProUGUI>();
    }

    private void MoneyMessage()
    {
        AssignMessage();
        AssignMoney();
        moneyMessage.gameObject.SetActive(true);
        Invoke("FadeAndDeactivateMoneyMessage", 5f); // Invocar el método después de 5 segundos
    }

    private void FadeAndDeactivateMoneyMessage()
    {
        // Asumiendo que tienes un componente CanvasGroup en moneyMessage para controlar la transparencia
        CanvasGroup canvasGroup = moneyMessage.GetComponent<CanvasGroup>();

        // Iniciar el proceso de desvanecimiento utilizando una corrutina
        StartCoroutine(FadeOut(canvasGroup, 1f)); // Duración de 1 segundo
    }

    private IEnumerator FadeOut(CanvasGroup canvasGroup, float duration)
    {
        float currentTime = 0f;
        float startAlpha = canvasGroup.alpha;
        float targetAlpha = 0f; // Desvanecer completamente

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, currentTime / duration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;

        // Desactivar el mensaje después de desvanecerlo
        moneyMessage.gameObject.SetActive(false);
    }

    private void AssignMessage()
    {
        if (previousScene == "Office") moneyMessage.text = "Has vendido el USB a unos Ciudadanos Naturalmente Inteligentes. Has ganado 1000Zc que han sido depositados en tu caja fuerte";
    }

    private void AssignMoney()
    {
        if (previousScene == "Office") moneyManager.AddMoney(1000);
        Debug.Log(moneyManager.GetPlayerMoney());
    }

}
