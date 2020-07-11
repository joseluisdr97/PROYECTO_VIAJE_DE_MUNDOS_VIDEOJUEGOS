using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagenBarraController : MonoBehaviour
{
    public Sprite[] VidasDepredador;
    // Start is called before the first frame update
    void Start()
    {
        //CambioImagen();
    }

    // Update is called once per frame
    void Update()
    {
        CambioImagen();
    }
    public void CambioImagen()
    {
        if (DepredadorController.vidaDepredador >= 0)
        {
            this.GetComponent<Image>().sprite = VidasDepredador[DepredadorController.vidaDepredador];
        }
    }
}
