using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioColorDaño : MonoBehaviour
{
    public Material blanco;
    public Material negro;
    public Renderer[] cuerpo;
    public bool activo;

    void Update()
    {
        if (activo == true)
        {
            foreach (Renderer renderer in cuerpo)
            {
                renderer.material = blanco;
            }
        }

        if (activo == false)
        {
            foreach (Renderer renderer in cuerpo)
            {
                renderer.material = negro;
            }
        }
    }
}
