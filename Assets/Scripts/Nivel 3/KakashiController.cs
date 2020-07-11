using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KakashiController : MonoBehaviour
{
    public static bool LanzarRayo = false;
    private float fuerzSalto=0;
    private Rigidbody2D rb;
    private int cont = 0;
    private Animator animator;
    private bool puedesaltar = false;

    public GameObject Rayo;
    public Transform Posision1;
    public Transform Posision2;
    public Transform Posision3;
    public Transform Posision4;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cont++;

        //if (cont >= 100)
        //{
        //    animator.SetInteger("Estado", 1);
        //    if (cont == 100)
        //    {
        //        
        //    }
        //    else if (cont == 132)
        //    {
        //        cont = 0;
        //    }
        //}



        if (LanzarRayo == true)
        {
            Instantiate(Rayo, Posision1.position, Quaternion.identity);
            Instantiate(Rayo, Posision2.position, Quaternion.identity);
            Instantiate(Rayo, Posision3.position, Quaternion.identity);
            Instantiate(Rayo, Posision4.position, Quaternion.identity);
            LanzarRayo = false;
        }
        if (cont >99 && cont<101 && puedesaltar ==true)
        {
            rb.velocity = Vector2.up * 60;
            puedesaltar = false;
        }
        else
        {
            if(cont>100 && cont < 150)
            {
                animator.SetInteger("Estado", 1);
            }
            else if(cont >0 && cont<100)
            {
                animator.SetInteger("Estado", 0);
            }
        }
        if (cont == 150)
        {
            cont = 0;
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            LanzarRayo = true;
        }
        puedesaltar = true;
    }
}
