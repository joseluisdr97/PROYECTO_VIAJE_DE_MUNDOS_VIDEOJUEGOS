using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JuegoGanadoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void EmpezarJuego()
    {
        JugadorController.vidas = 5;
        JugadorController.Monedas = 0;
        JugadorController.Balas = 0;
        JugadorController.llaves = 0;
        SceneManager.LoadScene("Menu");
    }
    public void CerrarJuego()
    {
        Application.Quit();
    }
}