using DespieceArmarios.Clases;
using DespieceArmarios.ClasesApoyo;
using DespieceArmarios.ClasesApoyo.ClasesParticular;
using DespieceArmarios.ClasesBd;
using System;
using System.Collections.Generic;

namespace DespieceArmarios.LogicaNegocio
{
    public class CalculosArmarioParticular
    {
        /**********************   REVISAR VARIABLES   ***********************************/
        private int numeroPuertas = 0;
        private decimal anchoTotal = 0;
        private decimal anchoTotalDos = 0;

        private decimal anchoModuloIgual = 0;
        private decimal anchoModuloDiferente = 0;
        private decimal interiorArmarioAnchoTotalParaPuertas = 0;

        private bool primeraVueltaPuertas;
        //REPASAR TAMBIEN MEDIDA DE COSTADOS , HAY QUE RESTAR LA CORNI
        /**********************   REVISAR VARIABLES   ***********************************/
        private decimal medidasRestarSegunTrasera_altura;
        private decimal medidasRestarSegunTrasera_anchura;

        private int numeroTapajuntas = 2;
        private int numeroCornisa = 1;
        private int numeroRodapie = 1;
        private int restaTraseraAcanalada = 20;

        private List<Pieza> piezas = new List<Pieza>();
        List<InfoModulo> listaInfoModulos;
        private Armario armarioa = new Armario();
        private Guia guia = null;
        private DefinirHolgurasGruesos holguraGrueso = new DefinirHolgurasGruesos();
        private DatosFormArmariosParticular datosForm;
        private Armario armario = new Armario();
        private Armario vueltaArmario = new Armario();
        private string obra;
        private string cliente;
        private string tipoArmario;

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

        public void recibirDatos(string obra, string cliente, string tipoArmario, List<InfoModulo> listaInfoModulos, DatosFormArmariosParticular datosFormArmariosObra)
        {
            this.datosForm = datosFormArmariosObra;
            this.cliente = cliente;
            this.obra = obra;
            this.tipoArmario = tipoArmario;
            this.listaInfoModulos = listaInfoModulos;
            guia = CallBbdd.GetGuia();
            holguraGrueso = CallBbdd.GetHolgurasGruesos();

            sacarModulos();
        }

        private void sacarModulos()
        {

            SacarArmario();

            Costados();

            if (!datosForm.infoOpciones.esPuertaAbatible)
            {
                Costados_Centrales();
            }

            foreach (InfoModulo infoModulo in listaInfoModulos)
            {
                //    Bases();
                //    Baldas();
                //    Trasera_Inferior();
                //    Trasera_Superior();
                if (infoModulo.HayCajonera)
                {
                    SacarCajonera(infoModulo.Cajonera);

                    if (infoModulo.BarrasColgar > 0)
                    {
                        //Revisar el modulo completamente ya que no esta bien implementado para lista de modulos
                        SacarBarra();
                    }
                }
            }

            TapajuntasDM();
            if (!datosForm.infoOpciones.esPuertaAbatible)
            {
                TapetasInteriorDM();
            }
            CornisaDM();
            PuertasDM();

            if (datosForm.infoOpciones.tapajuntasSuelo)
            {
                RodapieDM();
            }

            if (!datosForm.infoOpciones.esPuertaAbatible)
            {
                SacarPerfilPuerta();
                SacarPerfilU();
                SacarGuiaSupInf();
            }
        }



        /**********************************************************************************************************
        *************************************  Metodos Armario General  *******************************************
        ***********************************************************************************************************/
        private void SacarArmario()
        {
            armario.escalera = "Particular";
            armario.piso = obra;
            armario.habitacion = cliente;
            armario.h_alto = (int)datosForm.infoHueco.Alto;
            armario.h_ancho = (int)datosForm.infoHueco.Ancho;
            armario.h_fondo = (int)datosForm.infoHueco.Fondo;
            armario.modulos = datosForm.infoOpciones.numeroModulos;
            armario.altura_patas = (int)GetAlturaPatas();
            armario.alto_armario = GetAlturaArmario();
            armario.ancho_armario = GetAnchoArmario(tipoArmario, datosForm);
            armario.fondo_armario = GetFondoArmario();
            armario.modelo_armario = tipoArmario;
            armario.puertas = GetPuertas();//HAY que hacerlo
        }

