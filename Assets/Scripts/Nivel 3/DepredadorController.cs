using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepredadorController : MonoBehaviour
{
    private int cont = 0;
    public static int vidaDepredador = 20;
    private bool EstaMuerto = false;
    public GameObject Bala;
    public Transform PosicionBala;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    private const int ANIMATION_QUIETO = 0;
    private const int ANIMATION_DISPARAR = 1;
    private const int ANIMATION_MORIR = 2;
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
        if (vidaDepredador == 0)
        {
            EstaMuerto = true;
        }
        if (!EstaMuerto)
        {
            cont++;
            if (cont >= 180)
            {
                CambiarAnimacion(ANIMATION_DISPARAR);
                if (cont == 190)
                {
                    Instantiate(Bala, PosicionBala.position, Quaternion.identity);
                    cont = 0;
                }
            }
            else
            {
                CambiarAnimacion(ANIMATION_QUIETO);
            }
        }
        else
        {
            CambiarAnimacion(ANIMATION_QUIETO);
            Destroy(this.gameObject, 1f);
        }

                   
    }

    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BalaJugador")
        {
            vidaDepredador--;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}