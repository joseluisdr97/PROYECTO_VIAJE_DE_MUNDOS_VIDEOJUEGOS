using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaAcidoController : MonoBehaviour
{
    public int velocidad = 3;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    private const int ANIMATION_CAMINAR = 0;
    private const int ANIMATION_ATACAR = 1;
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

        if (spriteRenderer.flipX == false)
        {
            rb.velocity = Vector2.up * velocidad;
        }
        else
        {
            rb.velocity = Vector2.down * velocidad;
        }
    }

    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TriguerAcido")
        {
            if (spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}