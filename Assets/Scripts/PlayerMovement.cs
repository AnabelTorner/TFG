using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Velocidad de movimiento del jugador
    public float rotationSpeed = 3f; // Velocidad de rotaci�n del jugador
    public Transform cameraTransform; // Transform de la c�mara

    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true; // Evitar rotaciones debido a colisiones
    }

    void Update()
    {
        // Obtener la entrada de teclado para el movimiento horizontal y vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular la direcci�n de movimiento relativa a la c�mara
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Asegurarse de que forward y right no tengan componente y
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Calcular el vector de movimiento basado en la entrada del teclado y la c�mara
        Vector3 movement = forward * moveVertical + right * moveHorizontal;

        // Aplicar el movimiento al Rigidbody
        rb.velocity = movement * moveSpeed;

        // Actualizar el par�metro IsWalking del Animator basado en el movimiento
        bool isWalking = movement != Vector3.zero;
        animator.SetBool("IsWalking", isWalking);

        // Rotar el personaje hacia la direcci�n del movimiento
        if (isWalking)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
