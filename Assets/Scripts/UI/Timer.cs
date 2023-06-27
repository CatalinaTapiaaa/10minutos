using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float tiempoCuentaAtras;
    public TextMeshProUGUI texto;

    private void Update()
    {
        tiempoCuentaAtras -= Time.deltaTime;
        texto.text = tiempoCuentaAtras.ToString("00:00");

        if (tiempoCuentaAtras <= 0)
        {
            Debug.Log("a");
            //activar efecto bomba nuclear
        }
    }
}

