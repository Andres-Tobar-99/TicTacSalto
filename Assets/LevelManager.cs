using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BotonStart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void BotonExit()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
