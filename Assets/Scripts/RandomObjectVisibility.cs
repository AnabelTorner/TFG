using UnityEngine;

public class RandomObjectVisibility : MonoBehaviour
{
    public GameObject[] objetos;

    void Start()
    {
        // Oculta todos los objetos al inicio
        foreach (GameObject objetos in objetos)
        {
            objetos.SetActive(false);
        }

        // Escoge un objeto aleatorio para volverlo visible
        int indexObjetoVisible = Random.Range(0, objetos.Length);
        objetos[indexObjetoVisible].SetActive(true);
    }
}
