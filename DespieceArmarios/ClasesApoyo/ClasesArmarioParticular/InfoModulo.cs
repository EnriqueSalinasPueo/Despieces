using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.ClasesApoyo.ClasesParticular
{
    ///<summary>
    ///Clase que se usa para recoger los datos de cada modulo dentro de FormArmariosParticular.
    ///</summary>
    ///<remarks>
    ///</remarks>
    public class InfoModulo
    {
        ///<summary>
        ///Variable para guardar el calculo de la operacion para la altura.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal Alto { get; set; }
        ///<summary>
        ///Variable para guardar el calculo de la operacion para la anchura. 
        ///</summary>
        ///<remarks>
        ///tambien se puede definir por el nmnumericUpDown del groupBox Ancho modulo dentro de FormArmariosParticular.
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal Ancho { get; set; }
        ///<summary>
        ///Variable para guardar el calculo de la operacion para el fondo .
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal Fondo { get; set; }
        ///<summary>
        ///Variable para guardar el numero de baldas que tiene cada modulo.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public int NumeroBaldas { get; set; }
        ///<summary>
        ///Variable para guardar el numero de barras de colgar de cada modulo..
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public int BarrasColgar { get; set; }
        ///<summary>
        ///Variable para guardar si hay cajonera.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public bool HayCajonera { get; set; }
        ///<summary>
        ///Variable cajonera para recoger datos.
        ///</summary>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public Cajonera Cajonera { get; set; }
    }
}
