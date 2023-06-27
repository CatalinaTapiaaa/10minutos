using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public GameObject[] walkPoint;
    public NavMeshAgent agente;
    public GameObject componente;
    public Jugador jugador;
    public GameObject explocion;

    [Header("Stats")]
    public int vida;
    public int daño;

    [Header("Ataque")]
    public GameObject areaAdvertencia;
    public GameObject areaAtacar;

    [Header("Daño Balas")]
    public int bala1;
    public int bala2;
    public int bala3;
    public int bala4;
    public int bala5;


    [Header("Bool")]
    public bool advertencia;
    public bool perseguir;
    public bool atacar;

    bool tiempoSalida;

    [Header("Movimiento")]
    public float caminar;
    public float correr;
    float detener = 0;
    public float tiempoDeEspera;

    Vector3 target;
    float timer;
    float tiempo1;
    float tiempo2;
    float tiempo3;

    void Start()
    {
        walkPoint = GameObject.FindGameObjectsWithTag("Walk Points");
        componente = GameObject.Find("Cuerpo");
        agente = GetComponent<NavMeshAgent>();
        jugador = componente.GetComponent<Jugador>();
        target = walkPoint[0].transform.position;
    }

    private void Update()
    {
        if (vida <= 0)
        {
            Instantiate(explocion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (perseguir == false)
        {
            agente.speed = caminar;
            CambiarTarget();
        }
        else
        {
            agente.speed = correr;
            target = componente.transform.position;
        }

        if (atacar == true)
        {
            agente.speed = detener;
            areaAtacar.SetActive(false);
            tiempo2 += Time.deltaTime;

            if (tiempo2 >= 1)
            {
                areaAtacar.SetActive(true);
                atacar = false;
                tiempo2 = 0;
            }
        }

        if (advertencia == true)
        {
            agente.speed = detener;
            tiempo3 += Time.deltaTime;
            if (tiempo3 >= 1)
            {
                advertencia = false;
                tiempo3 = 0;
            }
        }

        if (tiempoSalida == true)
        {
            tiempo1 += Time.deltaTime;
            if (tiempo1 >= 1)
            {
                perseguir = false;
                areaAdvertencia.SetActive(true);
                tiempo1 = 0;
                tiempoSalida = false;
            }
        }
        agente.SetDestination(target);

        if (vida <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void CambiarTarget()
    {
        timer += Time.deltaTime;
        if (timer >= tiempoDeEspera)
        {
            target = walkPoint[Random.Range(0, walkPoint.Length)].transform.position;
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            perseguir = true;
            advertencia = false;
            areaAdvertencia.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            tiempoSalida = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            jugador.vida -= daño;
        }


        if (other.gameObject.CompareTag("Bala 1"))
        {
            vida -= bala1;
        }
        if (other.gameObject.CompareTag("Bala 2"))
        {
            vida -= bala2;
        }
        if (other.gameObject.CompareTag("Bala 3"))
        {
            vida -= bala3;
        }
        if (other.gameObject.CompareTag("Bala 4"))
        {
            vida -= bala4;
        }
        if (other.gameObject.CompareTag("Bala 5"))
        {
            vida -= bala5;
        }
    }
}
