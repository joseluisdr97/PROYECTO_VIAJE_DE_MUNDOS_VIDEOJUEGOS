using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HongoController : MonoBehaviour
{


    private bool EstaMuerto = false;
    public int velocidad = 3;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    private const int ANIMATION_CAMINAR = 0;
    private const int ANIMATION_MORIR = 1;
    void Start()//Se ejecuta la primera ves que es instanciado el objeto, la primera ves que aparece el jugador en escena
    {
        Debug.Log("Esto se crea una unica vez");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()//Se ejecuta siempre, como si tuvieramos un bucle eterno...Aqui va toda la programacion
    {
        if (EstaMuerto == false)
        {
            CambiarAnimacion(ANIMATION_CAMINAR);//Accion correr

            if (spriteRenderer.flipX == false)
            {
                rb.velocity = new Vector2(velocidad, rb.velocity.y);//velocidad de mi objeto
            }
            else
            {
                rb.velocity = new Vector2(-velocidad, rb.velocity.y);//velocidad de mi objeto
            }
        }
        else
        {
            bc.isTrigger = false;
            CambiarAnimacion(ANIMATION_MORIR);//Accion correr
            rb.velocity = new Vector2(0, rb.velocity.y);//velocidad de mi objeto
            Destroy(this.gameObject,1f);
        }
    }

    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BordeTroll")
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
        if (collision.gameObject.name == "Jugador")
        {
            bc.isTrigger = false;
            EstaMuerto = true;
        }
    }
}