        private int GetPuertas()
        {
            bool modulosIguales = GetModulosIguales();
            int devolverNumeroPuertas = 0;
            decimal restasMontarTapajuntas = 0;
            decimal[] puertas = new decimal[listaInfoModulos.Count];
            decimal medidahuecoPuertas = 0;

            if (modulosIguales)
            {
                medidahuecoPuertas = armario.ancho_armario - (holguraGrueso.M_tapajuntas * 2);
                if ((medidahuecoPuertas / armario.modulos)  < holguraGrueso.max_puertas + holguraGrueso.H_puertas)
                {
                    puertas[0] = (medidahuecoPuertas / armario.modulos ) - holguraGrueso.H_puertas;
                    devolverNumeroPuertas = armario.modulos;                    
                }
                else if ((medidahuecoPuertas / armario.modulos) / 2 < (holguraGrueso.max_puertas + holguraGrueso.H_puertas ))
                {
                    puertas[0] = (medidahuecoPuertas / armario.modulos / 2) - holguraGrueso.H_puertas;
                    devolverNumeroPuertas = armario.modulos * 2;
                }

            }
            else
            {

                for (int i = 0; i < listaInfoModulos.Count; i++)
                {
                    InfoModulo mod = listaInfoModulos[i];
                    if (datosForm.infoOpciones.esPuertaAbatible)
                    {
                        if (i == 0 || i == listaInfoModulos.Count - 1)
                        {
                            restasMontarTapajuntas = holguraGrueso.M_tapajuntas;
                        }
                        if (mod.Ancho < holguraGrueso.max_puertas + holguraGrueso.H_puertas)
                        {
                            restasMontarTapajuntas = 0;
                            devolverNumeroPuertas++;
                        }
                        else if (mod.Ancho / 2 < holguraGrueso.max_puertas + holguraGrueso.H_puertas)
                        {
                            Console.WriteLine("Ancho puertas abatibles= " + mod.Ancho / 2 + "Hay dos puertas");

                            restasMontarTapajuntas = 0;
                            devolverNumeroPuertas += 2;
                        }
                    }
                    else
                    {
                        if (mod.Ancho < holguraGrueso.max_correderas)
                        {

                            devolverNumeroPuertas++;
                        }
                        else if (mod.Ancho / 2 < holguraGrueso.max_correderas)
                        {
                            Console.WriteLine("Ancho puertas correderas = " + mod.Ancho / 2 + "Hay dos puertas");

                            devolverNumeroPuertas += 2;
                        }

                    }
                }
            }

            return devolverNumeroPuertas;
        }

        private bool GetModulosIguales()
        {
            bool devolver = true;
            decimal[] modulosAncho = new decimal[listaInfoModulos.Count];
            for (int i = 0; i < listaInfoModulos.Count; i++)
            {
                InfoModulo mod = listaInfoModulos[i];
                modulosAncho[i] = mod.Ancho;
            }
            decimal unico = 0;
            decimal nuevo = 0;
            for (int i = 0; i < modulosAncho.Length; i++)
            {
                nuevo = modulosAncho[i];
                if (i == 0)
                {
                    unico = nuevo;
                }
                else
                {
                    if (unico != nuevo)
                    {
                        devolver = false;
                    }
                }
            }
            return devolver;
        }

        private decimal GetFondoArmario()
        {
            decimal devolveFondo = 0;
            if (datosForm.infoOpciones.esTraseraAtornillada)
            {
                devolveFondo = (datosForm.infoHueco.Fondo - holguraGrueso.H_fondo - holguraGrueso.G_traseras);
            }
            else
            {
                devolveFondo = (datosForm.infoHueco.Fondo - holguraGrueso.H_fondo);
            }
            return devolveFondo;
        }

