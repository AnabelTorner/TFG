using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public GameObject pcShop;
    public MoneyManager moneyManager;
    public BonusManager bonusManager;

    public Button velocidadButton;
    public GameObject checkMarkVelocidad;
    public int velocidadPrecio = 5000;

    public Button invisibilidadButton;
    public GameObject checkMarkInvisibilidad;
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
            if (bonusManager.GetVelocidadComprada()) checkMarkVelocidad.SetActive(true);
            else checkMarkVelocidad.SetActive(false);
            if (bonusManager.GetInvisibilidadComprada()) checkMarkInvisibilidad.SetActive(true);
            else checkMarkInvisibilidad.SetActive(false);
        }
    }

    public void OnTriggerExit()
    {
        pcShop.SetActive(false);
    }

    private void buttonState()
    {
        int money = moneyManager.GetPlayerMoney();
        velocidadButton.interactable = money  >= velocidadPrecio && !bonusManager.velocidadComprada;
        invisibilidadButton.interactable = money >= invisibilidadPrecio && !bonusManager.invisibilidadComprada;
    }

    public void ComprarVelocidad()
    {
        if (moneyManager.GetPlayerMoney() >= velocidadPrecio)
        {
            moneyManager.SubstractMoney(velocidadPrecio);
            buttonState();
            bonusManager.VelocidadComprada();
            checkMarkVelocidad.SetActive(true);
        }
    }

    public void ComprarInvisibilidad()
    {
        if (moneyManager.GetPlayerMoney() >= invisibilidadPrecio)
        {
            moneyManager.SubstractMoney(invisibilidadPrecio);
            buttonState();
            bonusManager.InvisibilidadComprada();
            checkMarkInvisibilidad.SetActive(true);
        }
    }
}
