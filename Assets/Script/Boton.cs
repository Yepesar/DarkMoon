using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour 
{
    [SerializeField]
    private GameObject nave;  
    [SerializeField]
    private string ID;

    private bool moverse = false;
    private Player jugador;
    private Escudo escudo;
    private Arma arma;


    private void Start()
    {
        jugador = nave.GetComponent<Player>();
        escudo = nave.GetComponentInChildren<Escudo>();
        arma = nave.GetComponent<Arma>();
    }

    // Update is called once per frame
    void Update ()
    {
		if(ID == "Arriba" && moverse)
        {
            jugador.MoverseArriba();
        }

        if (ID == "Abajo" && moverse)
        {
            jugador.MoverseAbajo();
        }

        if (ID == "Derecha" && moverse)
        {
            jugador.MoverseDerecha();
        }

        if (ID == "Izquierda" && moverse)
        {
            jugador.MoverseIzquierda();
        }

        if (ID == "Arma" && moverse && arma != null)
        {
            arma.Disparar();
            moverse = false;
        }

        if (ID == "Escudo" && moverse && escudo != null)
        {
            escudo.Cambiar();
        }
    }

    private void OnMouseDown()
    {
        moverse = true;
    }

    private void OnMouseUp()
    {
        moverse = false;
        jugador.Quieto();
    }

    
}