        private decimal GetAlturaArmario()
        {

            decimal devolverAltura = 0;
            decimal restarAltoAltillo = 0;
            if (datosForm.infoOpciones.hayAltillo)
            {
                restarAltoAltillo = datosForm.infoAltillo.altura;
            }
            if (datosForm.infoOpciones.hayJacena)
            {
                devolverAltura = datosForm.infoHueco.Alto - restarAltoAltillo - armario.altura_patas - holguraGrueso.H_techo;
            }
            else
            {
                if (datosForm.infoOpciones.esPuertaAbatible)
                {
                    //La cornisa monta en el costasdo lo mismo que el tapajuntas.
                    devolverAltura = datosForm.infoHueco.Alto - restarAltoAltillo - armario.altura_patas - (datosForm.infoRemates.AnchoCornisa - holguraGrueso.M_tapajuntas);
                }
                else
                {
                    devolverAltura = datosForm.infoHueco.Alto - restarAltoAltillo - armario.altura_patas - (datosForm.infoRemates.AnchoCornisa - holguraGrueso.G_costados - holguraGrueso.G_guia);
                }
            }

            return devolverAltura;
        }

        private decimal GetAlturaPatas()
        {
            decimal devolverAltura = 0;
            if (datosForm.infoOpciones.esPuertaAbatible)
            {
                devolverAltura = datosForm.infoRemates.AnchoRodapie - holguraGrueso.M_rodapie;
            }
            else
            {
                devolverAltura = datosForm.infoRemates.AnchoRodapie - holguraGrueso.G_costados - 3;
                //Los tres mm son lo que monta el rodapie en la guia por eso se las restamos al rodapie
                //PASAR A VARIBLE QUE SE PUEDA DEFINIR EN FORM HOLGURAS GRUESO
            }
            return devolverAltura;
        }



        /**********************************************************************************************************
        ***************************************  Medida Ancho Total  **********************************************
        ***********************************************************************************************************/
        public decimal GetAnchoArmario(string tipoArmario, DatosFormArmariosParticular datosFormArmariosParticular)
        {
            decimal anchoTotal = 0;
            decimal anchoTotalDos = 0;
            /*Es los siguientes "if" se determina el largo de la base o 
             * lo que es lo mismo el ancho del mueble menos los gruesos de los costados.*/
            if (tipoArmario == "Omega")
            {
                if (!datosFormArmariosParticular.infoOpciones.esArmarioRecto)
                {
                    anchoTotal = datosFormArmariosParticular.infoHueco.Ancho - holguraGrueso.H_pared - holguraGrueso.H_fondo;
                    anchoTotalDos = datosForm.infoArmarioRinconero.segundoAncho - holguraGrueso.H_pared - holguraGrueso.H_fondo;
                }
                else
                {
                    if (!datosFormArmariosParticular.infoOpciones.esPuertaAbatible)
                    {
                        anchoTotal = (datosFormArmariosParticular.infoHueco.Ancho - (holguraGrueso.H_pared * 2));
                    }
                    else
                    {
                        anchoTotal = (datosFormArmariosParticular.infoHueco.Ancho - (holguraGrueso.H_pared * 2));
                    }
                }
            }
            if (tipoArmario == "L")
            {
                if (!datosFormArmariosParticular.infoOpciones.esArmarioRecto)
                {
                    if (datosFormArmariosParticular.infoArmarioRinconero.paredDerechaAbierta)
                    {
                        anchoTotal = datosFormArmariosParticular.infoHueco.Ancho - (datosFormArmariosParticular.infoRemates.AnchoTapajuntas - holguraGrueso.G_tapeta - holguraGrueso.G_costados) - holguraGrueso.H_fondo;
                        anchoTotalDos = datosForm.infoArmarioRinconero.segundoAncho - holguraGrueso.H_pared - holguraGrueso.H_fondo;
                    }
                    else
                    {
                        anchoTotal = datosFormArmariosParticular.infoHueco.Ancho - holguraGrueso.H_pared - holguraGrueso.H_fondo;
                        anchoTotalDos = datosForm.infoArmarioRinconero.segundoAncho - (datosForm.infoRemates.AnchoTapajuntas - holguraGrueso.G_tapeta - holguraGrueso.G_costados) - holguraGrueso.H_fondo;
                    }

                }
                else
                {
                    if (!datosFormArmariosParticular.infoOpciones.esPuertaAbatible)
                    {
                        anchoTotal = (datosFormArmariosParticular.infoHueco.Ancho - ((datosFormArmariosParticular.infoRemates.AnchoTapajuntas - holguraGrueso.G_tapeta - holguraGrueso.G_costados) + holguraGrueso.H_pared));
                    }
                    else
                    {
                        anchoTotal = (datosFormArmariosParticular.infoHueco.Ancho - ((datosFormArmariosParticular.infoRemates.AnchoTapajuntas - (holguraGrueso.G_costados / 2)) + holguraGrueso.H_pared));
                    }

                }
            }
            if (tipoArmario == "U")
            {
                if (!datosFormArmariosParticular.infoOpciones.esPuertaAbatible)
                {
                    anchoTotal = datosFormArmariosParticular.infoHueco.Ancho - (datosFormArmariosParticular.infoRemates.AnchoTapajuntas - holguraGrueso.G_tapeta - holguraGrueso.G_costados) - holguraGrueso.H_fondo;
                    anchoTotalDos = datosForm.infoArmarioRinconero.segundoAncho - (datosForm.infoRemates.AnchoTapajuntas - holguraGrueso.G_tapeta - holguraGrueso.G_costados) - holguraGrueso.H_fondo;
                }
                else
                {
                    if (!datosFormArmariosParticular.infoOpciones.esPuertaAbatible)
                    {
                        anchoTotal = (datosFormArmariosParticular.infoHueco.Ancho - (2 * (datosFormArmariosParticular.infoRemates.AnchoTapajuntas - holguraGrueso.G_tapeta - holguraGrueso.G_costados)));
                    }
                    else
                    {
                        anchoTotal = (datosFormArmariosParticular.infoHueco.Ancho - (2 * (datosFormArmariosParticular.infoRemates.AnchoTapajuntas - (holguraGrueso.G_costados / 2))));
                    }
                }
            }

            /*En los siguiente "if" se recogen valores usados para determinar el largo de la trasera*/

            if (datosFormArmariosParticular.infoOpciones.esTraseraAtornillada)
            {
                medidasRestarSegunTrasera_altura = 0;
                medidasRestarSegunTrasera_anchura = 0;
            }
            else
            {
                medidasRestarSegunTrasera_altura = 15;
                medidasRestarSegunTrasera_anchura = 20;
            }

            return anchoTotal;
        }

