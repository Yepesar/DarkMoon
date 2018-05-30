using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Enemigo : MonoBehaviour {

    [SerializeField]
    private Arma arma;
    [SerializeField]
    private int cadencia;
    [SerializeField]
    private int vidaMax;
    [SerializeField]
    private float velocidad;
    [SerializeField]
    private AudioClip sonido_explosion;

    private AudioSource reproductor;
    private int vida;
    private int contador = 0;
    private Animator anim;
    
    

    public int Cadencia
    {
        get
        {
            return cadencia;
        }

        set
        {
            cadencia = value;
        }
    }

    public float Velocidad
    {
        get
        {
            return velocidad;
        }

        set
        {
            velocidad = value;
        }
    }

    public int Vida
    {
        get
        {
            return vida;
        }

        set
        {
            vida = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        Vida = vidaMax;     
        anim = GetComponent<Animator>();
        arma = GetComponent<Arma>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        contador++;

        if (contador >= Cadencia && arma != null)
        {
            arma.Disparar();
            contador = 0;
        }

        if (vida <= 0)
        {
            arma = null;
            anim.SetInteger("Estado", 1);
            reproductor = GetComponent<AudioSource>();
            reproductor.clip = sonido_explosion;
            reproductor.Play();
            vida = 1000000;
            Destroy(gameObject,1);
        }

        Moverse();
	}

    private void Moverse()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector3(transform.position.x,transform.position.y - 0.1f),Velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BalaPlayer")
        {
            vida -= 30;
        }

        if (collision.gameObject.tag == "Boss")
        {
            vida = 0;
        }

        if (collision.gameObject.tag == "P01" || collision.gameObject.tag == "P02")
        {
            vida = 0;
            Debug.Log("Me ha golpeado el jugador!");
        }
    }
}
