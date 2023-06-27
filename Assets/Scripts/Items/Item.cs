using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject componente;
    public Puntaje puntaje;
    public int puntos;

    public void Awake()
    {
        componente = GameObject.Find("Puntaje");
        puntaje = componente.GetComponent<Puntaje>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            puntaje.totalPuntaje += puntos;
            Destroy(gameObject);
        }
    }

}
