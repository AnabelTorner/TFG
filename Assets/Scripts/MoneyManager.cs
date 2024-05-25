using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    private int playerMoney = 0;
    private string moneyKey = "PlayerMoney";

    private void Awake()
    {
        // Verifica si ya existe una instancia del MoneyManager
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
        LoadPlayerMoney();
    }

    public void AddMoney(int amount)
    {
        playerMoney += amount;
        SavePlayerMoney();
    }

    public void SubstractMoney(int amount)
    {
        playerMoney -= amount;
        SavePlayerMoney();
    }    
    
    public void RestartMoney()
    {
        playerMoney = 0;
        SavePlayerMoney();
    }

    private void SavePlayerMoney()
    {
        PlayerPrefs.SetInt(moneyKey, playerMoney);
    }

    private void LoadPlayerMoney()
    {
        if (PlayerPrefs.HasKey(moneyKey))
        {
            playerMoney = PlayerPrefs.GetInt(moneyKey);
        }
    }

    public int GetPlayerMoney()
    {
        return playerMoney;
    }
}
