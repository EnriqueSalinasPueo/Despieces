using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.ClasesApoyo.ClasesParticular
{
    ///<summary>
    ///Clase que se usa para recoger datos del groupBoxHueco y groupBoxHuecoArmario dentro de FormArmariosParticular.
    ///</summary>
    ///<remarks>
    ///</remarks>
    public class InfoHueco
    {
        ///<summary>
        ///Variable que almacena el tipo hueco del armrio.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public string tipoHueco { get; set; }
        ///<summary>
        ///Variable que almacena la altura que tiene el hueco.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal Alto { get; set; }
        ///<summary>
        ///Variable que almacena la anchura que tiene el hueco.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal Ancho { get; set; }
        ///<summary>
        ///Variable que almacena el fondo que tiene el hueco.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal Fondo { get; set; }
    }
}
