using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject pausa;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pausa.SetActive(true);
        }
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        pausa.SetActive(false);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
