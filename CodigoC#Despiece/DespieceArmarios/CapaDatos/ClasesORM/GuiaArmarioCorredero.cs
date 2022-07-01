using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.Clases
{

    [Table("guia")]
    public class Guia
    {
        [ExplicitKey]
        public int id_guia { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string formula_ancho_dos_puertas { get; set; }
        public string formula_ancho_tres_puertas { get; set; }
        public string formula_ancho_cuatro_puertas { get; set; }
        public string formula_ancho_cinco_puertas { get; set; }
        public string formula_ancho_seis_puertas { get; set; }
        public string formula_ancho_siete_puertas { get; set; }
        public string formula_ancho_ocho_puertas { get; set; }
        public int milimetros_resta_altura_puerta { get; set; }
        public int milimetros_resta_ancho_perfil_u_puerta { get; set; }
        public int ancho_guia { get; set; }
        public int alto_guia { get; set; }

        public string tipo_guia { get; set; }
    }
}
