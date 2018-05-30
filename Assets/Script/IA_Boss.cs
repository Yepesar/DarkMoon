using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IA_Boss : MonoBehaviour {

    [SerializeField]
    private ArmaBoss arma;
    [SerializeField]
    private int cadencia;
    [SerializeField]
    private int vidaMax;
    [SerializeField]
    private float velocidad;
    [SerializeField]
    private Transform punto00;
    [SerializeField]
    private Transform punto01;
    [SerializeField]
    private GameObject botones;
    [SerializeField]
    private GameObject victoria;
    [SerializeField]
    private AudioClip sonido_explo;
   
    private Transform objetivo;
    private int vida;
    private int contador = 0;
    private int indice = 1;
    private Animator anim;
    private AudioSource reproductor;

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
    void Start()
    {
        Vida = vidaMax;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        contador++;

        if (contador >= Cadencia)
        {
            arma.Disparar();
            contador = 0;
        }

        if (vida <= 0)
        {
            anim.SetInteger("Estado", 1);
            botones.SetActive(true);
            victoria.SetActive(true);
            reproductor.clip = sonido_explo;
            reproductor.Play();
            Vida = 100000;
            Destroy(gameObject, 1);
        }

        if(indice == 1)
        {
            objetivo = punto00;
        }

        if (indice == -1)
        {
            objetivo = punto01;
        }

       
        Moverse(objetivo);
    }

    private void Moverse(Transform objetivo)
    {
        transform.position = Vector2.MoveTowards(transform.position, objetivo.position, Velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BalaPlayer")
        {
            vida -= 30;
            indice *= -1;
        }

        if (collision.gameObject.tag == "BalaPlayer")
        {
            vida -= 30;
            indice *= -1;
        }
    }
}
