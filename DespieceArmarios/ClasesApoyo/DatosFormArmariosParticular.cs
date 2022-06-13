using DespieceArmarios.ClasesApoyo.ClasesArmarioParticular;
using DespieceArmarios.ClasesApoyo.ClasesParticular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespieceArmarios.ClasesApoyo
{
    ///<summary>
    ///Clase para  almacenar las diferentes clases de recogida de datos 
    ///</summary>
    ///<remarks>
    ///</remarks>
    public class DatosFormArmariosParticular
    {

        public InfoAltillo infoAltillo { get; set; } = new InfoAltillo();
        public InfoArmarioRinconero infoArmarioRinconero { get; set; } = new InfoArmarioRinconero();
        public InfoHueco infoHueco { get; set; } = new InfoHueco();
        public InfoModulo infoModulo { get; set; } = new InfoModulo();
        public InfoOpciones infoOpciones { get; set; } = new InfoOpciones();
        public InfoRemates infoRemates { get; set; } = new InfoRemates();
    }
}
