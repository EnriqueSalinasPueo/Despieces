using DespieceArmarios.Clases;
using DespieceArmarios.ClasesApoyo;
using DespieceArmarios.ClasesBd;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespieceArmarios.Formularios
{
    public partial class FormArmarioObra : System.Windows.Forms.Form
    {
        private List<ArmarioPiezas> armarios = new List<ArmarioPiezas>();
        private List<MedidasTotales> medidas = new List<MedidasTotales>();
        private Tablero tablero { get; set; }
        private DatosFormArmariosObra Datos { get; set; }

        private string nombreClinete;
        private string obra;
        private string guia;

        public FormArmarioObra(string cliente, string obra)
        {
            this.nombreClinete = cliente;
            this.obra = obra;
            InitializeComponent();
            this.Text = "Cliente: " + cliente + "  Obra: " + obra;
            Datos = new DatosFormArmariosObra();

            DarValoresPredeterminados();
            CargarLista();
            Configuracion();
            EngancharEventos();


        }

        private void CargarLista()
        {
            List<Armario> recuperarListaArmarios = new List<Armario>();
            recuperarListaArmarios = CallBbdd.GetListaArmarios(obra, nombreClinete);


            foreach (Armario armario in recuperarListaArmarios)
            {
                List<Pieza> recuperarListaPiezas;
                recuperarListaPiezas = CallBbdd.GetListaPiezas(armario);
                ArmarioPiezas armarioPiezas = new ArmarioPiezas();
                armarioPiezas.armario = armario;
                armarioPiezas.piezas = recuperarListaPiezas;
                armarios.Add(armarioPiezas);
            }
            VerLista(armarios);
            if (armarios.Count > 0)
            {
                numericUpDownQuitarArmario.Maximum = armarios.Count;
            }
        }

        private void DarValoresPredeterminados()
        {

            Datos.TipoArmario = radioButtonL.Tag.ToString();
            RecuperarGuia();
        }

        private async void RecuperarGuia()
        {
            Guia guia = new Guia();
            guia = CallBbdd.GetGuia();
            if (guia != null)
            {
                PonerDatosEnForm(guia);
            }
        }

        private void PonerDatosEnForm(Guia guia)
        {
            textBoxMarca.Text = guia.marca;
            textBoxModelo.Text = guia.modelo;
            textBoxDescontarAltoPuerta.Text = guia.milimetros_resta_altura_puerta.ToString();
            textBoxPerfil.Text = (guia.milimetros_resta_ancho_perfil_u_puerta / 2).ToString();
            textBoxAnchoGuia.Text = guia.ancho_guia.ToString();
            textBoxAltoGuia.Text = guia.alto_guia.ToString();
        }

        private void EngancharEventos()
        {
            butAnadir.Click += ButAnadir_Click;
            buttonVerLista.Click += ButtonVerLista_Click;
            buttonVerDis.Click += ButtonVerDis_Click;
            radioButtonL.CheckedChanged += RadioButtonL_CheckedChanged;
            radioButtonU.CheckedChanged += RadioButtonL_CheckedChanged;
            radioButtonOmega.CheckedChanged += RadioButtonL_CheckedChanged;
            pictureBoxL.Click += PictureBox_Click;
            pictureBoxU.Click += PictureBox_Click;
            pictureBoxOmega.Click += PictureBox_Click;
            buttonImprimir.Click += ButtonImprimir_Click;
            buttonQuitarUltimo.Click += ButtonQuitarUltimo_Click;
            buttonModificarHolguras.Click += ButtonModificarHolguras_Click;
            buttonModificarGuia.Click += ButtonModificarGuia_Click;

            /****************Revisar el quitar armarios******************/
            buttonQuitarArmario.Visible = false;
            numericUpDownQuitarArmario.Visible = false;
            //buttonQuitarArmario.Click += ButtonQuitarArmario_Click;

            buttonSacarMaterial.Click += ButtonSacarMaterial_Click;
            checkBoxEnL.CheckedChanged += CheckBoxEnL_CheckedChanged;
            checkBoxBarra.CheckedChanged += CheckBoxBarra_CheckedChanged;
            numericAncho.ValueChanged += NumericAncho_ValueChanged;
            numericFondo.ValueChanged += NumericFondo_ValueChanged;
        }

        private void ButtonVerDis_Click(object sender, EventArgs e)
        {
            ExternalizarDatos.MapearDatos(armarios[(armarios.Count - 1)], Datos);
        }

        private void ButtonModificarGuia_Click(object sender, EventArgs e)
        {
            FormModificarGuia form = new FormModificarGuia();
            form.FormClosed += (o, a) => RecuperarGuia();
            form.ShowDialog();
        }

        private void ButtonModificarHolguras_Click(object sender, EventArgs e)
        {
            FormDefinirHolgurasGruesos form = new FormDefinirHolgurasGruesos();
            form.ShowDialog();
        }

        private void NumericFondo_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownSegundoFondo.Value = numericFondo.Value;
        }

        private void NumericAncho_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownSegundoAncho.Value = numericAncho.Value;
        }

        private void CheckBoxBarra_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBarra.Checked)
            {
                radioButtonBarraColgar.Visible = true;
                radioButtonBarraLateral.Visible = true;
            }
            else
            {
                radioButtonBarraColgar.Visible = false;
                radioButtonBarraLateral.Visible = false;
            }
        }

        private void CheckBoxEnL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEnL.Checked)
            {
                labelSegundoAncho.Visible = true;
                labelSegundoFondo.Visible = true;
                numericUpDownSegundoAncho.Visible = true;
                numericUpDownSegundoFondo.Visible = true;
                numericUpDownSegundoAncho.Value = numericAncho.Value;
                numericUpDownSegundoFondo.Value = numericFondo.Value;
                labelMm.Visible = true;
                labelmm2.Visible = true;
                if (radioButtonL.Checked)
                {
                    radioButtonParedAbierta.Visible = true;
                    radioButtonParedCerrada.Visible = true;
                }
                else
                {
                    radioButtonParedAbierta.Visible = false;
                    radioButtonParedCerrada.Visible = false;
                }

            }
            else
            {
                labelSegundoAncho.Visible = false;
                labelSegundoFondo.Visible = false;
                numericUpDownSegundoAncho.Visible = false;
                numericUpDownSegundoFondo.Visible = false;
                labelMm.Visible = false;
                labelmm2.Visible = false;
                radioButtonParedAbierta.Visible = false;
                radioButtonParedCerrada.Visible = false;
            }
        }

        private void ButtonVerLista_Click(object sender, EventArgs e)
        {
            VerLista(armarios);
        }

        private void ButtonSacarMaterial_Click(object sender, EventArgs e)
        {
            EstimacionMaterial es = new EstimacionMaterial();

            tablero = new Tablero();

            tablero.largo = 2800;
            tablero.ancho = 2070;
            tablero.grueso = 19;

            medidas = es.CalcularTableros(armarios, tablero);

            richTextBoxLista.Clear();
            richTextBoxLista.Text += "NOMBRE                                        Metros o Unidades.\n\n";
            foreach (var item in medidas)
            {
                richTextBoxLista.Text += item.Nombre.PadRight(40, ' ') + "-->  " + item.TotalMetros.ToString() + "\n";
            }

            //FormImpresion impresion = new FormImpresion(medidas);
            //impresion.ShowDialog();

        }

        private void ButtonQuitarArmario_Click(object sender, EventArgs e)
        {
            if (armarios.Count > 0)
            {
                Armario armario = armarios[armarios.Count - 1].armario;
                int numeroBorrar = (int)numericUpDownQuitarArmario.Value;
                armarios.RemoveAt(numeroBorrar - 1);
                VerLista(armarios);
                BorrarArmarioBd(armario);
                MessageBox.Show("Borrado armario numero " + numeroBorrar + " de la lista.");
            }
        }

        private void BorrarArmarioBd(Armario armario)
        {
            var borrado = CallBbdd.DeleteArmario(armario);
            numericUpDownQuitarArmario.Maximum = armarios.Count;
        }

        private void ButtonQuitarUltimo_Click(object sender, EventArgs e)
        {
            if (armarios.Count > 0)
            {
                Armario armario = armarios[armarios.Count - 1].armario;
                armarios.RemoveAt(armarios.Count - 1);
                VerLista(armarios);
                BorrarArmarioBd(armario);
                MessageBox.Show("Borrado ultimo armario de la lista.");
            }
        }

        private void ButtonImprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de imprimir la lista?", "Confirmar impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var armariosFull = new List<ArmarioFull>();
                armarios.ForEach(a =>
                {
                    var armarioFull = new ArmarioFull
                    {
                        alto_armario = a.armario.alto_armario,
                        ancho_armario = a.armario.ancho_armario,
                        fondo_armario = a.armario.fondo_armario,
                        h_alto = a.armario.h_alto,
                        h_ancho = a.armario.h_ancho,
                        h_fondo = a.armario.h_fondo,
                        escalera = a.armario.escalera,
                        piso = a.armario.piso,
                        habitacion = a.armario.habitacion,
                        modulos = a.armario.modulos,
                        puertas = a.armario.puertas,
                        altura_patas = a.armario.altura_patas,
                        modelo_armario = a.armario.modelo_armario,
                        PiezasString = string.Empty,
                    };
                    foreach (var pieza in a.piezas)
                    {
                        armarioFull.PiezasString += $"{pieza.ToFormattedString()}{Environment.NewLine}";
                    }
                    armariosFull.Add(armarioFull);
                });
                FormImpresion impresion = new FormImpresion(armariosFull);
                impresion.ShowDialog();
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

        private void RadioButtonL_CheckedChanged(object sender, EventArgs e)
        {

            if (sender is RadioButton radioButton)
            {
                if (radioButton.Checked == true)
                {
                    Datos.TipoArmario = radioButton.Tag.ToString();
                    //MessageBox.Show(tipoArmario);
                    if (checkBoxEnL.Checked && radioButtonL.Checked)
                    {
                        radioButtonParedAbierta.Visible = true;
                        radioButtonParedCerrada.Visible = true;
                    }
                    else
                    {
                        radioButtonParedAbierta.Visible = false;
                        radioButtonParedCerrada.Visible = false;
                    }
                }
            }
        }

        /************************   Añadimos armario llamado a la clase necesaria para las medidas, tambien se guarda el armario en base datos         **************************/
        private void ButAnadir_Click(object sender, EventArgs e)
        {
            if (checkBoxEnL.Checked)
            {
                if (Validar())
                {
                    CalculosArmarioCorrederoObra mandarDatos = new CalculosArmarioCorrederoObra(nombreClinete, obra, guia, Datos, armarios);

                    Limpiar();
                    numericUpDownQuitarArmario.Maximum = armarios.Count;
                    VerArmario();
                }
            }
            else
            {
                if (Validar())
                {
                    CalculosArmarioCorrederoObra mandarDatos = new CalculosArmarioCorrederoObra(nombreClinete, obra, guia, Datos, armarios);

                    Limpiar();
                    numericUpDownQuitarArmario.Maximum = armarios.Count;
                    VerArmario();
                }
            }
        }

        private void Limpiar()
        {
            textBoxHabitacion.Clear();
        }

        /*****************   Se recogen los datos del formulario y se validan los campos                                                            ***************************/
        private bool Validar()
        {
            try
            {
                Datos.Escalera = textBoxEscalera.Text;
                Datos.Piso = textBoxPiso.Text;
                Datos.Habitacion = textBoxHabitacion.Text;

                Datos.Hueco_alto = (int)numericALto.Value;
                Datos.Hueco_ancho = (int)numericAncho.Value;
                Datos.Hueco_fondo = (int)numericFondo.Value;

                Datos.GruesoModulos = (int)numGruesoModulos.Value;
                Datos.GruesoPuertas = (int)numGruesoPuertas.Value;
                Datos.AnchoTapajuntas = (int)numTapajuntas.Value;
                Datos.AltoRodapie = (int)numRodapie.Value;
                Datos.NumeroBadas = (int)numericBaldas.Value;
                Datos.HastaSuelo = radioButtonHastaSuelo.Checked;
                Datos.HastaRodapie = radioButtonHastaRodapie.Checked;
                Datos.PuertasCorrederas = radioButtonCorrederas.Checked;
                Datos.PuertasAbatibles = radioButtonAbatibles.Checked;
                Datos.TraseraAcanalada = radioButtonAcanalada.Checked;
                Datos.TraseraAtornillada = radioButtonAtornillada.Checked;
                if (checkBoxBarra.Checked)
                {
                    Datos.BarraColgar = radioButtonBarraColgar.Checked;
                    Datos.BarraLateral = radioButtonBarraLateral.Checked;
                }
                else
                {
                    Datos.BarraColgar = false;
                    Datos.BarraLateral = false;

                }
                Datos.ConJacena = checkBoxJacena.Checked;

                if (checkBoxEnL.Checked)
                {
                    Datos.ArmarioRinconero = checkBoxEnL.Checked;
                    Datos.Hueco_segundoAncho = (int)numericUpDownSegundoAncho.Value;
                    Datos.Hueco_segundoFondo = (int)numericUpDownSegundoFondo.Value;
                    Datos.ParedAbierta = radioButtonParedAbierta.Checked;
                    Datos.ParedCerrada = radioButtonParedCerrada.Checked;
                }
                else
                {
                    Datos.ArmarioRinconero = false;
                    Datos.Hueco_segundoAncho = 0;
                    Datos.Hueco_segundoFondo = 0;
                }

                if (string.IsNullOrEmpty(textBoxEscalera.Text) || string.IsNullOrEmpty(textBoxPiso.Text) || string.IsNullOrEmpty(textBoxHabitacion.Text))
                {
                    MessageBox.Show("Por favor introduce todos los nombres de escalera, piso y habitación para identificar el armario.");
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("FALLO DE EXCEPCION Controla los datos introducidos ");
                return false;
            }
            return true;
        }

        /*****************    Listamos todos los armarios que tenemos en la base de datos del trabajo y cliente seleccionado     **********************************************/
        private void VerLista(List<ArmarioPiezas> armariosPiezasLista)
        {
            richTextBoxLista.Clear();
            int numeroArmario = 0;
            foreach (ArmarioPiezas armarioPiezas in armariosPiezasLista)
            {
                Armario ar = armarioPiezas.armario;
                numeroArmario++;
                richTextBoxLista.Text += "N " + numeroArmario.ToString() + " Escalera:  " + ar.escalera + "\tPiso: " + ar.piso + "\tHabitacion: " + ar.habitacion + "\tModelo: " + ar.modelo_armario +
                                        "\nModulos: " + ar.modulos + "\tPuertas: " + ar.puertas + "\tAltura patas: " + ar.altura_patas +
                                      "\n\nHueco >  Alto: " + ar.h_alto + "\tAncho: " + ar.h_ancho + "\tFondo: " + ar.h_fondo +
                                        "\nCasco >  Alto: " + ar.alto_armario + "\tAncho: " + ar.ancho_armario + "\tFondo: " + ar.fondo_armario + "\n\n";

                foreach (Pieza pieza in armarioPiezas.piezas)
                {
                    if (pieza.nombre == "DM Puertas" || pieza.nombre == "Perfiles")
                    {
                        richTextBoxLista.Text += "---------------------------------------------------------------------------------\n";
                    }
                    richTextBoxLista.Text += pieza.nombre.PadRight(20, ' ') + pieza.cantidad.ToString().PadRight(4, ' ') + " = ".PadLeft(4, ' ') + Decimal.Round(pieza.largo).ToString().PadLeft(6, ' ') + "\t  x\t" + Decimal.Round(pieza.ancho).ToString().PadLeft(4, ' ') + "\t  x\t" + Decimal.Round(pieza.grueso).ToString().PadLeft(4, ' ') + "\n";

                }
                richTextBoxLista.Text += "=======================================================================\n";
            }
        }
        /*****************    Cada vez que añadimos un armaio vemos el resumen de sus piezas                                ***************************************************/
        private void VerArmario()
        {
            richTextBoxLista.Clear();
            if (armarios.Count > 0)
            {
                ArmarioPiezas armarioPiezas = armarios[armarios.Count - 1];

                Armario ar = armarioPiezas.armario;
                int numeroArmario = armarios.Count;
                richTextBoxLista.Text += "N " + numeroArmario.ToString() + " Escalera:  " + ar.escalera + "  Piso: " + ar.piso + "  Habitacion: " + ar.habitacion + "  Modelo: " + ar.modelo_armario +
                                        "\nModulos: " + ar.modulos + "\tPuertas: " + ar.puertas + "\tAltura patas: " + ar.altura_patas +
                                      "\n\nHueco >  Alto: " + ar.h_alto + "\tAncho: " + ar.h_ancho + "\tFondo: " + ar.h_fondo +
                                        "\nCasco >  Alto: " + ar.alto_armario + "\tAncho: " + ar.ancho_armario + "\tFondo: " + ar.fondo_armario + "\n\n";

                foreach (Pieza pieza in armarioPiezas.piezas)
                {
                    if (pieza.nombre == "DM Puertas" || pieza.nombre == "Perfiles")
                    {
                        richTextBoxLista.Text += "---------------------------------------------------------------------------------\n";
                    }
                    richTextBoxLista.Text += pieza.nombre.PadRight(20, ' ') + pieza.cantidad.ToString().PadRight(4, ' ') + " = ".PadLeft(4, ' ') + Decimal.Round(pieza.largo).ToString().PadLeft(6, ' ') + "\t  x\t" + Decimal.Round(pieza.ancho).ToString().PadLeft(4, ' ') + "\t  x\t" + Decimal.Round(pieza.grueso).ToString().PadLeft(4, ' ') + "\n";

                }
                richTextBoxLista.Text += "=======================================================================\n";

            }
        }

        private void Configuracion()
        {
            ConfiguracionElementos.miForm(this);
            ConfiguracionElementos.miButtonInicio(butAnadir);
            ConfiguracionElementos.miButtonInicio(buttonImprimir);
            ConfiguracionElementos.miButtonInicio(buttonQuitarArmario);
            ConfiguracionElementos.miButtonInicio(buttonQuitarUltimo);
            ConfiguracionElementos.miButtonInicio(buttonSacarMaterial);
            ConfiguracionElementos.miButtonInicio(buttonVerLista);
            ConfiguracionElementos.miButtonInicio(buttonModificarHolguras);
            ConfiguracionElementos.miButtonInicio(buttonVerDis);
            ConfiguracionElementos.miButtonInicio(buttonModificarGuia);

        }
    }
}
