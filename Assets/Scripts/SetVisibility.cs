using UnityEngine;

public class SetVisibility : MonoBehaviour
{
    public GameObject objeto;

    void Start()
    {
        objeto.SetActive(false);
    }

    private void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E)) // Comprueba que se pulsa la tecla E
        {
            objeto.SetActive(true);
        }
    }

    public void OnTriggerExit()
    {
        objeto.SetActive(false);
    }
}
