namespace DespieceArmarios.Formularios
{
    partial class FormImpresion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImpresion));
            this.ArmarioFullBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ArmarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PiezaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ArmarioPiezasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MedidasTotalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ArmarioFullBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArmarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PiezaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArmarioPiezasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedidasTotalesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ArmarioFullBindingSource
            // 
            this.ArmarioFullBindingSource.DataSource = typeof(DespieceArmarios.Clases.ArmarioFull);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ArmarioFullBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DespieceArmarios.Reports.Report1.rdlc";
            this.reportViewer1.LocalReport.ReportPath = "C:\\Users\\kike\\Source\\Repos\\Lansaque Despiece Armarios\\DespieceArmarios\\Reports\\Re" +
    "port1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // ArmarioBindingSource
            // 
            this.ArmarioBindingSource.DataSource = typeof(DespieceArmarios.Clases.Armario);
            // 
            // PiezaBindingSource
            // 
            this.PiezaBindingSource.DataSource = typeof(DespieceArmarios.Clases.Pieza);
            // 
            // ArmarioPiezasBindingSource
            // 
            this.ArmarioPiezasBindingSource.DataMember = "piezas";
            this.ArmarioPiezasBindingSource.DataSource = typeof(DespieceArmarios.Clases.ArmarioPiezas);
            // 
            // MedidasTotalesBindingSource
            // 
            this.MedidasTotalesBindingSource.DataSource = typeof(DespieceArmarios.Clases.MedidasTotales);
            // 
            // FormImpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormImpresion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informes";
            this.Load += new System.EventHandler(this.FormImpresion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ArmarioFullBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArmarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PiezaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArmarioPiezasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedidasTotalesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ArmarioBindingSource;
        private System.Windows.Forms.BindingSource PiezaBindingSource;
        private System.Windows.Forms.BindingSource ArmarioPiezasBindingSource;
        private System.Windows.Forms.BindingSource ArmarioFullBindingSource;
        private System.Windows.Forms.BindingSource MedidasTotalesBindingSource;
    }
}