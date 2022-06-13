using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.Clases
{
    public class MedidasTotales
    {
        public string Nombre { get; set; }
        public decimal TotalMetros { get; set; }

        public MedidasTotales(string nombre, decimal totalMetros)
        {
            Nombre = nombre;
            TotalMetros = totalMetros;
        }


    }
}
