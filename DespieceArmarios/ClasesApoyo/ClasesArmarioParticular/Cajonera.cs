using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.ClasesApoyo.ClasesParticular
{
    ///<summary>
    ///Clase que se usa para recoger datos del groupBoxCajonera dentro de FormArmariosParticular.
    ///</summary>
    ///<remarks>
    ///</remarks>
    public class Cajonera
    {
        public int NumeroCajones { get; set; }
        public bool SonDiferentes { get; set; }
        public decimal Altura1 { get; set; }
        public decimal Altura2 { get; set; }
        public int NumeroCajonesAltura2 { get; set; }
        public decimal Altura3 { get; set; }
        public int NumeroCajonesAltura3 { get; set; }
        public decimal OrejaIzquierda { get; set; }
        public decimal OrejaDerecha { get; set; }
        public decimal LevantadoSuelo { get; set; }

    }
}
