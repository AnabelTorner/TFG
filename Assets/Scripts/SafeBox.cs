using UnityEngine;

public class SafeBox : MonoBehaviour
{

    public GameObject safeInventory;

    void Start()
    {
        safeInventory.SetActive(false);
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
