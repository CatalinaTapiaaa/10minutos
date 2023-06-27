using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntar : MonoBehaviour
{
    public Jugador jugador;
    public Arma arma;
    public GameObject[] componentes;
    public Animator ani;

    private Camera cam;
    private Plane groundPlane;
    private float rayLength;
    void Start()
    {
        cam = Camera.main;
        ani = GetComponent<Animator>();
        groundPlane = new Plane(Vector3.up, transform.position);
    }
    void Update()
    {
        componentes = GameObject.FindGameObjectsWithTag("Punteros");
        arma = componentes[0].GetComponent<Arma>();

        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);

        if (arma.apuntar == true)
        {
            ani.SetBool("Apuntar", true);

            if (arma.disparar == true)
            {
                ani.SetBool("Disparar", true);
            }
            else if (arma.sinBalas == true)
            {
                ani.SetBool("SinBalas", true);
            }
        }
        else
        {
            ani.SetBool("Apuntar", false);
            ani.SetBool("Disparar", false);
            ani.SetBool("SinBalas", false);
        }


        if (Input.GetMouseButton(1))
        {
            if (groundPlane.Raycast(camRay, out rayLength))
            {
                Vector3 pointToLook = camRay.GetPoint(rayLength);
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
            arma.apuntar = true;
            jugador.noEstaApuntando = false;
            jugador.estaApuntando = true;
        }
        else
        {
            arma.apuntar = false;
            jugador.noEstaApuntando = true;
            jugador.estaApuntando = false;
        }
    }
}
