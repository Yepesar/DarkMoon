using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject enemigoPequeño;
    [SerializeField]
    private GameObject enemigoMedio;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private int cadencia;
    [SerializeField]
    private float velocidad;
    [SerializeField]
    private Transform punto00;
    [SerializeField]
    private Transform punto01;
    [SerializeField]
    private int unidades = 0;


    private int contador = 0;
    private Transform objetivo;

    private void Start()
    {
        objetivo = punto00;
    }

    // Update is called once per frame
    void Update ()
    {
        contador++;
        if (contador == cadencia && unidades > 0)
        {
            int num = Random.Range(0, 2);
            Debug.Log(num);

            if (num != 0)
            {
                Spawnear(enemigoPequeño);
                contador = 0;
            }
            if (num == 0)
            {
                Spawnear(enemigoMedio);
                contador = 0;
            }
        }
        else if(contador == cadencia && unidades <= 0) { CrearBoss(); }

        if(Vector2.Distance(transform.position,punto00.position) <= 1)
        {
            objetivo = punto01;
        }

        if (Vector2.Distance(transform.position, punto01.position) <= 1)
        {
            objetivo = punto00;
        }

        Moverse(objetivo);
    }

    private void Spawnear(GameObject objeto)
    {
        GameObject Clon = Instantiate(objeto, transform.position, Quaternion.identity);
        IA_Enemigo propiedades = Clon.GetComponent<IA_Enemigo>();
        propiedades.Cadencia = Random.Range(90, 200);
        propiedades.Velocidad = Random.Range(0.1f, 1.1f);
        Arma arma = Clon.GetComponent<Arma>();
        arma.Disparar1 = true;
        arma.Velocidad_balas = Random.Range(2, 6);
        unidades -= 1;
    }

    private void CrearBoss()
    {
        GameObject ClonBoss = Instantiate(boss, transform.position, Quaternion.identity);
        IA_Boss propiedades = ClonBoss.GetComponent<IA_Boss>();
        propiedades.Velocidad = Random.Range(1,3);
        propiedades.Cadencia = Random.Range(75, 95);
        ArmaBoss armaboss = ClonBoss.GetComponent<ArmaBoss>();
        armaboss.Disparar1 = true;
    }

    private void Moverse(Transform objetivo)
    {
        transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
    }

}
