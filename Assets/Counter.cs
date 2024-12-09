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

    void Update()
    {
        if (!hasWon)
        {
            // Reduce el tiempo según el tiempo real transcurrido
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
        textCounter.text = "¡Ganaste!"; // Mensaje de victoria
        Time.timeScale = 0;
        boxGana.SetActive(true);
        // Aquí puedes agregar más lógica para manejar la victoria, como cargar una nueva escena o activar un panel
    }
}