        /**********************************************************************************************************
        *******************************************  METODOS PIEZAS  **********************************************
        ***********************************************************************************************************/

        private void Costados()
        {
            costados.nombre = "Costados";
            costados.tag = "Costados";
            if (!datosForm.infoOpciones.esPuertaAbatible)
            {
                costados.cantidad = 2;
            }
            else
            {
                costados.cantidad = datosForm.infoOpciones.numeroModulos * 2;
            }
            costados.largo = armario.alto_armario;
            costados.ancho = armario.fondo_armario;
            costados.grueso = holguraGrueso.G_costados;
        }
        private void Costados_Centrales()
        {
            costadosCentrales.nombre = "Costados Centrales";
            costadosCentrales.tag = "Costados";
            costadosCentrales.cantidad = (datosForm.infoOpciones.numeroModulos * 2) - 2;
            costadosCentrales.largo = armario.alto_armario;
            costadosCentrales.ancho = (int)(armario.fondo_armario - guia.ancho_guia - holguraGrueso.H_guia);
            costadosCentrales.grueso = holguraGrueso.G_costados;
        }
        /* private void Bases()
         {
             bases.nombre = "Bases";
             bases.tag = "Bases";
             if (numeroPuertas % 2 == 0)
             {
                 bases.cantidad = datosForm.infoOpciones.numeroModulos * 2;
             }
             else
             {
                 bases.cantidad = (datosForm.infoOpciones.numeroModulos * 2) - 2;

                 basesCortas.nombre = "Bases Cortas";
                 basesCortas.tag = "Bases";
                 basesCortas.cantidad = 2;
                 basesCortas.largo = anchoModuloDiferente - (holguraGrueso.G_costados * 2);
                 basesCortas.ancho = armario.fondo_armario;
                 basesCortas.grueso = holguraGrueso.G_costados;
             }
             bases.largo = anchoModuloIgual - (holguraGrueso.G_costados * 2);
             bases.ancho = armario.fondo_armario;
             bases.grueso = holguraGrueso.G_costados;

             if (!datosForm.infoOpciones.esArmarioRecto)
             {
                 bases.largo = anchoTotal - holguraGrueso.G_costados;

                 vueltaBases.nombre = "Bases Vuelta";
                 vueltaBases.nombre = "Bases";
                 vueltaBases.cantidad = bases.cantidad;
                 vueltaBases.largo = vueltaArmario.ancho_armario - armario.fondo_armario - holguraGrueso.G_costados;
                 vueltaBases.ancho = vueltaArmario.fondo_armario;
                 vueltaBases.grueso = holguraGrueso.G_costados;

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
                baldasCortas.largo = anchoModuloDiferente - (holguraGrueso.G_costados * 2);

                if (TraseraAcanalada)
                {
                    if (PuertaCorredera)
                    {
                        baldasCortas.ancho = (armario.fondo_armario - guia.ancho_guia - holguraGrueso.H_guia - restaTraseraAcanalada - 2);
                    }
                    else if (datosForm.infoOpciones.esPuertaAbatible)
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
                    else if (datosForm.infoOpciones.esPuertaAbatible)
                    {
                        baldasCortas.ancho = (armario.fondo_armario - holguraGrueso.H_baldas);
                    }
                }

                baldasCortas.grueso = holguraGrueso.G_costados;

            }

            baldas.largo = anchoModuloIgual - (holguraGrueso.G_costados * 2);

            if (TraseraAcanalada)
            {
                if (PuertaCorredera)
                {
                    baldas.ancho = (armario.fondo_armario - guia.ancho_guia - holguraGrueso.H_guia - restaTraseraAcanalada - 2);
                }
                else if (datosForm.infoOpciones.esPuertaAbatible)
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
                else if (datosForm.infoOpciones.esPuertaAbatible)
                {
                    baldas.ancho = (armario.fondo_armario - holguraGrueso.H_baldas);
                }
            }

            baldas.grueso = holguraGrueso.G_costados;

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
                apoyo.grueso = holguraGrueso.G_costados;
            }

            if (!datosForm.infoOpciones.esArmarioRecto)
            {
                baldas.largo = anchoTotal - holguraGrueso.G_costados - restaTraseraAcanalada;

                vueltaBaldas.nombre = "Baldas Vuelta";
                vueltaBaldas.tag = "Baldas";
                vueltaBaldas.cantidad = baldas.cantidad;
                vueltaBaldas.largo = anchoTotalDos - holguraGrueso.G_costados - baldas.ancho - restaTraseraAcanalada; if (TraseraAcanalada)
                {
                    if (PuertaCorredera)
                    {
                        vueltaBaldas.ancho = (vueltaArmario.fondo_armario - guia.ancho_guia - holguraGrueso.H_guia - restaTraseraAcanalada - 2);
                    }
                    else if (datosForm.infoOpciones.esPuertaAbatible)
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
                    else if (datosForm.infoOpciones.esPuertaAbatible)
                    {
                        vueltaBaldas.ancho = (vueltaArmario.fondo_armario - holguraGrueso.H_baldas);
                    }
                }
                vueltaBaldas.grueso = holguraGrueso.G_costados;
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

            if (!datosForm.infoOpciones.esArmarioRecto)
            {
                traseraInferior.ancho = anchoTotal - (medidasRestarSegunTrasera_anchura / 2) - restaTraseraAcanalada;

                vueltaTraseraInferior.nombre = "Trasera Inf Vuelta";
                vueltaTraseraInferior.tag = "Traseras";
                vueltaTraseraInferior.cantidad = 1;
                vueltaTraseraInferior.largo = traseraInferior.largo;
                vueltaTraseraInferior.ancho = anchoTotalDos - (medidasRestarSegunTrasera_anchura / 2) - restaTraseraAcanalada;
                vueltaTraseraInferior.grueso = holguraGrueso.G_costados;
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

            if (!datosForm.infoOpciones.esArmarioRecto)
            {
                traseraSuperior.ancho = anchoTotal - (medidasRestarSegunTrasera_anchura / 2) - restaTraseraAcanalada;

                vueltaTraseraSuperior.nombre = "Trasera Sup Vuelta";
                vueltaTraseraSuperior.tag = "Traseras";
                vueltaTraseraSuperior.cantidad = 1;
                vueltaTraseraSuperior.largo = traseraSuperior.largo;
                vueltaTraseraSuperior.ancho = anchoTotalDos - (medidasRestarSegunTrasera_anchura / 2) - restaTraseraAcanalada;
                vueltaTraseraSuperior.grueso = holguraGrueso.G_costados;
            }
        }*/

