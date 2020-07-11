﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorTiburonController : MonoBehaviour
{
    public float RangoInicial;
    public float RangoFinal;
    private Transform transform;
    public GameObject Tiburon;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        InvokeRepeating("Creando", 0f, Random.Range(RangoInicial, RangoFinal));
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void Creando()
    {
        Vector3 SpawnPosition = new Vector3(0, 0, 0);
        //SpawnPosition = this.transform.position + Random.onUnitSphere * RangoCreacion;
        SpawnPosition = new Vector3(transform.position.x, transform.position.y, 0);

        GameObject FDragon = Instantiate(Tiburon, SpawnPosition, Quaternion.identity);
    }
}