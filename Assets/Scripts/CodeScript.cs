using TMPro;
using UnityEngine;

public class CodeScript : MonoBehaviour
{
    // Referencia al componente TextMeshPro
    public TextMeshProUGUI code;
    public GameObject note;

    void Start()
    {
        // Generar cuatro números aleatorios entre 0 y 9 y asignarlos como texto
        string randomNumbers = GenerateRandomNumbers();
        code.text = randomNumbers;
        note.SetActive(false);
    }

    // Método para generar cuatro números aleatorios como texto
    string GenerateRandomNumbers()
    {
        string numbers = "";
        for (int i = 0; i < 4; i++)
        {
            // Generar un número aleatorio entre 0 y 9 y agregarlo al texto
            int randomNumber = Random.Range(0, 10);
            numbers += randomNumber.ToString();
        }
        return numbers;
    }

    private void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E)) // Comprueba que se pulsa la tecla E
        {
            note.SetActive(true);
        }
    }

    public void OnTriggerExit()
    {
        note.SetActive(false);
    }
}
