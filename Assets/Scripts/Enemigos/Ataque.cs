using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public Enemigo enemigo;
    public GameObject componente;
    public Jugador jugador;

    private void Update()
    {
        componente = GameObject.FindGameObjectWithTag("Jugador");
        jugador = componente.GetComponent<Jugador>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            jugador.jugadorDañado = true;
            enemigo.atacar = true;
            enemigo.jugador.vida -= enemigo.daño;
        }
    }
}
