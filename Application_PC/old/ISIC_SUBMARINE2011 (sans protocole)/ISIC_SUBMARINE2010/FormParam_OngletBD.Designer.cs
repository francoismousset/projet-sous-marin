namespace ISIC_SUBMARINE2010
{
    partial class FormParam_OngletBD
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxAcquisition = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BoutonParam_EffacerBD = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BoutonParam_ExporterBD = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBoxAcquisition);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acquisition";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "L\'acquisition des données se fait toutes les secondes.\r\nLes données sont directem" +
                "ent enregistrées dans la base de données.";
            // 
            // checkBoxAcquisition
            // 
            this.checkBoxAcquisition.AutoSize = true;
            this.checkBoxAcquisition.Location = new System.Drawing.Point(15, 29);
            this.checkBoxAcquisition.Name = "checkBoxAcquisition";
            this.checkBoxAcquisition.Size = new System.Drawing.Size(180, 17);
            this.checkBoxAcquisition.TabIndex = 0;
            this.checkBoxAcquisition.Text = "Activer l\'acquisition des données";
            this.checkBoxAcquisition.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.BoutonParam_EffacerBD);
            this.groupBox2.Location = new System.Drawing.Point(16, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Effacement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliquez sur le bouton pour effacer toutes les données de la BD.";
            // 
            // BoutonParam_EffacerBD
            // 
            this.BoutonParam_EffacerBD.Location = new System.Drawing.Point(15, 50);
            this.BoutonParam_EffacerBD.Name = "BoutonParam_EffacerBD";
            this.BoutonParam_EffacerBD.Size = new System.Drawing.Size(165, 23);
            this.BoutonParam_EffacerBD.TabIndex = 0;
            this.BoutonParam_EffacerBD.Text = "Effacer le contenu de la BD";
            this.BoutonParam_EffacerBD.UseVisualStyleBackColor = true;
            this.BoutonParam_EffacerBD.Click += new System.EventHandler(this.BoutonParam_EffacerBD_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BoutonParam_ExporterBD);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(16, 195);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(396, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Exportation";
            // 
            // BoutonParam_ExporterBD
            // 
            this.BoutonParam_ExporterBD.Location = new System.Drawing.Point(15, 55);
            this.BoutonParam_ExporterBD.Name = "BoutonParam_ExporterBD";
            this.BoutonParam_ExporterBD.Size = new System.Drawing.Size(165, 23);
            this.BoutonParam_ExporterBD.TabIndex = 1;
            this.BoutonParam_ExporterBD.Text = "Exporter le contenu de la BD";
            this.BoutonParam_ExporterBD.UseVisualStyleBackColor = true;
            this.BoutonParam_ExporterBD.Click += new System.EventHandler(this.BoutonParam_ExporterBD_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cliquez sur le bouton pour exporter la BD dans un fichier csv.";
            // 
            // FormParam_OngletBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 368);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormParam_OngletBD";
            this.Text = "FormParam_OngletBD";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BoutonParam_EffacerBD;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BoutonParam_ExporterBD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxAcquisition;
    }
}