using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocaDesplazadoraController : MonoBehaviour
{
    public int velocidad = 3;
    private bool Colisiono = true;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    void Start()//Se ejecuta la primera ves que es instanciado el objeto, la primera ves que aparece el jugador en escena
    {
        Debug.Log("Esto se crea una unica vez");
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()//Se ejecuta siempre, como si tuvieramos un bucle eterno...Aqui va toda la programacion
    {
        if (Colisiono == false)
        {
            rb.velocity = Vector2.up * velocidad;
            rb.gravityScale = 0;
        }
        else
        {
            rb.velocity = Vector2.down * velocidad;
            rb.gravityScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BordeTroll")
        {
            if (Colisiono == true)
            {
                Colisiono = false;
            }
            else
            {
                Colisiono = true;
            }

        }

    }
}