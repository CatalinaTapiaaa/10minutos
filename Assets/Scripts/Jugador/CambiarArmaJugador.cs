using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarArmaJugador : MonoBehaviour
{
    [Header("Desactivar Canvas")]
    public GameObject pausa;

    [Header("Paneles")]
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item Arma 1"))
        {
            Time.timeScale = 0f;
            panel1.SetActive(true);
        }
        if (other.CompareTag("Item Arma 2"))
        {
            Time.timeScale = 0f;
            panel2.SetActive(true);
        }
        if (other.CompareTag("Item Arma 3"))
        {
            Time.timeScale = 0f;
            panel3.SetActive(true);
        }
        if (other.CompareTag("Item Arma 4"))
        {
            Time.timeScale = 0f;
            panel4.SetActive(true);
        }
        if (other.CompareTag("Item Arma 5"))
        {
            Time.timeScale = 0f;
            panel5.SetActive(true);
        }
    }
}
