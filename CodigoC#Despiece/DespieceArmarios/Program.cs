using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespieceArmarios
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DateTime Caducidad = new DateTime(2025,6,1);

            if(DateTime.Now > Caducidad)
            {
                MessageBox.Show("Licencia caducada");
                Application.Exit();
            }
            else
            {
                try
                {
                    Application.Run(new FormInicio());

                }
                catch (Exception)
                {

                    MessageBox.Show("Funcion todavia no implementada");
                }
            }

        }
    }
}
