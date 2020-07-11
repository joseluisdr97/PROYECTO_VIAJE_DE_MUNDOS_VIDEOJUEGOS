using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoDragonGrandeController : MonoBehaviour
{
    public float velocidadX = -9;
    public float velocidadY = -9;
    // Start is called before the first frame update
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
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocidadX, rb.velocity.y);
        rb.velocity = new Vector2(velocidadY, rb.velocity.x);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
