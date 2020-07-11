using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPequeñoController : MonoBehaviour
{
    private bool cambiarFlip = false;
    private int contador;
    private int contAnim = 0;
    public GameObject FuegoD;
    public GameObject FuegoI;
    public Transform BalaPosisionIzquiera;
    public Transform BalaPosisionDerecha;
    private Transform transform;
    private GameObject fuego;

    private Animator animator;

    private SpriteRenderer spriteRendere;

    private const int ANIMATION_Quieto = 0;
    private const int ANIMATION_ATACAR = 1;
    void Start()//Se ejecuta la primera ves que es instanciado el objeto, la primera ves que aparece el jugador en escena
    {
        Debug.Log("Esto se crea una unica vez");
        animator = GetComponent<Animator>();
        spriteRendere = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (cambiarFlip == false)
        {
            spriteRendere.flipX = true;
            transform = BalaPosisionIzquiera;
            fuego = FuegoI;
        }
        else if(cambiarFlip==true)
        {
            spriteRendere.flipX = false;
            transform = BalaPosisionDerecha;
            fuego = FuegoD;
        }
        contador++;
        if (contador == 500)
        {
            CambiarAnimacion(ANIMATION_ATACAR);
            Instantiate(fuego, transform.position, Quaternion.identity);
            for (contAnim = 0; contAnim < 300; contAnim++) { }contAnim = 0;
        }
        else if (contador == 800)
        {
            CambiarAnimacion(ANIMATION_ATACAR);
            Instantiate(fuego, transform.position, Quaternion.identity);
            //Instantiate(FuegoI, BalaPosisionIzquiera.position, Quaternion.identity);
            contador = 0;
            for (contAnim = 0; contAnim < 300; contAnim++) { }
            contAnim = 0;
        }
        else
        {
            CambiarAnimacion(ANIMATION_Quieto);
        }


    }
private void CambiarAnimacion(int animacion)
{
    animator.SetInteger("Estado", animacion);
}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Jugador")
        {
            cambiarFlip = true;
        }
            if (collision.gameObject.tag == "BalaJugador")
            {
                Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

}
