using System.Drawing;
using System.Windows.Forms;

namespace DespieceArmarios.Clases
{
    static class ConfiguracionElementos
    {
        private static Color colorFondoElementos = SystemColors.Control;
        private static Color colorTextoElementos = Color.Black;
        private static Color colorFondoButInicio = Color.Black;
        private static Color colorTextoButInicio = SystemColors.Control;
        private static Color colorFondoForm = SystemColors.ActiveCaption;
        //private static Icon iconoVentanas = new Icon("");

        public static void miButton(Button button)
        {
            button.BackColor = colorFondoElementos;
            button.ForeColor = colorTextoElementos;
        }
        public static void miButtonInicio(Button button)
        {
            button.BackColor = colorFondoButInicio;
            button.ForeColor = colorTextoButInicio;
        }

        public static void miTextBox(TextBox textBox)
        {
            textBox.BackColor = colorFondoElementos;
            textBox.ForeColor = colorTextoElementos;
        }
        public static void miRichTextBox(RichTextBox richTextBox)
        {
            richTextBox.BackColor = colorFondoElementos;
            richTextBox.ForeColor = colorTextoElementos;
        }

        public static void miListBox(ListBox listBox)
        {
            listBox.BackColor = colorFondoElementos;
            listBox.ForeColor = colorTextoElementos;
        }
        public static void miComboBox(ComboBox comboBox)
        {
            comboBox.BackColor = colorFondoElementos;
            comboBox.ForeColor = colorTextoElementos;
        }

        public static void miForm(System.Windows.Forms.Form form)
        {
            form.BackColor = colorFondoForm;
            //form.Icon = iconoVentanas;
        }
        public static void miLabel(Label label)
        {
            label.BackColor = colorFondoElementos;
            label.BackColor = colorTextoElementos;
        }
    }
}
