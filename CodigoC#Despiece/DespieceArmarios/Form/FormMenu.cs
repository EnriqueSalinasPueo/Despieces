using DespieceArmarios.Clases;
using DespieceArmarios.Formularios;
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
            buttonParticular.Click += ButtonParticular_Click;
            buttonArmariosObra.Click += ButtonArmariosObra_Click;
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
            ConfiguracionElementos.miButtonInicio(buttonArmariosObra);
            ConfiguracionElementos.miButtonInicio(buttonParticular);
        }
    }
}
