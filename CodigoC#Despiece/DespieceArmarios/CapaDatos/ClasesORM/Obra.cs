using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.Clases
{
    [Table("obra")]
    public class Obra
    {
        [ExplicitKey]
        public int id_obra { get; set; }
        public string nombre{ get; set; }
        public int id_cliente { get; set; }
    }
}
