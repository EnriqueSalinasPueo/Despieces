using DespieceArmarios.Clases;
using DespieceArmarios.ClasesApoyo;
using DespieceArmarios.ClasesApoyo.ClasesParticular;
using DespieceArmarios.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespieceArmarios
{
    public partial class FomrArmariosParticular : Form
    {
        private int editandoModuloPintar = -1;
        private int numeroModulo;
        private string tipoModulo;
        private decimal[] decimalArray;
        private decimal[] apoyo;
        decimal medidaModulosAncho = 0;

        private List<Modulo> ListaModulosPintar { get; set; } = new List<Modulo>();
        private List<InfoModulo> ListaModulos { get; set; } = new List<InfoModulo>();

        private CalculosArmarioParticular calculosArmarioParticular = new CalculosArmarioParticular();

        private DatosFormArmariosParticular datosArmario = new DatosFormArmariosParticular();
        public string nombreCliente { get; set; }
        public string nombreObra { get; set; }


        public FomrArmariosParticular(string cliente, string obra)
        {
            this.nombreCliente = cliente;
            this.nombreObra = obra;
            InitializeComponent();
            this.Text += cliente + " " + obra;
            Configuracion();
            // MessageBox.Show("Revisa las caracteristicas del armario.");
            EngancharEventos();
        }


        private void EngancharEventos()
        {
            // EVENTOS OPCIONES ARMARIO
            checkBoxAltillo.CheckedChanged += CheckBoxAltillo_CheckedChanged;
            checkBoxCajonera.CheckedChanged += CheckBoxCajonera_CheckedChanged;
            checkBoxDiferentes.CheckedChanged += CheckBoxDiferentes_CheckedChanged;
            numericUpDownBaldas.ValueChanged += NumericUpDownBaldas_ValueChanged;
            radioButtonTodoAncho.CheckedChanged += RadioButtonTodoAncho_CheckedChanged;
            radioButtonCorredera.CheckedChanged += (o, a) => { buttonModificarGuia.Visible = radioButtonCorredera.Checked ? true : false; };
            radioButtonParedAbierta.CheckedChanged += RadioButtonParedAbierta_CheckedChanged;
            radioButtonParedCerrada.CheckedChanged += RadioButtonParedAbierta_CheckedChanged;
            checkBoxEnL.CheckedChanged += CheckBoxEnL_CheckedChanged;

            // EVENTOS HUECO ARMARIO
            radioButtonL.CheckedChanged += RadioButtonL_CheckedChanged;
            radioButtonU.CheckedChanged += RadioButtonL_CheckedChanged;
            radioButtonOmega.CheckedChanged += RadioButtonL_CheckedChanged;
            pictureBoxL.Click += PictureBox_Click;
            pictureBoxU.Click += PictureBox_Click;
            pictureBoxOmega.Click += PictureBox_Click;


            // EVENTOS BOTONES SUPERIORES FORMULARIO 
            buttonModulos.Click += ButtonModulos_Click;
            buttonSiguiente.Click += ButtonSiguiente_Click;
            buttonAtras.Click += ButtonAtras_Click;
            buttonMedidas.Click += ButtonMedidas_Click;
            buttonModificarGuia.Click += ButtonModificarGuia_Click;
            buttonModificarHolguras.Click += ButtonModificarHolguras_Click;

        }


        // ***************************************************************************************************************
        // ************************************************* Recoger Datos  **********************************************
        // ***************************************************************************************************************
        private void RecogerDatosFormulario()
        {
            if (radioButtonL.Checked)
            {
                tipoModulo = (string)radioButtonL.Tag;
            }
            else if (radioButtonU.Checked)
            {
                tipoModulo = (string)radioButtonU.Tag;
            }
            else if (radioButtonOmega.Checked)
            {
                tipoModulo = (string)radioButtonOmega.Tag;
            }

            datosArmario.infoOpciones.numeroModulos = (int)numericUpDownNumeroModulos.Value;
            numeroModulo = datosArmario.infoOpciones.numeroModulos;
            datosArmario.infoAltillo.altura = numericUpDownAltillo.Value;

            datosArmario.infoHueco.Alto = numericALtoHueco.Value;
            datosArmario.infoHueco.Ancho = numericAnchoHueco.Value;
            datosArmario.infoHueco.Fondo = numericFondoHueco.Value;
            datosArmario.infoRemates.AnchoCornisa = numericUpDownAltoCornisa.Value;
            datosArmario.infoRemates.AnchoTapajuntas = numericUpDownAnchoTapajuntas.Value;
            datosArmario.infoRemates.AnchoRodapie = numericUpDownAltoRopapie.Value;


            if (radioButtonDosGruesos.Checked)
            {
                datosArmario.infoAltillo.esUnGrueso = false;
            }
            else if (radioButtonUnGrueso.Checked)
            {
                datosArmario.infoAltillo.esUnGrueso = true;
            }
            if (radioButtonCadaModulo.Checked)
            {
                datosArmario.infoAltillo.esPorModulo = false;
            }
            else if (radioButtonTodoAncho.Checked)
            {
                datosArmario.infoAltillo.esPorModulo = true;
            }
            if (radioButtonAcanalada.Checked)
            {
                datosArmario.infoOpciones.esTraseraAtornillada = false;
            }
            else if (radioButtonAtornillada.Checked)
            {
                datosArmario.infoOpciones.esTraseraAtornillada = true;
            }
            if (radioButtonAbatible.Checked)
            {
                datosArmario.infoOpciones.esPuertaAbatible = true;
            }
            else if (radioButtonCorredera.Checked)
            {
                datosArmario.infoOpciones.esPuertaAbatible = false;
            }
            if (radioButtonRecto.Checked)
            {
                datosArmario.infoOpciones.esArmarioRecto = true;
            }
            else if (radioButtonRinconero.Checked)
            {
                datosArmario.infoOpciones.esArmarioRecto = false;
            }
            if (checkBoxJacena.Checked)
            {
                datosArmario.infoOpciones.hayJacena = true;
            }
            else 
            {
                datosArmario.infoOpciones.hayJacena = false;
            }
            if (checkBoxTapajuntasSuelo.Checked)
            {
                datosArmario.infoOpciones.tapajuntasSuelo = true;
            }
            else
            {
                datosArmario.infoOpciones.tapajuntasSuelo = false;
            }

            decimalArray = new decimal[numeroModulo + 1];
            apoyo = new decimal[numeroModulo + 1];
            apoyo[0] = 2;
        }

        // ***************************************************************************************************************
        // *************************************************  ACCIONES CHANGED  ******************************************
        // ***************************************************************************************************************
        private void CheckBoxDiferentes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDiferentes.Checked)
            {
                labelAltura2.Visible = true;
                labelAltura3.Visible = true;
                numericUpDownAltura2.Visible = true;
                numericUpDownAltura3.Visible = true;
                labelCantidad_1.Visible = true;
                labelCantidad_2.Visible = true;
                numericUpDownCantidadAltura2.Visible = true;
                numericUpDownCantidadAltura3.Visible = true;
            }
            else
            {
                labelAltura2.Visible = false;
                labelAltura3.Visible = false;
                numericUpDownAltura2.Visible = false;
                numericUpDownAltura3.Visible = false;
                labelCantidad_1.Visible = false;
                labelCantidad_2.Visible = false;
                numericUpDownCantidadAltura2.Visible = false;
                numericUpDownCantidadAltura3.Visible = false;

            }
        }

        private void CheckBoxCajonera_CheckedChanged(object sender, EventArgs e)
        {
            var moduloActual = ListaModulosPintar[editandoModuloPintar];
            if (checkBoxCajonera.Checked)
            {
                moduloActual.hayCajonara = true;
                numericUpDownBaldas.Maximum = 7;
                //pictureBoxCajonera.Visible = true;
                groupBoxAlturaCajon.Visible = true;
                groupBoxOrejas.Visible = true;
                numericUpDownNumeroCajones.Visible = true;
                labelCajones.Visible = true;
            }
            else
            {
                moduloActual.hayCajonara = false;
                numericUpDownBaldas.Maximum = 10;
                //pictureBoxCajonera.Visible = false;
                groupBoxAlturaCajon.Visible = false;
                groupBoxOrejas.Visible = false;
                numericUpDownNumeroCajones.Visible = false;
                labelCajones.Visible = false;
            }
        }

        private void NumericUpDownBaldas_ValueChanged(object sender, EventArgs e)
        {
            if (editandoModuloPintar >= 0)
            {
                var moduloActual = ListaModulosPintar[editandoModuloPintar];
                moduloActual.NumeroBaldas = (int)numericUpDownBaldas.Value;
            }
        }

        private void RadioButtonTodoAncho_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTodoAncho.Checked)
            {
                radioButtonDosGruesos.Checked = true;
            }
        }

        private void CheckBoxAltillo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAltillo.Checked)
            {
                labelAltura.Visible = true;
                numericUpDownAltillo.Visible = true;
                groupBoxEmpalme.Visible = true;
                groupBoxModulacion.Visible = true;
            }
            else
            {
                labelAltura.Visible = false;
                numericUpDownAltillo.Visible = false;
                groupBoxEmpalme.Visible = false;
                groupBoxModulacion.Visible = false;
            }
        }

        private void RadioButtonL_CheckedChanged(object sender, EventArgs e)
        {

            if (sender is RadioButton radioButton)
            {
                if (radioButton.Checked == true)
                {

                    //Reger los datos del tag del radio button activo
                    //MessageBox.Show(tipoArmario);

                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                if (pictureBox.Tag.ToString() == "radioButtonU")
                {
                    radioButtonU.Checked = true;
                }
                if (pictureBox.Tag.ToString() == "radioButtonL")
                {
                    radioButtonL.Checked = true;
                }
                if (pictureBox.Tag.ToString() == "radioButtonOmega")
                {
                    radioButtonOmega.Checked = true;
                }

            }
        }

        private void RadioButtonParedAbierta_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonParedAbierta.Checked)
            {
                datosArmario.infoArmarioRinconero.paredDerechaAbierta = true;
            }
            else
            {
                datosArmario.infoArmarioRinconero.paredDerechaAbierta = false;
            }
        }

        private void CheckBoxEnL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnL.Checked)
            {
                labelmm2.Visible = true;
                labelMm.Visible = true;
                numericUpDownSegundoAncho.Visible = true;
                numericUpDownSegundoFondo.Visible = true;
                radioButtonParedAbierta.Visible = true;
                radioButtonParedCerrada.Visible = true;
                labelSegundoAncho.Visible = true;
                labelSegundoFondo.Visible = true;
            }
            else
            {
                labelmm2.Visible = false;
                labelMm.Visible = false;
                numericUpDownSegundoAncho.Visible = false;
                numericUpDownSegundoFondo.Visible = false;
                radioButtonParedAbierta.Visible = false;
                radioButtonParedCerrada.Visible = false;
                labelSegundoAncho.Visible = false;
                labelSegundoFondo.Visible = false;
            }
        }

        // ***************************************************************************************************************
        // *************************************************  ACCIONES BOTONES  ******************************************
        // ***************************************************************************************************************
        private void ButtonAtras_Click(object sender, EventArgs e)
        {
            if (editandoModuloPintar == numeroModulo - 1)
            {
                buttonDiseño.Visible = false;
                buttonMedidas.Visible = false;
                buttonSiguiente.Visible = true;
            }
            if (editandoModuloPintar == numeroModulo - 1)
            {
                buttonDiseño.Visible = false;
                buttonMedidas.Visible = false;
            }
            if (editandoModuloPintar > 0)
            {
                editandoModuloPintar--;
                ObtenerInfoModulo();
                ValorTextBoxAnchoArmario(editandoModuloPintar, false);
            }
            else if (editandoModuloPintar == 0)
            {
                editandoModuloPintar--;
                ListaModulosPintar.Clear();
                pnlPlantillaModulo.Controls.Clear();
                ListaModulos.Clear();

                buttonAtras.Visible = false;
                buttonSiguiente.Visible = false;
                groupBoxBaldas.Visible = false;
                groupBoxBarras.Visible = false;
                groupBoxAnchoModulo.Visible = false;
                groupBoxCajonera.Visible = false;
                checkBoxCajonera.Visible = false;

                groupBoxHueco.Enabled = true;
                groupBoxNumeroModulos.Enabled = true;
                groupBoxAltillo.Enabled = true;
                groupBoxAltoCornisa.Enabled = true;
                groupBoxAnchoTapajuntas.Enabled = true;
                groupBoxAltoRodapie.Enabled = true;
                groupBoxTrasera.Enabled = true;
                groupBoxPuertas.Enabled = true;
                groupBoxArmarioL.Enabled = true;
                groupBoxTipoArmario.Enabled = true;
                groupBoxJacena.Enabled = true;

                buttonModulos.Enabled = true;
                buttonModificarGuia.Enabled = true;
                buttonModificarHolguras.Enabled = true;
                numericUpDownAnchoModulo.Enabled = true;

            }

        }

        private void ButtonSiguiente_Click(object sender, EventArgs e)
        {
            decimalArray[editandoModuloPintar] = numericUpDownAnchoModulo.Value;
            var crearModulo = editandoModuloPintar == ListaModulosPintar.Count - 1;
            if (editandoModuloPintar < numeroModulo)
            {
                if (crearModulo)
                {
                    if (editandoModuloPintar < numeroModulo - 1)
                    {
                        AñadirModuloPintar();
                    }
                }
                else
                {
                    editandoModuloPintar++;
                    ValorTextBoxAnchoArmario(editandoModuloPintar, true);
                    // añdirModulo(editandoModuloPintar);
                }
                ObtenerInfoModulo();
            }
            if (editandoModuloPintar == numeroModulo - 1)
            {
                buttonDiseño.Visible = true;
                buttonMedidas.Visible = true;
                buttonSiguiente.Visible = false;
            }
        }

        private void ButtonModulos_Click(object sender, EventArgs e)
        {

            RecogerDatosFormulario();
            if (editandoModuloPintar == -1)
            {
                medidaModulosAncho = calculosArmarioParticular.GetAnchoArmario(tipoModulo, datosArmario);
                AñadirModuloPintar();
            }

            buttonAtras.Visible = true;
            if (numeroModulo != 1)
            {
                buttonSiguiente.Visible = true;
            }
            else
            {
                buttonDiseño.Visible = true;
                buttonMedidas.Visible = true;
                numericUpDownAnchoModulo.Enabled = false;
            }
            groupBoxBaldas.Visible = true;
            groupBoxBarras.Visible = true;
            groupBoxAnchoModulo.Visible = true;
            groupBoxCajonera.Visible = true;
            checkBoxCajonera.Visible = true;

            groupBoxHueco.Enabled = false;
            groupBoxNumeroModulos.Enabled = false;
            groupBoxAltillo.Enabled = false;
            groupBoxAltoCornisa.Enabled = false;
            groupBoxAnchoTapajuntas.Enabled = false;
            groupBoxAltoRodapie.Enabled = false;
            groupBoxTrasera.Enabled = false;
            groupBoxPuertas.Enabled = false;
            groupBoxArmarioL.Enabled = false;
            groupBoxTipoArmario.Enabled = false;
            groupBoxJacena.Enabled = false;

            buttonModulos.Enabled = false;
            buttonModificarGuia.Enabled = false;
            buttonModificarHolguras.Enabled = false;

        }

        private void ButtonModificarHolguras_Click(object sender, EventArgs e)
        {
            FormDefinirHolgurasGruesos formDefinirHolgurasGruesos = new FormDefinirHolgurasGruesos();
            formDefinirHolgurasGruesos.ShowDialog();
        }

        private void ButtonModificarGuia_Click(object sender, EventArgs e)
        {
            FormModificarGuia formModificarGuia = new FormModificarGuia();
            formModificarGuia.ShowDialog();
        }

        private void ButtonMedidas_Click(object sender, EventArgs e)
        {
            RecogerArmario();
            // calculosArmarioParticular.recibirDatos(nombreObra, nombreCliente, tipoModulo, ListaModulos, datosArmario);
            MessageBox.Show("Funcionalidad en construccion");
        }

        private void RecogerArmario()
        {
            ListaModulos.Clear();
            for (int i = 0; i < ListaModulosPintar.Count; i++)
            {
                InfoModulo m = new InfoModulo();
                Modulo moduloAtual = ListaModulosPintar[i];
                m = moduloAtual.Info;
                m.Ancho = decimalArray[i];
                ListaModulos.Add(m);
            }
        }


        // ***************************************************************************************************************
        // *************************************************  METODOS MODULOS  *******************************************
        // ***************************************************************************************************************
        private void ObtenerInfoModulo()
        {

            var moduloActualPintar = ListaModulosPintar[editandoModuloPintar];
            checkBoxCajonera.Checked = moduloActualPintar.hayCajonara;
            numericUpDownBaldas.Value = moduloActualPintar.NumeroBaldas;
            DesactivarModulos();
            moduloActualPintar.Enabled = true;
        }

        private void AñadirModuloPintar()
        {
            editandoModuloPintar++;
            var nuevoModuloPintar = new Modulo(editandoModuloPintar + 1);
            nuevoModuloPintar.Dock = DockStyle.Left;
            ListaModulosPintar.Add(nuevoModuloPintar);
            pnlPlantillaModulo.Controls.Add(nuevoModuloPintar);
            pnlPlantillaModulo.Controls.SetChildIndex(nuevoModuloPintar, 0);
            ValorTextBoxAnchoArmario(editandoModuloPintar, true);
        }

        private void ValorTextBoxAnchoArmario(int editandoModuloPintar, bool esSiguiente)
        {

            if (esSiguiente)
            {
                if (editandoModuloPintar != 0 && decimalArray[editandoModuloPintar - 1] == apoyo[editandoModuloPintar - 1])
                {
                    numericUpDownAnchoModulo.Value = decimalArray[editandoModuloPintar];
                }
                else
                {

                    if (editandoModuloPintar == 0 && decimalArray[0] == 0)
                    {
                        decimal cadaModulo = medidaModulosAncho / numeroModulo;
                        for (int i = 0; i < decimalArray.Length - 1; i++)
                        {
                            decimalArray[i] = cadaModulo;
                            apoyo[i] = cadaModulo;
                        }

                    }
                    else
                    {
                        if (decimalArray[editandoModuloPintar - 1] != (medidaModulosAncho / numeroModulo))
                        {
                            decimal acumulador = 0; ;
                            for (int i = 0; i < editandoModuloPintar; i++)
                            {
                                acumulador += decimalArray[i];
                            }
                            decimal nuevoAncho = medidaModulosAncho - acumulador;
                            int numeroModulosRestante = numeroModulo - editandoModuloPintar;
                            for (int i = editandoModuloPintar; i < decimalArray.Length - 1; i++)
                            {
                                decimalArray[i] = (nuevoAncho / numeroModulosRestante);
                                apoyo[i] = (nuevoAncho / numeroModulosRestante);
                            }
                        }

                    }
                    numericUpDownAnchoModulo.Value = decimalArray[editandoModuloPintar];
                }
            }
            else
            {
                numericUpDownAnchoModulo.Value = decimalArray[editandoModuloPintar];
            }
        }

        private void DesactivarModulos()
        {
            for (int i = 0; i < ListaModulosPintar.Count; i++)
            {
                ListaModulosPintar[i].Enabled = false;
            }
        }

        private void Configuracion()
        {
            ConfiguracionElementos.miForm(this);
            ConfiguracionElementos.miButtonInicio(buttonAtras);
            ConfiguracionElementos.miButtonInicio(buttonDiseño);
            ConfiguracionElementos.miButtonInicio(buttonMedidas);
            ConfiguracionElementos.miButtonInicio(buttonSiguiente);
            ConfiguracionElementos.miButtonInicio(buttonModulos);
            ConfiguracionElementos.miButtonInicio(buttonModificarHolguras);
            ConfiguracionElementos.miButtonInicio(buttonModificarGuia);
        }
    }
}
