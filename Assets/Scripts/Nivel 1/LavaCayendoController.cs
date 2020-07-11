using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCayendoController : MonoBehaviour
{
    public int tiempo;
    private int contador;

    public GameObject Gota;
    public Transform PosisionGota;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;



    void Start()//Se ejecuta la primera ves que es instanciado el objeto, la primera ves que aparece el jugador en escena
    {
        Debug.Log("Esto se crea una unica vez");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()//Se ejecuta siempre, como si tuvieramos un bucle eterno...Aqui va toda la programacion
    {
        contador++;
        if (contador == tiempo)
        {
            Instantiate(Gota, PosisionGota.position, Quaternion.identity);
            contador = 0;
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Suelo")
    //    {

    //    }
    //}
}
