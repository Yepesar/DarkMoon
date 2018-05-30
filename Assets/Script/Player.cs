using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float velocidad;
    [SerializeField]
    private Button boton_derecha;
    [SerializeField]
    private float desplazamiento;
    [SerializeField]
    private int vidas = 3;
    [SerializeField]
    private GameObject vida01;
    [SerializeField]
    private GameObject vida02;
    [SerializeField]
    private GameObject vida03;
    [SerializeField]
    private GameObject botones;
    [SerializeField]
    private GameObject derrota;
    [SerializeField]
    private AudioClip sonido_explo;

    private AudioSource reproductor;
    private Animator anim;
    private bool vivo = true;

    public int Vidas
    {
        get
        {
            return vidas;
        }

        set
        {
            vidas = value;
        }
    }


    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        reproductor = gameObject.AddComponent<AudioSource>();
    }
	
	

    public void MoverseDerecha()
    {
        if (vivo)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(transform.position.x + desplazamiento, transform.position.y), velocidad * Time.deltaTime);
            anim.SetInteger("Estado", 1);
        }
    }

    public void MoverseIzquierda()
    {
        if (vivo)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(transform.position.x - desplazamiento, transform.position.y), velocidad * Time.deltaTime);
            anim.SetInteger("Estado", 3);
        }
    }

    public void MoverseArriba()
    {
        if (vivo)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + desplazamiento), velocidad * Time.deltaTime);
        }
    }

    public void MoverseAbajo()
    {
        if (vivo)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - desplazamiento), velocidad * Time.deltaTime);
        }
    }

    public void Quieto()
    {
        if (vivo)
        {
            anim.SetInteger("Estado", 0);
        }
    }
   
    private void Morir()
    {
        anim.SetInteger("Estado", 2);
        velocidad = 0;
        botones.SetActive(true);
        derrota.SetActive(true);
        reproductor.clip = sonido_explo;
        reproductor.Play();
        Vidas = 1;
        vivo = true;
    }


    public void RecibirDaño()
    {
        if(Vidas == 2)
        {
            vida01.SetActive(false);
        }

        if (Vidas == 1)
        {
            vida02.SetActive(false);
        }

        if (Vidas <= 0)
        {
            vida03.SetActive(false);
            vivo = false;
            Morir();
        }
    }
}
