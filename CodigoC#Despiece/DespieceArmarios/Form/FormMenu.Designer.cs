namespace DespieceArmarios
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.btnArmariosObra = new System.Windows.Forms.Button();
            this.btnParticular = new System.Windows.Forms.Button();
            this.btnCajonera = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnArmariosObra
            // 
            this.btnArmariosObra.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnArmariosObra.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArmariosObra.Location = new System.Drawing.Point(10, 10);
            this.btnArmariosObra.Name = "btnArmariosObra";
            this.btnArmariosObra.Size = new System.Drawing.Size(356, 41);
            this.btnArmariosObra.TabIndex = 11;
            this.btnArmariosObra.Text = "Armarios Obra";
            this.btnArmariosObra.UseVisualStyleBackColor = true;
            // 
            // btnParticular
            // 
            this.btnParticular.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnParticular.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParticular.Location = new System.Drawing.Point(10, 51);
            this.btnParticular.Name = "btnParticular";
            this.btnParticular.Size = new System.Drawing.Size(356, 41);
            this.btnParticular.TabIndex = 12;
            this.btnParticular.Text = "Armarios Particular";
            this.btnParticular.UseVisualStyleBackColor = true;
            // 
            // btnCajonera
            // 
            this.btnCajonera.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCajonera.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCajonera.Location = new System.Drawing.Point(10, 92);
            this.btnCajonera.Name = "btnCajonera";
            this.btnCajonera.Size = new System.Drawing.Size(356, 41);
            this.btnCajonera.TabIndex = 13;
            this.btnCajonera.Text = "Cajonera";
            this.btnCajonera.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCajonera);
            this.panel1.Controls.Add(this.btnParticular);
            this.panel1.Controls.Add(this.btnArmariosObra);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(376, 147);
            this.panel1.TabIndex = 14;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 450);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnArmariosObra;
        private System.Windows.Forms.Button btnParticular;
        private System.Windows.Forms.Button btnCajonera;
        private System.Windows.Forms.Panel panel1;
    }
}