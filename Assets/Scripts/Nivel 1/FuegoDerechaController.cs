using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoDerechaController : MonoBehaviour
{
    public float velocidad = 6f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 7f);
    }


    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocidad, rb.velocity.y);
        spriteRenderer.flipX = true;
    }
}
