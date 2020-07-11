using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonGrandeController : MonoBehaviour
{
    public float velocidad = 4;

    private bool EstaSubiendo = false;//Para que solo salte una vez

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()//Se ejecuta la primera ves que es instanciado el objeto, la primera ves que aparece el jugador en escena
    {
        //Debug.Log("Esto se crea una unica vez");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()//Se ejecuta siempre, como si tuvieramos un bucle eterno...Aqui va toda la programacion
    {
        if (EstaSubiendo == true)
        {
            rb.velocity = Vector2.up * velocidad;
        }
        else
        {
            rb.velocity = Vector2.down * velocidad;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TriguerDragon")//Todos los objetos que tengan como tag destruible
        {
            if (EstaSubiendo == true)
            {
                EstaSubiendo = false;
            }
            else
            {
                EstaSubiendo = true;
            }
        }
        if (collision.gameObject.tag == "BalaJugador")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}