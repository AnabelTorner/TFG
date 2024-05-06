using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public GameObject pcShop;
    public MoneyManager moneyManager;

    public Button velocidadButton;
    public int velocidadPrecio = 5000;

    public Button invisibilidadButton;
    public int invisibilidadPrecio = 10000;

    void Start()
    {
        pcShop.SetActive(false);
    }

    private void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E)) // Comprueba que se pulsa la tecla E
        {
            pcShop.SetActive(true);
            buttonState();
        }
    }

    public void OnTriggerExit()
    {
        pcShop.SetActive(false);
    }

    private void buttonState()
    {
        int money = moneyManager.GetPlayerMoney();
        velocidadButton.interactable = money  >= velocidadPrecio;
        invisibilidadButton.interactable = money >= invisibilidadPrecio;
    }

    public void ComprarVelocidad()
    {
        if (moneyManager.GetPlayerMoney() >= velocidadPrecio)
        {
            moneyManager.SubstractMoney(velocidadPrecio);
            buttonState();
            // Añadir código compra velocidad
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para comprar la velocidad.");
        }
    }

    public void ComprarInvisibilidad()
    {
        if (moneyManager.GetPlayerMoney() >= invisibilidadPrecio)
        {
            moneyManager.SubstractMoney(invisibilidadPrecio);
            buttonState();
            // Añadir código compra invisibilidad
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para comprar la invisibilidad.");
        }
    }
}
