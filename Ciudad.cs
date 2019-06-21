using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zombie = NPC.enemigo;
using aldeano = NPC.Amigo;
using UnityEngine.UI;

public class Ciudad : MonoBehaviour
{
    GameObject cube;
    GameObject heroe;
    int cont_Ald;
    int cont_Zomb;
    public Text num_Z;
    public Text num_C;
    public readonly int minimo_Cubos = Datos.cubos_pequeños;
    const int maximoCubos = Datos.cubos_Grandes;
    
    void Start()
    {
       
        heroe = GameObject.CreatePrimitive(PrimitiveType.Cube);
        heroe.AddComponent<Heroe>();
        
        for(int i = minimo_Cubos;  i < maximoCubos; i++)
        {
            int azar = Random.Range(0, 2);
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (azar == 0)
            {
                cube.AddComponent<aldeano.Aldeano>();
            }
            if (azar == 1)
            {
                cube.AddComponent<zombie.Zombie>();
            }
           
        }
        StartCoroutine(ContadorPNJ());
      
    }
    public void Stop()
    {
        StopCoroutine(ContadorPNJ());
    }

    IEnumerator ContadorPNJ()
    {
      
        zombie.Zombie[] infectados = FindObjectsOfType<zombie.Zombie>();
        foreach (zombie.Zombie z in infectados)
        {
           cont_Zomb++;
        }
        num_Z.text = "# de Zombies :" + cont_Zomb.ToString();
        aldeano.Aldeano[] pueblo = FindObjectsOfType<aldeano.Aldeano>();
        foreach(aldeano.Aldeano c in pueblo)
        {
            cont_Ald++;
        }
        num_C.text = "# de Ciudadanos : " + cont_Ald.ToString();
        yield return new WaitForSeconds(0.3f);
        
    }
}
