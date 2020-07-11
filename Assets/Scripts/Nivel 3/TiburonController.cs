using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiburonController : MonoBehaviour
{
    public float fuerzaSalto = 5f;
    private Rigidbody2D rb;
    private bool colisiono = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colisiono == true)
        {
            rb.velocity = Vector2.down * fuerzaSalto;
        }
        else
        {
            rb.velocity = Vector2.up * fuerzaSalto;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ColisionTiburon")
        {
            colisiono = true;
        }
        if (collision.gameObject.tag == "Agua")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}