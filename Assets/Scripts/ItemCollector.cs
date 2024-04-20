using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private bool itemCollected = false; // Variable para rastrear si el objeto ha sido recogido
    public GameObject itemImage; // Imagen del objeto en el canvas
    public GameObject door;

    private void Start()
    {
        itemImage.SetActive(false);
    }

    // Propiedad para acceder al estado de recolección desde otros scripts
    public bool IsItemCollected
    {
        get { return itemCollected; }
    }

    private void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E)) // Comprueba que se pulsa la tecla E
        {
            gameObject.SetActive(false);
            itemImage.SetActive(true);
            RotateDoor();
        }
    }

    public void RotateDoor()
    {
        if (door != null)
        {
            // Girar el objeto 90 grados alrededor del eje Y
            door.transform.Rotate(0, 90, 0);
        }
    }
}
