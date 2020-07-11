using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControlller : MonoBehaviour
{
    //private GameObject Jugador;

    // Start is called before the first frame update
    void Start()
    {
        //Jugador = GameObject.Find("Jugador");//Obtenermos el objeto por su nombre para poder manipularlo
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
        DepredadorController.vidaDepredador = 20;
        SceneManager.LoadScene("Nivel 1");
    }
    public void CerrarJuego()
    {
        Application.Quit();
    }
}
