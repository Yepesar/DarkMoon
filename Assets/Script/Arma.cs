using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

    [SerializeField]
    private GameObject bala;
    [SerializeField]
    private Transform salida;
    [SerializeField]
    private Transform final;
    [SerializeField]
    private int municion;
    [SerializeField]
    private float velocidad_balas;
    [SerializeField]
    private AudioClip sonido_disparo;
    [SerializeField]
    private bool disparar = false;

    private AudioSource reproductor;
    private GameObject[] balas;
    private int bala_actual;

    public float Velocidad_balas
    {
        get
        {
            return velocidad_balas;
        }

        set
        {
            velocidad_balas = value;
        }
    }

    public bool Disparar1
    {
        get
        {
            return disparar;
        }

        set
        {
            disparar = value;
        }
    }

   
    // Use this for initialization
    void Start ()
    {
        balas = new GameObject[municion];
        bala_actual = municion;
        CrearMunicion();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(bala_actual <= 0)
        {
            bala_actual = municion;
        }
	}

    private void CrearMunicion()
    {
        for (int i = 0; i < balas.Length; i++)
        {
            GameObject clon = Instantiate(bala, new Vector3(bala.transform.position.x, bala.transform.position.y - i), Quaternion.identity);
            balas[i] = clon;
        }

        Debug.Log("Municion de " + gameObject.name + " creada: " + balas.Length);
    }

    public void Disparar()
    {

        if (Disparar1)
        {
            if (!balas[bala_actual - 1].activeInHierarchy)
            {
                balas[bala_actual - 1].gameObject.SetActive(true);
            }

            Rigidbody2D rb = balas[bala_actual - 1].GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            balas[bala_actual - 1].transform.position = salida.position;
            Vector2 direccion = final.position - salida.position;
            direccion.Normalize();
            rb.AddForce(direccion * Velocidad_balas, ForceMode2D.Impulse);
            bala_actual -= 1;
            reproductor = GetComponent<AudioSource>();
            reproductor.clip = sonido_disparo;
            reproductor.Play();
        }

    }
}
