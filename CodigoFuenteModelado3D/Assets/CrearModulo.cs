using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearModulo : MonoBehaviour
{
    /************************* TODO *********************************/
    /* -Implementación de la posicion de los muebles en el caso de que el armario sea rinconero
        Se debe contemplar que cada tipo de hueco implicara una disposicion diferente de los modulos */
    /****************************************************************/

    public void Construir(List<Pieza> piezas, Armario armario, Holguras holguras){

        /* Obtengo el tamaño de la base corta mas el costado en el caso de que exista, en caso contrario almaceno 0 */
        float tamanioBaseCorta = piezas.Find(x => x.nombre.Equals("Bases Cortas")) != null ? piezas.Find(x => x.nombre.Equals("Bases Cortas")).largo: 0;

        /* Puntero para la posición de los módulos */
        float puntero = 0;

        /* Variable de control de ancho de un módulo */
        float anchoModuloNormal = 0;

        /* Tapeta posicionada adyacente al costado */
        float gruesoTapeta = 0.1f;
        

        /* Establece fondo de los costados centrales en caso de que sea armario con puertas correderas */
        float fondoCentrales = 0;
        float fondoNormal = 0;
        float diferencia = 0;
        
        /* Establecer altura de los modulos */
        float alturaModulo = armario.alturaPatas;

        /* Establece los valores del costado, costado central y su diferencia */
        if(armario.puertaCorredera && armario.modulos > 1){        
            fondoCentrales = piezas.Find(x => x.nombre == "Costados Centrales").ancho;
            fondoNormal = piezas.Find(x => x.nombre == "Costados").ancho;
            diferencia = (fondoNormal - fondoCentrales)/2;
        }

        for(int i = 0; i < armario.modulos; i++){

            /* Creación de el GameObject padre y escalado de las piezas pertenecientes al mismo */
            GameObject modulo = new GameObject();
            modulo.name = "Modulo"+ i;

            float alturaCostado = piezas.Find(x => x.nombre == "Costados").largo;
            
            Pieza p = piezas.Find(x => x.nombre == "Bases");
            GameObject @base = GameObject.CreatePrimitive(PrimitiveType.Cube);
            @base.GetComponent<Renderer>().material = Resources.Load("roble", typeof(Material)) as Material;
             

            @base.name = p.nombre;
            @base.transform.localScale = new Vector3(p.largo,p.ancho,p.grueso);
            @base.transform.eulerAngles = new Vector3(@base.transform.eulerAngles.x+90,@base.transform.eulerAngles.y,@base.transform.eulerAngles.z);
            @base.transform.position = new Vector3(0,0,0);
            @base.transform.SetParent(modulo.transform,false);
            Instantiate(@base,new Vector3(@base.transform.position.x, alturaCostado-p.grueso, @base.transform.position.z), @base.transform.rotation).transform.SetParent(modulo.transform,false);

            p = piezas.Find(x => x.nombre == "Costados");

            GameObject costado = GameObject.CreatePrimitive(PrimitiveType.Cube);
            costado.GetComponent<Renderer>().material = Resources.Load("roble", typeof(Material)) as Material;

            costado.transform.SetParent(modulo.transform,false);
            costado.name = p.nombre;
            costado.transform.localScale = new Vector3(p.largo,p.ancho,p.grueso);
            costado.transform.eulerAngles = new Vector3(costado.transform.eulerAngles.x,costado.transform.eulerAngles.y + 90,costado.transform.eulerAngles.z + 90);
            costado.transform.position = new Vector3(costado.transform.position.x - p.grueso/2 - (piezas.Find(x => x.nombre == "Bases").largo/2), costado.transform.position.y+ (p.largo/2-piezas.Find(x => x.nombre == "Bases").grueso/2), costado.transform.position.z);

            Instantiate(costado,new Vector3(costado.transform.position.x + p.grueso + (piezas.Find(x => x.nombre == "Bases").largo), costado.transform.position.y, costado.transform.position.z), costado.transform.rotation).transform.SetParent(modulo.transform,false);

            float anchoBase = piezas.Find(x => x.nombre == "Bases").largo + (p.grueso * 2);
            p = piezas.Find(x => x.tag == "Traseras");
            GameObject trasera = GameObject.CreatePrimitive(PrimitiveType.Cube);
            trasera.GetComponent<Renderer>().material = Resources.Load("roble", typeof(Material)) as Material;
            trasera.transform.SetParent(modulo.transform,false);
            trasera.name = "Trasera";
            trasera.transform.localScale = new Vector3(anchoBase, costado.transform.localScale.x, p.grueso);
            trasera.transform.position = new Vector3(trasera.transform.position.x, costado.transform.localScale.x/2- piezas.Find(x => x.nombre == "Bases").grueso/2, trasera.transform.position.z + (piezas.Find(x => x.nombre == "Bases").ancho/2) + p.grueso/2);
            trasera.transform.eulerAngles = new Vector3(trasera.transform.eulerAngles.x,trasera.transform.eulerAngles.y ,trasera.transform.eulerAngles.z);
            
            /* Posicionamiento del modulo en la escena */
            //////* Si es el primer modulo, pon x en el punto (0 + mitad de la base) */
            if (i == 0){                                      
                anchoModuloNormal = modulo.transform.Find("Bases").localScale.x + modulo.transform.Find("Costados").localScale.z*2;
                modulo.transform.position = new Vector3(anchoModuloNormal/2, modulo.transform.position.y + alturaModulo, modulo.transform.position.z);

                /* Si el armario tiene puertas correderas, el fondo del costado derecho es menor */
                if(armario.puertaCorredera && armario.modulos > 1){                  
                    foreach(Transform hijo in modulo.transform){
                        if(hijo.name.Contains("Costados(Clone)")){
                            hijo.transform.localScale = new Vector3(hijo.transform.localScale.x,fondoCentrales,hijo.transform.localScale.z);
                            hijo.transform.position = new Vector3(hijo.transform.position.x, hijo.transform.position.y, diferencia);
                        }
                    }
                }
                continue;
            }

            /* Si es el último módulo de tamaño normal añade el tamaño restante de costado al puntero */
            if(i == armario.modulos-1){
                if(tamanioBaseCorta != 0){
                    GameObject bCorta = null;
                    foreach(Transform hijo in modulo.transform){
                        if(hijo.name.Contains("Bases")){
                            bCorta = hijo.gameObject;
                            hijo.transform.localScale = new Vector3(tamanioBaseCorta,hijo.transform.localScale.y,hijo.transform.localScale.z);
                        } else if(hijo.name.Equals("Costados")){            //posicionando costado izquierdo
                            hijo.transform.position = new Vector3((bCorta.transform.position.x - tamanioBaseCorta/2) - hijo.transform.localScale.z/2,hijo.transform.position.y ,hijo.transform.position.z);
                        } else if(hijo.name.Equals("Costados(Clone)")){    //posicionando costado derecho
                            hijo.transform.position = new Vector3((bCorta.transform.position.x + tamanioBaseCorta/2) + hijo.transform.localScale.z/2,hijo.transform.position.y ,hijo.transform.position.z);
                        } else if(hijo.name.Contains("Trasera")){
                            hijo.transform.localScale = new Vector3(tamanioBaseCorta+costado.transform.localScale.z*2,hijo.transform.localScale.y,hijo.transform.localScale.z);
                        }
                    }
                    puntero += anchoModuloNormal + tamanioBaseCorta/2 + costado.transform.localScale.z;
                    modulo.transform.position = new Vector3(puntero,modulo.transform.position.y + alturaModulo, modulo.transform.position.z);
                } else {
                    puntero += anchoModuloNormal;
                    modulo.transform.position = new Vector3(puntero + anchoModuloNormal/2, modulo.transform.position.y + alturaModulo, modulo.transform.position.z);
                }
                /* Si el armario tiene puertas correderas, el fondo del costado izquierdo es menor */
                if(armario.puertaCorredera && armario.modulos > 1){                  
                    foreach(Transform hijo in modulo.transform){
                        if(hijo.name.Equals("Costados")){
                            hijo.transform.localScale = new Vector3(hijo.transform.localScale.x,fondoCentrales,hijo.transform.localScale.z);
                            hijo.transform.position = new Vector3(hijo.transform.position.x, hijo.transform.position.y, diferencia);
                        }
                    }
                    
                }
                continue;                
            }

            puntero += anchoModuloNormal;
            modulo.transform.position = new Vector3(puntero + anchoModuloNormal/2, modulo.transform.position.y + alturaModulo, modulo.transform.position.z);

            /* Si el armario tiene puertas correderas, el fondo de los costados es menor */
            if(armario.puertaCorredera && armario.modulos > 1){                  
                foreach(Transform hijo in modulo.transform){
                    if(hijo.name.Contains("Costados(Clone)") || hijo.name.Contains("Costados")){
                        hijo.transform.localScale = new Vector3(hijo.transform.localScale.x,fondoCentrales,hijo.transform.localScale.z);
                        hijo.transform.position = new Vector3(hijo.transform.position.x, hijo.transform.position.y, diferencia);
                    }
                }
                
            }
            
        }
        /* Modifico posicion del objeto paredes, para dejar mas o menos hueco entre el mismo y el mueble 
            El tamaño del hueco dependera del tipo de hueco y del tipo de armario (corredero|abatible)*/
        if(armario.puertaCorredera){
                if(armario.modeloArmario.Contains("Omega")){

                    GameObject.Find("Paredes").transform.position = new Vector3((armario.ancho_H/2)-holguras.h_pared, 0, 0);

                } else if (armario.modeloArmario.Contains("L")){

                    GameObject.Find("Paredes").transform.position = new Vector3(armario.ancho_H/2 - (piezas.Find(x => x.nombre.Equals("DM Tapajuntas")).ancho - piezas.Find(x => x.nombre.Equals("Costados")).grueso - gruesoTapeta), 0, 0);

                } else if (armario.modeloArmario.Contains("U")){

                    GameObject.Find("Paredes").transform.position = new Vector3(armario.ancho_H/2 - (piezas.Find(x => x.nombre.Equals("DM Tapajuntas")).ancho - piezas.Find(x => x.nombre.Equals("Costados")).grueso - gruesoTapeta), 0, 0);
                }
            } else {
                if(armario.modeloArmario.Contains("Omega")){

                    GameObject.Find("Paredes").transform.position = new Vector3((armario.ancho_H/2)-holguras.h_pared, 0, 0);

                } else if (armario.modeloArmario.Contains("L")){

                    GameObject.Find("Paredes").transform.position = new Vector3(armario.ancho_H/2 - piezas.Find(x => x.nombre.Equals("DM Tapajuntas")).ancho + holguras.m_tapajuntas, 0, 0);

                } else if (armario.modeloArmario.Contains("U")){

                    GameObject.Find("Paredes").transform.position = new Vector3(armario.ancho_H/2 - piezas.Find(x => x.nombre.Equals("DM Tapajuntas")).ancho + holguras.m_tapajuntas, 0, 0);
                }
            }
    }
}
