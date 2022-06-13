namespace DespieceArmarios.Formularios
{
    partial class FormVerDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerDatos));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.titulo = new System.Windows.Forms.Label();
            this.buttonVerDatos = new System.Windows.Forms.Button();
            this.textBoxDatoss = new System.Windows.Forms.TextBox();
            this.buttonAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 151);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(913, 533);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.Tag = "Clientes";
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.Location = new System.Drawing.Point(508, 24);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(151, 39);
            this.titulo.TabIndex = 7;
            this.titulo.Text = "Clientes";
            // 
            // buttonVerDatos
            // 
            this.buttonVerDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVerDatos.Location = new System.Drawing.Point(12, 98);
            this.buttonVerDatos.Name = "buttonVerDatos";
            this.buttonVerDatos.Size = new System.Drawing.Size(196, 41);
            this.buttonVerDatos.TabIndex = 8;
            this.buttonVerDatos.Text = "Ver datos";
            this.buttonVerDatos.UseVisualStyleBackColor = true;
            // 
            // textBoxDatoss
            // 
            this.textBoxDatoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDatoss.Location = new System.Drawing.Point(265, 103);
            this.textBoxDatoss.Name = "textBoxDatoss";
            this.textBoxDatoss.Size = new System.Drawing.Size(660, 31);
            this.textBoxDatoss.TabIndex = 9;
            // 
            // buttonAtras
            // 
            this.buttonAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAtras.Location = new System.Drawing.Point(12, 27);
            this.buttonAtras.Name = "buttonAtras";
            this.buttonAtras.Size = new System.Drawing.Size(196, 41);
            this.buttonAtras.TabIndex = 10;
            this.buttonAtras.Text = "Atras";
            this.buttonAtras.UseVisualStyleBackColor = true;
            // 
            // FormVerDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 698);
            this.Controls.Add(this.buttonAtras);
            this.Controls.Add(this.textBoxDatoss);
            this.Controls.Add(this.buttonVerDatos);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVerDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVerDatos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Button buttonVerDatos;
        private System.Windows.Forms.TextBox textBoxDatoss;
        private System.Windows.Forms.Button buttonAtras;
    }
}