using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explocion : MonoBehaviour
{
    float tiempo;

    private void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= 1)
        {
            Destroy(gameObject);
        }
    }
}
