
using DespieceArmarios.ClasesBd;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespieceArmarios.Clases
{
    public class CalculosArmarioCorrederoObra
    {
        // Variables recogida de datos
        // Nombres para identificar el armario
        private string cliente;
        private string obra;
        private string escalera;
        private string piso;
        private string habitacion;
        // Tipo de armario
        private string tipoArmario;
        private string tipoBarra;
        // Medidas de hueco
        private int h_alto;
        private int h_ancho;
        private int h_fondo;
        // Caracteristicas
        private decimal gruesoModulo;
        private int gruesoPuerta;
        private int tapajuntasAncho;
        private int rodapieAltura;
        private int numeroBaldas;
        private bool TapajuntasSuelo;
        private bool TapajuntasRodapie;
        private bool PuertaCorredera;
        private bool PuertaAbatibale;
        private bool TraseraAcanalada;
        private bool TraseraAtornillada;
        private bool BarraColgar;
        private bool BarraLateral;
        private bool conjacena;
        // Catacteristicas Rinconero
        private bool armarioRinconero;
        private int h_segundo_ancho;
        private int h_segundo_fondo;
        private bool paredDerechaAbierta;
        private bool paredDerechaCerrada;
        private bool segundaVueltaRinconero = false;
        private bool primeraVueltaPuertas = true;

        // Variables para trabajar
        private int medidasRestarSegunTrasera_altura;
        private int medidasRestarSegunTrasera_anchura;
        private int medidasAlturaAltillo;
        private int numeroModulos;
        private int numeroPuertas;
        private decimal anchoTotal;
        private decimal anchoTotalDos;

        private decimal anchoModuloIgual;
        private decimal anchoModuloDiferente;
        private decimal interiorArmarioAnchoTotalParaPuertas;

        private int numeroTapajuntas = 2;
        private int numeroCornisa = 1;
        private int numeroRodapie = 1;
        private int restaTraseraAcanalada = 20;

        // Objetos de trabajo para recupara datos y definir medidas
        private List<Pieza> piezas = new List<Pieza>();
        private List<ArmarioPiezas> armariosPiezasLista = new List<ArmarioPiezas>();
        private Guia guia = null;
        private ArmarioPiezas armarioPiezas = new ArmarioPiezas();
        private Armario armario = new Armario();
        private Armario vueltaArmario = new Armario();
        private DefinirHolgurasGruesos holguraGrueso = new DefinirHolgurasGruesos();

        // Objetos de trabajo de las piezas de los armarios
        // correderos y abatibles
        private Pieza costados = new Pieza();
        private Pieza costadosCentrales = new Pieza();
        private Pieza bases = new Pieza();
        private Pieza basesCortas = new Pieza();
        private Pieza altillos = new Pieza();
        private Pieza altillosCortos = new Pieza();
        private Pieza apoyo = new Pieza();
        private Pieza baldas = new Pieza();
        private Pieza baldasCortas = new Pieza();
        private Pieza traseraInferior = new Pieza();
        private Pieza traseraInferiorCorta = new Pieza();
        private Pieza traseraSuperior = new Pieza();
        private Pieza traseraSuperiorCorta = new Pieza();

        // Perfileria 
        private Pieza barra = new Pieza();
        private Pieza barraCorta = new Pieza();
        private Pieza perfilPuerta = new Pieza();
        private Pieza perfilEnU = new Pieza();
        private Pieza guiasSuperiorInferior = new Pieza();

        // Remates exteriores
        private Pieza puertasDM = new Pieza();
        private Pieza tapetasInterioDM = new Pieza();
        private Pieza cornisaDM = new Pieza();
        private Pieza rodapieDM = new Pieza();
        private Pieza tapajuntasDM = new Pieza();

        // Rinconero
        private Pieza vueltaBases = new Pieza();
        private Pieza vueltaBaldas = new Pieza();
        private Pieza vueltaAltillo = new Pieza();
        private Pieza vueltaTraseraInferior = new Pieza();
        private Pieza vueltaTraseraSuperior = new Pieza();
        private Pieza puertasDMVuelta = new Pieza();
        private Pieza cornisaDMVuelta = new Pieza();
        private Pieza rodapieDMVuelta = new Pieza();
        private Pieza perfilEnUVuelta = new Pieza();
        private Pieza guiasSuperiorInferiorVuelta = new Pieza();
        private Pieza barraVuelta = new Pieza();


        public CalculosArmarioCorrederoObra(string cliente, string obra, string guiaa, DatosFormArmariosObra datos, List<ArmarioPiezas> armarios)
        {
            this.cliente = cliente;
            this.obra = obra;
            this.escalera = datos.Escalera;
            this.piso = datos.Piso;
            this.habitacion = datos.Habitacion;

            this.tipoArmario = datos.TipoArmario;

            this.h_alto = datos.Hueco_alto;
            this.h_ancho = datos.Hueco_ancho;
            this.h_fondo = datos.Hueco_fondo;

            this.gruesoModulo = datos.GruesoModulos;
            this.gruesoPuerta = datos.GruesoPuertas;
            this.tapajuntasAncho = datos.AnchoTapajuntas;
            this.rodapieAltura = datos.AltoRodapie;
            this.numeroBaldas = datos.NumeroBadas;
            this.TapajuntasSuelo = datos.HastaSuelo;
            this.TapajuntasRodapie = datos.HastaRodapie;
            this.PuertaCorredera = datos.PuertasCorrederas;
            this.PuertaAbatibale = datos.PuertasAbatibles;
            this.TraseraAcanalada = datos.TraseraAcanalada;
            this.TraseraAtornillada = datos.TraseraAtornillada;
            this.BarraLateral = datos.BarraLateral;
            this.BarraColgar = datos.BarraColgar;
            this.conjacena = datos.ConJacena;

            this.armarioRinconero = datos.ArmarioRinconero;
            this.h_segundo_ancho = datos.Hueco_segundoAncho;
            this.h_segundo_fondo = datos.Hueco_segundoFondo;
            this.paredDerechaAbierta = datos.ParedAbierta;
            this.paredDerechaCerrada = datos.ParedCerrada;

            this.armariosPiezasLista = armarios;



            guia = CallBbdd.GetGuia();
            holguraGrueso = CallBbdd.GetHolgurasGruesos();
            SacarMedidas();

        }

        private void SacarMedidas()
        {
            AsignarVariablesSeleccionadas();
            ArmarioMedidas();

            Costados();
            if (PuertaCorredera)
            {
                Costados_Centrales();
            }
            Bases();
            Altillo();
            Baldas();
            Trasera_Inferior();
            Trasera_Superior();

            TapajuntasDM();
            if (PuertaCorredera)
            {
                TapetasInteriorDM();
            }
            CornisaDM();
            PuertasDM();

            if (TapajuntasSuelo)
            {
                RodapieDM();
            }

            if (PuertaCorredera)
            {
                SacarPerfilPuerta();
                SacarPerfilU();
                SacarGuiaSupInf();
            }
            if (BarraColgar || BarraLateral)
            {
                SacarBarra();
            }

            HacerLista();
            CallBbdd.SaveDatos(armario, piezas, cliente, obra, armariosPiezasLista);
        }



        /**************************  Preparar las medidas de los armarios totales para sacarlas por modulos  ************************************/
        private void AsignarVariablesSeleccionadas()
        {
            /*Es los siguientes "if" se determina el largo de la base o 
             * lo que es lo mismo el ancho del mueble menos los gruesos de los costados.*/
            if (tipoArmario == "Omega")
            {
                if (armarioRinconero)
                {
                    anchoTotal = h_ancho - holguraGrueso.H_pared - holguraGrueso.H_fondo;
                    anchoTotalDos = h_segundo_ancho - holguraGrueso.H_pared - holguraGrueso.H_fondo;
                }
                else
                {
                    if (PuertaCorredera)
                    {
                        anchoTotal = (h_ancho - (holguraGrueso.H_pared * 2));
                    }
                    else if (PuertaAbatibale)
                    {
                        anchoTotal = (h_ancho - (holguraGrueso.H_pared * 2));
                    }
                }
            }
            if (tipoArmario == "L")
            {
                if (armarioRinconero)
                {
                    if (paredDerechaAbierta)
                    {
                        anchoTotal = h_ancho - (tapajuntasAncho - holguraGrueso.G_tapeta - gruesoModulo) - holguraGrueso.H_fondo;
                        anchoTotalDos = h_segundo_ancho - holguraGrueso.H_pared - holguraGrueso.H_fondo;
                    }
                    else if (paredDerechaCerrada)
                    {
                        anchoTotal = h_ancho - holguraGrueso.H_pared - holguraGrueso.H_fondo;
                        anchoTotalDos = h_segundo_ancho - (tapajuntasAncho - holguraGrueso.G_tapeta - gruesoModulo) - holguraGrueso.H_fondo;
                    }

                }
                else
                {
                    if (PuertaCorredera)
                    {
                        anchoTotal = (h_ancho - ((tapajuntasAncho - holguraGrueso.G_tapeta - gruesoModulo) + holguraGrueso.H_pared));
                    }
                    else if (PuertaAbatibale)
                    {
                        anchoTotal = (h_ancho - ((tapajuntasAncho - (gruesoModulo / 2)) + holguraGrueso.H_pared));
                    }

                }
            }
            if (tipoArmario == "U")
            {
                if (armarioRinconero)
                {
                    anchoTotal = h_ancho - (tapajuntasAncho - holguraGrueso.G_tapeta - gruesoModulo) - holguraGrueso.H_fondo;
                    anchoTotalDos = h_segundo_ancho - (tapajuntasAncho - holguraGrueso.G_tapeta - gruesoModulo) - holguraGrueso.H_fondo;
                }
                else
                {
                    if (PuertaCorredera)
                    {
                        anchoTotal = (h_ancho - (2 * (tapajuntasAncho - holguraGrueso.G_tapeta - gruesoModulo)));
                    }
                    else if (PuertaAbatibale)
                    {
                        anchoTotal = (h_ancho - (2 * (tapajuntasAncho - (gruesoModulo / 2))));
                    }
                }
            }

            /*En los siguiente "if" se recogen valores usados para determinar el largo de la trasera*/
            if (TraseraAcanalada)
            {
                medidasRestarSegunTrasera_altura = 15;
                medidasRestarSegunTrasera_anchura = 20;
            }
            if (TraseraAtornillada)
            {
                medidasRestarSegunTrasera_altura = 0;
                medidasRestarSegunTrasera_anchura = 0;
            }

        }
        private void ArmarioMedidas()
        {
            armario.escalera = escalera.ToUpper();
            armario.piso = piso.ToUpper();
            armario.habitacion = habitacion.ToUpper();
            armario.h_alto = h_alto;
            armario.h_ancho = h_ancho;
            armario.h_fondo = h_fondo;
            armario.modulos = CalcularModulosYPuertas(false);
            armario.puertas = CalcularModulosYPuertas(true);
            armario.altura_patas = (int)(rodapieAltura - gruesoModulo - holguraGrueso.M_rodapie_guia);
            armario.alto_armario = (h_alto - (rodapieAltura - gruesoModulo - 3) - holguraGrueso.H_techo);
            armario.ancho_armario = anchoTotal;
            if (TraseraAtornillada)
            {
                armario.fondo_armario = (h_fondo - holguraGrueso.H_fondo - holguraGrueso.G_traseras);
            }
            else
            {
                armario.fondo_armario = (h_fondo - holguraGrueso.H_fondo);
            }
            armario.modelo_armario = tipoArmario;
            if (armarioRinconero)
            {
                armario.modelo_armario = tipoArmario + " Rinconero";
                vueltaArmario.escalera = armario.escalera;
                vueltaArmario.piso = armario.piso;
                vueltaArmario.habitacion = armario.habitacion + " derecha";
                vueltaArmario.h_alto = h_alto;
                vueltaArmario.h_ancho = h_segundo_ancho;
                vueltaArmario.h_fondo = h_segundo_fondo;
                vueltaArmario.modulos = CalcularModulosYPuertas(false);
                vueltaArmario.puertas = CalcularModulosYPuertas(true);
                vueltaArmario.altura_patas = armario.altura_patas;
                vueltaArmario.alto_armario = armario.alto_armario;
                vueltaArmario.ancho_armario = anchoTotalDos;
                if (TraseraAtornillada)
                {
                    vueltaArmario.fondo_armario = (h_segundo_fondo - holguraGrueso.H_fondo - holguraGrueso.G_traseras);
                }
                else
                {
                    vueltaArmario.fondo_armario = (h_segundo_fondo - holguraGrueso.H_fondo);
                }
                vueltaArmario.modelo_armario = tipoArmario + " Rinconero";
            }

            /*Dependiendo de la medida total de largo del modulo,
             la altura del altillos sera 1900  o  1800 mm*/
            if (armario.alto_armario >= 2200)
            {
                medidasAlturaAltillo = 1900;
            }
            else
            {
                medidasAlturaAltillo = 1800;
            }
        }
        private int CalcularModulosYPuertas(bool puertas)
        {
            if (armarioRinconero)
            {
                // CUIDADO la variable solo tiene la medida de la parte del frente, falta el segundo fondo o el ancho de la guia para sacar las puertas
                decimal anchoTotalMenosFondo = 0;
                decimal fondoActual = 0;

                if (!segundaVueltaRinconero)
                {
                    fondoActual = h_segundo_fondo;
                    anchoTotalMenosFondo = anchoTotal - h_segundo_fondo;
                    segundaVueltaRinconero = true;
                }
                else if (segundaVueltaRinconero)
                {
                    fondoActual = h_fondo;
                    anchoTotalMenosFondo = anchoTotalDos - h_fondo;
                }

                if (PuertaCorredera)
                {
                    if (anchoTotalMenosFondo <= holguraGrueso.max_correderas * 2)
                    {
                        numeroModulos = 1;
                        numeroPuertas = 2;

                        anchoModuloIgual = (anchoTotalMenosFondo / numeroPuertas) * 2 + fondoActual;
                    }
                    else if (anchoTotalMenosFondo > holguraGrueso.max_correderas * 2 && anchoTotalMenosFondo <= holguraGrueso.max_correderas * 3)
                    {
                        numeroModulos = 2;
                        numeroPuertas = 3;

                        anchoModuloIgual = (anchoTotalMenosFondo / numeroPuertas) * 2 + fondoActual;
                        anchoModuloDiferente = anchoTotalMenosFondo / numeroPuertas + fondoActual;
                    }
                    else if (anchoTotalMenosFondo > holguraGrueso.max_correderas * 3 && anchoTotalMenosFondo <= holguraGrueso.max_correderas * 4)
                    {
                        numeroModulos = 2;
                        numeroPuertas = 4;

                        anchoModuloIgual = (anchoTotalMenosFondo / numeroPuertas) * 2 + fondoActual;
                    }
                    else if (anchoTotalMenosFondo > holguraGrueso.max_correderas * 4 && anchoTotalMenosFondo <= holguraGrueso.max_correderas * 5)
                    {
                        numeroModulos = 3;
                        numeroPuertas = 5;

                        anchoModuloIgual = (anchoTotalMenosFondo / numeroPuertas) * 2 + fondoActual;
                        anchoModuloDiferente = anchoTotalMenosFondo / numeroPuertas + fondoActual;
                    }
                    else if (anchoTotalMenosFondo > holguraGrueso.max_correderas * 5 && anchoTotalMenosFondo <= holguraGrueso.max_correderas * 6)
                    {
                        numeroModulos = 3;
                        numeroPuertas = 6;

                        anchoModuloIgual = (anchoTotalMenosFondo / numeroPuertas) * 2 + fondoActual;
                    }
                    else if (anchoTotalMenosFondo > holguraGrueso.max_correderas * 6 && anchoTotalMenosFondo <= holguraGrueso.max_correderas * 7)
                    {
                        numeroModulos = 4;
                        numeroPuertas = 7;

                        anchoModuloIgual = (anchoTotalMenosFondo / numeroPuertas) * 2 + fondoActual;
                        anchoModuloDiferente = anchoTotalMenosFondo / numeroPuertas + fondoActual;
                    }
                    else if (anchoTotalMenosFondo > holguraGrueso.max_correderas * 7 && anchoTotalMenosFondo <= holguraGrueso.max_correderas * 8)
                    {
                        numeroModulos = 4;
                        numeroPuertas = 8;

                        anchoModuloIgual = (anchoTotalMenosFondo / numeroPuertas) * 2 + fondoActual;
                    }

                }

                if (PuertaAbatibale)
                {
                    if (anchoTotal <= holguraGrueso.max_puertas)
                    {
                        numeroModulos = 1;
                        numeroPuertas = 1;

                        anchoModuloIgual = (anchoTotal / numeroPuertas);
                    }
                    else if (anchoTotal <= holguraGrueso.max_puertas * 2)
                    {
                        numeroModulos = 1;
                        numeroPuertas = 2;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                    }
                    else if (anchoTotal > holguraGrueso.max_puertas * 2 && anchoTotal <= holguraGrueso.max_puertas * 3)
                    {
                        numeroModulos = 2;
                        numeroPuertas = 3;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                        anchoModuloDiferente = anchoTotal / numeroPuertas;
                    }
                    else if (anchoTotal > holguraGrueso.max_puertas * 3 && anchoTotal <= holguraGrueso.max_puertas * 4)
                    {
                        numeroModulos = 2;
                        numeroPuertas = 4;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                    }
                    else if (anchoTotal > holguraGrueso.max_puertas * 4 && anchoTotal <= holguraGrueso.max_puertas * 5)
                    {
                        numeroModulos = 3;
                        numeroPuertas = 5;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                        anchoModuloDiferente = anchoTotal / numeroPuertas;
                    }
                    else if (anchoTotal > holguraGrueso.max_puertas * 5 && anchoTotal <= holguraGrueso.max_puertas * 6)
                    {
                        numeroModulos = 3;
                        numeroPuertas = 6;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                    }
                    else if (anchoTotal > holguraGrueso.max_puertas * 6 && anchoTotal <= holguraGrueso.max_puertas * 7)
                    {
                        numeroModulos = 4;
                        numeroPuertas = 7;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                        anchoModuloDiferente = anchoTotal / numeroPuertas;
                    }
                    else if (anchoTotal > holguraGrueso.max_puertas * 7 && anchoTotal <= holguraGrueso.max_puertas * 8)
                    {
                        numeroModulos = 4;
                        numeroPuertas = 8;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                    }
                }


            }
            else
            {
                if (PuertaCorredera)
                {
                    if (anchoTotal <= holguraGrueso.max_correderas * 2)
                    {
                        numeroModulos = 1;
                        numeroPuertas = 2;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                    }
                    else if (anchoTotal > holguraGrueso.max_correderas * 2 && anchoTotal <= holguraGrueso.max_correderas * 3)
                    {
                        numeroModulos = 2;
                        numeroPuertas = 3;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                        anchoModuloDiferente = anchoTotal / numeroPuertas;
                    }
                    else if (anchoTotal > holguraGrueso.max_correderas * 3 && anchoTotal <= holguraGrueso.max_correderas * 4)
                    {
                        numeroModulos = 2;
                        numeroPuertas = 4;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                    }
                    else if (anchoTotal > holguraGrueso.max_correderas * 4 && anchoTotal <= holguraGrueso.max_correderas * 5)
                    {
                        numeroModulos = 3;
                        numeroPuertas = 5;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                        anchoModuloDiferente = anchoTotal / numeroPuertas;
                    }
                    else if (anchoTotal > holguraGrueso.max_correderas * 5 && anchoTotal <= holguraGrueso.max_correderas * 6)
                    {
                        numeroModulos = 3;
                        numeroPuertas = 6;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                    }
                    else if (anchoTotal > holguraGrueso.max_correderas * 6 && anchoTotal <= holguraGrueso.max_correderas * 7)
                    {
                        numeroModulos = 4;
                        numeroPuertas = 7;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                        anchoModuloDiferente = anchoTotal / numeroPuertas;
                    }
                    else if (anchoTotal > holguraGrueso.max_correderas * 7 && anchoTotal <= holguraGrueso.max_correderas * 8)
                    {
                        numeroModulos = 4;
                        numeroPuertas = 8;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                    }

                }

                // Nada implementado sobre puertas abatibles
                if (PuertaAbatibale)
                {
                    if (anchoTotal <= holguraGrueso.max_puertas)
                    {
                        numeroModulos = 1;
                        numeroPuertas = 1;

                        anchoModuloIgual = (anchoTotal / numeroPuertas);
                    }
                    else if (anchoTotal <= holguraGrueso.max_puertas * 2)
                    {
                        numeroModulos = 1;
                        numeroPuertas = 2;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                    }
                    else if (anchoTotal > holguraGrueso.max_puertas * 2 && anchoTotal <= holguraGrueso.max_puertas * 3)
                    {
                        numeroModulos = 2;
                        numeroPuertas = 3;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                        anchoModuloDiferente = anchoTotal / numeroPuertas;
                    }
                    else if (anchoTotal > holguraGrueso.max_puertas * 3 && anchoTotal <= holguraGrueso.max_puertas * 4)
                    {
                        numeroModulos = 2;
                        numeroPuertas = 4;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                    }
                    else if (anchoTotal > holguraGrueso.max_puertas * 4 && anchoTotal <= holguraGrueso.max_puertas * 5)
                    {
                        numeroModulos = 3;
                        numeroPuertas = 5;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                        anchoModuloDiferente = anchoTotal / numeroPuertas;
                    }
                    else if (anchoTotal > holguraGrueso.max_puertas * 5 && anchoTotal <= holguraGrueso.max_puertas * 6)
                    {
                        numeroModulos = 3;
                        numeroPuertas = 6;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                    }
                    else if (anchoTotal > holguraGrueso.max_puertas * 6 && anchoTotal <= holguraGrueso.max_puertas * 7)
                    {
                        numeroModulos = 4;
                        numeroPuertas = 7;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                        anchoModuloDiferente = anchoTotal / numeroPuertas;
                    }
                    else if (anchoTotal > holguraGrueso.max_puertas * 7 && anchoTotal <= holguraGrueso.max_puertas * 8)
                    {
                        numeroModulos = 4;
                        numeroPuertas = 8;

                        anchoModuloIgual = (anchoTotal / numeroPuertas) * 2;
                    }
                }

            }

            if (puertas)
            {
                return numeroPuertas;
            }
            else
            {
                return numeroModulos;
            }
        }


        /*************************  Sacar el despiece con la medida total de cada modulo  *******************************************************/
        private void Costados()
        {
            costados.nombre = "Costados";
            costados.tag = "Costados";
            if (PuertaCorredera)
            {

                costados.cantidad = 2;

            }
            else if (PuertaAbatibale)
            {
                costados.cantidad = numeroModulos * 2;
            }
            costados.largo = armario.alto_armario;
            costados.ancho = armario.fondo_armario;
            costados.grueso = gruesoModulo;
        }
        private void Costados_Centrales()
        {
            costadosCentrales.nombre = "Costados Centrales";
            costadosCentrales.tag = "Costados";
            costadosCentrales.cantidad = (numeroModulos * 2) - 2;
            costadosCentrales.largo = armario.alto_armario;
            costadosCentrales.ancho = (int)(armario.fondo_armario - guia.ancho_guia - holguraGrueso.H_guia);
            costadosCentrales.grueso = gruesoModulo;
        }
        private void Bases()
        {
            bases.nombre = "Bases";
            bases.tag = "Bases";
            if (numeroPuertas % 2 == 0)
            {
                bases.cantidad = numeroModulos * 2;
            }
            else
            {
                bases.cantidad = (numeroModulos * 2) - 2;

                basesCortas.nombre = "Bases Cortas";
                basesCortas.tag = "Bases";
                basesCortas.cantidad = 2;
                basesCortas.largo = anchoModuloDiferente - (gruesoModulo * 2);
                basesCortas.ancho = armario.fondo_armario;
                basesCortas.grueso = gruesoModulo;
            }
            bases.largo = anchoModuloIgual - (gruesoModulo * 2);
            bases.ancho = armario.fondo_armario;
            bases.grueso = gruesoModulo;

            if (armarioRinconero)
            {
                bases.largo = anchoTotal - gruesoModulo;

                vueltaBases.nombre = "Bases Vuelta";
                vueltaBases.nombre = "Bases";
                vueltaBases.cantidad = bases.cantidad;
                vueltaBases.largo = vueltaArmario.ancho_armario - armario.fondo_armario - gruesoModulo;
                vueltaBases.ancho = vueltaArmario.fondo_armario;
                vueltaBases.grueso = gruesoModulo;

            }
        }
        private void Altillo()
        {
            altillos.nombre = "Altillo";
            if (numeroPuertas % 2 == 0)
            {
                altillos.cantidad = numeroModulos;
            }
            else
            {
                altillos.cantidad = numeroModulos - 1;

                altillosCortos.nombre = "Altillo Corto";
                altillosCortos.cantidad = 1;
                altillosCortos.largo = anchoModuloDiferente - (gruesoModulo * 2);
                if (PuertaCorredera)
                {
                    altillosCortos.ancho = (armario.fondo_armario - guia.ancho_guia - holguraGrueso.H_guia);
                }
                else if (PuertaAbatibale)
                {
                    altillosCortos.ancho = (armario.fondo_armario);
                }
                altillosCortos.grueso = gruesoModulo;
            }
            altillos.largo = anchoModuloIgual - (gruesoModulo * 2);
            if (PuertaCorredera)
            {
                altillos.ancho = (armario.fondo_armario - guia.ancho_guia - holguraGrueso.H_guia);
                vueltaAltillo.largo = vueltaArmario.ancho_armario - armario.fondo_armario + guia.ancho_guia + holguraGrueso.H_guia - gruesoModulo;
                vueltaAltillo.ancho = vueltaArmario.fondo_armario - guia.ancho_guia - holguraGrueso.H_guia;

            }
            else if (PuertaAbatibale)
            {
                altillos.ancho = (armario.fondo_armario);
                vueltaAltillo.largo = vueltaArmario.ancho_armario - armario.fondo_armario - gruesoModulo;
                vueltaAltillo.ancho = vueltaArmario.fondo_armario;
            }
            altillos.grueso = gruesoModulo;

            if (armarioRinconero)
            {
                altillos.largo = anchoTotal - gruesoModulo;

                vueltaAltillo.nombre = "Altillos Vuelta";
                vueltaAltillo.cantidad = altillos.cantidad;
                vueltaAltillo.grueso = gruesoModulo;
            }
        }
        private void Baldas()
        {
            baldas.nombre = "Balda Inferior";
            baldas.tag = "Baldas";
            if (numeroPuertas % 2 == 0)
            {
                baldas.cantidad = numeroBaldas * numeroModulos;
            }
            else
            {
                baldas.cantidad = (numeroBaldas * numeroModulos) - numeroBaldas;

                baldasCortas.nombre = "Balda Inf Corta";
                baldasCortas.tag = "Baldas";
                baldasCortas.cantidad = numeroBaldas;
                baldasCortas.largo = anchoModuloDiferente - (gruesoModulo * 2);

                if (TraseraAcanalada)
                {
                    if (PuertaCorredera)
                    {
                        baldasCortas.ancho = (armario.fondo_armario - guia.ancho_guia - holguraGrueso.H_guia - restaTraseraAcanalada - 2);
                    }
                    else if (PuertaAbatibale)
                    {
                        baldasCortas.ancho = (armario.fondo_armario - holguraGrueso.H_baldas - restaTraseraAcanalada);
                    }
                }
                else if (TraseraAtornillada)
                {
                    if (PuertaCorredera)
                    {
                        baldasCortas.ancho = (armario.fondo_armario - guia.ancho_guia - holguraGrueso.H_guia - holguraGrueso.H_baldas);
                    }
                    else if (PuertaAbatibale)
                    {
                        baldasCortas.ancho = (armario.fondo_armario - holguraGrueso.H_baldas);
                    }
                }

                baldasCortas.grueso = gruesoModulo;

            }

            baldas.largo = anchoModuloIgual - (gruesoModulo * 2);

            if (TraseraAcanalada)
            {
                if (PuertaCorredera)
                {
                    baldas.ancho = (armario.fondo_armario - guia.ancho_guia - holguraGrueso.H_guia - restaTraseraAcanalada - 2);
                }
                else if (PuertaAbatibale)
                {
                    baldas.ancho = (armario.fondo_armario - holguraGrueso.H_baldas - restaTraseraAcanalada);
                }
            }
            else if (TraseraAtornillada)
            {
                if (PuertaCorredera)
                {
                    baldas.ancho = (armario.fondo_armario - guia.ancho_guia - holguraGrueso.H_guia - holguraGrueso.H_baldas);
                }
                else if (PuertaAbatibale)
                {
                    baldas.ancho = (armario.fondo_armario - holguraGrueso.H_baldas);
                }
            }

            baldas.grueso = gruesoModulo;

            if (baldas.largo > 1300)
            {
                apoyo.nombre = "Apoyo";
                if (baldasCortas.largo > 1300)
                {
                    apoyo.cantidad = baldas.cantidad + baldasCortas.cantidad;
                }
                else
                {
                    apoyo.cantidad = baldas.cantidad;
                }
                apoyo.largo = 30;
                apoyo.ancho = baldas.ancho;
                apoyo.grueso = gruesoModulo;
            }

            if (armarioRinconero)
            {
                baldas.largo = anchoTotal - gruesoModulo - restaTraseraAcanalada;

                vueltaBaldas.nombre = "Baldas Vuelta";
                vueltaBaldas.tag = "Baldas";
                vueltaBaldas.cantidad = baldas.cantidad;
                vueltaBaldas.largo = anchoTotalDos - gruesoModulo - baldas.ancho - restaTraseraAcanalada; if (TraseraAcanalada)
                {
                    if (PuertaCorredera)
                    {
                        vueltaBaldas.ancho = (vueltaArmario.fondo_armario - guia.ancho_guia - holguraGrueso.H_guia - restaTraseraAcanalada - 2);
                    }
                    else if (PuertaAbatibale)
                    {
                        vueltaBaldas.ancho = (vueltaArmario.fondo_armario - holguraGrueso.H_baldas - restaTraseraAcanalada);
                    }
                }
                else if (TraseraAtornillada)
                {
                    if (PuertaCorredera)
                    {
                        vueltaBaldas.ancho = (vueltaArmario.fondo_armario - guia.ancho_guia - holguraGrueso.H_guia - holguraGrueso.H_baldas);
                    }
                    else if (PuertaAbatibale)
                    {
                        vueltaBaldas.ancho = (vueltaArmario.fondo_armario - holguraGrueso.H_baldas);
                    }
                }
                vueltaBaldas.grueso = gruesoModulo;
            }
        }
        private void Trasera_Inferior()
        {
            traseraInferior.nombre = "Trasera Inferior";
            traseraInferior.tag = "Traseras";
            if (numeroPuertas % 2 == 0)
            {
                traseraInferior.cantidad = numeroModulos;
            }
            else
            {
                traseraInferior.cantidad = numeroModulos - 1;

                traseraInferiorCorta.nombre = "Trasera Inf Corta";
                traseraInferiorCorta.tag = "Traseras";
                traseraInferiorCorta.cantidad = 1;
                traseraInferiorCorta.largo = medidasAlturaAltillo - medidasRestarSegunTrasera_altura;
                traseraInferiorCorta.ancho = anchoModuloDiferente - medidasRestarSegunTrasera_anchura;
                traseraInferiorCorta.grueso = holguraGrueso.G_traseras;
            }
            traseraInferior.largo = medidasAlturaAltillo - medidasRestarSegunTrasera_altura;
            traseraInferior.ancho = anchoModuloIgual - medidasRestarSegunTrasera_anchura;
            traseraInferior.grueso = holguraGrueso.G_traseras;

            if (armarioRinconero)
            {
                traseraInferior.ancho = anchoTotal - (medidasRestarSegunTrasera_anchura / 2) - restaTraseraAcanalada;

                vueltaTraseraInferior.nombre = "Trasera Inf Vuelta";
                vueltaTraseraInferior.tag = "Traseras";
                vueltaTraseraInferior.cantidad = 1;
                vueltaTraseraInferior.largo = traseraInferior.largo;
                vueltaTraseraInferior.ancho = anchoTotalDos - (medidasRestarSegunTrasera_anchura / 2) - restaTraseraAcanalada;
                vueltaTraseraInferior.grueso = gruesoModulo;
            }
        }
        private void Trasera_Superior()
        {
            int alturaRestante = (int)armario.alto_armario - medidasAlturaAltillo;

            traseraSuperior.nombre = "Trasera Superior";
            traseraSuperior.tag = "Traseras";

            if (numeroPuertas % 2 == 0)
            {
                traseraSuperior.cantidad = numeroModulos;
            }
            else
            {
                traseraSuperior.cantidad = numeroModulos - 1;

                traseraSuperiorCorta.nombre = "Trasera Sup Corta";
                traseraSuperiorCorta.tag = "Traseras";
                traseraSuperiorCorta.cantidad = 1;
                traseraSuperiorCorta.largo = alturaRestante - medidasRestarSegunTrasera_altura;
                traseraSuperiorCorta.ancho = anchoModuloDiferente - medidasRestarSegunTrasera_anchura;
                traseraSuperiorCorta.grueso = holguraGrueso.G_traseras;
            }
            traseraSuperior.largo = alturaRestante - medidasRestarSegunTrasera_altura;
            traseraSuperior.ancho = anchoModuloIgual - medidasRestarSegunTrasera_anchura;
            traseraSuperior.grueso = holguraGrueso.G_traseras;

            if (armarioRinconero)
            {
                traseraSuperior.ancho = anchoTotal - (medidasRestarSegunTrasera_anchura / 2) - restaTraseraAcanalada;

                vueltaTraseraSuperior.nombre = "Trasera Sup Vuelta";
                vueltaTraseraSuperior.tag = "Traseras";
                vueltaTraseraSuperior.cantidad = 1;
                vueltaTraseraSuperior.largo = traseraSuperior.largo;
                vueltaTraseraSuperior.ancho = anchoTotalDos - (medidasRestarSegunTrasera_anchura / 2) - restaTraseraAcanalada;
                vueltaTraseraSuperior.grueso = gruesoModulo;
            }
        }

        /**************  Piezas DM para barnizar  **************** PUERTA ABATIBLE revisar si esta terminado */
        private void TapajuntasDM()
        {
            tapajuntasDM.nombre = "DM Tapajuntas";
            tapajuntasDM.tag = "DM";
            tapajuntasDM.cantidad = numeroTapajuntas;
            if (conjacena)
            {
                if (TapajuntasSuelo)
                {
                    tapajuntasDM.largo = (int)(h_alto + holguraGrueso.M_jacena);
                }
                if (TapajuntasRodapie)
                {
                    tapajuntasDM.largo = (int)(h_alto - rodapieAltura + holguraGrueso.M_jacena);
                }
            }
            else
            {
                if (TapajuntasSuelo)
                {
                    tapajuntasDM.largo = h_alto;
                }
                if (TapajuntasRodapie)
                {
                    tapajuntasDM.largo = h_alto - rodapieAltura;
                }
            }
            tapajuntasDM.ancho = tapajuntasAncho;
            tapajuntasDM.grueso = (int)(holguraGrueso.G_tapajuntas);
        }
        private void CornisaDM()
        {
            cornisaDM.nombre = "DM Cornisa";
            cornisaDM.tag = "DM";
            cornisaDM.cantidad = numeroCornisa;

            if (PuertaCorredera)
            {
                cornisaDM.largo = armario.ancho_armario - (gruesoModulo * 2) - (tapetasInterioDM.grueso * 2) + 1;
            }
            else if (PuertaAbatibale)
            {
                cornisaDM.largo = armario.ancho_armario - (holguraGrueso.M_tapajuntas * 2);
            }

            if (conjacena)
            {
                if (PuertaCorredera)
                {
                    cornisaDM.ancho = (gruesoModulo + holguraGrueso.H_techo + holguraGrueso.G_guia + holguraGrueso.Descolgar_cornisa + holguraGrueso.M_jacena);
                }
                else if (PuertaAbatibale)
                {
                    cornisaDM.ancho = ((gruesoModulo / 2) + holguraGrueso.H_techo + holguraGrueso.M_jacena);
                }
            }
            else
            {
                if (PuertaCorredera)
                {
                    cornisaDM.ancho = (gruesoModulo + holguraGrueso.H_techo + holguraGrueso.G_guia + holguraGrueso.Descolgar_cornisa);
                }
                else if (PuertaAbatibale)
                {
                    cornisaDM.ancho = ((gruesoModulo / 2) + holguraGrueso.H_techo);
                }
            }
            cornisaDM.grueso = holguraGrueso.G_cornisa;

            if (armarioRinconero)
            {
                if (PuertaCorredera)
                {
                    cornisaDM.largo = armario.ancho_armario - gruesoModulo - tapetasInterioDM.grueso - vueltaArmario.fondo_armario + 1;
                    cornisaDMVuelta.largo = vueltaArmario.ancho_armario - gruesoModulo - tapetasInterioDM.grueso - armario.fondo_armario + 1;
                }
                else if (PuertaAbatibale)
                {
                    cornisaDM.largo = armario.ancho_armario - (gruesoModulo / 2) - vueltaArmario.fondo_armario;
                    cornisaDMVuelta.largo = vueltaArmario.ancho_armario - (gruesoModulo / 2) - armario.fondo_armario;
                }

                cornisaDMVuelta.nombre = "DM Cornisa Vuelta";
                cornisaDMVuelta.tag = "DM";
                cornisaDMVuelta.cantidad = numeroCornisa;
                cornisaDMVuelta.ancho = cornisaDM.ancho;
                cornisaDMVuelta.grueso = holguraGrueso.G_cornisa;


            }
        }
        private void RodapieDM()
        {
            rodapieDM.nombre = "DM Rodapie";
            rodapieDM.cantidad = numeroRodapie;
            if (PuertaCorredera)
            {
                rodapieDM.largo = armario.ancho_armario - (gruesoModulo * 2) - (tapetasInterioDM.grueso * 2) + 2;
            }
            else if (PuertaAbatibale)
            {
                rodapieDM.largo = armario.ancho_armario - (holguraGrueso.M_tapajuntas * 2);
            }
            rodapieDM.ancho = rodapieAltura;
            rodapieDM.grueso = holguraGrueso.G_rodapie;

            if (armarioRinconero)
            {
                if (PuertaCorredera)
                {
                    rodapieDM.largo = armario.ancho_armario - gruesoModulo - tapetasInterioDM.grueso - vueltaArmario.fondo_armario + 1;
                    rodapieDMVuelta.largo = vueltaArmario.ancho_armario - gruesoModulo - tapetasInterioDM.grueso - armario.fondo_armario + 1;
                }
                else if (PuertaAbatibale)
                {
                    rodapieDM.largo = armario.ancho_armario - (gruesoModulo / 2) - vueltaArmario.fondo_armario;
                    rodapieDMVuelta.largo = vueltaArmario.ancho_armario - (gruesoModulo / 2) - armario.fondo_armario;
                }

                rodapieDMVuelta.nombre = "DM Rodapie Vuelta";
                rodapieDMVuelta.tag = "DM";
                rodapieDMVuelta.cantidad = numeroRodapie;
                rodapieDMVuelta.ancho = rodapieAltura;
                rodapieDMVuelta.cantidad = holguraGrueso.G_rodapie;

            }
        }
        private void TapetasInteriorDM()
        {
            tapetasInterioDM.nombre = "DM Tapetas";
            tapetasInterioDM.tag = "DM";
            tapetasInterioDM.cantidad = numeroTapajuntas;
            tapetasInterioDM.largo = armario.alto_armario - (gruesoModulo * 2);
            tapetasInterioDM.ancho = (int)(guia.ancho_guia + holguraGrueso.H_guia);
            tapetasInterioDM.grueso = (int)holguraGrueso.G_tapeta;
        }
        private void PuertasDM()
        {
            puertasDM.nombre = "DM Puertas";
            puertasDM.tag = "DM";
            puertasDM.cantidad = numeroPuertas;
            if (PuertaCorredera)
            {
                puertasDM.largo = armario.alto_armario - (gruesoModulo * 2) - guia.milimetros_resta_altura_puerta;
                puertasDM.ancho = SacarAnchoPuertaCorrederas();
                primeraVueltaPuertas = false;
            }
            else if (PuertaAbatibale)
            {
                puertasDM.largo = (armario.alto_armario - gruesoModulo - holguraGrueso.H_puertas);
                puertasDM.ancho = SacarAnchoPuertaAbatible();
                primeraVueltaPuertas = false;
            }
            puertasDM.grueso = gruesoPuerta;

            if (armarioRinconero)
            {
                puertasDMVuelta.nombre = "DM Puertas vuelta";
                puertasDMVuelta.tag = "DM";
                puertasDMVuelta.cantidad = numeroPuertas;
                puertasDMVuelta.largo = puertasDM.largo;
                if (PuertaCorredera)
                {
                    puertasDMVuelta.ancho = SacarAnchoPuertaCorrederas();
                }
                else if (PuertaAbatibale)
                {
                    puertasDMVuelta.ancho = SacarAnchoPuertaAbatible();
                }
                puertasDMVuelta.grueso = gruesoPuerta;
            }
        }

        // TODO:Revisar cuanto montan las puertas dependiendo de la bisagra que pongas
        private int SacarAnchoPuertaAbatible()
        {
            int anchoPuerta = 0;
            if (armarioRinconero)
            {
                if (primeraVueltaPuertas)
                {
                    anchoPuerta = (int)(((armario.ancho_armario - (gruesoModulo / 2) - vueltaArmario.fondo_armario) / numeroPuertas) - holguraGrueso.H_puertas);
                }
                else
                {
                    anchoPuerta = (int)(((vueltaArmario.ancho_armario - (gruesoModulo / 2) - armario.fondo_armario) / numeroPuertas) - holguraGrueso.H_puertas);
                }
            }
            else
            {
                anchoPuerta = (int)(((armario.ancho_armario - gruesoModulo) / numeroPuertas) - holguraGrueso.H_puertas);
            }
            return anchoPuerta;
        }

        private int SacarAnchoPuertaCorrederas()
        {
            string cadena = null;
            if (armarioRinconero)
            {
                if (primeraVueltaPuertas)
                {
                    interiorArmarioAnchoTotalParaPuertas = armario.ancho_armario - gruesoModulo - tapetasInterioDM.grueso - vueltaArmario.fondo_armario + (guia.ancho_guia / 2);
                }
                else
                {
                    interiorArmarioAnchoTotalParaPuertas = vueltaArmario.ancho_armario - gruesoModulo - tapetasInterioDM.grueso - armario.fondo_armario + (guia.ancho_guia / 2);
                }
            }
            else
            {
                interiorArmarioAnchoTotalParaPuertas = armario.ancho_armario - (gruesoModulo * 2) - (tapetasInterioDM.grueso * 2);
            }
            if (numeroPuertas == 2)
            {
                cadena = guia.formula_ancho_dos_puertas;
            }
            else if (numeroPuertas == 3)
            {
                cadena = guia.formula_ancho_tres_puertas;
            }
            else if (numeroPuertas == 4)
            {
                cadena = guia.formula_ancho_cuatro_puertas;
            }
            else if (numeroPuertas == 5)
            {
                cadena = guia.formula_ancho_cinco_puertas;
            }
            else if (numeroPuertas == 6)
            {
                cadena = guia.formula_ancho_seis_puertas;
            }
            else if (numeroPuertas == 7)
            {
                cadena = guia.formula_ancho_siete_puertas;
            }
            else if (numeroPuertas == 8)
            {
                cadena = guia.formula_ancho_ocho_puertas;
            }

            cadena = cadena.Replace("a", "");
            if (guia.tipo_guia == "a-descontar/puertas")
            {
                string[] formula = cadena.Split('/');
                int resta = int.Parse(formula[0]);
                int divididoPor = int.Parse(formula[1]);
                //MessageBox.Show(resta.ToString());
                //MessageBox.Show(divididoPor.ToString());

                return (int)(interiorArmarioAnchoTotalParaPuertas + resta) / divididoPor;

            }
            else if (guia.tipo_guia == "a/puertas-descontar")
            {

                cadena = cadena.Replace("/", "");
                string[] formula = cadena.Split('-');
                int divididoPor = int.Parse(formula[0]);
                int resta = int.Parse(formula[1]);
                //MessageBox.Show(resta.ToString());
                //MessageBox.Show(divididoPor.ToString());

                return (int)interiorArmarioAnchoTotalParaPuertas / divididoPor - resta;

            }
            return 0;
        }

        /**************  Perfileria necesaria  ****************/


        private void SacarPerfilPuerta()
        {
            perfilPuerta.nombre = "Perfiles";
            if (armarioRinconero)
            {
                perfilPuerta.cantidad = (armario.puertas * 2) + (vueltaArmario.puertas * 2);
            }
            else
            {
                perfilPuerta.cantidad = armario.puertas * 2;
            }
            perfilPuerta.largo = puertasDM.largo + 1;
        }
        private void SacarPerfilU()
        {
            perfilEnU.nombre = "Perfil U";
            perfilEnU.cantidad = armario.puertas;
            perfilEnU.largo = puertasDM.ancho - guia.milimetros_resta_ancho_perfil_u_puerta;
            if (armarioRinconero)
            {
                perfilEnUVuelta.nombre = "Perfil U Vuelta";
                perfilEnUVuelta.cantidad = vueltaArmario.puertas;
                perfilEnUVuelta.largo = puertasDMVuelta.ancho - guia.milimetros_resta_ancho_perfil_u_puerta;
            }
        }
        private void SacarGuiaSupInf()
        {
            guiasSuperiorInferior.nombre = "Guia Sup/Inf";
            guiasSuperiorInferior.cantidad = 2;
            guiasSuperiorInferior.largo = armario.ancho_armario - (gruesoModulo * 2) - (tapetasInterioDM.grueso * 2);
            if (armarioRinconero)
            {
                guiasSuperiorInferior.largo = armario.ancho_armario - gruesoModulo - tapetasInterioDM.grueso - vueltaArmario.fondo_armario + (guia.ancho_guia / 2);

                guiasSuperiorInferiorVuelta.nombre = "Guia Sup/Inf Vuelta";
                guiasSuperiorInferiorVuelta.cantidad = 2;
                guiasSuperiorInferiorVuelta.largo = vueltaArmario.ancho_armario - gruesoModulo - tapetasInterioDM.grueso - armario.fondo_armario + (guia.ancho_guia / 2);
            }
        }
        private void SacarBarra()
        {
            barra.nombre = "Barra" + tipoBarra;
            if (numeroPuertas % 2 == 0)
            {
                barra.cantidad = numeroModulos;
                if (BarraLateral)
                {
                    barra.nombre += " lateral";
                    barra.largo = (int)(altillos.largo - holguraGrueso.G_apoyo_barra * 2);
                }
                if (BarraColgar)
                {
                    barra.nombre += " colgar";
                    barra.largo = (int)(altillos.largo - holguraGrueso.G_apoyo_barra * 2);
                }
            }
            else
            {
                barra.cantidad = numeroModulos - 1;

                barraCorta.nombre = "Barra Corta";
                barraCorta.cantidad = 1;
                if (tipoBarra == "Lateral")
                {
                    barra.largo = (int)(altillos.largo - holguraGrueso.G_apoyo_barra * 2);
                    barraCorta.largo = (int)(altillosCortos.largo - holguraGrueso.G_apoyo_barra * 2);
                }
                if (tipoBarra == "Colgar")
                {
                    barra.largo = (int)(altillos.largo - holguraGrueso.G_apoyo_barra * 2);
                    barraCorta.largo = (int)(altillosCortos.largo - holguraGrueso.G_apoyo_barra * 2);
                }
            }
            if (armarioRinconero)
            {
                barra.largo = armario.ancho_armario - gruesoModulo - tapetasInterioDM.grueso - (vueltaArmario.fondo_armario / 2);

                barraVuelta.nombre = "Barra Vuelta";
                barraVuelta.cantidad = 1;
                barraVuelta.largo = vueltaArmario.ancho_armario - gruesoModulo - tapetasInterioDM.grueso - (armario.fondo_armario / 2);
            }
        }


        /*************************  Añadir a la lista todas las piezas e imprimir la lista  *****************************************************/
        private void HacerLista()
        {
            piezas.Add(costados);

            if (PuertaCorredera)
            {
                if (numeroModulos > 1)
                {
                    piezas.Add(costadosCentrales);
                }
            }

            piezas.Add(bases);

            if (armarioRinconero)
            {
                piezas.Add(vueltaBases);
            }

            if (numeroPuertas % 2 != 0)
            {
                piezas.Add(basesCortas);
            }

            piezas.Add(altillos);

            if (armarioRinconero)
            {
                piezas.Add(vueltaAltillo);
            }

            if (numeroPuertas % 2 != 0)
            {
                piezas.Add(altillosCortos);
            }
            if (numeroBaldas > 0)
            {
                piezas.Add(baldas);
                if (armarioRinconero)
                {
                    piezas.Add(vueltaBaldas);
                }
                if (numeroPuertas % 2 != 0)
                {
                    piezas.Add(baldasCortas);
                }
                if (baldas.largo > 1300)
                {
                    piezas.Add(apoyo);
                }
            }

            piezas.Add(traseraInferior);

            if (armarioRinconero)
            {
                piezas.Add(vueltaTraseraInferior);
            }

            if (numeroPuertas % 2 != 0)
            {
                piezas.Add(traseraInferiorCorta);
            }

            piezas.Add(traseraSuperior);

            if (armarioRinconero)
            {
                piezas.Add(vueltaTraseraSuperior);
            }

            if (numeroPuertas % 2 != 0)
            {
                piezas.Add(traseraSuperiorCorta);
            }

            piezas.Add(puertasDM);

            if (armarioRinconero)
            {
                piezas.Add(puertasDMVuelta);
            }


            if (PuertaCorredera)
            {
                piezas.Add(tapetasInterioDM);
            }

            piezas.Add(tapajuntasDM);
            piezas.Add(cornisaDM);

            if (armarioRinconero)
            {
                piezas.Add(cornisaDMVuelta);
            }

            if (TapajuntasSuelo)
            {
                piezas.Add(rodapieDM);
                if (armarioRinconero)
                {
                    piezas.Add(rodapieDMVuelta);
                }
            }
            if (PuertaCorredera)
            {
                piezas.Add(perfilPuerta);
                piezas.Add(perfilEnU);
                if (armarioRinconero)
                {
                    piezas.Add(perfilEnUVuelta);
                }
                piezas.Add(guiasSuperiorInferior);
                if (armarioRinconero)
                {
                    piezas.Add(guiasSuperiorInferiorVuelta);
                }
            }
            if (BarraColgar || BarraLateral)
            {
                piezas.Add(barra);
                if (numeroPuertas % 2 != 0)
                {
                    piezas.Add(barraCorta);
                }
                if (armarioRinconero)
                {
                    piezas.Add(barraVuelta);
                }
            }

            armarioPiezas.armario = armario;
            armarioPiezas.piezas = piezas;
            armariosPiezasLista.Add(armarioPiezas);
        }
    }
}
