using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemArma : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            Destroy(gameObject);
        }
    }
}
