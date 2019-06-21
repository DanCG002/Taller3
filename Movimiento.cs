using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zombie = NPC.enemigo;
using aldeano = NPC.Amigo;

public class Movimiento : MonoBehaviour
{
   
    void Update()
    {
        float H = Input.GetAxisRaw("Horizontal");
        float V = Input.GetAxisRaw("Vertical");

        transform.Rotate(0f, H * 2f, 0);
        transform.Translate(0f, 0f, V * 0.5f);
    }

    void OnCollisionEnter(Collision collision)
    {
       if (collision.collider.GetComponent<zombie.Zombie>())
        {
            zombie.Zombie zombie = collision.collider.GetComponent<zombie.Zombie>();
            Debug.Log("Wrrrrrr soy un Zombie y quiero comer" + " " + zombie.Get_Datos_Zomb().deseos);
        }
        if (collision.collider.GetComponent<aldeano.Aldeano>())
        {
            aldeano.Aldeano ciud = collision.collider.GetComponent<aldeano.Aldeano>();
            Debug.Log("Hola soy " + ciud.Datos().apodo + " y tengo " + ciud.Datos().años + " años");
        }
    } 
}
