using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPuertas : MonoBehaviour
{
    public void Construir(List<Pieza> piezas, Armario armario, Holguras holguras){
        
        if(armario.puertaCorredera){
            Pieza puerta = piezas.Find(x => x.nombre.Equals("DM Puertas"));
            Pieza perfil = piezas.Find(x => x.nombre.Equals("Perfiles"));
            GameObject rodapie = GameObject.Find("Rodapie");
            GameObject tapajuntas = GameObject.Find("Tapajuntas");
            /* Añadir costado y sacar la posicion de z de las puertas del mismo */
            GameObject costado = GameObject.Find("Costados");

            Vector3 escalaPuerta = new Vector3(puerta.largo, puerta.ancho, puerta.grueso);
            Vector3 escalaPerfil = new Vector3(perfil.largo, 0.25f, puerta.grueso + 0.1f);

            Vector3 rotacion = new Vector3(0,0,90);

            float puertaInterior = costado.transform.position.z + costado.transform.localScale.y/2 - escalaPerfil.z/2;
            float puertaExterior = puertaInterior - escalaPerfil.z;

            float altura = rodapie.transform.position.y + rodapie.transform.localScale.y/2 + puerta.largo/2;
            float inicio = tapajuntas.transform.position.x + tapajuntas.transform.localScale.y/2 + escalaPerfil.z/2;
            GameObject puertas = new GameObject();
            puertas.name = "Puertas";
            for(int i = 0; i<puerta.cantidad; i++){
                if(i%2 == 0){
                    GameObject puertaAux = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    puertaAux.name = "Puerta" + i;

                    GameObject perfilAux = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    perfilAux.name = "Perfil";
                    perfilAux.GetComponent<Renderer>().material = Resources.Load("metal", typeof(Material)) as Material;
                    perfilAux.transform.localScale = escalaPerfil;
                    perfilAux.transform.eulerAngles = rotacion;
                    perfilAux.transform.position = new Vector3(inicio,altura, puertaInterior);
                    puertaAux.transform.localScale = escalaPuerta;
                    puertaAux.transform.eulerAngles = rotacion;
                    puertaAux.transform.position = new Vector3(perfilAux.transform.position.x + perfilAux.transform.localScale.y/2 + puertaAux.transform.localScale.y/2, perfilAux.transform.position.y,puertaInterior);
                    puertaAux.GetComponent<Renderer>().material = Resources.Load("violeta", typeof(Material)) as Material;
                    var perfilAux2 = Instantiate(perfilAux,new Vector3(puertaAux.transform.position.x + perfilAux.transform.localScale.y/2 + puertaAux.transform.localScale.y/2 , perfilAux.transform.position.y, puertaInterior),perfilAux.transform.rotation);
                    perfilAux2.name = "Perfil2";
                    perfilAux2.GetComponent<Renderer>().material = Resources.Load("metal", typeof(Material)) as Material;

                    perfilAux.transform.SetParent(puertaAux.transform, true);
                    perfilAux2.transform.SetParent(puertaAux.transform, true); 
                    puertaAux.transform.SetParent(puertas.transform, true);
                    inicio += puertaAux.transform.localScale.y + perfilAux.transform.localScale.y/2;
                } else {
                    GameObject puertaAux = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    puertaAux.name = "Puerta" + i;

                    GameObject perfilAux = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    perfilAux.name = "Perfil";
                    perfilAux.GetComponent<Renderer>().material = Resources.Load("metal", typeof(Material)) as Material;
                    perfilAux.transform.localScale = escalaPerfil;
                    perfilAux.transform.eulerAngles = rotacion;
                    perfilAux.transform.position = new Vector3(inicio,altura, puertaExterior);
                    puertaAux.transform.localScale = escalaPuerta;
                    puertaAux.transform.eulerAngles = rotacion;
                    puertaAux.transform.position = new Vector3(perfilAux.transform.position.x + perfilAux.transform.localScale.y/2 + puertaAux.transform.localScale.y/2, perfilAux.transform.position.y,puertaExterior);
                    puertaAux.GetComponent<Renderer>().material = Resources.Load("violeta", typeof(Material)) as Material;
                    var perfilAux2 = Instantiate(perfilAux,new Vector3(puertaAux.transform.position.x + perfilAux.transform.localScale.y/2 + puertaAux.transform.localScale.y/2 , perfilAux.transform.position.y, puertaExterior),perfilAux.transform.rotation);
                    perfilAux2.name = "Perfil2";
                    perfilAux2.GetComponent<Renderer>().material = Resources.Load("metal", typeof(Material)) as Material;

                    perfilAux.transform.SetParent(puertaAux.transform, true);
                    perfilAux2.transform.SetParent(puertaAux.transform, true); 
                    puertaAux.transform.SetParent(puertas.transform, true);
                    inicio += puertaAux.transform.localScale.y + perfilAux.transform.localScale.y/2;
                }
            }
        } else {
            Pieza puerta = piezas.Find(x => x.nombre.Equals("DM Puertas"));

            GameObject rodapie = GameObject.Find("Rodapie");
            GameObject tapajuntas = GameObject.Find("Tapajuntas");

            Vector3 escalaPuerta = new Vector3(puerta.largo, puerta.ancho, puerta.grueso);

            Vector3 rotacion = new Vector3(0,0,90);

            float alturaPomo = 10.5f;
            float distanciaPomo = 0.5f;

            float fondoPuerta = rodapie.transform.position.z + rodapie.transform.localScale.z/2;
            float altura = rodapie.transform.position.y + rodapie.transform.localScale.y/2 + puerta.largo/2;
            float puntero = tapajuntas.transform.position.x + tapajuntas.transform.localScale.y/2 + puerta.ancho/2 + holguras.h_puertas+0.02f;

            GameObject puertas = new GameObject();
            puertas.name = "Puertas";

            for(int i = 0; i<puerta.cantidad; i++){
                
                GameObject rotacionPuerta = new GameObject();
                rotacionPuerta.name = "Puerta"+ i;
                rotacionPuerta.transform.SetParent(puertas.transform, true);
                GameObject puertaAux = GameObject.CreatePrimitive(PrimitiveType.Cube);
                
                puertaAux.name = "Puerta" + i;

                GameObject perfilAux = GameObject.CreatePrimitive(PrimitiveType.Cube);
                
                puertaAux.transform.localScale = escalaPuerta;
                puertaAux.transform.eulerAngles = rotacion;
                puertaAux.transform.position = new Vector3(puntero, altura ,fondoPuerta);
                puertaAux.GetComponent<Renderer>().material = Resources.Load("violeta", typeof(Material)) as Material;
                rotacionPuerta.transform.position = new Vector3(i%2==0 && i!=puerta.cantidad-1 ? puertaAux.transform.position.x - puertaAux.transform.localScale.y/2 : puertaAux.transform.position.x + puertaAux.transform.localScale.y/2 , rotacionPuerta.transform.position.y, fondoPuerta);
                puertaAux.transform.SetParent(rotacionPuerta.transform, true); 
                GameObject pomo = Instantiate((GameObject)Resources.Load("Pomo"));
                pomo.transform.eulerAngles = new Vector3(180,0,0);
                pomo.transform.localScale = new Vector3(pomo.transform.localScale.x/2, pomo.transform.localScale.y/2, pomo.transform.localScale.z/2);
                if(i%2==0){
                    if(i == puerta.cantidad-1){
                        pomo.transform.position = new Vector3(puertaAux.transform.position.x - puertaAux.transform.localScale.y/2 + distanciaPomo, alturaPomo, puertaAux.transform.position.z - pomo.transform.localScale.z/2 );
                    } else {
                    pomo.transform.position = new Vector3(puertaAux.transform.position.x + puertaAux.transform.localScale.y/2 - distanciaPomo, alturaPomo, puertaAux.transform.position.z - pomo.transform.localScale.z/2 );
                    }
                    pomo.transform.SetParent(puertaAux.transform, true);
                } else {
                    pomo.transform.position = new Vector3(puertaAux.transform.position.x - puertaAux.transform.localScale.y/2 + distanciaPomo, alturaPomo, puertaAux.transform.position.z - pomo.transform.localScale.z/2 );
                    pomo.transform.SetParent(puertaAux.transform, true);
                }
                
                puntero += puertaAux.transform.localScale.y + holguras.h_puertas+0.02f;
                
            }
        }

    }

}
