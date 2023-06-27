using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public CantidadBalas cantidadBalas;
    public GameObject bala;
    public GameObject puntero;

    [Header("Sistema de Armas")]
    public float balasArma;
    public float retrocesoDisparo;
    public int tiempoEnfriamiento;
    float tiempo;
    public bool apuntar;
    public bool disparar;
    public bool sinBalas;

    void Update()
    {
        balasArma = cantidadBalas.totalBalas;

        if (apuntar == true)
        {
            puntero.SetActive(true);

            if (disparar == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (balasArma >= 1)
                    {
                        sinBalas = false;
                        tiempo += Time.deltaTime;
                        Instantiate(bala, transform.position, transform.rotation);
                        cantidadBalas.totalBalas -= 1;
                        disparar = true;

                        if (tiempo >= tiempoEnfriamiento)
                        {
                            tiempo = 0;
                            disparar = false;
                        }
                    }
                    if (balasArma <= 1)
                    {
                        sinBalas = true;
                    }
                }
                else
                {
                    disparar = false;
                }
            }           
        }
        if (apuntar == false)
        {
            puntero.SetActive(false);
        }
    }
}
