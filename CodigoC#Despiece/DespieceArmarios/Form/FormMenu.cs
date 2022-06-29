using DespieceArmarios.Clases;
using DespieceArmarios.Formularios;
using System;
using System.Windows.Forms;

namespace DespieceArmarios
{
    public partial class FormMenu : Form
    {
        public string Obra { get; set; }
        public string Cliente { get; set; }

        public FormMenu(string cliente, string obra)
        {
            this.Cliente = cliente;
            this.Obra = obra;

            InitializeComponent();
            Configuracion();
            EngancharEventos();
        }

        private void EngancharEventos()
        {
            btnParticular.Click += ButtonParticular_Click;
            btnArmariosObra.Click += ButtonArmariosObra_Click;
            btnCajonera.Click += BtnCajonera_Click;
        }

        private void BtnCajonera_Click(object sender, EventArgs e)
        {

        }

        private void ButtonArmariosObra_Click(object sender, EventArgs e)
        {
            FormArmarioObra formArmariosObra = new FormArmarioObra(Cliente,Obra);
            formArmariosObra.ShowDialog();
        }

        private void ButtonParticular_Click(object sender, EventArgs e)
        {
            FomrArmariosParticular fomrArmariosParticular = new FomrArmariosParticular(Cliente, Obra);
            fomrArmariosParticular.ShowDialog();
        }

        private void Configuracion()
        {
            ConfiguracionElementos.miForm(this);
            ConfiguracionElementos.miButtonInicio(btnArmariosObra);
            ConfiguracionElementos.miButtonInicio(btnParticular);
            ConfiguracionElementos.miButtonInicio(btnCajonera);
        }
    }
}
