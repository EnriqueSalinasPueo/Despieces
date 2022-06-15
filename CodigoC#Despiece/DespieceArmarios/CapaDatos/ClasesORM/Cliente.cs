using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.Clases
{
    [Table("cliente")]
    public class Cliente
    {
        [ExplicitKey]
        public int id_cliente { get; set; }
        public string nombre { get; set; }
    }
}
