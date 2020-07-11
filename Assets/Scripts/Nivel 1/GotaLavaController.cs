using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotaLavaController : MonoBehaviour
{ 
    private bool Exploto = false;
    private int contAnim = 0;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    private const int ANIMATION_CAER = 0;
    private const int ANIMATION_SALPICAR = 1;

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
            Exploto = false;
        }
        else
        {
            animator.SetInteger("Estado", 0);
            Exploto = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Exploto = true;
        //Destroy(this.gameObject,1f);
    }

}