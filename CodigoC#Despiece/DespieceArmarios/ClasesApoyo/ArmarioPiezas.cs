using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.Clases
{
    public class ArmarioFull : Armario
    {
        public string PiezasString { get; set; }
    }
    public class ArmarioPiezas
    {
        public Armario armario { get; set; }
        public List<Pieza> piezas { get; set; }
    }
}
