using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public GameObject itemImage; // Imagen del objeto en el canvas
    public GameObject door;
    public GameObject exit = null;

    public bool lastObject = false; // Bool para saber si es el objeto que completa el nivel

    private void Start()
    {
        itemImage.SetActive(false);
        exit.SetActive(false);
    }

    private void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E)) // Comprueba que se pulsa la tecla E
        {
            gameObject.SetActive(false);
            itemImage.SetActive(true);
            rotateDoor();
            levelCompleted();
        }
    }

    private void rotateDoor()
    {
        if (door != null)
        {
            // Girar el objeto 90 grados alrededor del eje Y
            door.transform.Rotate(0, 90, 0);
        }
    }

    private void levelCompleted()
    {
        if (lastObject && exit != null)
        {
            // Activar salida
            exit.SetActive(true);
        }
    }
}
