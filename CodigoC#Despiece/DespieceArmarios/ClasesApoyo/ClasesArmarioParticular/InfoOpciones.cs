using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.ClasesApoyo.ClasesArmarioParticular
{
    ///<summary>
    ///Clase para saber si existen difenerentes elementos para su almacenacion. 
    ///</summary>
    ///<remarks>
    ///</remarks>
    public class InfoOpciones
    {
        ///<summary>
        ///Variable para saber si hay altillo si esta cheked el checkBoxAltilo.
        ///</summary>
        ///<remarks>
        ///.
        ///</remarks>
        public bool hayAltillo { get; set; }
        ///<summary>
        ///Variable para saber si la puerta es abatible.
        ///</summary>
        ///<remarks>
        ///Si es true la puerta es Abatible.
        ///</remarks>
        ///<remarks>
        ///Si es false la puerta es corredera.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public bool esPuertaAbatible { get; set; }
        ///<summary>
        ///Variable para saber si hay altillo.
        ///</summary>
        ///<remarks>
        ///Si es true la trasera es atornillada.
        ///</remarks>
        ///<remarks>
        ///Si es false la trasera es acanalada.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public bool esTraseraAtornillada { get; set; }
        ///<summary>
        ///Variable para saber si hay altillo.
        ///</summary>
        ///<remarks>
        ///Si es true el armario es recto.
        ///</remarks>
        ///<remarks>
        ///Si es false el armario es rinconero.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public bool esArmarioRecto { get; set; }
        ///<summary>
        ///Variable para saber si hay jacena.
        ///</summary>
        ///<remarks>
        ///Si es true si hay jacena.
        ///</remarks>
        ///<remarks>
        ///Si es false no hay jacena.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public bool hayJacena { get; set; }
        ///<summary>
        ///Variable para saber si el tapajuntas llega hasta el suelo.
        ///</summary>
        ///<remarks>
        ///Si es true si que llega hasta el suelo.
        ///</remarks>
        ///<remarks>
        ///Si es false no llega hasra el suelo.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public bool tapajuntasSuelo { get; set; }
        ///<summary>
        ///Variable para recoger el numero de modulos.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public int numeroModulos { get; set; }



    }
}
