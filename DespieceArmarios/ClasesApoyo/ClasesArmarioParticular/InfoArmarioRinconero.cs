using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.ClasesApoyo.ClasesArmarioParticular
{
    ///<summary>
    ///Clase que se usa para recoger datos del groupBoxArmarioRinconero dentro de FormArmariosParticular.
    ///</summary>
    ///<remarks>
    ///</remarks>
    public class InfoArmarioRinconero
    {
        ///<summary>
        ///Variable para recoger los datos del numericUpDown Segundo ancho.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal segundoAncho { get; set; }
        ///<summary>c
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal segundoFondo { get; set; }
        ///<summary>
        ///Variable parasaber si la pared de la derecha es abierta.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public bool paredDerechaAbierta { get; set; }
    }
}
