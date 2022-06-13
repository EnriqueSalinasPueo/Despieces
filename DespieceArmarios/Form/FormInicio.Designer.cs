namespace DespieceArmarios
{
    partial class FormInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            this.labelCliente = new System.Windows.Forms.Label();
            this.butNuevo = new System.Windows.Forms.Button();
            this.labelObra = new System.Windows.Forms.Label();
            this.textBoxCliente = new System.Windows.Forms.TextBox();
            this.textBoxTrabajo = new System.Windows.Forms.TextBox();
            this.butBuscar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCliente.Location = new System.Drawing.Point(143, 394);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(93, 25);
            this.labelCliente.TabIndex = 4;
            this.labelCliente.Text = "Cliente ";
            // 
            // butNuevo
            // 
            this.butNuevo.Location = new System.Drawing.Point(148, 334);
            this.butNuevo.Name = "butNuevo";
            this.butNuevo.Size = new System.Drawing.Size(153, 30);
            this.butNuevo.TabIndex = 3;
            this.butNuevo.Text = "Nuevo";
            this.toolTip1.SetToolTip(this.butNuevo, "Crea una nueva obra asociada a un cliente.");
            this.butNuevo.UseVisualStyleBackColor = true;
            // 
            // labelObra
            // 
            this.labelObra.AutoSize = true;
            this.labelObra.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelObra.Location = new System.Drawing.Point(143, 439);
            this.labelObra.Name = "labelObra";
            this.labelObra.Size = new System.Drawing.Size(63, 25);
            this.labelObra.TabIndex = 5;
            this.labelObra.Text = "Obra";
            // 
            // textBoxCliente
            // 
            this.textBoxCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCliente.Location = new System.Drawing.Point(283, 399);
            this.textBoxCliente.Name = "textBoxCliente";
            this.textBoxCliente.Size = new System.Drawing.Size(225, 22);
            this.textBoxCliente.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBoxCliente, "Introduce el nombre para quien es el trabajo.");
            // 
            // textBoxTrabajo
            // 
            this.textBoxTrabajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTrabajo.Location = new System.Drawing.Point(283, 439);
            this.textBoxTrabajo.Name = "textBoxTrabajo";
            this.textBoxTrabajo.Size = new System.Drawing.Size(225, 22);
            this.textBoxTrabajo.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxTrabajo, "Introduce un nombre para referencar a la obra.");
            // 
            // butBuscar
            // 
            this.butBuscar.Location = new System.Drawing.Point(355, 334);
            this.butBuscar.Name = "butBuscar";
            this.butBuscar.Size = new System.Drawing.Size(153, 30);
            this.butBuscar.TabIndex = 0;
            this.butBuscar.Text = "Buscar";
            this.toolTip1.SetToolTip(this.butBuscar, "Buscar en las obras de los clientes ya realizadas.");
            this.butBuscar.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DespieceArmarios.Properties.Resources.logo_lansaque_sin_texto__1_;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(662, 292);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 509);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.butBuscar);
            this.Controls.Add(this.textBoxTrabajo);
            this.Controls.Add(this.textBoxCliente);
            this.Controls.Add(this.labelObra);
            this.Controls.Add(this.butNuevo);
            this.Controls.Add(this.labelCliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(703, 548);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(703, 548);
            this.Name = "FormInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Depiece armarios.";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Button butNuevo;
        private System.Windows.Forms.Label labelObra;
        private System.Windows.Forms.TextBox textBoxCliente;
        private System.Windows.Forms.TextBox textBoxTrabajo;
        private System.Windows.Forms.Button butBuscar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

