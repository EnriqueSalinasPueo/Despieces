using Dapper.Contrib.Extensions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///<summary>
///Lee la configuración de la aplicación desde el disco.
///</summary>
///<remarks>
///Puede ser modificada en cualquier momento.
///</remarks>
///<return>
///Devuelve true si la configuración fue leida. Si hubo algún error se devuelve false.
///</return>
///<param name="archivo">
///Ruta del archivo en disco a leer.
///</param>

namespace DespieceArmarios.Clases
{
    ///<summary>
    ///Clase que se usa para construir un armario.
    ///</summary>
    ///<remarks>
    ///Clase mapeada con la base de datos
    ///</remarks>
    [Table("armario")]
   public class Armario
    {
        ///<summary>
        ///Variable clave primaria para el mapeo.
        ///</summary>
        ///<remarks>
        ///NO ASIGNAR NINGUN VALOR
        ///</remarks>
        [ExplicitKey]
        public int id_armario { get; set; }
        public string escalera { get; set; }
        public string piso { get; set; }
        public string habitacion { get; set; }
        public int h_alto{ get; set; }
        public int h_ancho { get; set; }
        public int h_fondo { get; set; }
        public int modulos { get; set; }
        public int puertas { get; set; }
        public int altura_patas { get; set; }
        public decimal alto_armario { get; set; }
        public decimal ancho_armario { get; set; }
        public decimal fondo_armario { get; set; }
        public string modelo_armario { get; set; }
        public int id_obra { get; set; }

    }
}
