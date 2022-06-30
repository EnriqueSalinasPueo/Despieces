using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DespieceArmarios.Clases;
using DespieceArmarios.ClasesApoyo.ClasesParticular;
using Microsoft.CSharp.RuntimeBinder;

namespace DespieceArmarios.Form
{
    public partial class FormCajonera : System.Windows.Forms.Form
    {
        private Cajonera Cajonera { get; set; } = new Cajonera();

        public FormCajonera()
        {
            InitializeComponent();

            Configuracion();
            CargarFormulario();
            Bind();
            EngancharEventos();
        }

        private void CargarFormulario()
        {
            
        }

        private void EngancharEventos()
        {
            btnSalir.Click += BtnSalir_Click;
            btnGuardarDatos.Click += BtnGuardarDatos_Click;
        }

        private void BtnGuardarDatos_Click(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bind()
        {
            ClearBind();
            numAlturaCajon.DataBindings.Add(nameof(NumericUpDown.Value), Cajonera, nameof(Cajonera.Altura1));
            numNumeroCajoenes.DataBindings.Add(nameof(NumericUpDown.Value), Cajonera, nameof(Cajonera.NumeroCajones));
            numOrejaDerecha.DataBindings.Add(nameof(NumericUpDown.Value), Cajonera, nameof(Cajonera.OrejaDerecha));
            numOrejaIzquierda.DataBindings.Add(nameof(NumericUpDown.Value), Cajonera, nameof(Cajonera.OrejaIzquierda));
        }

        private void ClearBind()
        {
            numAlturaCajon.DataBindings.Clear();
            numNumeroCajoenes.DataBindings.Clear();
            numOrejaDerecha.DataBindings.Clear();
            numOrejaIzquierda.DataBindings.Clear();
        }

        private void Configuracion()
        {
            ConfiguracionElementos.miForm(this);
            ConfiguracionElementos.miButtonInicio(btnGuardarDatos);
            ConfiguracionElementos.miButtonInicio(btnSalir);
            ConfiguracionElementos.miButtonInicio(btnCargarGuias);
        }
    }
}
