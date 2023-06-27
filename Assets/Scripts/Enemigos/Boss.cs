using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator ani;

    IEnumerable Start()
    {
        ani = GetComponent<Animator>();

        while (true)
        {
            yield return new WaitForSeconds(3);

            ani.SetInteger("MovimientoIndex", Random.Range(0, 1));
            ani.SetTrigger("Movimiento");
        }
    }
}
