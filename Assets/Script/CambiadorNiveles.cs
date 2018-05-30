using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CambiadorNiveles : MonoBehaviour {

	
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
