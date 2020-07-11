using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gota1LavaController : MonoBehaviour
{
    private int contador=1;
    public GameObject Zombies;

    public float velocidad = 3;

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

        //InvokeRepeating("Creando", 5f, 0f);//Que aparezca en 8 segundos
    }

    // Update is called once per frame
    void Update()//Se ejecuta siempre, como si tuvieramos un bucle eterno...Aqui va toda la programacion
    {

        //rb.velocity = new Vector2(-velocidad, rb.velocity.y);//velocidad de mi objeto
        //spriteRenderer.flipX = true;

    }
    //public void Creando()
    //{
    //    if (contador == 1)
    //    {
    //        Vector3 SpawnPosition = new Vector3(42.8f, -9.7f, 0);
    //        GameObject Zombie = Instantiate(Zombies, SpawnPosition, Quaternion.identity);
    //        contador = 2;
    //    }
    //    else if(contador == 2)
    //    {
    //        Vector3 SpawnPosition = new Vector3(68.7f, 12.2f, 0);
    //        GameObject Zombie = Instantiate(Zombies, SpawnPosition, Quaternion.identity);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(this.gameObject);
    }



}