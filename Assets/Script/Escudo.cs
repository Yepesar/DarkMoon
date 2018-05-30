using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour {

    [SerializeField]
    private Sprite po1;
    [SerializeField]
    private Sprite po2;
    [SerializeField]
    private AudioClip sonido_escudo;
    [SerializeField]
    private AudioClip sonido_golpe_escudo;
    [SerializeField]
    private AudioClip sonido_golpe_nave;

    private AudioSource reproductor;
    private Player player;
    private SpriteRenderer sr;
    private int indice = 1;
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GetComponentInParent<Player>();
        sr.sprite = po1;
        gameObject.tag = "P01";
        reproductor = gameObject.AddComponent<AudioSource>();
    }
	
    private void CambiarPolaridad()
    {

        indice *= -1;

        if (indice == 1)
        {
            sr.sprite = po1;
            gameObject.tag = "P01";
        }

        if (indice == -1)
        {
            sr.sprite = po2;
            gameObject.tag = "P02";
        }

        Debug.Log("Polaridad del escudo cambiada");
        reproductor.clip = sonido_escudo;
        reproductor.Play();
    }

    public void Cambiar()
    {
        CambiarPolaridad();      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "P01" && collision.gameObject.tag == "Bala02")
        {
            player.Vidas -= 1;
            player.RecibirDaño();
            reproductor.clip = sonido_golpe_escudo;
            reproductor.Play();
        }
       

        if (gameObject.tag == "P02" && collision.gameObject.tag == "Bala01")
        {
            player.Vidas -= 1;
            player.RecibirDaño();
            reproductor.clip = sonido_golpe_escudo;
            reproductor.Play();
        }
        
        if(gameObject.tag == "P01" && collision.gameObject.tag == "Bala01" || gameObject.tag == "P02" && collision.gameObject.tag == "Bala02")
        {
            reproductor.clip = sonido_golpe_nave;
            reproductor.Play();
        }

        if (collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Enemy")
        {
            player.Vidas -= 1;
            player.RecibirDaño();
            reproductor.clip = sonido_golpe_nave;
            reproductor.Play();
        }
    }
}
