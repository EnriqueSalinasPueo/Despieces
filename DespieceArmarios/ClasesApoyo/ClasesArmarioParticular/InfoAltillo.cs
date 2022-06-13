using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.ClasesApoyo.ClasesArmarioParticular
{
    ///<summary>
    ///Clase que se usa para recoger datos del groupBoxAltillo dentro de FormArmariosParticular.
    ///</summary>
    ///<remarks>
    ///</remarks>
    public class InfoAltillo
    {
        ///<summary>
        ///Variable que almacena la altura que tiene el altillo.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal altura { get; set; }
        ///<summary>
        ///Variable que almacena si la union de los muebles tiene solo un grueso.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public bool esUnGrueso { get; set; }
        ///<summary>
        ///Variable que almacena si hay un altillo por modulo.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public bool esPorModulo { get; set; }
    }
}
