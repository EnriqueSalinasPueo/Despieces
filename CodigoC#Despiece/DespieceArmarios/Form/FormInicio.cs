using Dapper;
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
using Dapper.Contrib.Extensions;
using DespieceArmarios.ClasesBd;

namespace DespieceArmarios
{
    public partial class FormInicio : System.Windows.Forms.Form
    {
        private string nombreCliente;
        private string nombreObra;

        public FormInicio()
        {
            InitializeComponent();
            Configuracion();
            EngancharEventos();
        }

        private void EngancharEventos()
        {
            butNuevo.Click += ButNuevo_Click; ;
            butBuscar.Click += ButBuscar_Click;
        }

       
        private void ButNuevo_Click(object sender, EventArgs e)
        {
            this.nombreCliente = textBoxCliente.Text;
            this.nombreObra = textBoxTrabajo.Text;
            if (!string.IsNullOrEmpty(nombreCliente) && !string.IsNullOrEmpty(nombreObra))
            {
                CallBbdd.SaveClienteObra(nombreCliente, nombreObra);
                FormMenu formMenu = new FormMenu(nombreCliente,nombreObra);
                textBoxCliente.Clear();
                textBoxTrabajo.Clear();
                butNuevo.Enabled = false;
                butBuscar.Enabled = false;
                formMenu.FormClosed += (o, es) => { butBuscar.Enabled = true; butNuevo.Enabled = true; };
                formMenu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor indica nombres de referencia en '" + labelCliente.Text + "' y '" + labelObra.Text + "'.");
            }
        }        

        private void ButBuscar_Click(object sender, EventArgs e)
        {
            //FormVerDatos form = new FormVerDatos();
            //form.ShowDialog();
            MessageBox.Show("Funcionalidad en construccion");
        }

        private void Configuracion()
        {
            ConfiguracionElementos.miForm(this);
            ConfiguracionElementos.miButtonInicio(butNuevo);
            ConfiguracionElementos.miButtonInicio(butBuscar);
        }
    }
}
