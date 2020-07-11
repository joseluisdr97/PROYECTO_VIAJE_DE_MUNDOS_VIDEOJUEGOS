using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CañonController : MonoBehaviour
{
    private int contador;
    public GameObject Bala;
    public GameObject BalaIzquierda;
    public Transform BalaPosisionIzquiera;
    public Transform BalaPosisionDerecha;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        contador++;
        if (contador == 1000)
        {
            Instantiate(Bala, BalaPosisionDerecha.position, Quaternion.identity);
        }
        if (contador == 1300)
        {
            Instantiate(BalaIzquierda, BalaPosisionIzquiera.position, Quaternion.identity);
            contador = 0;
        }
        
    }
}
