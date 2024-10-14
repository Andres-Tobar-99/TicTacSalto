using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float initialSpeed = 20f; // Velocidad inicial rápida
    public float maxSpeed = 100f; // Velocidad máxima que alcanzará
    public float acceleration = 0.5f; // Controla la rapidez con que se incrementa la velocidad (más bajo, más gradual)
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

        // Usamos una función de suavizado para incrementar gradualmente la velocidad
        // Esto hará que la velocidad aumente rápido al inicio y luego se vaya estabilizando
        currentSpeed = Mathf.Lerp(initialSpeed, maxSpeed, 1 - Mathf.Exp(-acceleration * timeElapsed));

        // Aplicamos la rotación al objeto
        transform.Rotate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}
