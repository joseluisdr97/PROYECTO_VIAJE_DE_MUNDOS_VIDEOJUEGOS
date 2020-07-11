using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuedaController : MonoBehaviour
{
    public GameObject Ruedas;

    public float velocidad = 5;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()//Se ejecuta la primera ves que es instanciado el objeto, la primera ves que aparece el jugador en escena
    {
        Debug.Log("Esto se crea una unica vez");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        InvokeRepeating("Creando", 6f, 0f);//Que aparezca en 8 segundos
    }

    // Update is called once per frame
    void Update()//Se ejecuta siempre, como si tuvieramos un bucle eterno...Aqui va toda la programacion
    {

        rb.velocity = new Vector2(-velocidad, rb.velocity.y);//velocidad de mi objeto
        spriteRenderer.flipX = true;

    }
    public void Creando()
    {
        Vector3 SpawnPosition = new Vector3(409.2f, 47f, 0);
        GameObject Zombie = Instantiate(Ruedas, SpawnPosition, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BalaJugador")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Acido")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }



}