using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float force = 10f; // Fuerza de movimiento

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal"); // Entrada horizontal (teclas A/D o flechas izquierda/derecha)
        float v = Input.GetAxis("Vertical"); // Entrada vertical (teclas W/S o flechas arriba/abajo)

        Vector3 movement = new Vector3(h, 0f, v); // Vector de movimiento

        // Aplicar fuerza al Rigidbody solo si hay entrada de teclado
        if (Mathf.Abs(h) > 0.01f || Mathf.Abs(v) > 0.01f)
        {
            rb.AddForce(movement * force * Time.deltaTime);
        }
        else
        {
            // Detener el movimiento si no hay entrada de teclado
            rb.velocity = Vector3.zero;
        }
    }
}
