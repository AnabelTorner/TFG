using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartScript : MonoBehaviour
{
    public MoneyManager moneyManager;
    public BonusManager bonusManager;
    public GameObject cuadroAviso;
    public GameObject InvisibilityBonusCanvas;

    private void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E)) // Comprueba que se pulsa la tecla E
        {
            cuadroAviso.SetActive(true);
        }
    }
    
    public void restartAll()
    {
        moneyManager.RestartMoney();
        bonusManager.RestartBonus();
        cuadroAviso.SetActive(false);
        InvisibilityBonusCanvas.SetActive(false);
    }
}
