using DespieceArmarios.CapaDatos.ClasesORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespieceArmarios.Form
{
    public partial class FormGuiaCajonera : System.Windows.Forms.Form
    {
        private List<GuiaCajon> Guias { set; get; } = new List<GuiaCajon>();

        public FormGuiaCajonera()
        {
            InitializeComponent();
            CargarGrid();
        }

        private void CargarGrid()
        {
            Guias =  
        }
    }
}
