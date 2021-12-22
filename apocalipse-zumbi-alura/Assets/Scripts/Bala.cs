﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody rigibodyBala;

    public float Velocidade = 20;
    
    //som morte zumbi
    public AudioClip SomDeMorte;
    // Start is called before the first frame update
    private void Start()
    {
        rigibodyBala = GetComponent<Rigidbody>();
    }

    // fazendo bala ir em linha reta
    // Update is called once per frame
    void FixedUpdate()
    {
        rigibodyBala.MovePosition
            (rigibodyBala.position + 
             transform.forward * Velocidade * Time.deltaTime);
    }

    //destruindo um inimigo com a bala
    private void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (objetoDeColisao.tag == "Inimigo")
        {
            Destroy(objetoDeColisao.gameObject);
            //som de morte zumbi
            ControlaAudio.instancia.PlayOneShot(SomDeMorte);
        }
        
        //destruindo a bala depois dela colidir com qualquer coisa
        Destroy(gameObject);
    }
}