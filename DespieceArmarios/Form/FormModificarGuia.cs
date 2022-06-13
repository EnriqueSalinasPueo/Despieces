using Dapper;
using Dapper.Contrib.Extensions;
using DespieceArmarios.Clases;
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
    public partial class FormModificarGuia : Form
    {
        public FormModificarGuia()
        {
            InitializeComponent();


            Configuracion();
            RecuperarDatos();
            EngancharEventos();
        }

        private void EngancharEventos()
        {
            buttonSalir.Click += ButtonSalir_Click;
            buttonGuardar.Click += ButtonGuardar_Click;

            // Los evventos para las mostrar las fotos de las explicaciones de las cajas
            numericAltoGuia.Enter += (o, a) => { pictureBoxImagen.Image = Properties.Resources.GuiaSuperiorAlto; };
            numericAnchoGuia.Enter += (o, a) => { pictureBoxImagen.Image = Properties.Resources.GuiaSuperiorAncho; };
            numericUpDownDescontarAlto.Enter += (o, a) => { pictureBoxImagen.Image = Properties.Resources.MedidaRestarPuerta; };
            numericUpDownMilimetrosPerfil.Enter += (o, a) => { pictureBoxImagen.Image = Properties.Resources.tirador; };
            numericAnchoGuia.Leave += (o, a) => { pictureBoxImagen.Image = null; };
            numericAltoGuia.Leave += (o, a) => { pictureBoxImagen.Image = null; };
            numericUpDownDescontarAlto.Leave += (o, a) => { pictureBoxImagen.Image = null; };
            numericUpDownMilimetrosPerfil.Leave += (o, a) => { pictureBoxImagen.Image = null; };

            numericDescontar2Puertas.Enter += NumericDescontarPuertas_Enter;
            numericDescontar3Puertas.Enter += NumericDescontarPuertas_Enter;
            numericDescontar2Puertas.Leave += (o, a) => { pictureBoxImagen.Image = null; };
            numericDescontar2Puertas.Leave += (o, a) => { pictureBoxImagen.Image = null; };


            //labelAnchoGuia.MouseHover += (o, a) => { pictureBoxImagen.Image = Properties.Resources.GuiaSuperiorAncho; };
            //labelAltoGuia.MouseHover += (o, a) => { pictureBoxImagen.Image = Properties.Resources.GuiaSuperiorAlto; };
        }


        private void NumericDescontarPuertas_Enter(object sender, EventArgs e)
        {
            if (ADescontarPartidoPuertas.Checked)
            {
                pictureBoxImagen.Image = Properties.Resources.formulaUno;
            }
            else if (APartidoPuertasDescontar.Checked)
            {
                pictureBoxImagen.Image = Properties.Resources.formulaDos;
            }

            numericDescontar2Puertas.Leave += (o, a) => { pictureBoxImagen.Image = null; };
            numericDescontar2Puertas.Leave += (o, a) => { pictureBoxImagen.Image = null; };
        }

        private void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de guardar los cambios?", "Confirmar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Guia guia = new Guia();
                string dosPuertas = "";
                string tresPuertas = "";
                string cuatroPuertas = "";
                string cincoPuertas = "";
                string seisPuertas = "";
                string sietePuertas = "";
                string ochoPuertas = "";
                string formula = "";

                guia.marca = textBoxMarca.Text;
                guia.modelo = textBoxModelo.Text;
                guia.milimetros_resta_altura_puerta = (int)numericUpDownDescontarAlto.Value;
                guia.milimetros_resta_ancho_perfil_u_puerta = (int)(numericUpDownMilimetrosPerfil.Value * 2);
                guia.ancho_guia = (int)numericAnchoGuia.Value;
                guia.alto_guia = (int)numericAltoGuia.Value;

                dosPuertas = numericDescontar2Puertas.Value.ToString();
                tresPuertas = numericDescontar3Puertas.Value.ToString();

                if (ADescontarPartidoPuertas.Checked)
                {
                    formula = ADescontarPartidoPuertas.Tag.ToString();
                    guia.tipo_guia = formula;


                    cuatroPuertas = (numericDescontar2Puertas.Value + 10).ToString();
                    cincoPuertas = (numericDescontar3Puertas.Value + 10).ToString();
                    seisPuertas = (numericDescontar2Puertas.Value + 20).ToString();
                    sietePuertas = (numericDescontar3Puertas.Value + 20).ToString();
                    ochoPuertas = (numericDescontar2Puertas.Value + 30).ToString();
                }

                if (APartidoPuertasDescontar.Checked)
                {
                    formula = APartidoPuertasDescontar.Tag.ToString();
                    guia.tipo_guia = formula;


                    cuatroPuertas = numericDescontar2Puertas.Value.ToString();
                    cincoPuertas = numericDescontar3Puertas.Value.ToString();
                    seisPuertas = numericDescontar2Puertas.Value.ToString();
                    sietePuertas = numericDescontar3Puertas.Value.ToString();
                    ochoPuertas = numericDescontar2Puertas.Value.ToString();
                }

                string formulaModificada = "";
                formulaModificada = formula.Replace("descontar", dosPuertas);
                guia.formula_ancho_dos_puertas = formulaModificada.Replace("puertas", "2");
                formulaModificada = formula.Replace("descontar", tresPuertas);
                guia.formula_ancho_tres_puertas = formulaModificada.Replace("puertas", "3");
                formulaModificada = formula.Replace("descontar", cuatroPuertas);
                guia.formula_ancho_cuatro_puertas = formulaModificada.Replace("puertas", "4");
                formulaModificada = formula.Replace("descontar", cincoPuertas);
                guia.formula_ancho_cinco_puertas = formulaModificada.Replace("puertas", "5");
                formulaModificada = formula.Replace("descontar", seisPuertas);
                guia.formula_ancho_seis_puertas = formulaModificada.Replace("puertas", "6");
                formulaModificada = formula.Replace("descontar", sietePuertas);
                guia.formula_ancho_siete_puertas = formulaModificada.Replace("puertas", "7");
                formulaModificada = formula.Replace("descontar", ochoPuertas);
                guia.formula_ancho_ocho_puertas = formulaModificada.Replace("puertas", "8");

                guia.id_guia = 1;

                using (var conn = Bd.GetConnection())
                {
                    var resultado = conn.Query<Guia>("SELECT * FROM guia where id_guia = 1");
                    if (resultado.Count() == 0)
                    {
                        conn.Insert(guia);
                        //MessageBox.Show("Datos guardados.");
                    }
                    else
                    {
                        conn.Delete(guia);
                        conn.Insert(guia);
                       // MessageBox.Show("Datos Modificados.");
                    }
                }
                this.Close();
            }
        }

        private void ButtonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RecuperarDatos()
        {
            bool dat = false;
            Guia guia = new Guia();

            using (var conn = Bd.GetConnection())
            {
                var resultado = conn.Query<Guia>("SELECT * FROM guia where id_guia = 1");
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
                    guia = conn.Query<Guia>("SELECT * FROM guia where id_guia = 1").First<Guia>();
                }
                PonerDatosEnForm(guia);
            }
        }

        private void PonerDatosEnForm(Guia guia)
        {
            int dospuertas = 0;
            int trespuertas = 0;
            string[] trozos;
            if (guia.tipo_guia == "a-descontar/puertas")
            {
                trozos = guia.formula_ancho_dos_puertas.Split(new Char[] { '-', '/' });
                dospuertas = Int32.Parse(trozos[1]);
                trozos = guia.formula_ancho_tres_puertas.Split(new Char[] { '-', '/' });
                trespuertas = Int32.Parse(trozos[1]);
            }
            else if (guia.tipo_guia == "a/puertas-descontar")
            {
                trozos = guia.formula_ancho_dos_puertas.Split(new Char[] { '/', '-' });
                dospuertas = Int32.Parse(trozos[1]);
                trozos = guia.formula_ancho_tres_puertas.Split(new Char[] { '/', '-' });
                trespuertas = Int32.Parse(trozos[1]);
            }

            textBoxMarca.Text = guia.marca;
            textBoxModelo.Text = guia.modelo;
            numericAltoGuia.Value = guia.alto_guia;
            numericAnchoGuia.Value = guia.ancho_guia;
            numericUpDownDescontarAlto.Value = guia.milimetros_resta_altura_puerta;
            numericUpDownMilimetrosPerfil.Value = guia.milimetros_resta_ancho_perfil_u_puerta / 2;
            numericDescontar2Puertas.Value = dospuertas;
            numericDescontar3Puertas.Value = trespuertas;
        }

        private void Configuracion()
        {
            ConfiguracionElementos.miForm(this);
            ConfiguracionElementos.miButtonInicio(buttonGuardar);
            ConfiguracionElementos.miButtonInicio(buttonSalir);
        }
    }
}
