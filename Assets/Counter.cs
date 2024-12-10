using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] Text textCounter;

    public float countdownTime = 20f;
    private bool hasWon = false;
    public GameObject boxGana;

    public GameAudioController audioController;

    void Start()
    {
        if (audioController == null)
        {
            audioController = FindObjectOfType<GameAudioController>();
            if (audioController == null)
            {
                Debug.LogError("No se encontr� un GameAudioController en la escena.");
            }
        }
    }


    void Update()
    {
        if (!hasWon)
        {
            // Reduce el tiempo seg�n el tiempo real transcurrido
            countdownTime -= Time.deltaTime;
            countdownTime = Mathf.Clamp(countdownTime, 0, 20f); // Evita que sea menor a 0

            // Actualiza el texto en pantalla
            textCounter.text = "Tiempo: " + Mathf.Ceil(countdownTime).ToString();

            // Verifica si el contador llega a 0
            if (countdownTime <= 0)
            {
                hasWon = true;
                Win();
            }
        }
    }

    void Win()
    {
        textCounter.text = "�Ganaste!"; // Mensaje de victoria
        Time.timeScale = 0;
        boxGana.SetActive(true);
        // Aqu� puedes agregar m�s l�gica para manejar la victoria, como cargar una nueva escena o activar un panel

        if (audioController != null)
        {
            audioController.PlayWinSound();
        }
        else
        {
            Debug.LogWarning("No se asign� el controlador de audio en el script Counter.");
        }
    }
}