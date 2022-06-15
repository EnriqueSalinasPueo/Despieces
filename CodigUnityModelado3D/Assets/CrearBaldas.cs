using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearBaldas : MonoBehaviour
{
    
    public void Construir(List<Pieza> piezas, Armario armario, Holguras holguras){
        /* Obtengo la cantidad de baldas que habrá que crear */
        int numBaldas = piezas.Find(x => x.nombre.Equals("Balda Inferior")) != null ? piezas.Find(x => x.nombre.Equals("Balda Inferior")).cantidad : 0;
        numBaldas += piezas.Find(x => x.nombre.Equals("Balda Inf Corta")) != null ? piezas.Find(x => x.nombre.Equals("Balda Inf Corta")).cantidad : 0;
        
        /* Establece fondo del altillo, fondo de las baldas y fondo normal (el fondo de los costados) */
        float fondoAltillo = 0;
        float fondoNormal = piezas.Find(x => x.nombre.Equals("Costados")).ancho;
        float fondoBalda = 0;
        float diferenciaBalda = 0;
        float diferenciaAltillo = 0;

         /* Si el armario es corredero se debe pintar el altillo */
        if(numBaldas != 0){
            fondoBalda = piezas.Find(x => x.nombre.Equals("Balda Inferior")).ancho;
            diferenciaBalda = (fondoNormal - fondoBalda)/2;
        }
        if(armario.puertaCorredera){        
            fondoAltillo = piezas.Find(x => x.nombre.Equals("Altillo")).ancho;
            diferenciaAltillo = (fondoNormal - fondoAltillo)/2;
        }
        

        GameObject modulo = null;
        for(int i = 0; i<armario.modulos;i++){

            modulo = GameObject.Find("Modulo"+i);
            foreach(Transform hijo in modulo.transform){
                
                if(hijo.name.Equals("Bases")){
                     GameObject @base = hijo.gameObject;
                     
                    if(armario.puertaCorredera){ 
                        var altillo = Instantiate(@base);
                        altillo.GetComponent<Renderer>().material = Resources.Load("roble", typeof(Material)) as Material;
                        altillo.name = "Altillo";
                        altillo.transform.position = new Vector3(@base.transform.position.x, piezas.Find(x => x.nombre.Equals("Trasera Inferior")).largo, diferenciaAltillo);
                        altillo.transform.rotation =  @base.transform.rotation;
                        altillo.transform.localScale = new Vector3(@base.transform.localScale.x, fondoAltillo, @base.transform.localScale.z);
                        altillo.transform.SetParent(modulo.transform,true);
                    }

                    if (numBaldas/armario.modulos == 2){
                        /* Si el armario es corredero, el tope superior debe ser la posicion en 'y' del altillo, sino debe ser la posición en 'y' de la base superior */
                        float topeSuperior = armario.puertaCorredera ? modulo.transform.Find("Altillo").transform.position.y : modulo.transform.Find("Bases(Clone)").transform.position.y;

                        var balda = Instantiate(@base);
                        balda.GetComponent<Renderer>().material = Resources.Load("roble", typeof(Material)) as Material;
                        balda.name = "Balda";
                        balda.transform.position = new Vector3(@base.transform.position.x, 5, diferenciaAltillo);
                        balda.transform.rotation =  @base.transform.rotation;
                        balda.transform.localScale = new Vector3(@base.transform.localScale.x, fondoBalda, @base.transform.localScale.z);
                        balda.transform.SetParent(modulo.transform,true);


                        var balda2 = Instantiate(@base);
                        balda2.GetComponent<Renderer>().material = Resources.Load("roble", typeof(Material)) as Material;
                        balda2.name = "Balda2";
                        balda2.transform.position = new Vector3(@base.transform.position.x, topeSuperior - (topeSuperior - balda.transform.position.y)/2 , diferenciaAltillo);
                        balda2.transform.rotation =  @base.transform.rotation;
                        balda2.transform.localScale = new Vector3(@base.transform.localScale.x, fondoBalda, @base.transform.localScale.z);
                        balda2.transform.SetParent(modulo.transform,true);
                        
                    }else if(numBaldas/armario.modulos ==1){
                        var balda = Instantiate(@base);
                        balda.GetComponent<Renderer>().material = Resources.Load("roble", typeof(Material)) as Material;
                        balda.name = "Balda";
                        balda.transform.position = new Vector3(@base.transform.position.x, 5, diferenciaAltillo);
                        balda.transform.rotation =  @base.transform.rotation;
                        balda.transform.localScale = new Vector3(@base.transform.localScale.x, fondoBalda, @base.transform.localScale.z);
                        balda.transform.SetParent(modulo.transform,true);   
                    }
                }
            }
                
        }
        



  }

}
