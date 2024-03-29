﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroe : MonoBehaviour
{
    GameObject heroe;
  
    void Start()
    {
        heroe = gameObject;
        heroe.name = "Heroe";
        heroe.GetComponent<Renderer>().material.color = Color.red;
        heroe.AddComponent<Rigidbody>();
        heroe.GetComponent<Rigidbody>().useGravity = false;
        heroe.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;        
        heroe.AddComponent<Camera>();
        heroe.AddComponent<Movimiento>();
    }
}
