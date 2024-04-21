using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Velocidad de movimiento del jugador

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evitar rotaciones debido a colisiones
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la entrada de teclado para el movimiento horizontal y vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento basado en la entrada del teclado
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Aplicar el movimiento al Rigidbody
        rb.velocity = movement * moveSpeed;
    }
}
