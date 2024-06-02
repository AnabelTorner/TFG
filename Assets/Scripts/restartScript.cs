using UnityEngine;

public class restartScript : MonoBehaviour
{
    public MoneyManager moneyManager;
    public BonusManager bonusManager;
    public VelocityBonus velocityBonus;
    public GameObject cuadroAviso;
    public GameObject invisibilityBonusCanvas;

    private void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        bonusManager = FindObjectOfType<BonusManager>();
        velocityBonus = FindObjectOfType<VelocityBonus>();
        
        Transform foundTransform = bonusManager.transform.Find("invisibilityBonusCanvas");
        invisibilityBonusCanvas = foundTransform.gameObject;
    }

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
        invisibilityBonusCanvas.SetActive(false);
        velocityBonus.restartVelocity();
    }

    public void OnTriggerExit()
    {
        cuadroAviso.SetActive(false);
    }
}
