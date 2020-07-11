using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagenVidaControlle : MonoBehaviour
{
    public Sprite[] Vidas;
    // Start is called before the first frame update
    void Start()
    {
        CambioVida();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambioVida()
    {
        this.GetComponent<Image>().sprite = Vidas[JugadorController.vidas];
    }
}
