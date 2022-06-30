using DespieceArmarios.Clases;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespieceArmarios.Formularios
{
    public partial class FormImpresion : System.Windows.Forms.Form
    {
        private List<ArmarioFull> armarios;
        private List<MedidasTotales> medidasTotales;
        private string quienLlama = string.Empty;

        public FormImpresion(List<ArmarioFull> armarios)
        {
            this.armarios = armarios;
            quienLlama = "armarios";
            InitializeComponent();
            
        }

        public FormImpresion(List<MedidasTotales> medidasTotales)
        {
            this.medidasTotales = medidasTotales;
            quienLlama = "medidas";
            InitializeComponent();
        }

        private void FormImpresion_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void CargarReporte()
        {
            if(quienLlama == "armarios")
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "espieceArmarios.Reports.Report1.rdlc";
                reportViewer1.LocalReport.ReportPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Reports", "Report1.rdlc");
                ArmarioFullBindingSource.DataSource = armarios;

                this.reportViewer1.RefreshReport();

            }

            if (quienLlama == "medidas")
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "espieceArmarios.Reports.Report.rdlc";
                reportViewer1.LocalReport.ReportPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Reports", "Report.rdlc");
                MedidasTotalesBindingSource.DataSource = medidasTotales;

                this.reportViewer1.RefreshReport();

            }


        }
    }


}
