using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    public int totalPuntaje;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMesh.text = totalPuntaje.ToString("0");
    }
}