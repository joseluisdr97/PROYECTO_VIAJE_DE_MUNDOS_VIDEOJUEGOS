using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagenLlaveController : MonoBehaviour
{
    public Sprite[] Llaves;
    // Start is called before the first frame update
    void Start()
    {
        CambioLlave();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CambioLlave()
    {
        this.GetComponent<Image>().sprite = Llaves[JugadorController.llaves];
    }
}
