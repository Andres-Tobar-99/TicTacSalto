using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLose : MonoBehaviour
{
    public string floorTag = "piso"; // Tag del objeto que representa el piso
    public GameObject loseMessage;   // Mensaje o panel de derrota (opcional)

    public static bool gameLost = false; // Variable compartida para verificar si se ha perdido

    void Start()
    {
        // Asegúrate de que el mensaje de derrota esté desactivado al inicio
        if (loseMessage != null)
        {
            loseMessage.SetActive(false);
        }
        gameLost = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que tocó tiene el tag del piso
        if (!gameLost && collision.gameObject.CompareTag(floorTag))
        {
            gameLost = true; // Evita múltiples activaciones
            Lose();
        }
    }

    void Lose()
    {
        Debug.Log("¡Has perdido!"); // Mensaje en la consola
        if (loseMessage != null)
        {
            loseMessage.SetActive(true); // Activa el mensaje de derrota si está configurado
        }

        // Puedes agregar aquí más lógica, como detener el juego:
        Time.timeScale = 0; // Pausa el juego
    }
}
