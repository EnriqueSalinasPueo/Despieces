using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;

namespace DespieceArmarios.ClasesBd
{
    ///<summary>
    ///Clase que se usa para recoger y dar valores del FromDefinirHolgurasGruesos.
    ///</summary>
    ///<remarks>
    ///Clase mapeada con la base de datos
    ///</remarks>
    [Table("holguras_gruesos")]
    public class DefinirHolgurasGruesos
    {
        ///<summary>
        ///Variable clave primaria para el mapeo.
        ///</summary>
        ///<remarks>
        ///NO ASIGNAR NINGUN VALOR
        ///</remarks>
        [ExplicitKey]
        public int id_holgurasGruesos { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_H_techo.
        ///</summary>
        ///<remarks>
        ///Holgura entre el techo y la base superio del armario.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal H_techo { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_H_fondo.
        ///</summary>
        ///<remarks>
        ///Holgura entrela pared y la trasera del armario.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal H_fondo { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_H_pared.
        ///</summary>
        ///<remarks>
        ///Holgura entre la pared y el costado.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal H_pared { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_H_puertas.
        ///</summary>
        ///<remarks>
        ///Holgura entre puertas abatibles y entre puerta y tapajuntas
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal H_puertas { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_H_cajones.
        ///</summary>
        ///<remarks>
        ///Holgura entre los frentes de los cajones
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal H_cajones { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_H_guia.
        ///</summary>
        ///<remarks>
        ///Holgura entre la guia de armario corredero y los costados interiores.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal H_guia { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_H_baldas.
        ///</summary>
        ///<remarks>
        ///Diferencia entre las  baldas y los costados
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal H_baldas { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_M_rodapie.
        ///</summary>
        ///<remarks>
        ///Milimetros que quieres montar el rodapie en la base del armario
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal M_rodapie{ get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_M_tapajuntas.
        ///</summary>
        ///<remarks>
        ///Milimetros que quieres montar el tapajuntas en el costado
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal M_tapajuntas { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_M_rodapie_guia.
        ///</summary>
        ///<remarks>
        ///Milimetros que quieres montar el rodapie en la guia de los correderos.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal M_rodapie_guia { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_M_jacena.
        ///</summary>
        ///<remarks>
        ///Milimetros que quieres montar el remate sobre la jacena.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal M_jacena { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeric_Descolgar_cornisa.
        ///</summary>
        ///<remarks>
        ///Milimetros que descuelga la cornisa de la guia en los correderos.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal Descolgar_cornisa { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_G_traseras.
        ///</summary>
        ///<remarks>
        ///Grueso del tablero que se usara para la trasera
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal G_traseras { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_G_costados.
        ///</summary>
        ///<remarks>
        ///Grueso del tablero que se usara para los costados y las bases
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal G_costados { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_G_puertas.
        ///</summary>
        ///<remarks>
        ///Grueso del tablero que se usara para las puertas que sean abatibles.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal G_puertas { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_G_correderas.
        ///</summary>
        ///<remarks>
        ///Grueso del tablero que se usará para las puertas correderas.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal G_correderas { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_G_guia.
        ///</summary>
        ///<remarks>
        ///Grueso de la guia superior en las puertas correderas.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal G_guia { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_G_apoyo_barra.
        ///</summary>
        ///<remarks>
        ///Grueso de las piezas donde se colocan las barras de colgar.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal G_apoyo_barra { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_G_tapeta.
        ///</summary>
        ///<remarks>
        ///Grueso de la tapeta donde cierran las puertas correderas.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal G_tapeta { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_G_tapajuntas.
        ///</summary>
        ///<remarks>
        ///Grueso del tapajuntas
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal G_tapajuntas { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_G_cornisa.
        ///</summary>
        ///<remarks>
        ///Grueso de la cornisa del armario.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal G_cornisa { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_G_rodapie.
        ///</summary>
        ///<remarks>
        ///Grueso rodapie de remate del armario.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal G_rodapie { get; set; }
        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_max_puertas.
        ///</summary>
        ///<remarks>
        ///Medida maxima de ancho para las puertas abatibles.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal max_puertas { get; set; }

        ///<summary>
        ///Variable que recoge del FormDefinirHolgurasGrueso el valor del numeri_max_correderas.
        ///</summary>
        ///<remarks>
        ///Medida maxima de ancho para las puertas correderas.
        ///</remarks>
        ///<remarks>
        ///Puede ser modificada en cualquier momento.
        ///</remarks>
        public decimal max_correderas { get; set; }

    }
}
