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
            this.buttonArmariosObra = new System.Windows.Forms.Button();
            this.buttonParticular = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonArmariosObra
            // 
            this.buttonArmariosObra.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonArmariosObra.Location = new System.Drawing.Point(12, 33);
            this.buttonArmariosObra.Name = "buttonArmariosObra";
            this.buttonArmariosObra.Size = new System.Drawing.Size(196, 41);
            this.buttonArmariosObra.TabIndex = 11;
            this.buttonArmariosObra.Text = "Armarios Obra";
            this.buttonArmariosObra.UseVisualStyleBackColor = true;
            // 
            // buttonParticular
            // 
            this.buttonParticular.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonParticular.Location = new System.Drawing.Point(12, 94);
            this.buttonParticular.Name = "buttonParticular";
            this.buttonParticular.Size = new System.Drawing.Size(196, 41);
            this.buttonParticular.TabIndex = 12;
            this.buttonParticular.Text = "Armarios Particular";
            this.buttonParticular.UseVisualStyleBackColor = true;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonParticular);
            this.Controls.Add(this.buttonArmariosObra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonArmariosObra;
        private System.Windows.Forms.Button buttonParticular;
    }
}