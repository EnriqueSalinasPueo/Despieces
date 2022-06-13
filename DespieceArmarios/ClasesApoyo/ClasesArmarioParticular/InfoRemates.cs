using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.ClasesApoyo.ClasesParticular
{
    ///<summary>
    ///Clase que se usa para recoger datos de los remates dentro de FormArmariosParticular.
    ///</summary>
    ///<remarks>
    ///Recoge los datos de las numericUpDown Alto cornisa, Ancho tapajunta, Alto rodapie.
    ///</remarks>
    public class InfoRemates
    {

        ///<summary>
        ///Variable que recoge los datos del  numericUpDown Alto cornisa.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal AnchoCornisa { get; set; }
        ///<summary>
        ///Variable que recoge los datos del  numericUpDown Ancho tapajuntas.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal AnchoTapajuntas { get; set; }
        ///<summary>
        ///Variable que recoge los datos del  numericUpDown Alto ridapie.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal AnchoRodapie { get; set; }
    }
}
