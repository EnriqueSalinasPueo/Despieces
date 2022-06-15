using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armario 
{
    public float alto_H { get; set; }
    public float ancho_H { get; set; }
    public float fondo_H { get; set; }
    public int modulos { get; set; }
    public bool puertaCorredera { get; set; }
    public int puertas { get; set; }
    public string modeloArmario { get; set; }
    public bool jacena { get; set; }
    public bool rinconero { get; set; }
    public bool paredAbierta { get; set; }
    public float alturaPatas { get; set; }
    public bool hastaSuelo { get; set; }
    public float altoRodapie { get; set; }
    public Armario(float alto_H, float ancho_H, float fondo_H, int modulos, bool puertaCorredera, int puertas, string modeloArmario, bool jacena, bool rinconero, bool paredAbierta, float alturaPatas, bool hastaSuelo, float altoRodapie)
    {
        this.alto_H = alto_H/100;
        this.ancho_H = ancho_H/100;
        this.fondo_H = fondo_H/100;
        this.modulos = modulos;
        this.puertaCorredera = puertaCorredera;
        this.puertas = puertas;
        this.modeloArmario = modeloArmario;
        this.jacena = jacena;
        this.rinconero = rinconero;
        this.paredAbierta = paredAbierta;
        this.alturaPatas = alturaPatas/100;
        this.hastaSuelo = hastaSuelo;
        this.altoRodapie = altoRodapie/100;
    }

}