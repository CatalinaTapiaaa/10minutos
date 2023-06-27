using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarArmaUI : MonoBehaviour
{
    [Header("Activar Canvas")]
    public GameObject pausa;

    [Header("Paneles")]
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;

    [Header("Armas")]
    public GameObject arma1;
    public GameObject arma2;
    public GameObject arma3;
    public GameObject arma4;
    public GameObject arma5;

    public void Si1()
    {
        arma1.SetActive(true);
        arma2.SetActive(false);
        arma3.SetActive(false);
        arma4.SetActive(false);
        arma5.SetActive(false);

        Time.timeScale = 1f;
        panel1.SetActive(false);
        pausa.SetActive(false);
    }
    public void Si2()
    {
        arma1.SetActive(false);
        arma2.SetActive(true);
        arma3.SetActive(false);
        arma4.SetActive(false);
        arma5.SetActive(false);

        Time.timeScale = 1f;
        panel2.SetActive(false);
        pausa.SetActive(false);
    }
    public void Si3()
    {
        arma1.SetActive(false);
        arma2.SetActive(false);
        arma3.SetActive(true);
        arma4.SetActive(false);
        arma5.SetActive(false);

        Time.timeScale = 1f;
        panel3.SetActive(false);
        pausa.SetActive(false);
    }
    public void Si4()
    {
        arma1.SetActive(false);
        arma2.SetActive(false);
        arma3.SetActive(false);
        arma4.SetActive(true);
        arma5.SetActive(false);

        Time.timeScale = 1f;
        panel4.SetActive(false);
        pausa.SetActive(false);
    }
    public void Si5()
    {
        arma1.SetActive(false);
        arma2.SetActive(false);
        arma3.SetActive(false);
        arma4.SetActive(false);
        arma5.SetActive(true);

        Time.timeScale = 1f;
        panel5.SetActive(false);
        pausa.SetActive(false);
    }

    public void No1()
    {
        Time.timeScale = 1f;
        panel1.SetActive(false);
        pausa.SetActive(false);
    }
    public void No2()
    {
        Time.timeScale = 1f;
        panel2.SetActive(false);
        pausa.SetActive(false);
    }
    public void No3()
    {
        Time.timeScale = 1f;
        panel3.SetActive(false);
        pausa.SetActive(false);
    }
    public void No4()
    {
        Time.timeScale = 1f;
        panel4.SetActive(false);
        pausa.SetActive(false);
    }
    public void No5()
    {
        Time.timeScale = 1f;
        panel5.SetActive(false);
        pausa.SetActive(false);
    }
}
