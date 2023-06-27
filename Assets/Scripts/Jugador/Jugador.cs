using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject armas;
    public Transform apuntar;
    public Animator ani;
    public Arma arma;
    public CambioColorDaño cambioColorDaño;
    public GameObject[] componentes;

    [Header("Canvas")]
    public GameObject pausa;
    public GameObject interfac;
    public GameObject gameOver;

    [Header("Animaciones")]
    public bool aniCaminar;
    public bool aniCorrer;
    public bool aniApuntar;

    [Header("Movimiento")]
    [SerializeField] private float apuntando;
    [SerializeField] private float caminar;
    [SerializeField] private float correr;
    public float tiempoRetrocesoDisparo;

    bool estaDentro;
    public bool estaApuntando;
    public bool noEstaApuntando;
    public bool jugadorDañado;
    public bool noMoverse;

    Vector3 movimiento;

    [Header("Salud")]
    [SerializeField] public int vida;
    [SerializeField] public float retroceso;
    public float tiempoRetroceso;

    float tiempoR;
    float tiempoR2;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        componentes = GameObject.FindGameObjectsWithTag("Punteros");
        arma = componentes[0].GetComponent<Arma>();         

        if (vida <= 0)
        {
            aniCaminar = false;
            aniCorrer = false;
            ani.SetBool("Muerte", true);
            noMoverse = true;

            gameOver.SetActive(true);
            interfac.SetActive(false);
            pausa.SetActive(false);
        }

        if (arma.disparar == true)
        {
            transform.position -= transform.forward * arma.retrocesoDisparo;
            tiempoR2 += Time.deltaTime;

            if (tiempoR2 >= tiempoRetrocesoDisparo)
            {
                arma.disparar = false;
                tiempoR = 0;
            }
        }



        if (noMoverse == false)
        {
            movimiento.x = Input.GetAxisRaw("Horizontal");
            movimiento.z = Input.GetAxisRaw("Vertical");

            if (jugadorDañado == true)
            {
                transform.position -= transform.forward * Time.deltaTime * retroceso;
                cambioColorDaño.activo = true;
                tiempoR += Time.deltaTime;

                if (tiempoR >= tiempoRetroceso)
                {
                    cambioColorDaño.activo = false;
                    jugadorDañado = false;
                    tiempoR = 0;
                }
            }
            else if (jugadorDañado == false)
            {
                if (noEstaApuntando == true)
                {
                    if (movimiento.magnitude > 0)
                    {
                        Quaternion newRotation = Quaternion.LookRotation(movimiento);
                        rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, newRotation, Time.fixedDeltaTime * 100f));
                    }
                }

                if (noEstaApuntando == false)
                {
                    Quaternion newRotation = Quaternion.Euler(0f, apuntar.rotation.eulerAngles.y, 0f);
                    transform.rotation = newRotation;
                }
            }
        }
        else if (noMoverse == true)
        {

        }
    }

    void FixedUpdate()
    {
        if (jugadorDañado == false)
        {
            if (noEstaApuntando == true)
            {
                if (estaDentro)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        rb.MovePosition(rb.position + movimiento * 0);
                        armas.SetActive(false);
                        aniCaminar = false;
                    }
                    else
                    {
                        rb.MovePosition(rb.position + movimiento * caminar * Time.fixedDeltaTime);
                        armas.SetActive(true);
                        aniCaminar = true;
                    }
                }

                if (!estaDentro)
                {
                    rb.MovePosition(rb.position + movimiento * caminar * Time.fixedDeltaTime);
                    aniCaminar = true;
                    aniCorrer = false;
                }

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    rb.MovePosition(rb.position + movimiento * correr * Time.fixedDeltaTime);
                    aniCaminar = false;
                    aniCorrer = true;
                }

                if (movimiento.magnitude > 0)
                {
                    Quaternion newRotation = Quaternion.LookRotation(movimiento);
                    rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, newRotation, Time.fixedDeltaTime * -100f));
                }

                else
                {
                    aniCaminar = false;
                    aniCorrer = false;
                }

                ani.SetBool("Apuntar", false);
            }

            if (estaApuntando == true)
            {
                rb.MovePosition(rb.position + movimiento * apuntando * Time.fixedDeltaTime);
                ani.SetBool("Apuntar", true);
                aniCaminar = false;
                aniCorrer = false;
            }
        }

        if (jugadorDañado == true)
        {
            rb.MovePosition(rb.position + movimiento * 0);

            aniCaminar = false;
            aniCorrer = false;
        }




        //Animaciones-----------------------
        if (aniCaminar == true)
        {
            ani.SetBool("Caminar", true);
        }
        if (aniCaminar == false)
        {
            ani.SetBool("Caminar", false);
        }

        if (aniCorrer == true)
        {
            ani.SetBool("Correr", true);
        }
        if (aniCorrer == false)
        {
            ani.SetBool("Correr", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactivo"))
        {
            estaDentro = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactivo"))
        {
            estaDentro = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            jugadorDañado = true;
        }
    }
}
