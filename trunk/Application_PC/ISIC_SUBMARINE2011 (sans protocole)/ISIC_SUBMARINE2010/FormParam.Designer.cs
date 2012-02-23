namespace ISIC_SUBMARINE2010
{
    partial class FormParam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

       

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParam));
            this.OngletsParam = new System.Windows.Forms.TabControl();
            this.OngletParamGeneral = new System.Windows.Forms.TabPage();
            this.OngletParamRS232 = new System.Windows.Forms.TabPage();
            this.OngletParamGraphiques = new System.Windows.Forms.TabPage();
            this.OngletParamBD = new System.Windows.Forms.TabPage();
            this.BoutonParam_Appliquer = new System.Windows.Forms.Button();
            this.BoutonParam_Annuler = new System.Windows.Forms.Button();
            this.BoutonParam_Ok = new System.Windows.Forms.Button();
            this.OngletsParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // OngletsParam
            // 
            this.OngletsParam.Controls.Add(this.OngletParamGeneral);
            this.OngletsParam.Controls.Add(this.OngletParamRS232);
            this.OngletsParam.Controls.Add(this.OngletParamGraphiques);
            this.OngletsParam.Controls.Add(this.OngletParamBD);
            this.OngletsParam.Location = new System.Drawing.Point(21, 12);
            this.OngletsParam.Name = "OngletsParam";
            this.OngletsParam.SelectedIndex = 0;
            this.OngletsParam.Size = new System.Drawing.Size(450, 468);
            this.OngletsParam.TabIndex = 0;
            // 
            // OngletParamGeneral
            // 
            this.OngletParamGeneral.Location = new System.Drawing.Point(4, 22);
            this.OngletParamGeneral.Name = "OngletParamGeneral";
            this.OngletParamGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.OngletParamGeneral.Size = new System.Drawing.Size(442, 442);
            this.OngletParamGeneral.TabIndex = 0;
            this.OngletParamGeneral.Text = "Général";
            this.OngletParamGeneral.UseVisualStyleBackColor = true;
            // 
            // OngletParamRS232
            // 
            this.OngletParamRS232.Location = new System.Drawing.Point(4, 22);
            this.OngletParamRS232.Name = "OngletParamRS232";
            this.OngletParamRS232.Size = new System.Drawing.Size(442, 442);
            this.OngletParamRS232.TabIndex = 4;
            this.OngletParamRS232.Text = "RS232";
            // 
            // OngletParamGraphiques
            // 
            this.OngletParamGraphiques.Location = new System.Drawing.Point(4, 22);
            this.OngletParamGraphiques.Name = "OngletParamGraphiques";
            this.OngletParamGraphiques.Padding = new System.Windows.Forms.Padding(3);
            this.OngletParamGraphiques.Size = new System.Drawing.Size(442, 442);
            this.OngletParamGraphiques.TabIndex = 1;
            this.OngletParamGraphiques.Text = "Graphiques";
            this.OngletParamGraphiques.UseVisualStyleBackColor = true;
            // 
            // OngletParamBD
            // 
            this.OngletParamBD.Location = new System.Drawing.Point(4, 22);
            this.OngletParamBD.Name = "OngletParamBD";
            this.OngletParamBD.Padding = new System.Windows.Forms.Padding(3);
            this.OngletParamBD.Size = new System.Drawing.Size(442, 442);
            this.OngletParamBD.TabIndex = 5;
            this.OngletParamBD.Text = "Base de données";
            this.OngletParamBD.UseVisualStyleBackColor = true;
            // 
            // BoutonParam_Appliquer
            // 
            this.BoutonParam_Appliquer.Location = new System.Drawing.Point(402, 486);
            this.BoutonParam_Appliquer.Name = "BoutonParam_Appliquer";
            this.BoutonParam_Appliquer.Size = new System.Drawing.Size(75, 23);
            this.BoutonParam_Appliquer.TabIndex = 6;
            this.BoutonParam_Appliquer.Text = "Appliquer";
            this.BoutonParam_Appliquer.UseVisualStyleBackColor = true;
            this.BoutonParam_Appliquer.Click += new System.EventHandler(this.BoutonParam_Appliquer_Click);
            // 
            // BoutonParam_Annuler
            // 
            this.BoutonParam_Annuler.Location = new System.Drawing.Point(312, 486);
            this.BoutonParam_Annuler.Name = "BoutonParam_Annuler";
            this.BoutonParam_Annuler.Size = new System.Drawing.Size(75, 23);
            this.BoutonParam_Annuler.TabIndex = 5;
            this.BoutonParam_Annuler.Text = "Annuler";
            this.BoutonParam_Annuler.UseVisualStyleBackColor = true;
            this.BoutonParam_Annuler.Click += new System.EventHandler(this.BoutonParam_Annuler_Click);
            // 
            // BoutonParam_Ok
            // 
            this.BoutonParam_Ok.Location = new System.Drawing.Point(221, 486);
            this.BoutonParam_Ok.Name = "BoutonParam_Ok";
            this.BoutonParam_Ok.Size = new System.Drawing.Size(75, 23);
            this.BoutonParam_Ok.TabIndex = 4;
            this.BoutonParam_Ok.Text = "Ok";
            this.BoutonParam_Ok.UseVisualStyleBackColor = true;
            this.BoutonParam_Ok.Click += new System.EventHandler(this.BoutonParam_Ok_Click);
            // 
            // FormParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 517);
            this.Controls.Add(this.BoutonParam_Appliquer);
            this.Controls.Add(this.BoutonParam_Annuler);
            this.Controls.Add(this.BoutonParam_Ok);
            this.Controls.Add(this.OngletsParam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration du Sous-Marin";
            this.Load += new System.EventHandler(this.FormParam_Load);
            this.OngletsParam.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl OngletsParam;
        private System.Windows.Forms.TabPage OngletParamGeneral;
        private System.Windows.Forms.TabPage OngletParamGraphiques;
        private System.Windows.Forms.TabPage OngletParamRS232;
        private System.Windows.Forms.Button BoutonParam_Appliquer;
        private System.Windows.Forms.Button BoutonParam_Annuler;
        private System.Windows.Forms.Button BoutonParam_Ok;
        private System.Windows.Forms.TabPage OngletParamBD;

        public System.Windows.Forms.TabPage OngletParam_OngletRS232 { get; set; }
    }
}