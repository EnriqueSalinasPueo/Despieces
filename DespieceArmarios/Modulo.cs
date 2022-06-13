using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DespieceArmarios.ClasesApoyo.ClasesParticular;

namespace DespieceArmarios
{
    public partial class Modulo : UserControl
    {

        public InfoModulo Info { get; set; } = new InfoModulo();
        public int NumeroBaldas
        {
            get => Info.NumeroBaldas; set
            {
                Info.NumeroBaldas = value;
                PintarBaldas();
            }
        }


        public bool hayCajonara
        {
            get => Info.HayCajonera; set
            {
                Info.HayCajonera = value;
                PintarCajonera();
            }
        }

        private void PintarCajonera()
        {
            if (hayCajonara)
            {
                pictureBoxCajonera.Visible = true;
            }
            else
            {
                pictureBoxCajonera.Visible = false;
            }
        }

        public Modulo(int numeroModulo)
        {
            InitializeComponent();
            groupBoxModulo1.Text = "Modulo " + numeroModulo.ToString();
        }

        private void PintarBaldas()
        {
            if (NumeroBaldas == 0)
            {
                pictureBoxBalda1.Visible = false;
                pictureBoxBalda2.Visible = false;
                pictureBoxBalda3.Visible = false;
                pictureBoxBalda4.Visible = false;
                pictureBoxBalda5.Visible = false;
                pictureBoxBalda6.Visible = false;
                pictureBoxBalda7.Visible = false;
                pictureBoxBalda8.Visible = false;
                pictureBoxBalda9.Visible = false;
                pictureBoxBalda10.Visible = false;
            }
            else if (NumeroBaldas == 1)
            {
                pictureBoxBalda1.Visible = true;
                pictureBoxBalda2.Visible = false;
                pictureBoxBalda3.Visible = false;
                pictureBoxBalda4.Visible = false;
                pictureBoxBalda5.Visible = false;
                pictureBoxBalda6.Visible = false;
                pictureBoxBalda7.Visible = false;
                pictureBoxBalda8.Visible = false;
                pictureBoxBalda9.Visible = false;
                pictureBoxBalda10.Visible = false;

            }
            else if (NumeroBaldas == 2)
            {
                pictureBoxBalda1.Visible = true;
                pictureBoxBalda2.Visible = true;
                pictureBoxBalda3.Visible = false;
                pictureBoxBalda4.Visible = false;
                pictureBoxBalda5.Visible = false;
                pictureBoxBalda6.Visible = false;
                pictureBoxBalda7.Visible = false;
                pictureBoxBalda8.Visible = false;
                pictureBoxBalda9.Visible = false;
                pictureBoxBalda10.Visible = false;

            }
            else if (NumeroBaldas == 3)
            {
                pictureBoxBalda1.Visible = true;
                pictureBoxBalda2.Visible = true;
                pictureBoxBalda3.Visible = true;
                pictureBoxBalda4.Visible = false;
                pictureBoxBalda5.Visible = false;
                pictureBoxBalda6.Visible = false;
                pictureBoxBalda7.Visible = false;
                pictureBoxBalda8.Visible = false;
                pictureBoxBalda9.Visible = false;
                pictureBoxBalda10.Visible = false;

            }
            else if (NumeroBaldas == 4)
            {
                pictureBoxBalda1.Visible = true;
                pictureBoxBalda2.Visible = true;
                pictureBoxBalda3.Visible = true;
                pictureBoxBalda4.Visible = true;
                pictureBoxBalda5.Visible = false;
                pictureBoxBalda6.Visible = false;
                pictureBoxBalda7.Visible = false;
                pictureBoxBalda8.Visible = false;
                pictureBoxBalda9.Visible = false;
                pictureBoxBalda10.Visible = false;

            }
            else if (NumeroBaldas == 5)
            {
                pictureBoxBalda1.Visible = true;
                pictureBoxBalda2.Visible = true;
                pictureBoxBalda3.Visible = true;
                pictureBoxBalda4.Visible = true;
                pictureBoxBalda5.Visible = true;
                pictureBoxBalda6.Visible = false;
                pictureBoxBalda7.Visible = false;
                pictureBoxBalda8.Visible = false;
                pictureBoxBalda9.Visible = false;
                pictureBoxBalda10.Visible = false;

            }
            else if (NumeroBaldas == 6)
            {
                pictureBoxBalda1.Visible = true;
                pictureBoxBalda2.Visible = true;
                pictureBoxBalda3.Visible = true;
                pictureBoxBalda4.Visible = true;
                pictureBoxBalda5.Visible = true;
                pictureBoxBalda6.Visible = true;
                pictureBoxBalda7.Visible = false;
                pictureBoxBalda8.Visible = false;
                pictureBoxBalda9.Visible = false;
                pictureBoxBalda10.Visible = false;

            }
            else if (NumeroBaldas == 7)
            {
                pictureBoxBalda1.Visible = true;
                pictureBoxBalda2.Visible = true;
                pictureBoxBalda3.Visible = true;
                pictureBoxBalda4.Visible = true;
                pictureBoxBalda5.Visible = true;
                pictureBoxBalda6.Visible = true;
                pictureBoxBalda7.Visible = true;
                pictureBoxBalda8.Visible = false;
                pictureBoxBalda9.Visible = false;
                pictureBoxBalda10.Visible = false;

            }
            else if (NumeroBaldas == 8)
            {
                pictureBoxBalda1.Visible = true;
                pictureBoxBalda2.Visible = true;
                pictureBoxBalda3.Visible = true;
                pictureBoxBalda4.Visible = true;
                pictureBoxBalda5.Visible = true;
                pictureBoxBalda6.Visible = true;
                pictureBoxBalda7.Visible = true;
                pictureBoxBalda8.Visible = true;
                pictureBoxBalda9.Visible = false;
                pictureBoxBalda10.Visible = false;

            }
            else if (NumeroBaldas == 9)
            {
                pictureBoxBalda1.Visible = true;
                pictureBoxBalda2.Visible = true;
                pictureBoxBalda3.Visible = true;
                pictureBoxBalda4.Visible = true;
                pictureBoxBalda5.Visible = true;
                pictureBoxBalda6.Visible = true;
                pictureBoxBalda7.Visible = true;
                pictureBoxBalda8.Visible = true;
                pictureBoxBalda9.Visible = true;
                pictureBoxBalda10.Visible = false;

            }
            else if (NumeroBaldas == 10)
            {
                pictureBoxBalda1.Visible = true;
                pictureBoxBalda2.Visible = true;
                pictureBoxBalda3.Visible = true;
                pictureBoxBalda4.Visible = true;
                pictureBoxBalda5.Visible = true;
                pictureBoxBalda6.Visible = true;
                pictureBoxBalda7.Visible = true;
                pictureBoxBalda8.Visible = true;
                pictureBoxBalda9.Visible = true;
                pictureBoxBalda10.Visible = true;

            }
        }
    }
}
