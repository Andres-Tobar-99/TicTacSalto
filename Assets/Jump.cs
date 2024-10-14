using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 5f;
    public float fallMultiplier = 0.03f; // Multiplicador para caída rápida
    public float fastFallSpeed = 0.5f; // Velocidad para caer más rápido
    private bool isGrounded = true;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Si el jugador está en el aire y presiona la flecha hacia abajo, cae más rápido
        if (!isGrounded && Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(rb.velocity.x, -fastFallSpeed, rb.velocity.z); // Aplica una caída rápida
        }
        // Si está en el aire y no está presionando la flecha hacia abajo, aplica un multiplicador para la caída normal
        else if (!isGrounded && rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        
    }
}
