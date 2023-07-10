using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float moveSpeed = 5f;   // Velocidad de movimiento del pez

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Obtener la entrada del teclado
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        // Aplicar la fuerza al Rigidbody para mover al pez
        rb.AddForce(movement * moveSpeed);
    }
}