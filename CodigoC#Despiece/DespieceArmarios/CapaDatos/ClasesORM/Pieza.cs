using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.Clases
{
    /// <summary>
    /// Clase para dara valores a cada pieza necesario
    /// </summary>
    /// <remarks>
    /// Clase mapea con base de datos, tiene que tener las mismas propiedades que campos en la basse de datos.
    /// </remarks>
    [Table("pieza")]
    public class Pieza
    {
        [ExplicitKey]
        public decimal id_pieza { get; set; }
        public string nombre { get; set; }
        public string tag { get; set; }
        public decimal cantidad { get; set; }
        public decimal largo { get; set; }
        public decimal ancho { get; set; }
        public decimal grueso { get; set; }
        public decimal id_armario { get; set; }
        /// <summary>
        /// Devuelve un string con todos las propiedades de la clase.
        /// </summary>
        /// <returns>
        /// string con todos las propiedades de la clase seteadas a cadena.
        /// </returns>
        public string ToFormattedString()
        {
            return $"{nombre.Trim().PadRight(19, ' ')} =>   {cantidad}  =  {Decimal.Round(largo).ToString().PadLeft(4, ' ')}  x  {Decimal.Round(ancho).ToString().PadLeft(4, ' ')}  x  {Decimal.Round(grueso).ToString().PadLeft(4, ' ')}";
        }
    }
}
