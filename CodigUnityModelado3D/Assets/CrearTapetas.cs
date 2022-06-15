using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CrearTapetas : MonoBehaviour
{
    public void Construir(List<Pieza> piezas, Armario armario, Holguras holguras){

        
        GameObject modulo;
        GameObject tapeta = null;
        GameObject pared;
        Pieza piezaTapeta = armario.puertaCorredera ? piezas.Find(x => x.nombre.Equals("DM Tapetas")) : null;
        Pieza piezaTapajuntas = piezas.Find(x => x.nombre.Equals("DM Tapajuntas"));
        Pieza piezaRodapie = piezas.Find(x => x.nombre.Equals("DM Rodapie"));
        Pieza piezaCornisa = piezas.Find(x => x.nombre.Equals("DM Cornisa"));
        Pieza piezaGuia = piezas.Find(x => x.nombre.Equals("Guia Sup/Inf"));

        /* Establezco la escala y rotación que van a tener las tapetas */
        Vector3 escalaTapeta = armario.puertaCorredera ? new Vector3(piezaTapeta.largo, piezaTapeta.ancho, piezaTapeta.grueso) : new Vector3();
        Vector3 rotacionTapeta = new Vector3(0, 90, 90);
        Vector3 escalaTapajuntas = new Vector3(piezaTapajuntas.largo, piezaTapajuntas.ancho, piezaTapajuntas.grueso);
        Vector3 rotacionTapajuntas = new Vector3(0, 0, 90);
        Vector3 escalaRodapie = armario.hastaSuelo ? new Vector3(piezaRodapie.largo, armario.altoRodapie, piezaRodapie.grueso) : new Vector3(piezaCornisa.largo + piezaTapajuntas.ancho*2, armario.altoRodapie, 0.1f);
        Vector3 escalaCornisa = new Vector3(piezaCornisa.largo, piezaCornisa.ancho, piezaCornisa.grueso);
        Vector3 rotacion = new Vector3 (0,0,0);
        
        for(int i=0; i < armario.modulos; i++){
            modulo = GameObject.Find("Modulo"+i);
            if(armario.puertaCorredera){
                if (i == 0){    
                    foreach(Transform hijo in modulo.transform){
                        if(hijo.name.Equals("Costados")){
                            tapeta = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            tapeta.GetComponent<Renderer>().material = Resources.Load("violeta", typeof(Material)) as Material;
                            tapeta.name = "Tapeta";
                            tapeta.transform.SetParent(modulo.transform, true);
                            tapeta.transform.localScale = escalaTapeta;
                            tapeta.transform.eulerAngles = rotacionTapeta;
                            tapeta.transform.position = new Vector3(hijo.transform.position.x + hijo.transform.localScale.z/2 + tapeta.transform.localScale.z/2,hijo.transform.position.y, -hijo.transform.localScale.y/2 + tapeta.transform.localScale.y/2);

                            if(armario.modeloArmario.Contains("L") || armario.modeloArmario.Contains("U")){
                                pared = armario.modeloArmario.Contains("L") ? GameObject.Find("ParedCerrada") : armario.modeloArmario.Contains("U") ? GameObject.Find("ParedCerradaIzq") : null;
                                tapeta = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                tapeta.GetComponent<Renderer>().material = Resources.Load("violeta", typeof(Material)) as Material;
                                tapeta.name = "Tapajuntas";
                                tapeta.transform.SetParent(modulo.transform, true);
                                tapeta.transform.localScale = escalaTapajuntas;
                                tapeta.transform.eulerAngles = rotacionTapajuntas;
                                tapeta.transform.position = new Vector3((pared.transform.position.x + pared.transform.localScale.x/2) + tapeta.transform.localScale.y/2 ,armario.hastaSuelo ? tapeta.transform.localScale.x/2 : tapeta.transform.localScale.x/2 + escalaRodapie.y, -hijo.transform.localScale.y/2 - tapeta.transform.localScale.z/2);
                            } else {
                                pared = GameObject.Find("ParedAbiertaIzq");
                                GameObject tapetaAux = tapeta;
                                tapeta = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                tapeta.GetComponent<MeshRenderer>().material = Resources.Load("violeta") as Material;
                                tapeta.name = "Tapajuntas";
                                tapeta.transform.SetParent(modulo.transform, true);
                                tapeta.transform.localScale = escalaTapajuntas;
                                tapeta.transform.eulerAngles = rotacionTapajuntas;
                                tapeta.transform.position = new Vector3(tapetaAux.transform.position.x + tapetaAux.transform.localScale.z/2 - tapeta.transform.localScale.y/2  , armario.hastaSuelo ? tapeta.transform.localScale.x/2 : tapeta.transform.localScale.x/2 + escalaRodapie.y, -hijo.transform.localScale.y/2-tapeta.transform.localScale.z/2);
                            }
                            /* Creacion de rodapie y cornisa */
                            GameObject tapAux = tapeta;
                            tapeta = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            tapeta.GetComponent<Renderer>().material = Resources.Load("violeta", typeof(Material)) as Material;
                            tapeta.name = "Rodapie";
                            tapeta.transform.SetParent(modulo.transform,true);
                            tapeta.transform.localScale = escalaRodapie;
                            tapeta.transform.eulerAngles = rotacion;
                            tapeta.transform.position = new Vector3(armario.hastaSuelo ? tapAux.transform.position.x + tapAux.transform.localScale.y/2 + tapeta.transform.localScale.x/2 : tapAux.transform.position.x - tapAux.transform.localScale.y/2 + tapeta.transform.localScale.x/2, tapeta.transform.localScale.y/2, - hijo.transform.localScale.y/2- tapeta.transform.localScale.z/2);
                            var cornisa = Instantiate(tapeta,tapeta.transform.position,tapeta.transform.rotation);
                            cornisa.name = "Cornisa";
                            cornisa.transform.SetParent(modulo.transform,true);
                            cornisa.transform.localScale = escalaCornisa;
                            cornisa.transform.position = new Vector3(tapAux.transform.position.x + tapAux.transform.localScale.y/2 + cornisa.transform.localScale.x/2, tapAux.transform.position.y + tapAux.transform.localScale.x/2 - cornisa.transform.localScale.y/2, cornisa.transform.position.z);
                            var guia = Instantiate(tapeta,tapeta.transform.position, tapeta.transform.rotation);
                            guia.name = "Guia";
                            guia.transform.SetParent(modulo.transform,true);
                            guia.GetComponent<Renderer>().material = Resources.Load("metal", typeof(Material)) as Material;
                            guia.transform.localScale = new Vector3( piezaGuia.largo, piezaTapeta.ancho, piezaTapeta.grueso);
                            guia.transform.eulerAngles = new Vector3(90, tapeta.transform.eulerAngles.y, tapeta.transform.eulerAngles.z);
                            guia.transform.position = new Vector3(guia.transform.position.x, tapeta.transform.position.y + tapeta.transform.localScale.y/2 - guia.transform.localScale.z/2, tapeta.transform.position.z + tapeta.transform.localScale.z/2 + guia.transform.localScale.y/2);

                        }
                    }
                } if (i == armario.modulos - 1 ){
                    foreach(Transform hijo in modulo.transform){
                        if(hijo.name.Equals("Costados(Clone)")){
                            tapeta = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            tapeta.GetComponent<Renderer>().material = Resources.Load("violeta", typeof(Material)) as Material;
                            tapeta.name = "Tapeta";
                            tapeta.transform.SetParent(modulo.transform, true);
                            tapeta.transform.localScale = escalaTapeta;
                            tapeta.transform.eulerAngles = rotacionTapeta;
                            tapeta.transform.position = new Vector3(hijo.transform.position.x - hijo.transform.localScale.z/2 - tapeta.transform.localScale.z/2 ,hijo.transform.position.y, -hijo.transform.localScale.y/2 + tapeta.transform.localScale.y/2);

                            if(armario.modeloArmario.Contains("U")){
                                pared = GameObject.Find("ParedCerradaDer");
                                tapeta = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                tapeta.GetComponent<Renderer>().material = Resources.Load("violeta", typeof(Material)) as Material;
                                tapeta.name = "Tapajuntas";
                                tapeta.transform.SetParent(modulo.transform, true);
                                tapeta.transform.localScale = escalaTapajuntas;
                                tapeta.transform.eulerAngles = rotacionTapajuntas;
                                tapeta.transform.position = new Vector3((pared.transform.position.x - pared.transform.localScale.x/2) - tapeta.transform.localScale.y/2 ,armario.hastaSuelo ? tapeta.transform.localScale.x/2 : tapeta.transform.localScale.x/2 + escalaRodapie.y, -hijo.transform.localScale.y/2 - tapeta.transform.localScale.z/2);
                            } else {
                                pared = armario.modeloArmario.Contains("Omega") ? GameObject.Find("ParedAbiertaDer") : GameObject.Find("ParedAbierta");
                                GameObject tapaAux = tapeta;
                                tapeta = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                tapeta.GetComponent<Renderer>().material = Resources.Load("violeta", typeof(Material)) as Material;
                                tapeta.name = "Tapajuntas";
                                tapeta.transform.SetParent(modulo.transform, true);
                                tapeta.transform.localScale = escalaTapajuntas;
                                tapeta.transform.eulerAngles = rotacionTapajuntas;
                                tapeta.transform.position = new Vector3((tapaAux.transform.position.x + tapeta.transform.localScale.y/2) - tapaAux.transform.localScale.z/2, armario.hastaSuelo ? tapeta.transform.localScale.x/2 : tapeta.transform.localScale.x/2 + escalaRodapie.y, tapaAux.transform.position.z - tapaAux.transform.localScale.y/2 - tapeta.transform.localScale.z/2);
                            }
                        }
                    }
                }
            } else if(!armario.puertaCorredera){
                if (i == 0){    
                    foreach(Transform hijo in modulo.transform){
                        if(hijo.name.Equals("Costados")){
                            if(armario.modeloArmario.Contains("L") || armario.modeloArmario.Contains("U")){
                                pared = armario.modeloArmario.Contains("L") ? GameObject.Find("ParedCerrada") : armario.modeloArmario.Contains("U") ? GameObject.Find("ParedCerradaIzq") : null;
                                tapeta = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                tapeta.GetComponent<Renderer>().material = Resources.Load("violeta", typeof(Material)) as Material;
                                tapeta.name = "Tapajuntas";
                                tapeta.transform.SetParent(modulo.transform, true);
                                tapeta.transform.localScale = escalaTapajuntas;
                                tapeta.transform.eulerAngles = rotacionTapajuntas;
                                tapeta.transform.position = new Vector3((pared.transform.position.x + pared.transform.localScale.x/2) + tapeta.transform.localScale.y/2 ,armario.hastaSuelo ? tapeta.transform.localScale.x/2 : tapeta.transform.localScale.x/2 + escalaRodapie.y, -hijo.transform.localScale.y/2 - tapeta.transform.localScale.z/2);
                            } else {
                                pared = GameObject.Find("ParedAbiertaIzq");
                                tapeta = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                tapeta.GetComponent<Renderer>().material = Resources.Load("violeta", typeof(Material)) as Material;
                                tapeta.name = "Tapajuntas";
                                tapeta.transform.SetParent(modulo.transform, true);
                                tapeta.transform.localScale = escalaTapajuntas;
                                tapeta.transform.eulerAngles = rotacionTapajuntas;
                                tapeta.transform.position = new Vector3(hijo.transform.position.x - hijo.transform.localScale.z/2 - tapeta.transform.localScale.y/2 + holguras.m_tapajuntas ,armario.hastaSuelo ? tapeta.transform.localScale.x/2 : tapeta.transform.localScale.x/2 + escalaRodapie.y, hijo.transform.position.z - hijo.transform.localScale.y/2 - (tapeta.transform.localScale.z/2));
                            }
                            /* Creacion de rodapie y cornisa */
                            GameObject tapAux = tapeta;
                            tapeta = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            tapeta.GetComponent<Renderer>().material = Resources.Load("violeta", typeof(Material)) as Material;
                            tapeta.name = "Rodapie";
                            tapeta.transform.localScale = escalaRodapie;
                            tapeta.transform.SetParent(modulo.transform,true);
                            tapeta.transform.eulerAngles = rotacion;
                            tapeta.transform.position = new Vector3(armario.hastaSuelo ? tapAux.transform.position.x + tapAux.transform.localScale.y/2 + tapeta.transform.localScale.x/2 : tapAux.transform.position.x - tapAux.transform.localScale.y/2 + tapeta.transform.localScale.x/2, tapeta.transform.localScale.y/2, - hijo.transform.localScale.y/2- tapeta.transform.localScale.z/2);
                            var cornisa = Instantiate(tapeta,tapeta.transform.position,tapeta.transform.rotation);
                            cornisa.name = "Cornisa";
                            cornisa.transform.SetParent(modulo.transform,true);
                            cornisa.transform.localScale = escalaCornisa;
                            cornisa.transform.position = new Vector3(tapAux.transform.position.x + tapAux.transform.localScale.y/2 + cornisa.transform.localScale.x/2, tapAux.transform.position.y + tapAux.transform.localScale.x/2 - cornisa.transform.localScale.y/2, cornisa.transform.position.z);
                        }
                    }
                } if (i == armario.modulos - 1 ){
                    foreach(Transform hijo in modulo.transform){
                        if(hijo.name.Equals("Costados(Clone)")){

                            if(armario.modeloArmario.Contains("U")){
                                pared = GameObject.Find("ParedCerradaDer");
                                tapeta = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                tapeta.GetComponent<Renderer>().material = Resources.Load("violeta", typeof(Material)) as Material;
                                tapeta.name = "Tapajuntas";
                                tapeta.transform.SetParent(modulo.transform, true);
                                tapeta.transform.localScale = escalaTapajuntas;
                                tapeta.transform.eulerAngles = rotacionTapajuntas;
                                tapeta.transform.position = new Vector3((pared.transform.position.x - pared.transform.localScale.x/2) - tapeta.transform.localScale.y/2 ,armario.hastaSuelo ? tapeta.transform.localScale.x/2 : tapeta.transform.localScale.x/2 + escalaRodapie.y, -hijo.transform.localScale.y/2 - tapeta.transform.localScale.z/2);
                            } else {
                                pared = armario.modeloArmario.Contains("Omega") ? GameObject.Find("ParedAbiertaDer") : GameObject.Find("ParedAbierta");
                                GameObject tapaAux = tapeta;
                                tapeta = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                tapeta.GetComponent<Renderer>().material = Resources.Load("violeta", typeof(Material)) as Material;
                                tapeta.name = "Tapajuntas";
                                tapeta.transform.SetParent(modulo.transform, true);
                                tapeta.transform.localScale = escalaTapajuntas;
                                tapeta.transform.eulerAngles = rotacionTapajuntas;
                                tapeta.transform.position = new Vector3(hijo.transform.position.x + hijo.transform.localScale.z/2 + tapeta.transform.localScale.y/2 - holguras.m_tapajuntas ,armario.hastaSuelo ? tapeta.transform.localScale.x/2 : tapeta.transform.localScale.x/2 + escalaRodapie.y, hijo.transform.position.z - hijo.transform.localScale.y/2 - (tapeta.transform.localScale.z/2));
                            }
                        }
                    }
                }
            }
        }

        
    }
}
