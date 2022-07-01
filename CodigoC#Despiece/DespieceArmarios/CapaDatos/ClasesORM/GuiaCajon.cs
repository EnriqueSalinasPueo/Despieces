
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace DespieceArmarios.CapaDatos.ClasesORM
{
    [Table("guiaCajon")]
    public class GuiaCajon
    {
        // descuentos sacados del catalogo de blum 
        // ISKL Largo del cajón interios
        // SKL  Largo de cajón
        // LW   Ancho interior cuerpo del mueble
        // NL   Largo nominal
        // X    Espesor del frente
        [ExplicitKey]
        public int id_guiaCajon { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
    }
}
