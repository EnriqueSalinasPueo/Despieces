namespace DespieceArmarios
{
    partial class FormModificarGuia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModificarGuia));
            this.label1 = new System.Windows.Forms.Label();
            this.labelMarca = new System.Windows.Forms.Label();
            this.labelModelo = new System.Windows.Forms.Label();
            this.labelPerfil = new System.Windows.Forms.Label();
            this.labelDescontarPuerta = new System.Windows.Forms.Label();
            this.labelAltoGuia = new System.Windows.Forms.Label();
            this.labelAnchoGuia = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxImagen = new System.Windows.Forms.PictureBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericDescontar3Puertas = new System.Windows.Forms.NumericUpDown();
            this.numericDescontar2Puertas = new System.Windows.Forms.NumericUpDown();
            this.labelDescontarTres = new System.Windows.Forms.Label();
            this.labelDescontarDos = new System.Windows.Forms.Label();
            this.APartidoPuertasDescontar = new System.Windows.Forms.RadioButton();
            this.ADescontarPartidoPuertas = new System.Windows.Forms.RadioButton();
            this.numericAltoGuia = new System.Windows.Forms.NumericUpDown();
            this.numericAnchoGuia = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMilimetrosPerfil = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDescontarAlto = new System.Windows.Forms.NumericUpDown();
            this.textBoxModelo = new System.Windows.Forms.TextBox();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDescontar3Puertas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDescontar2Puertas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAltoGuia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnchoGuia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMilimetrosPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDescontarAlto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1009, 93);
            this.label1.TabIndex = 0;
            this.label1.Text = "Introduce los datos de la Guía con la que vas a trabajar. \r\n\r\nIntroduce todas las" +
    " medidas en milímetros y despues pulsa el botón guardar.";
            // 
            // labelMarca
            // 
            this.labelMarca.AutoSize = true;
            this.labelMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelMarca.Location = new System.Drawing.Point(28, 42);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(62, 24);
            this.labelMarca.TabIndex = 1;
            this.labelMarca.Text = "Marca";
            this.toolTip1.SetToolTip(this.labelMarca, "En nombre de la marca de la guía para identificarla.");
            // 
            // labelModelo
            // 
            this.labelModelo.AutoSize = true;
            this.labelModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelModelo.Location = new System.Drawing.Point(28, 88);
            this.labelModelo.Name = "labelModelo";
            this.labelModelo.Size = new System.Drawing.Size(74, 24);
            this.labelModelo.TabIndex = 2;
            this.labelModelo.Text = "Modelo";
            this.toolTip1.SetToolTip(this.labelModelo, "El modelo de la guía para poder identificarla.");
            // 
            // labelPerfil
            // 
            this.labelPerfil.AutoSize = true;
            this.labelPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelPerfil.Location = new System.Drawing.Point(28, 187);
            this.labelPerfil.Name = "labelPerfil";
            this.labelPerfil.Size = new System.Drawing.Size(416, 24);
            this.labelPerfil.TabIndex = 3;
            this.labelPerfil.Text = "Milimetros que se introduce la puerta en el perfil ";
            this.toolTip1.SetToolTip(this.labelPerfil, "Sirve para determinar el largo de las piezas en U que van debajo de las puertas.\r" +
        "\nSOLO EN UNO DE LOS PERFILES.\r\n");
            // 
            // labelDescontarPuerta
            // 
            this.labelDescontarPuerta.AutoSize = true;
            this.labelDescontarPuerta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelDescontarPuerta.Location = new System.Drawing.Point(28, 140);
            this.labelDescontarPuerta.Name = "labelDescontarPuerta";
            this.labelDescontarPuerta.Size = new System.Drawing.Size(266, 24);
            this.labelDescontarPuerta.TabIndex = 4;
            this.labelDescontarPuerta.Text = "Descontar a las puertas de alto";
            this.toolTip1.SetToolTip(this.labelDescontarPuerta, "Milímetros que hay que descontar a la puerta para su funcionamiento.");
            // 
            // labelAltoGuia
            // 
            this.labelAltoGuia.AutoSize = true;
            this.labelAltoGuia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelAltoGuia.Location = new System.Drawing.Point(28, 278);
            this.labelAltoGuia.Name = "labelAltoGuia";
            this.labelAltoGuia.Size = new System.Drawing.Size(200, 24);
            this.labelAltoGuia.TabIndex = 5;
            this.labelAltoGuia.Text = "Alto de la Guía supeior";
            // 
            // labelAnchoGuia
            // 
            this.labelAnchoGuia.AutoSize = true;
            this.labelAnchoGuia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelAnchoGuia.Location = new System.Drawing.Point(28, 234);
            this.labelAnchoGuia.Name = "labelAnchoGuia";
            this.labelAnchoGuia.Size = new System.Drawing.Size(224, 24);
            this.labelAnchoGuia.TabIndex = 6;
            this.labelAnchoGuia.Text = "Ancho de la Guía supeior";
            this.toolTip1.SetToolTip(this.labelAnchoGuia, "Milímetros que tiene de ancho la guia con la que trabajamos.");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxImagen);
            this.groupBox1.Controls.Add(this.buttonGuardar);
            this.groupBox1.Controls.Add(this.buttonSalir);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.numericAltoGuia);
            this.groupBox1.Controls.Add(this.numericAnchoGuia);
            this.groupBox1.Controls.Add(this.numericUpDownMilimetrosPerfil);
            this.groupBox1.Controls.Add(this.numericUpDownDescontarAlto);
            this.groupBox1.Controls.Add(this.textBoxModelo);
            this.groupBox1.Controls.Add(this.textBoxMarca);
            this.groupBox1.Controls.Add(this.labelMarca);
            this.groupBox1.Controls.Add(this.labelAnchoGuia);
            this.groupBox1.Controls.Add(this.labelModelo);
            this.groupBox1.Controls.Add(this.labelAltoGuia);
            this.groupBox1.Controls.Add(this.labelPerfil);
            this.groupBox1.Controls.Add(this.labelDescontarPuerta);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(62, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(999, 435);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Guia";
            this.toolTip1.SetToolTip(this.groupBox1, "Datos generales de la guía con la que vamos a trabajar.\r\n");
            // 
            // pictureBoxImagen
            // 
            this.pictureBoxImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxImagen.Location = new System.Drawing.Point(610, 50);
            this.pictureBoxImagen.Name = "pictureBoxImagen";
            this.pictureBoxImagen.Size = new System.Drawing.Size(374, 341);
            this.pictureBoxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImagen.TabIndex = 92;
            this.pictureBoxImagen.TabStop = false;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardar.Location = new System.Drawing.Point(610, 397);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(374, 29);
            this.buttonGuardar.TabIndex = 7;
            this.buttonGuardar.Text = "Guardar";
            this.toolTip1.SetToolTip(this.buttonGuardar, "Botón para guardar los datos de la guía en base de datos.");
            this.buttonGuardar.UseVisualStyleBackColor = true;
            // 
            // buttonSalir
            // 
            this.buttonSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalir.Location = new System.Drawing.Point(610, 15);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(374, 29);
            this.buttonSalir.TabIndex = 8;
            this.buttonSalir.Text = "Salir ";
            this.toolTip1.SetToolTip(this.buttonSalir, "Botón para salir del formulario.");
            this.buttonSalir.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericDescontar3Puertas);
            this.groupBox2.Controls.Add(this.numericDescontar2Puertas);
            this.groupBox2.Controls.Add(this.labelDescontarTres);
            this.groupBox2.Controls.Add(this.labelDescontarDos);
            this.groupBox2.Controls.Add(this.APartidoPuertasDescontar);
            this.groupBox2.Controls.Add(this.ADescontarPartidoPuertas);
            this.groupBox2.Location = new System.Drawing.Point(32, 321);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(527, 105);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de formula";
            this.toolTip1.SetToolTip(this.groupBox2, "Marca el tipo de fórmula que se utiliza  para determinar el ancho de las puertas " +
        "correderas.");
            // 
            // numericDescontar3Puertas
            // 
            this.numericDescontar3Puertas.Location = new System.Drawing.Point(179, 65);
            this.numericDescontar3Puertas.Name = "numericDescontar3Puertas";
            this.numericDescontar3Puertas.Size = new System.Drawing.Size(89, 26);
            this.numericDescontar3Puertas.TabIndex = 1;
            this.toolTip1.SetToolTip(this.numericDescontar3Puertas, "Milimetros que hay que descontar en la formula seleccionada, en este caso para tr" +
        "es puertas.\r\nSUSTITUCIÖN EN LA FÓRMULA --> \"descontar\" = milímetros introducidos" +
        ".");
            // 
            // numericDescontar2Puertas
            // 
            this.numericDescontar2Puertas.Location = new System.Drawing.Point(179, 25);
            this.numericDescontar2Puertas.Name = "numericDescontar2Puertas";
            this.numericDescontar2Puertas.Size = new System.Drawing.Size(89, 26);
            this.numericDescontar2Puertas.TabIndex = 0;
            this.toolTip1.SetToolTip(this.numericDescontar2Puertas, "Milimetros que hay que descontar en la formula seleccionada, en este caso para do" +
        "s puertas.\r\nSUSTITUCIÖN EN LA FÓRMULA --> \"descontar\" = milímetros introducidos." +
        "");
            // 
            // labelDescontarTres
            // 
            this.labelDescontarTres.AutoSize = true;
            this.labelDescontarTres.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescontarTres.Location = new System.Drawing.Point(10, 68);
            this.labelDescontarTres.Name = "labelDescontarTres";
            this.labelDescontarTres.Size = new System.Drawing.Size(142, 18);
            this.labelDescontarTres.TabIndex = 45;
            this.labelDescontarTres.Text = "Descontar 3 puertas";
            this.toolTip1.SetToolTip(this.labelDescontarTres, "Milimetros que hay que descontar en la formula seleccionada, en este caso para tr" +
        "es puertas.\r\nSUSTITUCIÖN EN LA FÓRMULA --> \"descontar\" = milímetros introducidos" +
        ".\r\n");
            // 
            // labelDescontarDos
            // 
            this.labelDescontarDos.AutoSize = true;
            this.labelDescontarDos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescontarDos.Location = new System.Drawing.Point(10, 28);
            this.labelDescontarDos.Name = "labelDescontarDos";
            this.labelDescontarDos.Size = new System.Drawing.Size(142, 18);
            this.labelDescontarDos.TabIndex = 44;
            this.labelDescontarDos.Text = "Descontar 2 puertas";
            this.toolTip1.SetToolTip(this.labelDescontarDos, "Milimetros que hay que descontar en la formula seleccionada, en este caso para do" +
        "s puertas.\r\nSUSTITUCIÖN EN LA FÓRMULA --> \"descontar\" = milímetros introducidos." +
        "\r\n");
            // 
            // APartidoPuertasDescontar
            // 
            this.APartidoPuertasDescontar.AutoSize = true;
            this.APartidoPuertasDescontar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.APartidoPuertasDescontar.Location = new System.Drawing.Point(312, 65);
            this.APartidoPuertasDescontar.Name = "APartidoPuertasDescontar";
            this.APartidoPuertasDescontar.Size = new System.Drawing.Size(186, 24);
            this.APartidoPuertasDescontar.TabIndex = 3;
            this.APartidoPuertasDescontar.Tag = "a/puertas-descontar";
            this.APartidoPuertasDescontar.Text = "a / puertas - descontar";
            this.toolTip1.SetToolTip(this.APartidoPuertasDescontar, "La formula para sacar las medidas de ancho de las puertas es del tipo.\r\naltura / " +
        "puertas - milimetros a descontar\r\n");
            this.APartidoPuertasDescontar.UseVisualStyleBackColor = true;
            // 
            // ADescontarPartidoPuertas
            // 
            this.ADescontarPartidoPuertas.AutoSize = true;
            this.ADescontarPartidoPuertas.Checked = true;
            this.ADescontarPartidoPuertas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADescontarPartidoPuertas.Location = new System.Drawing.Point(312, 25);
            this.ADescontarPartidoPuertas.Name = "ADescontarPartidoPuertas";
            this.ADescontarPartidoPuertas.Size = new System.Drawing.Size(186, 24);
            this.ADescontarPartidoPuertas.TabIndex = 2;
            this.ADescontarPartidoPuertas.TabStop = true;
            this.ADescontarPartidoPuertas.Tag = "a-descontar/puertas";
            this.ADescontarPartidoPuertas.Text = "a - descontar / puertas";
            this.toolTip1.SetToolTip(this.ADescontarPartidoPuertas, "La formula para sacar las medidas de ancho de las puertas es del tipo.\r\naltura - " +
        "milímetros a descontar / puertas");
            this.ADescontarPartidoPuertas.UseVisualStyleBackColor = true;
            // 
            // numericAltoGuia
            // 
            this.numericAltoGuia.Location = new System.Drawing.Point(296, 279);
            this.numericAltoGuia.Name = "numericAltoGuia";
            this.numericAltoGuia.Size = new System.Drawing.Size(89, 26);
            this.numericAltoGuia.TabIndex = 5;
            this.toolTip1.SetToolTip(this.numericAltoGuia, "Milímetros que tiene de alto la guia con la que trabajamos.");
            // 
            // numericAnchoGuia
            // 
            this.numericAnchoGuia.Location = new System.Drawing.Point(296, 235);
            this.numericAnchoGuia.Name = "numericAnchoGuia";
            this.numericAnchoGuia.Size = new System.Drawing.Size(89, 26);
            this.numericAnchoGuia.TabIndex = 4;
            this.toolTip1.SetToolTip(this.numericAnchoGuia, "Milímetros que tiene de ancho la guia con la que trabajamos.");
            // 
            // numericUpDownMilimetrosPerfil
            // 
            this.numericUpDownMilimetrosPerfil.Location = new System.Drawing.Point(470, 188);
            this.numericUpDownMilimetrosPerfil.Name = "numericUpDownMilimetrosPerfil";
            this.numericUpDownMilimetrosPerfil.Size = new System.Drawing.Size(89, 26);
            this.numericUpDownMilimetrosPerfil.TabIndex = 3;
            this.toolTip1.SetToolTip(this.numericUpDownMilimetrosPerfil, "Sirve para determinar el largo de las piezas en U que van debajo de las puertas.\r" +
        "\nSOLO EN UNO DE LOS PERFILES.\r\n\r\n");
            // 
            // numericUpDownDescontarAlto
            // 
            this.numericUpDownDescontarAlto.Location = new System.Drawing.Point(470, 141);
            this.numericUpDownDescontarAlto.Name = "numericUpDownDescontarAlto";
            this.numericUpDownDescontarAlto.Size = new System.Drawing.Size(89, 26);
            this.numericUpDownDescontarAlto.TabIndex = 2;
            this.toolTip1.SetToolTip(this.numericUpDownDescontarAlto, "Milímetros que hay que descontar a la puerta para su funcionamiento.");
            // 
            // textBoxModelo
            // 
            this.textBoxModelo.Location = new System.Drawing.Point(119, 88);
            this.textBoxModelo.Name = "textBoxModelo";
            this.textBoxModelo.Size = new System.Drawing.Size(228, 26);
            this.textBoxModelo.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBoxModelo, "El modelo de la guía para poder identificarla.");
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Location = new System.Drawing.Point(119, 42);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.Size = new System.Drawing.Size(228, 26);
            this.textBoxMarca.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxMarca, "En nombre de la marca de la guía para identificarla.");
            // 
            // FormModificarGuia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 579);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormModificarGuia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Guia";
            this.toolTip1.SetToolTip(this, "Altura - milímetros a descontar / numero de puertas");
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDescontar3Puertas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDescontar2Puertas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAltoGuia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnchoGuia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMilimetrosPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDescontarAlto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMarca;
        private System.Windows.Forms.Label labelModelo;
        private System.Windows.Forms.Label labelPerfil;
        private System.Windows.Forms.Label labelDescontarPuerta;
        private System.Windows.Forms.Label labelAltoGuia;
        private System.Windows.Forms.Label labelAnchoGuia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownMilimetrosPerfil;
        private System.Windows.Forms.NumericUpDown numericUpDownDescontarAlto;
        private System.Windows.Forms.TextBox textBoxModelo;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericAltoGuia;
        private System.Windows.Forms.NumericUpDown numericAnchoGuia;
        private System.Windows.Forms.RadioButton APartidoPuertasDescontar;
        private System.Windows.Forms.RadioButton ADescontarPartidoPuertas;
        private System.Windows.Forms.NumericUpDown numericDescontar3Puertas;
        private System.Windows.Forms.NumericUpDown numericDescontar2Puertas;
        private System.Windows.Forms.Label labelDescontarTres;
        private System.Windows.Forms.Label labelDescontarDos;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.PictureBox pictureBoxImagen;
    }
}