        /**************  Piezas DM para barnizar  **************** PUERTA ABATIBLE revisar si esta terminado */
        private void TapajuntasDM()
        {
            tapajuntasDM.nombre = "DM Tapajuntas";
            tapajuntasDM.tag = "DM";
            tapajuntasDM.cantidad = numeroTapajuntas;
            if (datosForm.infoOpciones.hayJacena)
            {
                if (datosForm.infoOpciones.tapajuntasSuelo)
                {
                    tapajuntasDM.largo = (int)(datosForm.infoHueco.Alto + holguraGrueso.M_jacena);
                }
                else
                {
                    tapajuntasDM.largo = (int)(datosForm.infoHueco.Alto - datosForm.infoRemates.AnchoRodapie + holguraGrueso.M_jacena);
                }
            }
            else
            {
                if (datosForm.infoOpciones.tapajuntasSuelo)
                {
                    tapajuntasDM.largo = datosForm.infoHueco.Alto;
                }
                else
                {
                    tapajuntasDM.largo = datosForm.infoHueco.Alto - datosForm.infoRemates.AnchoRodapie;
                }
            }
            tapajuntasDM.ancho = datosForm.infoRemates.AnchoTapajuntas;
            tapajuntasDM.grueso = (int)(holguraGrueso.G_tapajuntas);
        }
        private void CornisaDM()
        {
            cornisaDM.nombre = "DM Cornisa";
            cornisaDM.tag = "DM";
            cornisaDM.cantidad = numeroCornisa;

            if (datosForm.infoOpciones.esPuertaAbatible)
            {
                cornisaDM.largo = armario.ancho_armario - holguraGrueso.G_costados;
            }
            else
            {
                cornisaDM.largo = armario.ancho_armario - (holguraGrueso.G_costados * 2) - (tapetasInterioDM.grueso * 2) + 1;
            }

            if (datosForm.infoOpciones.hayJacena)
            {
                if (datosForm.infoOpciones.esPuertaAbatible)
                {
                    cornisaDM.ancho = ((holguraGrueso.G_costados / 2) + holguraGrueso.H_techo + holguraGrueso.M_jacena);
                }
                else
                {
                    cornisaDM.ancho = (holguraGrueso.G_costados + holguraGrueso.H_techo + holguraGrueso.G_guia + holguraGrueso.Descolgar_cornisa + holguraGrueso.M_jacena);
                }
            }
            else
            {
                if (datosForm.infoOpciones.esPuertaAbatible)
                {
                    cornisaDM.ancho = ((holguraGrueso.G_costados / 2) + holguraGrueso.H_techo);
                }
                else
                {
                    cornisaDM.ancho = (holguraGrueso.G_costados + holguraGrueso.H_techo + holguraGrueso.G_guia + holguraGrueso.Descolgar_cornisa);
                }
            }
            cornisaDM.grueso = holguraGrueso.G_cornisa;

            if (!datosForm.infoOpciones.esArmarioRecto)
            {
                if (datosForm.infoOpciones.esPuertaAbatible)
                {
                    cornisaDM.largo = armario.ancho_armario - (holguraGrueso.G_costados / 2) - vueltaArmario.fondo_armario;
                    cornisaDMVuelta.largo = vueltaArmario.ancho_armario - (holguraGrueso.G_costados / 2) - armario.fondo_armario;
                }
                else
                {
                    cornisaDM.largo = armario.ancho_armario - holguraGrueso.G_costados - tapetasInterioDM.grueso - vueltaArmario.fondo_armario + 1;
                    cornisaDMVuelta.largo = vueltaArmario.ancho_armario - holguraGrueso.G_costados - tapetasInterioDM.grueso - armario.fondo_armario + 1;
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
            if (!datosForm.infoOpciones.esPuertaAbatible)
            {
                rodapieDM.largo = armario.ancho_armario - (holguraGrueso.G_costados * 2) - (tapetasInterioDM.grueso * 2) + 2;
            }
            else if (datosForm.infoOpciones.esPuertaAbatible)
            {
                rodapieDM.largo = armario.ancho_armario - holguraGrueso.G_costados;
            }
            rodapieDM.ancho = datosForm.infoRemates.AnchoRodapie;
            rodapieDM.grueso = holguraGrueso.G_rodapie;

            if (!datosForm.infoOpciones.esArmarioRecto)
            {
                if (datosForm.infoOpciones.esPuertaAbatible)
                {
                    rodapieDM.largo = armario.ancho_armario - (holguraGrueso.G_costados / 2) - vueltaArmario.fondo_armario;
                    rodapieDMVuelta.largo = vueltaArmario.ancho_armario - (holguraGrueso.G_costados / 2) - armario.fondo_armario;
                }
                else
                {
                    rodapieDM.largo = armario.ancho_armario - holguraGrueso.G_costados - tapetasInterioDM.grueso - vueltaArmario.fondo_armario + 1;
                    rodapieDMVuelta.largo = vueltaArmario.ancho_armario - holguraGrueso.G_costados - tapetasInterioDM.grueso - armario.fondo_armario + 1;
                }

                rodapieDMVuelta.nombre = "DM Rodapie Vuelta";
                rodapieDMVuelta.tag = "DM";
                rodapieDMVuelta.cantidad = numeroRodapie;
                rodapieDMVuelta.ancho = datosForm.infoRemates.AnchoRodapie;
                rodapieDMVuelta.cantidad = holguraGrueso.G_rodapie;

            }
        }
        private void TapetasInteriorDM()
        {
            tapetasInterioDM.nombre = "DM Tapetas";
            tapetasInterioDM.tag = "DM";
            tapetasInterioDM.cantidad = numeroTapajuntas;
            tapetasInterioDM.largo = armario.alto_armario - (holguraGrueso.G_costados * 2);
            tapetasInterioDM.ancho = (int)(guia.ancho_guia + holguraGrueso.H_guia);
            tapetasInterioDM.grueso = (int)holguraGrueso.G_tapeta;
        }
        private void PuertasDM()
        {
            puertasDM.nombre = "DM Puertas";
            puertasDM.tag = "DM";
            puertasDM.cantidad = numeroPuertas;
            if (datosForm.infoOpciones.esPuertaAbatible)
            {
                puertasDM.largo = (armario.alto_armario - holguraGrueso.G_costados - holguraGrueso.H_puertas);
                puertasDM.ancho = SacarAnchoPuertaAbatible();
                puertasDM.grueso = holguraGrueso.G_puertas;
                primeraVueltaPuertas = false;
            }
            else
            {
                puertasDM.largo = armario.alto_armario - (holguraGrueso.G_costados * 2) - guia.milimetros_resta_altura_puerta;
                puertasDM.ancho = SacarAnchoPuertaCorrederas();
                puertasDM.grueso = holguraGrueso.G_correderas;
                primeraVueltaPuertas = false;
            }

            if (!datosForm.infoOpciones.esArmarioRecto)
            {
                puertasDMVuelta.nombre = "DM Puertas vuelta";
                puertasDMVuelta.tag = "DM";
                puertasDMVuelta.cantidad = numeroPuertas;
                puertasDMVuelta.largo = puertasDM.largo;
                if (datosForm.infoOpciones.esPuertaAbatible)
                {
                    puertasDMVuelta.ancho = SacarAnchoPuertaAbatible();
                    puertasDMVuelta.grueso = holguraGrueso.G_puertas;
                }
                else
                {
                    puertasDMVuelta.ancho = SacarAnchoPuertaCorrederas();
                    puertasDMVuelta.grueso = holguraGrueso.G_correderas;
                }
            }
        }

        private int SacarAnchoPuertaAbatible()
        {
            int anchoPuerta = 0;
            if (!datosForm.infoOpciones.esArmarioRecto)
            {
                if (primeraVueltaPuertas)
                {
                    anchoPuerta = (int)(((armario.ancho_armario - (holguraGrueso.G_costados / 2) - vueltaArmario.fondo_armario) / numeroPuertas) - holguraGrueso.H_puertas);
                }
                else
                {
                    anchoPuerta = (int)(((vueltaArmario.ancho_armario - (holguraGrueso.G_costados / 2) - armario.fondo_armario) / numeroPuertas) - holguraGrueso.H_puertas);
                }
            }
            else
            {
                anchoPuerta = (int)(((armario.ancho_armario - holguraGrueso.G_costados) / numeroPuertas) - holguraGrueso.H_puertas);
            }
            return anchoPuerta;
        }

        private int SacarAnchoPuertaCorrederas()
        {
            string cadena = null;
            if (!datosForm.infoOpciones.esArmarioRecto)
            {
                if (primeraVueltaPuertas)
                {
                    interiorArmarioAnchoTotalParaPuertas = armario.ancho_armario - holguraGrueso.G_costados - tapetasInterioDM.grueso - vueltaArmario.fondo_armario + (guia.ancho_guia / 2);
                }
                else
                {
                    interiorArmarioAnchoTotalParaPuertas = vueltaArmario.ancho_armario - holguraGrueso.G_costados - tapetasInterioDM.grueso - armario.fondo_armario + (guia.ancho_guia / 2);
                }
            }
            else
            {
                interiorArmarioAnchoTotalParaPuertas = armario.ancho_armario - (holguraGrueso.G_costados * 2) - (tapetasInterioDM.grueso * 2);
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
            if (!datosForm.infoOpciones.esArmarioRecto)
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
            if (!datosForm.infoOpciones.esArmarioRecto)
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
            guiasSuperiorInferior.largo = armario.ancho_armario - (holguraGrueso.G_costados * 2) - (tapetasInterioDM.grueso * 2);
            if (!datosForm.infoOpciones.esArmarioRecto)
            {
                guiasSuperiorInferior.largo = armario.ancho_armario - holguraGrueso.G_costados - tapetasInterioDM.grueso - vueltaArmario.fondo_armario + (guia.ancho_guia / 2);

                guiasSuperiorInferiorVuelta.nombre = "Guia Sup/Inf Vuelta";
                guiasSuperiorInferiorVuelta.cantidad = 2;
                guiasSuperiorInferiorVuelta.largo = vueltaArmario.ancho_armario - holguraGrueso.G_costados - tapetasInterioDM.grueso - armario.fondo_armario + (guia.ancho_guia / 2);
            }
        }
        private void SacarBarra()
        {
            barra.nombre = "Barra";
            if (numeroPuertas % 2 == 0)
            {
                barra.cantidad = datosForm.infoOpciones.numeroModulos;
                barra.nombre += " lateral";
                barra.largo = (int)(altillos.largo - holguraGrueso.G_apoyo_barra * 2);

            }
            else
            {
                barra.cantidad = datosForm.infoOpciones.numeroModulos - 1;

                barraCorta.nombre = "Barra Corta";
                barraCorta.cantidad = 1;
                barra.largo = (int)(altillos.largo - holguraGrueso.G_apoyo_barra * 2);
                barraCorta.largo = (int)(altillosCortos.largo - holguraGrueso.G_apoyo_barra * 2);

            }
            if (!datosForm.infoOpciones.esArmarioRecto)
            {
                barra.largo = armario.ancho_armario - holguraGrueso.G_costados - tapetasInterioDM.grueso - (vueltaArmario.fondo_armario / 2);

                barraVuelta.nombre = "Barra Vuelta";
                barraVuelta.cantidad = 1;
                barraVuelta.largo = vueltaArmario.ancho_armario - holguraGrueso.G_costados - tapetasInterioDM.grueso - (armario.fondo_armario / 2);
            }
        }


        private void SacarCajonera(Cajonera cajonera)
        {
            // Hacer piezas cajonera
        }

    }
}
