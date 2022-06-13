using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.Clases
{
    public class EstimacionMaterial
    {
        public Tablero tablero { get; set; }
        public List<ArmarioPiezas> lista { get; set; }

        public decimal totalMilimetrosGuia { get; set; }
        public decimal totalMilimetrosBarra { get; set; }
        public decimal totalMilimetrosCanto { get; set; }
        public decimal puertasTotales { get; set; }
        public decimal tiras19 { get; set; }
        public decimal tableros10 { get; set; }

        public List<MedidasTotales> CalcularTableros(List<ArmarioPiezas> lista, Tablero tablero)
        {
            List<MedidasTotales> listaMedidasTotales = new List<MedidasTotales>();

            this.tablero = tablero;
            this.lista = lista;

            totalMilimetrosGuia = 0;
            totalMilimetrosBarra = 0;
            totalMilimetrosCanto = 0;
            puertasTotales = 0;
            tiras19 = 0;
            tableros10 = 0;

            foreach (ArmarioPiezas ap in lista)
            {
                List<Pieza> piezas = ap.piezas;
                for (int i = 0; i < piezas.Count; i++)
                {
                    if (piezas[i].nombre == "DM Puertas")
                    {
                        puertasTotales += piezas[i].cantidad;
                    }

                    if (piezas[i].nombre == "Guia Sup/Inf")
                    {
                        totalMilimetrosGuia += piezas[i].largo;
                    }

                    if (piezas[i].nombre == "BarraLateral" || piezas[i].nombre == "Barra Corta" || piezas[i].nombre == "BarraColgar")
                    {
                        totalMilimetrosBarra += piezas[i].largo;
                    }

                    if (piezas[i].nombre == "Costados Centrales" || piezas[i].nombre == "Bases" || piezas[i].nombre == "Bases Cortas" ||
                        piezas[i].nombre == "Altillo" || piezas[i].nombre == "Altillo Corto" || piezas[i].nombre == "Balda Inferior" ||
                        piezas[i].nombre == "Balda Inf Corta" || piezas[i].nombre == "Apoyo")
                    {
                        totalMilimetrosCanto += piezas[i].largo;
                    }

                    if (piezas[i].nombre == "Costados" || piezas[i].nombre == "Costados Centrales" || piezas[i].nombre == "Bases Cortas" || 
                        piezas[i].nombre == "Bases" || piezas[i].nombre == "Altillo" || piezas[i].nombre == "Altillo Corto" ||
                        piezas[i].nombre == "Balda Inferior" || piezas[i].nombre == "Balda Inf Corta" || piezas[i].nombre == "Apoyo")
                    {
                        if (piezas[i].largo > (tablero.largo - 100) / 2)
                        {
                            tiras19 += piezas[i].cantidad;
                        }
                    }

                    if (piezas[i].nombre == "CTrasera Inferior" || piezas[i].nombre == "Trasera Inf Corta" ||
                        piezas[i].nombre == "Trasera Superior" || piezas[i].nombre == "Trasera Sup Corta")
                    {
                        if (piezas[i].ancho > (tablero.ancho - 50) / 2)
                        {
                            tableros10 += piezas[i].cantidad;
                        }
                        else
                        {
                            tableros10 += piezas[i].cantidad / 2;
                        }
                    }

                }
            }

            listaMedidasTotales.Add(new MedidasTotales("Unidades Tablero melamina 19", tiras19 / 3));
            listaMedidasTotales.Add(new MedidasTotales("Unidades Tablero melamina 10", tableros10));
            listaMedidasTotales.Add(new MedidasTotales("Unidades Tableros dm 10", puertasTotales / 2));
            listaMedidasTotales.Add(new MedidasTotales("Metros Canto", totalMilimetrosCanto / 1000));
            listaMedidasTotales.Add(new MedidasTotales("Metros Guia Sup/Inf", totalMilimetrosGuia / 1000));
            listaMedidasTotales.Add(new MedidasTotales("Metros barra Colgar", totalMilimetrosBarra / 1000));


            return listaMedidasTotales;
        }

    }
}
