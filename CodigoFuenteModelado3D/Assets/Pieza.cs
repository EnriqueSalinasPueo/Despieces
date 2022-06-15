using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieza 
{
    public int cantidad { get; set; }
    public string nombre { get; set; }
    public string tag { get; set; }
    public float largo { get; set; }
    public float ancho { get; set; }
    public float grueso { get; set; }

    public Pieza(string nombre, string tag, int cantidad, float largo, float ancho, float grueso){
        this.nombre = nombre;
        this.tag = tag;
        this.cantidad = cantidad;
        this.largo = largo/100;
        this.ancho = ancho/100;
        this.grueso = grueso/100;
    }

}