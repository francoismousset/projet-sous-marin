namespace ISIC_SUBMARINE2010
{
    partial class FormApropos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApropos));
            this.LogoHelha = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LienSite = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LogoHelha)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoHelha
            // 
            this.LogoHelha.Image = ((System.Drawing.Image)(resources.GetObject("LogoHelha.Image")));
            this.LogoHelha.Location = new System.Drawing.Point(12, 12);
            this.LogoHelha.Name = "LogoHelha";
            this.LogoHelha.Size = new System.Drawing.Size(153, 90);
            this.LogoHelha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoHelha.TabIndex = 0;
            this.LogoHelha.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Interface réalisée par les Master 2 Electronique\r\nde l\'ISIC dans le cadre du proj" +
                "et Sous-Marin.";
            // 
            // LienSite
            // 
            this.LienSite.ActiveLinkColor = System.Drawing.Color.Red;
            this.LienSite.AutoSize = true;
            this.LienSite.Location = new System.Drawing.Point(9, 343);
            this.LienSite.Name = "LienSite";
            this.LienSite.Size = new System.Drawing.Size(221, 13);
            this.LienSite.TabIndex = 2;
            this.LienSite.TabStop = true;
            this.LienSite.Text = "http://sites.google.com/site/projetsousmarin/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 156);
            this.label2.TabIndex = 3;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "2011 - Haute Ecole Louvain en Hainaut";
            // 
            // FormApropos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 399);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LienSite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogoHelha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormApropos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A propos du programme...";
            ((System.ComponentModel.ISupportInitialize)(this.LogoHelha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoHelha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LienSite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}