using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaBoss : MonoBehaviour {

    [SerializeField]
    private GameObject bala;
    [SerializeField]
    private GameObject bala2;
    [SerializeField]
    private Transform salida;
    [SerializeField]
    private Transform final;
    [SerializeField]
    private Transform salida2;
    [SerializeField]
    private Transform final2;
    [SerializeField]
    private int municion;
    [SerializeField]
    private float velocidad_balas;
    [SerializeField]
    private AudioClip sonido_disparo;

    private GameObject[] balas;
    private GameObject[] balas2;
    private int bala_actual;
    private AudioSource reproductor;
    private bool disparar = false;

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
    void Start()
    {
        balas = new GameObject[municion];
        balas2 = new GameObject[municion];
        bala_actual = municion;
        CrearMunicion();
        reproductor = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bala_actual <= 0)
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

            GameObject clon2 = Instantiate(bala2, new Vector3(bala2.transform.position.x, bala2.transform.position.y - i), Quaternion.identity);
            balas2[i] = clon2;
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

            if (!balas2[bala_actual - 1].activeInHierarchy)
            {
                balas2[bala_actual - 1].gameObject.SetActive(true);
            }

            //Bala01
            Rigidbody2D rb = balas[bala_actual - 1].GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            balas[bala_actual - 1].transform.position = salida.position;
            Vector2 direccion = final.position - salida.position;
            direccion.Normalize();
            rb.AddForce(direccion * Velocidad_balas, ForceMode2D.Impulse);


            //Bala02
            Rigidbody2D rb2 = balas2[bala_actual - 1].GetComponent<Rigidbody2D>();
            rb2.velocity = Vector2.zero;
            balas2[bala_actual - 1].transform.position = salida2.position;
            Vector2 direccion2 = final2.position - salida2.position;
            direccion2.Normalize();
            rb2.AddForce(direccion2 * Velocidad_balas, ForceMode2D.Impulse);

            bala_actual -= 1;

            reproductor.clip = sonido_disparo;
            reproductor.Play();
        }

    }
}
