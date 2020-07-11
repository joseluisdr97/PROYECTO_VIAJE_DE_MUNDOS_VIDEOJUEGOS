using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurcielagoController : MonoBehaviour
{
    public int velocidad = 6;
    private int contador;

    public GameObject Bomba;
    public Transform PosisionBomba;

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
        if (spriteRenderer.flipX == false)
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);//velocidad de mi objeto
        }
        else
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);//velocidad de mi objeto
        }

        contador++;
        if (contador == 120)
        {
            Instantiate(Bomba, PosisionBomba.position, Quaternion.identity);
            contador = 0;
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

            if (collision.gameObject.tag == "BalaJugador")
            {
                Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
