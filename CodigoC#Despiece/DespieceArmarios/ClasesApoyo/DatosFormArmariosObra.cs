namespace DespieceArmarios.Clases
{
    public class DatosFormArmariosObra
    {
        // Nombres para identificar el armario
        public string Escalera { get; set; }
        public string Piso{ get; set; }
        public string Habitacion { get; set; }
        // Tipo de armario
        public string TipoArmario{ get; set; }
        // Medidas de hueco
        public int Hueco_alto { get; set; }
        public int Hueco_ancho { get; set; }
        public int Hueco_fondo { get; set; }
        // Caracteristicas
        public int GruesoModulos { get; set; }
        public int GruesoPuertas { get; set; }
        public int AnchoTapajuntas{ get; set; }
        public int AltoRodapie { get; set; }
        public int NumeroBadas { get; set; }
        public bool HastaSuelo { get; set; }
        public bool HastaRodapie { get; set; }
        public bool PuertasCorrederas { get; set; }
        public bool PuertasAbatibles { get; set; }
        public bool TraseraAcanalada { get; set; }
        public bool TraseraAtornillada { get; set; }
        public bool BarraLateral { get; set; }
        public bool BarraColgar { get; set; }
        public bool ConJacena { get; set; }
        // Catacteristicas Rinconero
        public bool ArmarioRinconero { get; set; }
        public int Hueco_segundoAncho { get; set; }
        public int Hueco_segundoFondo { get; set; }
        public bool ParedAbierta { get; set; }
        public bool ParedCerrada { get; set; }

    }
}
