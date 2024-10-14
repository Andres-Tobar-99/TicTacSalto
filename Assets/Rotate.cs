using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float initialSpeed = 20f; // Velocidad inicial r�pida
    public float maxSpeed = 100f; // Velocidad m�xima que alcanzar�
    public float acceleration = 0.5f; // Controla la rapidez con que se incrementa la velocidad (m�s bajo, m�s gradual)
    private float currentSpeed;
    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Incrementamos el tiempo transcurrido
        timeElapsed += Time.deltaTime;

        // Usamos una funci�n de suavizado para incrementar gradualmente la velocidad
        // Esto har� que la velocidad aumente r�pido al inicio y luego se vaya estabilizando
        currentSpeed = Mathf.Lerp(initialSpeed, maxSpeed, 1 - Mathf.Exp(-acceleration * timeElapsed));

        // Aplicamos la rotaci�n al objeto
        transform.Rotate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}
