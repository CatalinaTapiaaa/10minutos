using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionJugador : MonoBehaviour
{
    Vector2 movimiento;
    public Animator ani;

    void Start()
    {
        ani.GetComponent<Animator>();
    }

    void Update()
    {
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");

        ani.SetFloat("Horizontal", movimiento.x);
        ani.SetFloat("Vertical", movimiento.y);
    }
}
