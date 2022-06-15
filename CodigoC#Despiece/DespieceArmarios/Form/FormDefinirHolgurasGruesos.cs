using Dapper;
using Dapper.Contrib.Extensions;
using DespieceArmarios.Clases;
using DespieceArmarios.ClasesBd;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespieceArmarios
{
    public partial class FormDefinirHolgurasGruesos : Form
    {
        private DefinirHolgurasGruesos datos = new DefinirHolgurasGruesos();
        private bool dat = false;


        public FormDefinirHolgurasGruesos()
        {
            InitializeComponent();

            Configuracion();
            RecuperarDatos();
            EngancharEventos();
        }

        private void RecuperarDatos()
        {
            using (var conn = Bd.GetConnection())
            {
                var resultado = conn.Query<DefinirHolgurasGruesos>("SELECT * FROM holguras_gruesos where id_holgurasGruesos = 1");
                if (resultado.Count() == 0)
                {
                    dat = false;
                }
                else
                {
                    dat = true;
                }
            }
            if (dat)
            {
                using (var conn = Bd.GetConnection())
                {
                    datos = conn.Query<DefinirHolgurasGruesos>("SELECT * FROM holguras_gruesos where id_holgurasGruesos = 1").First<DefinirHolgurasGruesos>();
                }
                PonerDatosEnForm();
            }

        }

        private void PonerDatosEnForm()
        {
            numeric_Holgura_techo.Value = datos.H_techo;
            numeric_Holgura_fondo.Value = datos.H_fondo;
            numeric_Holgura_pared_abierta.Value = datos.H_pared;
            numeric_Holgura_puertas_abatibles.Value = datos.H_puertas;
            numeric_Holgura_entre_cajones.Value = datos.H_cajones;
            numeric_Holgura_guia_corredera.Value = datos.H_guia;
            numeric_Holgura_baldas_costado.Value = datos.H_baldas;

            numeric_Montar_rodapie_base.Value = datos.M_rodapie;
            numeric_Montar_tapajuntas_costado.Value = datos.M_tapajuntas;
            numericUpDown_Montar_rodapie_guia.Value = datos.M_rodapie_guia;
            numericUpDown_Montar_jacena.Value = datos.M_jacena;

            numericUpDown_Descolgar_cornisa.Value = datos.Descolgar_cornisa;
            numeric_Grueso_trasera.Value = datos.G_traseras;
            numeric_Grueso_costados.Value = datos.G_costados;
            numeric_Grueso_puerta.Value = datos.G_puertas;
            numeric_Grueso_puerta_corredera.Value = datos.G_correderas;
            numeric_Grueso_guia_corredera.Value = datos.G_guia;
            numeric_Grueso_apoyo_barra_lateral.Value = datos.G_apoyo_barra;
            numericUpDown_Grueso_tapeta_remate.Value = datos.G_tapeta;
            numericUpDown_Grueso_tapajuntas.Value = datos.G_tapajuntas;
            numericUpDown__Grueso_cornisa.Value = datos.G_cornisa;
            numericUpDown_Grueso_rodapie.Value = datos.G_rodapie;

            numericUpDownMaxPuertas.Value = datos.max_puertas;
            numericUpDownMaxCorrederas.Value = datos.max_correderas;

        }

        private void EngancharEventos()
        {
            //  Botonses guardas y salir
            buttonSalir.Click += ButtonSalir_Click;
            buttonGuardarDatos.Click += ButtonGuardarDatos_Click;

            //  Menu de opciones
            holgurasGeneralesToolStripMenuItem1.Click += (o, a) => { apagarGroupBox(); holguraGenerales.Visible = true; holgurasGeneralesToolStripMenuItem1.ForeColor = SystemColors.ControlText; };
            interiorModuloToolStripMenuItem1.Click += (o, a) => { apagarGroupBox(); interiorModulo.Visible = true; interiorModuloToolStripMenuItem1.ForeColor = SystemColors.ControlText; };
            opcionesCorrederoToolStripMenuItem1.Click += (o, a) => { apagarGroupBox(); opcionesCorredero.Visible = true; opcionesCorrederoToolStripMenuItem1.ForeColor = SystemColors.ControlText; };
            rematesExterioresToolStripMenuItem1.Click += (o, a) => { apagarGroupBox(); rematesExteriores.Visible = true; rematesExterioresToolStripMenuItem1.ForeColor = SystemColors.ControlText; };


            /*****************************Casmbiar fotos cuando el foco esta en los numericUpDown***********************/
            //  Holguras Generales
            numeric_Holgura_techo.Enter += (o, a) => { imagen.Image = Properties.Resources.HOLGURA_TECHO; };
            numeric_Holgura_fondo.Enter += (o, a) => { imagen.Image = Properties.Resources.HOLGURA_FONDO; };
            numeric_Holgura_entre_cajones.Enter += (o, a) => { imagen.Image = Properties.Resources.HOLGURA_CAJON; };
            numeric_Holgura_baldas_costado.Enter += (o, a) => { imagen.Image = Properties.Resources.HOLGURA_BALDA; };
            numeric_Holgura_pared_abierta.Enter += (o, a) => { imagen.Image = Properties.Resources.HOLGURA_PARED; };
            numeric_Holgura_puertas_abatibles.Enter += (o, a) => { imagen.Image = Properties.Resources.HOLGURA_PUERTAS; };

            //  Remates Exteriores
            numeric_Montar_rodapie_base.Enter += (o, a) => { imagen.Image = Properties.Resources.MONTAR_RODAPIE; };
            numeric_Montar_tapajuntas_costado.Enter += (o, a) => { imagen.Image = Properties.Resources.MONTAR_TAPAJUNTAS; };
            numericUpDown_Montar_jacena.Enter += (o, a) => { imagen.Image = Properties.Resources.MONTAR_JACENA; };
            numeric_Grueso_puerta.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_PUERTAS; };
            numericUpDown_Grueso_rodapie.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_RODAPIE; };
            numericUpDown_Grueso_tapajuntas.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_TAPAJUNTAS; };
            numericUpDown__Grueso_cornisa.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_CORNISA; };
            numericUpDownMaxPuertas.Enter += (o, a) => { imagen.Image = Properties.Resources.MAXIMO_PUERTAS; };

            //  Opciones Corredero
            numeric_Holgura_guia_corredera.Enter += (o, a) => { imagen.Image = Properties.Resources.HOLGURA_GUIA; };
            numericUpDownMaxCorrederas.Enter += (o, a) => { imagen.Image = Properties.Resources.MAXIMO_CORREDERAS; };
            numeric_Grueso_guia_corredera.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_GUIA; };
            numeric_Grueso_puerta_corredera.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_CORREDERAS; };
            numericUpDown_Grueso_tapeta_remate.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_TAPETA; };
            numericUpDown_Descolgar_cornisa.Enter += (o, a) => { imagen.Image = Properties.Resources.DESCOLGAR_CORNISA; };
            numericUpDown_Montar_rodapie_guia.Enter += (o, a) => { imagen.Image = Properties.Resources.MONTAR_RODAPIE_GUIA; };

            //  interior modulo
            numeric_Grueso_apoyo_barra_lateral.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_APOYO_BARRA; };
            numeric_Grueso_costados.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_COSTADOS; };
            numeric_Grueso_trasera.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_TRASERAS; };
        }

        private void apagarGroupBox()
        {
            holguraGenerales.Visible = false;
            interiorModulo.Visible = false;
            opcionesCorredero.Visible = false;
            rematesExteriores.Visible = false;

            holgurasGeneralesToolStripMenuItem1.ForeColor = SystemColors.ControlDarkDark;
            interiorModuloToolStripMenuItem1.ForeColor = SystemColors.ControlDarkDark;
            opcionesCorrederoToolStripMenuItem1.ForeColor = SystemColors.ControlDarkDark;
            rematesExterioresToolStripMenuItem1.ForeColor = SystemColors.ControlDarkDark;

            imagen.Image = null;

        }

        private void ButtonGuardarDatos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de guardar los cambios?", "Confirmar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DefinirHolgurasGruesos parametros = new DefinirHolgurasGruesos();

                parametros.id_holgurasGruesos = 1;

                parametros.H_techo = numeric_Holgura_techo.Value;
                parametros.H_fondo = numeric_Holgura_fondo.Value;
                parametros.H_pared = numeric_Holgura_pared_abierta.Value;
                parametros.H_puertas = numeric_Holgura_puertas_abatibles.Value;
                parametros.H_cajones = numeric_Holgura_entre_cajones.Value;
                parametros.H_guia = numeric_Holgura_guia_corredera.Value;
                parametros.H_baldas = numeric_Holgura_baldas_costado.Value;

                parametros.M_rodapie = numeric_Montar_rodapie_base.Value;
                parametros.M_tapajuntas = numeric_Montar_tapajuntas_costado.Value;
                parametros.M_rodapie_guia = numericUpDown_Montar_rodapie_guia.Value;
                parametros.M_jacena = numericUpDown_Montar_jacena.Value;

                parametros.Descolgar_cornisa = numericUpDown_Descolgar_cornisa.Value;
                parametros.G_traseras = numeric_Grueso_trasera.Value;
                parametros.G_costados = numeric_Grueso_costados.Value;
                parametros.G_puertas = numeric_Grueso_puerta.Value;
                parametros.G_correderas = numeric_Grueso_puerta_corredera.Value;
                parametros.G_guia = numeric_Grueso_guia_corredera.Value;
                parametros.G_apoyo_barra = numeric_Grueso_apoyo_barra_lateral.Value;
                parametros.G_tapeta = numericUpDown_Grueso_tapeta_remate.Value;
                parametros.G_tapajuntas = numericUpDown_Grueso_tapajuntas.Value;
                parametros.G_cornisa = numericUpDown__Grueso_cornisa.Value;
                parametros.G_rodapie = numericUpDown_Grueso_rodapie.Value;

                parametros.max_puertas = numericUpDownMaxPuertas.Value;
                parametros.max_correderas = numericUpDownMaxCorrederas.Value;

                using (var conn = Bd.GetConnection())
                {
                    var resultado = conn.Query<DefinirHolgurasGruesos>("SELECT * FROM holguras_gruesos where id_holgurasGruesos = 1");
                    if (resultado.Count() == 0)
                    {
                        conn.Insert(parametros);
                       // MessageBox.Show("Datos guardados.");
                    }
                    else
                    {
                        conn.Delete(parametros);
                        conn.Insert(parametros);
                        //MessageBox.Show("Datos Modificados.");
                    }
                }
                this.Close();
            }

        }

        private void ButtonSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Configuracion()
        {
            ConfiguracionElementos.miForm(this);
            ConfiguracionElementos.miButtonInicio(buttonGuardarDatos);
            ConfiguracionElementos.miButtonInicio(buttonSalir);
        }
    }
}
