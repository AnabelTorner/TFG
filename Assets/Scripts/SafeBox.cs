using UnityEngine;
using TMPro;

public class SafeBox : MonoBehaviour
{
    public GameObject safeInventory;
    public TextMeshProUGUI money;
    public MoneyManager moneyManager;

    void Start()
    {
        safeInventory.SetActive(false);
        moneyManager = FindObjectOfType<MoneyManager>();
        money.text = moneyManager.GetPlayerMoney().ToString() + "€";
    }

    private void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E)) // Comprueba que se pulsa la tecla E
        {
            safeInventory.SetActive(true);
        }
    }

    public void OnTriggerExit()
    {
        safeInventory.SetActive(false);
    }
}
