using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class JugadorController : MonoBehaviour
{
    public AudioClip morirClip;
    public AudioClip monedaClip;
    public AudioClip saltarClip;
    public AudioClip dispararClip;
    private AudioSource audiosource;

    public GameObject Bala;
    public Transform PosicionBala;

    private int cont = 0;
    public float fuerzaSalto = 30;
    public float velocidad = 10;

    private string EnqueEscenaEstoy = "", VolverAEscena;

    private bool EstaSaltando = false;
    private bool EstaMuerto = false;
    private bool EstaDestruido = false;

    public bool ReiniciarJuego = false;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;

    private const int ANIMATION_QUIETO = 0;
    private const int ANIMATION_CAMINAR = 1;
    private const int ANIMATION_CORRER = 2;
    private const int ANIMATION_SALTAR = 3;
    private const int ANIMATION_ARRODILLARSE = 4;
    private const int ANIMATION_ATACAR = 5;
    private const int ANIMATION_DISPARAR = 6;
    private const int ANIMATION_MORIR = 7;

    public static int vidas=0;
    public static int Monedas = 0;
    public static int Balas = 0;
    public static int llaves = 0;
    public Text VidasText, MonedasText, BalasText;

    // Start is called before the first frame update
    void Start()//Se ejecuta la primera ves que es instanciado el objeto, la primera ves que aparece el jugador en escena
    {
        //Debug.Log("Esto se crea una unica vez");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audiosource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()//Se ejecuta siempre, como si tuvieramos un bucle eterno...Aqui va toda la programacion
    {
        //VidasText.text = "Vidas: " + vidas;
        MonedasText.text = ": X " + Monedas;
        Balas = Monedas/20;
        BalasText.text = ": X " + Balas;

        if (EstaMuerto != true & EstaDestruido==false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (Balas >= 1)
                {
                    CambiarAnimacion(ANIMATION_DISPARAR);
                    audiosource.PlayOneShot(dispararClip);
                    Instantiate(Bala, PosicionBala.position, Quaternion.identity);
                    Monedas = Monedas - 20;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && !EstaSaltando)
                {
                    //CambiarAnimacion(ANIMATION_SALTAR);
                    //Saltar();
                    rb.velocity = Vector2.up * fuerzaSalto;//Vector 2.up es para que salte hacia arriba
                    audiosource.PlayOneShot(saltarClip);
                    EstaSaltando = true;
                }
                else
                if (Input.GetKey(KeyCode.RightArrow))//Si presiono la tecla rigtharrow voy a ir hacia la derecha
                {
                    rb.velocity = new Vector2(velocidad, rb.velocity.y);//velocidad de mi objeto
                    CambiarAnimacion(ANIMATION_CORRER);//Accion correr 
                    spriteRenderer.flipX = false;//Que mi objeto mire hacia la derecha

                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rb.velocity = new Vector2(-velocidad, rb.velocity.y);
                    CambiarAnimacion(ANIMATION_CORRER);
                    spriteRenderer.flipX = true;
                    //}else if (Input.GetKey(KeyCode.X))
                    //{
                    //    CambiarAnimacion(ANIMATION_ATAQUE_ESPADA);
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    CambiarAnimacion(ANIMATION_ARRODILLARSE);//Metodo donde mi objeto se va a quedar quieto
                    rb.velocity = new Vector2(0, rb.velocity.y);//Dar velocidad a nuestro objeto
                }
                else
                {
                    CambiarAnimacion(ANIMATION_QUIETO);//Metodo donde mi objeto se va a quedar quieto
                    rb.velocity = new Vector2(0, rb.velocity.y);//Dar velocidad a nuestro objeto
                }
            }



        }
        else if(EstaDestruido==false)
        {
            CambiarAnimacion(ANIMATION_MORIR);
            rb.velocity = new Vector2(0, rb.velocity.y);//velocidad de mi objeto
            audiosource.PlayOneShot(morirClip);
            rb.gravityScale = 1f;
                //Destroy(this.gameObject, 2f);
                EstaDestruido = true;
                rb.gravityScale = 5;
            vidas--;
            Monedas = 0;
            cont = 0;
        }
        else
        {
            cont++;
            if (cont==80)
            {
                cont = 0;
                if (vidas > 0)
                {
                    DepredadorController.vidaDepredador = 20;
                    SceneManager.LoadScene(VolverAEscena/*"Nivel 1"*/);
                }
                else
                {
                    if (vidas == 0) { SceneManager.LoadScene("Menu"); }
                }
            }
        }
 
    }

    private void Saltar()
    {
        rb.velocity = Vector2.up * fuerzaSalto;//Vector 2.up es para que salte hacia arriba
    }

    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Acido" | collision.gameObject.tag == "Agua" | collision.gameObject.tag == "Lava" 
            | collision.gameObject.tag == "FuegoDragon" | collision.gameObject.tag == "Tiburon" | collision.gameObject.tag == "Hongo" 
            | collision.gameObject.tag == "MiniDepredador" | collision.gameObject.tag == "BalaDepredador" | collision.gameObject.tag == "Bomba")
        {
            EstaMuerto = true; 
        }
        if (collision.gameObject.tag == "BolaAcido")
        {
            EstaMuerto = true;
        }
        if (collision.gameObject.tag == "Bala")
        {
            EstaMuerto = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "Nivel1")
        {
            EnqueEscenaEstoy = "Nivel 1";
        }
        else if(collision.gameObject.name == "Nivel2")
        {
            EnqueEscenaEstoy = "Nivel 2";
        }
        else if(collision.gameObject.name=="Nivel3")
        {
            EnqueEscenaEstoy = "Nivel 3";
        }
        VolverAEscena = EnqueEscenaEstoy;

        if (collision.gameObject.tag == "Moneda") {
            Destroy(collision.gameObject);
            audiosource.PlayOneShot(monedaClip);
            Monedas++;
        }

        if (collision.gameObject.tag == "MonedaEspecial")
        {
            Monedas = Monedas + 50;
            audiosource.PlayOneShot(monedaClip);
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EstaSaltando = false;//Cuando choca con alguna colision lo cambie mi estado a false para que pueda nuevamente saltar

        if (collision.gameObject.tag == "Troll" | collision.gameObject.tag == "Jabali" | collision.gameObject.tag=="Bomba" | collision.gameObject.tag=="Rueda" 
            | collision.gameObject.tag == "MuñecoFuego" | collision.gameObject.tag == "GotaLava" | collision.gameObject.tag == "FuegoDragon" 
            | collision.gameObject.name== "Kakashi" | collision.gameObject.name == "Dinosaurio" | collision.gameObject.tag == "Tortuga" | collision.gameObject.tag == "Rayo" | collision.gameObject.name == "Depredador" | collision.gameObject.name == "DragonGrande")
        {
            EstaMuerto = true;
        }
        if (collision.gameObject.name == "LlaveN1")
        {
            llaves++;
            SceneManager.LoadScene("Nivel 2");
        }else if (collision.gameObject.name == "LlaveN2")
        {
            llaves++;
            SceneManager.LoadScene("Nivel 3");
        }
        else if(collision.gameObject.name == "LlaveN3")
        {
            llaves++;
            SceneManager.LoadScene("JuegoGanado");
        }

    }
}
