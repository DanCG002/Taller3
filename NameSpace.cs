using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
   namespace enemigo
   {
        public class Zombie:MonoBehaviour
        {
            GameObject enem;
            Vector3 meta;
            Vector3 rotacion;

          public enum Extremidades
            {
                cabeza,cuello,torso,piernas,brazos
            }
            public Extremidades deseos;          

            public enum Estado_Zomb
            {
               movimiento, quieto,rotacion
            }
            Estado_Zomb estado_Zomb;
                      
            public enum Colores
            {
                magenta,cyan,verde
            }
            Colores zomb_Color;
            public struct DatosZombie
            {
                public  Colores color;
                public Extremidades deseos;
                public Estado_Zomb estados;
            }
            
             void Start()
             {
                int azar = Random.Range(0, 3);
                enem = gameObject;
                enem.name = "Zombie";
                enem.transform.position = new Vector3(Random.Range(-20, 20), 0f, Random.Range(-20, 15));
                enem.AddComponent<Rigidbody>();
                enem.GetComponent<Rigidbody>().useGravity = false;
                enem.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                zomb_Color = (Colores)Random.Range(0, 3);
                if (zomb_Color== Colores.cyan)
                {
                    enem.GetComponent<Renderer>().material.color = Color.cyan;
                }
                if (zomb_Color==Colores.magenta)
                {
                    enem.GetComponent<Renderer>().material.color = Color.magenta;
                }

                if (zomb_Color == Colores.verde)
                {
                    enem.GetComponent<Renderer>().material.color = Color.green;
                }
               
                    StartCoroutine(EstadosZombie());                                               
             }

             void Update()
            {
                if (estado_Zomb == Estado_Zomb.quieto)
                {
                    Debug.Log("Estoy quieto");
                }

                if (estado_Zomb == Estado_Zomb.movimiento)
                {
                    transform.Translate(meta * Time.deltaTime*0.3f);
                }
                if (estado_Zomb == Estado_Zomb.rotacion)
                {
                    transform.Rotate(rotacion);
                }
                
            }

            public DatosZombie Get_Datos_Zomb()
            {
                deseos = (Extremidades)Random.Range(0, 4); 
                DatosZombie datos = new DatosZombie();
                switch(deseos)
                {
                    case Extremidades.cabeza:
                        datos.deseos = Extremidades.cabeza;
                        Debug.Log("warrrrr soy un Zombie y quiero comerme tus" + datos.deseos);
                        break;
                    case Extremidades.cuello:
                        datos.deseos = Extremidades.cuello;
                        Debug.Log("warrrrr soy un Zombie y quiero comerte tu" + datos.deseos);
                        break;
                    case Extremidades.torso:
                        datos.deseos = Extremidades.torso;
                        Debug.Log("warrrrr soy un Zombie y quiero comerme tu" + datos.deseos);
                        break;
                    case Extremidades.brazos:
                        datos.deseos = Extremidades.brazos;
                        Debug.Log("warrrrr soy un Zombie y quiero comerte tu" + datos.deseos);
                        break;
                }
               
                return datos;

               
            }

             public IEnumerator EstadosZombie()
            {
               
                estado_Zomb = (Estado_Zomb)Random.Range(0, 3);
                switch(estado_Zomb)
                {
                    case Estado_Zomb.movimiento:
                        meta = new Vector3(Random.Range(-22, 20), 0f, Random.Range(-20, 20));
                        yield return null;
                        break;
                    case Estado_Zomb.quieto:
                        Debug.Log("No hacer nada.");
                        break;
                    
                    case Estado_Zomb.rotacion:
                        rotacion = new Vector3(0f, 1f, 0f);
                        yield return null;
                        break;
                }                
                yield return new WaitForSeconds(3f);
                yield return EstadosZombie();
             }


        }
    }

    namespace Amigo
    {
        public class Aldeano:MonoBehaviour
        {
            GameObject aldeano;
            public enum Nombres
            {
                Fred, Carlos, Jeremy, Annie, Carmen, Andres, Canela, Robin,
                Arturo, Otoniel, Robert, Fausto, Javier, Hernan, Larry, Gregorio, Zac,
                Victor, Rosa, Daniela
            }
          

            public struct Info_Aldeano
            {
                public int años;
                public string apodo;

            }
           // Info_Aldeano info;

            void  Start()
            {
                aldeano = gameObject;
                aldeano.GetComponent<Renderer>().material.color = Color.yellow;
                aldeano.name = "aldeano";
                aldeano.transform.position = new Vector3(Random.Range(-25, 20), 0f, Random.Range(-20, 25));
                aldeano.AddComponent<Rigidbody>();
                aldeano.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                aldeano.GetComponent<Rigidbody>().useGravity = false;
               
                
            }

            public Info_Aldeano Datos()
            {
                Info_Aldeano info = new Info_Aldeano();
                info.apodo = ((Nombres)Random.Range(0, 21)).ToString();
                info.años = Random.Range(15, 101);

                return info;
            }

        }
    }


}
