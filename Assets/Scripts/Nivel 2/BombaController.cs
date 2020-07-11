using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaController : MonoBehaviour
{
    private bool Exploto = false;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Exploto == true)
        {
            animator.SetInteger("Estado", 1);
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Exploto = true;
    }

}
