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
        // Aseg�rate de que el mensaje de derrota est� desactivado al inicio
        if (loseMessage != null)
        {
            loseMessage.SetActive(false);
        }
        gameLost = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que toc� tiene el tag del piso
        if (!gameLost && collision.gameObject.CompareTag(floorTag))
        {
            gameLost = true; // Evita m�ltiples activaciones
            Lose();
        }
    }

    void Lose()
    {
        Debug.Log("�Has perdido!"); // Mensaje en la consola
        if (loseMessage != null)
        {
            loseMessage.SetActive(true); // Activa el mensaje de derrota si est� configurado
        }

        // Puedes agregar aqu� m�s l�gica, como detener el juego:
        Time.timeScale = 0; // Pausa el juego
    }
}
