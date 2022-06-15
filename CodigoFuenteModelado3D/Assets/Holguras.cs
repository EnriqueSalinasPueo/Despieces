using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holguras {
    public Holguras(float h_techo, float h_fondo, float h_pared, float h_puertas, float h_cajones, float h_guia, float h_baldas, float rodapie, float tapajuntas, float rodapie_guia, float jacena, float descolgar_cornisa, float g_traseras, float g_costados, float g_puertas, float g_correderas, float g_guia, float g_apoyo_barra, float g_tapeta, float g_tapajuntas, float g_cornisa, float g_rodapie, float max_puertas, float max_correderas)
    {
        this.h_techo = h_techo/100;
        this.h_fondo = h_fondo/100;
        this.h_pared = h_pared/100;
        this.h_puertas = h_puertas/100;
        this.h_cajones = h_cajones/100;
        this.h_guia = h_guia/100;
        this.h_baldas = h_baldas/100;
        this.m_rodapie = rodapie/100;
        this.m_tapajuntas = tapajuntas/100;
        this.m_rodapie_guia = rodapie_guia/100;
        this.m_jacena = jacena/100;
        this.descolgar_cornisa = descolgar_cornisa/100;
        this.g_traseras = g_traseras/100;
        this.g_costados = g_costados/100;
        this.g_puertas = g_puertas/100;
        this.g_correderas = g_correderas/100;
        this.g_guia = g_guia/100;
        this.g_apoyo_barra = g_apoyo_barra/100;
        this.g_tapeta = g_tapeta/100;
        this.g_tapajuntas = g_tapajuntas/100;
        this.g_cornisa = g_cornisa/100;
        this.g_rodapie = g_rodapie/100;
        this.max_puertas = max_puertas/100;
        this.max_correderas = max_correderas/100;
    }

    public float h_techo { get; set; }
    public float h_fondo { get; set; }
    public float h_pared { get; set; }
    public float h_puertas { get; set; }
    public float h_cajones { get; set; }
    public float h_guia { get; set; }
    public float h_baldas { get; set; }
    public float m_rodapie { get; set; }
    public float m_tapajuntas { get; set; }
    public float m_rodapie_guia { get; set; }
    public float m_jacena { get; set; }
    public float descolgar_cornisa { get; set; }
    public float g_traseras { get; set; }
    public float g_costados { get; set; }
    public float g_puertas { get; set; }
    public float g_correderas { get; set; }
    public float g_guia { get; set; }
    public float g_apoyo_barra { get; set; }
    public float g_tapeta { get; set; }
    public float g_tapajuntas { get; set; }
    public float g_cornisa { get; set; }
    public float g_rodapie { get; set; }
    public float max_puertas { get; set; }
    public float max_correderas { get; set; }

}
