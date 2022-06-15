using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class Main : MonoBehaviour 
{
    public float speed = 5.0f;
    private List<Pieza> piezas = new List<Pieza>();
    private Armario armario;
    private Holguras holguras;
    private bool abiertas = false;
    private bool ocultas = false;
    private List<Vector3> posicionPuertas = new List<Vector3>();
    float zFondo, zTrasero, xDerecha, xIzquierda;
    private GameObject puertas = null;
    
	void Start () 
    {
        leerDatos();        //lectura de datos from archivo 'armario.csv'
        /* Creación del hueco para el armario y sus correspondientes paredes */
        crearHueco();

        /* Creación de los módulos en su correcta posición */
        CrearModulo crearModulo = gameObject.AddComponent<CrearModulo>();
        crearModulo.Construir(piezas,armario,holguras);

        /* Creación y posicionamiento de altillo y baldas */
        CrearBaldas crearBaldas = gameObject.AddComponent<CrearBaldas>();
        crearBaldas.Construir(piezas, armario, holguras);

        /* Creación y posicionaminento de tapetas */
        CrearTapetas crearTapetas = gameObject.AddComponent<CrearTapetas>();
        crearTapetas.Construir(piezas, armario, holguras);

        CrearPuertas crearPuertas = gameObject.AddComponent<CrearPuertas>();
        crearPuertas.Construir(piezas, armario, holguras);
	} 


    public void leerDatos(){
        StreamReader datos = new StreamReader("Assets/armario.csv");/* Esta ruta se cambia a ./armario.csv para que coja la misma ruta de ejecución  */
        List <string> lineas = new List<string>();
        while (!datos.EndOfStream){
            string linea = datos.ReadLine();
            lineas.Add(linea);
        }
        datos.Close();
        string[] datosHolguras = lineas[0].Split(new char[]{','});     //Lectura de las holguras y gruesos del armario.
        holguras = new Holguras(float.Parse(datosHolguras[0]),float.Parse(datosHolguras[1]),float.Parse(datosHolguras[2]),float.Parse(datosHolguras[3]),float.Parse(datosHolguras[4]),
                                float.Parse(datosHolguras[5]),float.Parse(datosHolguras[6]),float.Parse(datosHolguras[7]),float.Parse(datosHolguras[8]),float.Parse(datosHolguras[9]),
                                float.Parse(datosHolguras[10]),float.Parse(datosHolguras[11]),float.Parse(datosHolguras[12]),float.Parse(datosHolguras[13]),float.Parse(datosHolguras[14]),
                                float.Parse(datosHolguras[15]),float.Parse(datosHolguras[16]),float.Parse(datosHolguras[17]),float.Parse(datosHolguras[18]),float.Parse(datosHolguras[19]),
                                float.Parse(datosHolguras[20]),float.Parse(datosHolguras[21]),float.Parse(datosHolguras[22]),float.Parse(datosHolguras[23]));
        lineas.RemoveAt(0);

        string[] datosArmario = lineas[0].Split(new char[]{','});    //Lectura de información referente al armario.
        armario = new Armario(float.Parse(datosArmario[0]),float.Parse(datosArmario[1]),float.Parse(datosArmario[2]),int.Parse(datosArmario[3]),bool.Parse(datosArmario[4]),
                              int.Parse(datosArmario[5]),datosArmario[6],bool.Parse(datosArmario[7]),bool.Parse(datosArmario[8]),bool.Parse(datosArmario[9]), 
                              float.Parse(datosArmario[10]), bool.Parse(datosArmario[11]), float.Parse(datosArmario[12]));
        lineas.RemoveAt(0);

        foreach(string linea in lineas){    //Lectura de de datos referente a las piezas
            string[] row = linea.Split(new char[] {','});
            
            if (row[0] != "nombre")
            {
                Pieza p = new Pieza(row[0],row[1],int.Parse(row[2]),float.Parse(row[3]),
                float.Parse(row[4]),float.Parse(row[5]));
                piezas.Add(p);
            }
        }

    }

    public void crearHueco(){
        GameObject pared = new GameObject();
        pared.name = "Paredes";
        float ampliacionJacena = armario.jacena ? 4 : 0;

        if(armario.modeloArmario.EndsWith("L")){

            GameObject fondo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            fondo.name = "Fondo";
            fondo.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
            fondo.transform.localScale = new Vector3(armario.ancho_H ,armario.alto_H + ampliacionJacena,1);
            fondo.transform.position = new Vector3(0,fondo.transform.localScale.y/2, armario.fondo_H/2+fondo.transform.localScale.z/2);
            fondo.transform.SetParent(pared.transform, false);

            GameObject paredCerrada = GameObject.CreatePrimitive(PrimitiveType.Cube);
            paredCerrada.name = "ParedCerrada";
            paredCerrada.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
            paredCerrada.transform.localScale = new Vector3(1, armario.alto_H + ampliacionJacena , 60);
            paredCerrada.transform.position = new Vector3(0 - paredCerrada.transform.localScale.x/2 - armario.ancho_H/2,paredCerrada.transform.localScale.y/2,-(paredCerrada.transform.localScale.z/2)+armario.fondo_H/2+fondo.transform.localScale.z);
            paredCerrada.transform.SetParent(pared.transform, false);

            GameObject paredAbierta = GameObject.CreatePrimitive(PrimitiveType.Cube);
            paredAbierta.name="ParedAbierta";
            paredAbierta.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
            paredAbierta.transform.localScale = new Vector3(1,armario.alto_H + ampliacionJacena ,armario.fondo_H+fondo.transform.localScale.z);
            paredAbierta.transform.position = new Vector3(armario.ancho_H/2+paredAbierta.transform.localScale.x/2,paredAbierta.transform.localScale.y/2,0+fondo.transform.localScale.z/2+0.1f);
            paredAbierta.transform.SetParent(pared.transform, false);

            GameObject paredAbierta2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            paredAbierta2.name="ParedAbierta2";
            paredAbierta2.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
            paredAbierta2.transform.localScale = new Vector3(40,armario.alto_H + ampliacionJacena ,1);
            paredAbierta2.transform.position = new Vector3(armario.ancho_H/2+paredAbierta2.transform.localScale.x/2,paredAbierta2.transform.localScale.y/2,-paredAbierta.transform.localScale.z/2+paredAbierta2.transform.localScale.z);
            paredAbierta2.transform.SetParent(pared.transform, false);

        }else if (armario.modeloArmario.EndsWith("Omega")){

            GameObject fondo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            fondo.name = "Fondo";
            fondo.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
            fondo.transform.localScale = new Vector3(armario.ancho_H,armario.alto_H + ampliacionJacena,1);
            fondo.transform.position = new Vector3(0,fondo.transform.localScale.y/2,armario.fondo_H/2+fondo.transform.localScale.z/2);
            fondo.transform.SetParent(pared.transform, false);

            GameObject paredAbiertaIzq = GameObject.CreatePrimitive(PrimitiveType.Cube);
            paredAbiertaIzq.name = "ParedAbiertaIzq";
            paredAbiertaIzq.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
            paredAbiertaIzq.transform.localScale = new Vector3(1, armario.alto_H + ampliacionJacena, armario.fondo_H+fondo.transform.localScale.z);
            paredAbiertaIzq.transform.position = new Vector3(-(armario.ancho_H/2)-paredAbiertaIzq.transform.localScale.x/2,paredAbiertaIzq.transform.localScale.y/2,fondo.transform.localScale.z/2+0.1f);
            paredAbiertaIzq.transform.SetParent(pared.transform, false);

            GameObject paredAbiertaIzq2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            paredAbiertaIzq2.name="ParedAbiertaIzq2";
            paredAbiertaIzq2.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
            paredAbiertaIzq2.transform.localScale = new Vector3(60,armario.alto_H + ampliacionJacena,1);
            paredAbiertaIzq2.transform.position = new Vector3(-(armario.ancho_H/2)-paredAbiertaIzq2.transform.localScale.x/2,paredAbiertaIzq2.transform.localScale.y/2,-paredAbiertaIzq.transform.localScale.z/2+paredAbiertaIzq2.transform.localScale.z);
            paredAbiertaIzq2.transform.SetParent(pared.transform, false);

            GameObject paredAbiertaDer = GameObject.CreatePrimitive(PrimitiveType.Cube);
            paredAbiertaDer.name="ParedAbiertaDer";
            paredAbiertaDer.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
            paredAbiertaDer.transform.localScale = new Vector3(1,armario.alto_H + ampliacionJacena,armario.fondo_H+fondo.transform.localScale.z);
            paredAbiertaDer.transform.position = new Vector3(armario.ancho_H/2+paredAbiertaDer.transform.localScale.x/2,paredAbiertaDer.transform.localScale.y/2,0+fondo.transform.localScale.z/2+0.1f);
            paredAbiertaDer.transform.SetParent(pared.transform, false);

            GameObject paredAbiertaDer2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            paredAbiertaDer2.name="ParedAbiertaDer2";
            paredAbiertaDer2.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
            paredAbiertaDer2.transform.localScale = new Vector3(60,armario.alto_H + ampliacionJacena,1);
            paredAbiertaDer2.transform.position = new Vector3(armario.ancho_H/2+paredAbiertaDer2.transform.localScale.x/2,paredAbiertaDer2.transform.localScale.y/2,-paredAbiertaDer.transform.localScale.z/2+paredAbiertaDer2.transform.localScale.z);
            paredAbiertaDer2.transform.SetParent(pared.transform, false);
            
        }else if (armario.modeloArmario.EndsWith("U")){

            GameObject fondo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            fondo.name = "Fondo";
            fondo.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
            fondo.transform.localScale = new Vector3(armario.ancho_H,armario.alto_H + ampliacionJacena,1);
            fondo.transform.position = new Vector3(0,fondo.transform.localScale.y/2,armario.fondo_H/2+fondo.transform.localScale.z/2);
            fondo.transform.SetParent(pared.transform, false);

            GameObject paredCerradaIzq = GameObject.CreatePrimitive(PrimitiveType.Cube);
            paredCerradaIzq.name = "ParedCerradaIzq";
            paredCerradaIzq.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
            paredCerradaIzq.transform.localScale = new Vector3(1, armario.alto_H + ampliacionJacena, 60);
            paredCerradaIzq.transform.position = new Vector3(0 - paredCerradaIzq.transform.localScale.x/2 - armario.ancho_H/2,paredCerradaIzq.transform.localScale.y/2,-(paredCerradaIzq.transform.localScale.z/2)+armario.fondo_H/2+fondo.transform.localScale.z);
            paredCerradaIzq.transform.SetParent(pared.transform, false);

            GameObject paredCerradaDer = GameObject.CreatePrimitive(PrimitiveType.Cube);
            paredCerradaDer.name="ParedCerradaDer";
            paredCerradaDer.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
            paredCerradaDer.transform.localScale = new Vector3(1,armario.alto_H + ampliacionJacena,60);
            paredCerradaDer.transform.position = new Vector3(armario.ancho_H/2+paredCerradaDer.transform.localScale.x/2,paredCerradaDer.transform.localScale.y/2,-(paredCerradaDer.transform.localScale.z/2)+armario.fondo_H/2+fondo.transform.localScale.z);
            paredCerradaDer.transform.SetParent(pared.transform, false);
        }

        GameObject techo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        techo.name = "Techo";
        techo.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
        techo.transform.localScale = new Vector3(120,120,1);
        techo.transform.position = new Vector3(0,armario.alto_H + ampliacionJacena + techo.transform.localScale.z/2, -30);
        techo.transform.eulerAngles = new Vector3(90,0,0);
        techo.transform.SetParent(pared.transform, true);
        var suelo = Instantiate(techo, new Vector3(techo.transform.position.x, 0 - techo.transform.localScale.z/2, techo.transform.position.z) , techo.transform.rotation);
        suelo.GetComponent<Renderer>().material = Resources.Load("suelo", typeof(Material)) as Material;
        suelo.transform.SetParent(pared.transform, true);
        if(armario.jacena){
            GameObject jacena = GameObject.CreatePrimitive(PrimitiveType.Cube);
            jacena.name = "Jacnea";
            jacena.transform.SetParent(pared.transform, true);
            jacena.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
            jacena.transform.localScale = new Vector3(ampliacionJacena, armario.ancho_H, 1);
            jacena.transform.position = new Vector3(GameObject.Find("Fondo").transform.position.x , techo.transform.position.y - techo.transform.localScale.z/2 - jacena.transform.localScale.x/2, -piezas.Find(x => x.nombre.Equals("Bases")).ancho/2 + jacena.transform.localScale.z/2);
            jacena.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        GameObject limiteFondo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        limiteFondo.name ="limite";
        limiteFondo.transform.localScale = new Vector3(techo.transform.localScale.x,armario.alto_H + ampliacionJacena, 1);
        limiteFondo.transform.SetParent(pared.transform, true);
        limiteFondo.transform.position = new Vector3(techo.transform.position.x , (armario.alto_H + ampliacionJacena)/2, techo.transform.position.z + techo.transform.localScale.y/2);
        zFondo = limiteFondo.transform.position.z;
        limiteFondo.GetComponent<Renderer>().material = Resources.Load("paredes", typeof(Material)) as Material;
        var limiteTrasero = Instantiate(limiteFondo, new Vector3(limiteFondo.transform.position.x,limiteFondo.transform.position.y,techo.transform.position.z-techo.transform.localScale.y/2), limiteFondo.transform.rotation);
        limiteTrasero.transform.SetParent(pared.transform,true);
        zTrasero = limiteTrasero.transform.position.z; 
        var limiteIzquierdo = Instantiate(limiteFondo, new Vector3(techo.transform.position.x - techo.transform.localScale.x/2, limiteFondo.transform.position.y, techo.transform.position.z),Quaternion.Euler(new Vector3(0, 90, 0)));
        limiteIzquierdo.transform.SetParent(pared.transform,true);
        xIzquierda = limiteIzquierdo.transform.position.x;
        var limiteDerecho = Instantiate(limiteFondo, new Vector3(techo.transform.position.x + techo.transform.localScale.x/2, limiteFondo.transform.position.y, techo.transform.position.z),Quaternion.Euler(new Vector3(0, 90, 0)));
        limiteDerecho.transform.SetParent(pared.transform,true);
        xDerecha = limiteDerecho.transform.position.x;
    }
    
    public void AbrirPuertas(){

        GameObject puertas = GameObject.Find("Puertas");
        foreach(Transform hijo in puertas.transform){
            if(armario.puertaCorredera){
                if(armario.puertas%2 != 0){
                
                    if(int.Parse(hijo.name.Substring(hijo.name.Length-1))%2 != 0 ){
                        if(abiertas){
                            StartCoroutine(RestaX(hijo, hijo.transform.position.x - hijo.transform.localScale.y));
                        } else {
                            StartCoroutine(SumaX(hijo, hijo.transform.position.x + hijo.transform.localScale.y));
                        }
                    }

                } else if(int.Parse(hijo.name.Substring(hijo.name.Length-1))%2 == 0 ){
                    if(abiertas){
                        StartCoroutine(RestaX(hijo, hijo.transform.position.x - hijo.transform.localScale.y));
                    } else {
                        StartCoroutine(SumaX(hijo, hijo.transform.position.x + hijo.transform.localScale.y));
                    }
                }
            } else {
                if(abiertas){
                    StartCoroutine(RotaCerrar(hijo));
                } else {
                    StartCoroutine(RotaAbrir(hijo));
                }
            }
        }
        if(abiertas){
            abiertas = false;
        } else { 
            abiertas = true;
        }   
    }
    public void NoMostrar(){
        if(puertas==null){
            puertas = GameObject.Find("Puertas");
        }            
        if(ocultas){
            puertas.SetActive(false);
            ocultas = false;
        } else if (!ocultas){
            puertas.SetActive(true);
            ocultas = true;
        }    
    }

    public void Salir(){
        Application.Quit();
    }

    IEnumerator RestaX(Transform hijo, float x){
        while(hijo.transform.position.x > x){
            hijo.transform.position = new Vector3(hijo.transform.position.x - 0.1f, hijo.transform.position.y, hijo.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator SumaX(Transform hijo, float x){
        while(hijo.transform.position.x < x){
            hijo.transform.position = new Vector3(hijo.transform.position.x + 0.1f, hijo.transform.position.y, hijo.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator RotaAbrir(Transform hijo){
        if(int.Parse(hijo.name.Substring(hijo.name.Length-1))%2 == 0 && int.Parse(hijo.name.Substring(hijo.name.Length-1)) != armario.puertas-1){
            for (int i = 0; i < 85; i++){
                hijo.transform.eulerAngles = new Vector3(hijo.transform.eulerAngles.x, hijo.transform.eulerAngles.y + 1f, hijo.transform.eulerAngles.z);
                yield return new WaitForSeconds(0.009f);
            }
        } else {
            for (int i = 0; i< 85; i++){
                hijo.transform.eulerAngles = new Vector3(hijo.transform.eulerAngles.x, hijo.transform.eulerAngles.y - 1f, hijo.transform.eulerAngles.z);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
    IEnumerator RotaCerrar(Transform hijo){
        if(int.Parse(hijo.name.Substring(hijo.name.Length-1))%2 == 0 && int.Parse(hijo.name.Substring(hijo.name.Length-1)) != armario.puertas-1){
            for (int i = 0; i < 85; i++){
                hijo.transform.eulerAngles = new Vector3(hijo.transform.eulerAngles.x, hijo.transform.eulerAngles.y - 1f, hijo.transform.eulerAngles.z);
                yield return new WaitForSeconds(0.01f);
            }
        } else {
            for (int i = 0; i < 85; i++){
                hijo.transform.eulerAngles = new Vector3(hijo.transform.eulerAngles.x, hijo.transform.eulerAngles.y + 1f, hijo.transform.eulerAngles.z);
                yield return new WaitForSeconds(0.01f);
            }
        } 
    }

    void Update(){
        if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < xDerecha)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > xIzquierda+17)
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        if(Input.GetKey(KeyCode.DownArrow) && transform.position.z > zTrasero)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
        }
        if(Input.GetKey(KeyCode.UpArrow) && transform.position.z < zFondo-10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}