using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advertencia : MonoBehaviour
{
    public Enemigo enemigo;
    public GameObject iconoAdvertencia;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            enemigo.advertencia = true;
            iconoAdvertencia.SetActive(true);
        }
    }
}
