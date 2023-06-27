using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CantidadBalas : MonoBehaviour
{
    public int totalBalas;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMesh.text = totalBalas.ToString("0");
    }
}
