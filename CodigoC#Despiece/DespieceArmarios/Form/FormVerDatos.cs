using Dapper;
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

namespace DespieceArmarios.Formularios
{
    public partial class FormVerDatos : System.Windows.Forms.Form
    {
        private List<Cliente> clientes = null;
        private List<Obra> obras = null;
        private List<Armario> armarios = null;
        private List<Pieza> piezas = null;

        private Cliente cliente;
        private Obra obra;
        private Armario armario;
        private Pieza pieza;

        private string quienllama = "Clientes";
        private int id = 0;

        public FormVerDatos()
        {
            InitializeComponent();
            Configuracion();
            EngancharEventos();
        }

        public FormVerDatos(string quienllama, int id)
        {
            this.quienllama = quienllama;
            this.id = id;
            InitializeComponent();
            Configuracion();
            EngancharEventos();
        }

        private void EngancharEventos()
        {
            titulo.Text = dataGridView.Tag.ToString(); 
            this.Load += FormVerDatos_LoadAsync;
            buttonVerDatos.Click += ButtonVerDatos_Click;
        }

        private void ButtonVerDatos_Click(object sender, EventArgs e)
        {


            if (quienllama == "Clientes")
            {   
            }

            if (quienllama == "Obras")
            {
            }

            if (quienllama == "Armarios")
            {
            }

            if (quienllama == "Piezas")
            {
            }
        }

        private async void FormVerDatos_LoadAsync(object sender, EventArgs e)
        {
            if(quienllama == "Clientes")
            {
                using (var conn = Bd.GetConnection())
                {
                    clientes = (await conn.QueryAsync<Cliente>("SELECT * FROM cliente order by nombre")).ToList();
                    conn.Close();
                }
                dataGridView.SelectionChanged += DataGridView_SelectionChanged;
                dataGridView.DataSource = clientes;
            }

            if (quienllama == "Obras")
            {
                using (var conn = Bd.GetConnection())
                {
                    obras = (await conn.QueryAsync<Obra>("SELECT * FROM obra where id_cliente = " + cliente.id_cliente + " order by nombre")).ToList();
                    conn.Close();
                }
                dataGridView.SelectionChanged += DataGridView_SelectionChanged;
                dataGridView.DataSource = clientes;
            }

            if (quienllama == "Armarios")
            {
                using (var conn = Bd.GetConnection())
                {
                    armarios = (await conn.QueryAsync<Armario>("SELECT * FROM armario where id_tabajo = " + obra.id_obra + " order by nombre")).ToList();
                    conn.Close();
                }

                dataGridView.SelectionChanged += DataGridView_SelectionChanged;
                dataGridView.DataSource = clientes;
            }

            if (quienllama == "Piezas")
            {
                using (var conn = Bd.GetConnection())
                {
                    piezas = (await conn.QueryAsync<Pieza>("SELECT * FROM pieza where id_armario = " + armario.id_armario + " order by nombre")).ToList();
                    conn.Close();
                }
                dataGridView.SelectionChanged += DataGridView_SelectionChanged;
                dataGridView.DataSource = clientes;
            }
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                if (dataGridView.CurrentRow.DataBoundItem is Cliente cliente)
                {
                    textBoxDatoss.Text = cliente.nombre;
                }

                if (dataGridView.CurrentRow.DataBoundItem is Obra obra)
                {
                    textBoxDatoss.Text = obra.nombre;
                }

                if (dataGridView.CurrentRow.DataBoundItem is Armario armario)
                {
                    textBoxDatoss.Text = "Armarmio --> " + armario.escalera + " / " + armario.piso + armario.habitacion + " / ";
                }

                if (dataGridView.CurrentRow.DataBoundItem is Pieza pieza)
                {
                    textBoxDatoss.Text = "Pieza --> " + pieza.nombre  ;
                }
            }
        }

        private void Configuracion()
        {
            ConfiguracionElementos.miForm(this);
            ConfiguracionElementos.miButtonInicio(buttonVerDatos);
            ConfiguracionElementos.miButtonInicio(buttonAtras);
        }
    }
}
