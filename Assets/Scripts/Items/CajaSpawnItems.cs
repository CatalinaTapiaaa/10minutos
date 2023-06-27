using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CajaSpawnItems : MonoBehaviour
{
    [Header("Barra de Carga")]
    public Slider barraDeCarga;
    public GameObject barra;
    public float tiempoDeCarga;
    bool estaDentro;

    [Header("Spawn Items")]
    public GameObject[] items;
    private int aleatorio;

    float carga;

    void Start()
    {
        aleatorio = Random.Range(0, items.Length);
        barraDeCarga.value = 0;
        barra.SetActive(false);

    }

    void Update()
    {
        if (estaDentro)
        {
            if (Input.GetKey(KeyCode.E))
            {
                barra.SetActive(true);
                carga += Time.deltaTime;
                barraDeCarga.value = carga / tiempoDeCarga;

                if (carga >= tiempoDeCarga)
                {
                    Destroy(gameObject);
                    Instantiate(items[aleatorio], transform.position, transform.rotation);
                }
            }

            else
            {
                barra.SetActive(false);
                barraDeCarga.value = 0;
                carga = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            estaDentro = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            estaDentro = false;
        }
    }
}
