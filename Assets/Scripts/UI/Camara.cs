using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject jugador;
    private Vector3 Desplazamiento = new Vector3(0, 0, 0);

    void Update()
    {
        transform.position = jugador.transform.position + Desplazamiento;
    }
}
