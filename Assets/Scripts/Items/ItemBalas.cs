using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBalas : MonoBehaviour
{
    public GameObject componente;
    public CantidadBalas cantidadBalas;
    public int balas;
    int random;

    void Start()
    {
        componente = GameObject.Find("Cantidad Balas");
        cantidadBalas = componente.GetComponent<CantidadBalas>();
        random = Random.Range(1, 5);
        balas = random;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            cantidadBalas.totalBalas += balas;
            Destroy(gameObject);
        }
    }
}
