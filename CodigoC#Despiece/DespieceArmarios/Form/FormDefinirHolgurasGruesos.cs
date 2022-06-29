using Dapper;
using Dapper.Contrib.Extensions;
using DespieceArmarios.Clases;
using DespieceArmarios.ClasesBd;
using System;
using System.Drawing;
using System.Linq;
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
            numHolguraTecho.Value = datos.H_techo;
            numHolguraFondo.Value = datos.H_fondo;
            numHolguraParedAbierta.Value = datos.H_pared;
            numHolguraPuertasAbatibles.Value = datos.H_puertas;
            numHolguraEntreCajones.Value = datos.H_cajones;
            num_Holgura_guia_corredera.Value = datos.H_guia;
            numHolguraBaldasCostado.Value = datos.H_baldas;

            numMontarRodapieBase.Value = datos.M_rodapie;
            numMontarTapajuntasCostado.Value = datos.M_tapajuntas;
            num_Montar_rodapie_guia.Value = datos.M_rodapie_guia;
            numMontarJacena.Value = datos.M_jacena;

            num_Descolgar_cornisa.Value = datos.Descolgar_cornisa;
            numGruesoTrasera.Value = datos.G_traseras;
            numGruesoCostados.Value = datos.G_costados;
            numGruesoPuerta.Value = datos.G_puertas;
            num_Grueso_puerta_corredera.Value = datos.G_correderas;
            num_Grueso_guia_corredera.Value = datos.G_guia;
            numGruesoApoyoBarraLateral.Value = datos.G_apoyo_barra;
            num_Grueso_tapeta_remate.Value = datos.G_tapeta;
            numGruesoTapajuntas.Value = datos.G_tapajuntas;
            numGruesoCornisa.Value = datos.G_cornisa;
            numGruesoRodapie.Value = datos.G_rodapie;

            numMaxPuertas.Value = datos.max_puertas;
            numMaxCorrederas.Value = datos.max_correderas;

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
            numHolguraTecho.Enter += (o, a) => { imagen.Image = Properties.Resources.HOLGURA_TECHO; };
            numHolguraFondo.Enter += (o, a) => { imagen.Image = Properties.Resources.HOLGURA_FONDO; };
            numHolguraEntreCajones.Enter += (o, a) => { imagen.Image = Properties.Resources.HOLGURA_CAJON; };
            numHolguraBaldasCostado.Enter += (o, a) => { imagen.Image = Properties.Resources.HOLGURA_BALDA; };
            numHolguraParedAbierta.Enter += (o, a) => { imagen.Image = Properties.Resources.HOLGURA_PARED; };
            numHolguraPuertasAbatibles.Enter += (o, a) => { imagen.Image = Properties.Resources.HOLGURA_PUERTAS; };

            //  Remates Exteriores
            numMontarRodapieBase.Enter += (o, a) => { imagen.Image = Properties.Resources.MONTAR_RODAPIE; };
            numMontarTapajuntasCostado.Enter += (o, a) => { imagen.Image = Properties.Resources.MONTAR_TAPAJUNTAS; };
            numMontarJacena.Enter += (o, a) => { imagen.Image = Properties.Resources.MONTAR_JACENA; };
            numGruesoPuerta.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_PUERTAS; };
            numGruesoRodapie.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_RODAPIE; };
            numGruesoTapajuntas.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_TAPAJUNTAS; };
            numGruesoCornisa.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_CORNISA; };
            numMaxPuertas.Enter += (o, a) => { imagen.Image = Properties.Resources.MAXIMO_PUERTAS; };

            //  Opciones Corredero
            num_Holgura_guia_corredera.Enter += (o, a) => { imagen.Image = Properties.Resources.HOLGURA_GUIA; };
            numMaxCorrederas.Enter += (o, a) => { imagen.Image = Properties.Resources.MAXIMO_CORREDERAS; };
            num_Grueso_guia_corredera.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_GUIA; };
            num_Grueso_puerta_corredera.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_CORREDERAS; };
            num_Grueso_tapeta_remate.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_TAPETA; };
            num_Descolgar_cornisa.Enter += (o, a) => { imagen.Image = Properties.Resources.DESCOLGAR_CORNISA; };
            num_Montar_rodapie_guia.Enter += (o, a) => { imagen.Image = Properties.Resources.MONTAR_RODAPIE_GUIA; };

            //  interior modulo
            numGruesoApoyoBarraLateral.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_APOYO_BARRA; };
            numGruesoCostados.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_COSTADOS; };
            numGruesoTrasera.Enter += (o, a) => { imagen.Image = Properties.Resources.GRUESO_TRASERAS; };
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

                parametros.H_techo = numHolguraTecho.Value;
                parametros.H_fondo = numHolguraFondo.Value;
                parametros.H_pared = numHolguraParedAbierta.Value;
                parametros.H_puertas = numHolguraPuertasAbatibles.Value;
                parametros.H_cajones = numHolguraEntreCajones.Value;
                parametros.H_guia = num_Holgura_guia_corredera.Value;
                parametros.H_baldas = numHolguraBaldasCostado.Value;

                parametros.M_rodapie = numMontarRodapieBase.Value;
                parametros.M_tapajuntas = numMontarTapajuntasCostado.Value;
                parametros.M_rodapie_guia = num_Montar_rodapie_guia.Value;
                parametros.M_jacena = numMontarJacena.Value;

                parametros.Descolgar_cornisa = num_Descolgar_cornisa.Value;
                parametros.G_traseras = numGruesoTrasera.Value;
                parametros.G_costados = numGruesoCostados.Value;
                parametros.G_puertas = numGruesoPuerta.Value;
                parametros.G_correderas = num_Grueso_puerta_corredera.Value;
                parametros.G_guia = num_Grueso_guia_corredera.Value;
                parametros.G_apoyo_barra = numGruesoApoyoBarraLateral.Value;
                parametros.G_tapeta = num_Grueso_tapeta_remate.Value;
                parametros.G_tapajuntas = numGruesoTapajuntas.Value;
                parametros.G_cornisa = numGruesoCornisa.Value;
                parametros.G_rodapie = numGruesoRodapie.Value;

                parametros.max_puertas = numMaxPuertas.Value;
                parametros.max_correderas = numMaxCorrederas.Value;

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
