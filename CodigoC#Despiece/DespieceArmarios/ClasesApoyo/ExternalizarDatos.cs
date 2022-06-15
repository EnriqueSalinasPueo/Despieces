using DespieceArmarios.Clases;
using DespieceArmarios.ClasesBd;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespieceArmarios.ClasesApoyo
{
    class ExternalizarDatos
    {
        static public void MapearDatos(ArmarioPiezas amarioPiezas, DatosFormArmariosObra datos)
        {
            Armario armario = amarioPiezas.armario;
            List<Pieza> listaPiezas = amarioPiezas.piezas;
            DefinirHolgurasGruesos holgurasGruesos = CallBbdd.GetHolgurasGruesos();
            var csv = new StringBuilder();
            //*******************************Introduccion de holguras y gruesos en la primera linea del csv**********************************
            csv.AppendLine((int)holgurasGruesos.H_techo + ", " + (int)holgurasGruesos.H_fondo + ", " + (int)holgurasGruesos.H_pared + ", " + (int)holgurasGruesos.H_puertas + 
                ", " + (int)holgurasGruesos.H_cajones + ", " + (int)holgurasGruesos.H_guia + ", " + (int)holgurasGruesos.H_baldas + ", " + (int)holgurasGruesos.M_rodapie + 
                ", " + (int)holgurasGruesos.M_tapajuntas + ", " + (int)holgurasGruesos.M_rodapie_guia + ", " + (int)holgurasGruesos.M_jacena + ", " + (int)holgurasGruesos.Descolgar_cornisa + 
                ", " + (int)holgurasGruesos.G_traseras + ", " + (int)holgurasGruesos.G_costados + ", " + (int)holgurasGruesos.G_puertas + ", " + (int)holgurasGruesos.G_correderas + 
                ", " + (int)holgurasGruesos.G_guia + ", " + (int)holgurasGruesos.G_apoyo_barra + ", " + (int)holgurasGruesos.G_tapeta + ", " + (int)holgurasGruesos.G_tapajuntas + 
                ", " + (int)holgurasGruesos.G_cornisa + ", " + (int)holgurasGruesos.G_rodapie + ", " + (int)holgurasGruesos.max_puertas + ", " + (int)holgurasGruesos.max_correderas);

            //*******************************Introduccion de datos del armario en la segunda linea*******************************************
            csv.AppendLine(armario.h_alto + ", " + armario.h_ancho + ", " + armario.h_fondo + ", " + armario.modulos + ", " + datos.PuertasCorrederas + ", " + armario.puertas +
                ", " + armario.modelo_armario + ", " + datos.ConJacena + ", " + datos.ArmarioRinconero + ", " + datos.ParedAbierta + ", "+ armario.altura_patas + ", " + datos.HastaSuelo + ", "+datos.AltoRodapie);
            csv.AppendLine("nombre,tag,cantidad,largo,ancho,grueso");

            /**  Incorporamos las piezas al archivo csv definimos el formato (numero de variables que pasamos) y numero de columnas  **/
            foreach (Pieza pieza in listaPiezas)
            {
                csv.AppendLine(pieza.nombre + "," + pieza.tag + "," + pieza.cantidad + "," + (int)pieza.largo + "," + (int)pieza.ancho + "," + (int)pieza.grueso);
            }
            Console.WriteLine();
            /**  Escritura del archivo cvs en la ruta asignada  **/
            File.WriteAllText(Path.GetDirectoryName(Application.ExecutablePath) + "\\armario.csv", csv.ToString()); // Remplazamos las "," para  la asignacion, evitamos la confusion de columnas en le csv
            
            //**  Ejecutar el punto exe generado de Unity  **/
            var ruta = Path.GetDirectoryName(Application.ExecutablePath);
            Process.Start(ruta + "\\modelo3D\\DiseñoArmarios.exe");

        }
    }

}