using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBotiquin : MonoBehaviour
{
    public GameObject componente;
    public Jugador jugador;
    public int vidas;

    void Start()
    {
        componente = GameObject.Find("Cuerpo");
        jugador = componente.GetComponent<Jugador>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            jugador.vida += vidas;
            Destroy(gameObject);
        }
    }
}
