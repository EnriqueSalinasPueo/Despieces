using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.Clases
{
    [Table("tablero")]
    public class Tablero
    {
        [ExplicitKey]
        public int id_tablero { get; set; }
        public string nombre { get; set; }
        public string referencia { get; set; }
        public int largo { get; set; }
        public int ancho { get; set; }
        public int grueso { get; set; }
    }
}
