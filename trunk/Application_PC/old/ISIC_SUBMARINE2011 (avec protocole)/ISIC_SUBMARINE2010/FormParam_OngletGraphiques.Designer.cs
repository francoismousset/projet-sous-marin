namespace ISIC_SUBMARINE2010
{
    partial class FormParam_OngletGraphiques
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
            this.ValeurTailleFenetre = new System.Windows.Forms.Label();
            this.ValeurTauxRafraichissement = new System.Windows.Forms.Label();
            this.CurseurTailleFenetre = new System.Windows.Forms.TrackBar();
            this.CurseurTauxRafraichissement = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CouleurFond1 = new System.Windows.Forms.ComboBox();
            this.CouleurCourbe1 = new System.Windows.Forms.ComboBox();
            this.CapteurGraphe1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CouleurFond2 = new System.Windows.Forms.ComboBox();
            this.CouleurCourbe2 = new System.Windows.Forms.ComboBox();
            this.CapteurGraphe2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurseurTailleFenetre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurseurTauxRafraichissement)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ValeurTailleFenetre);
            this.groupBox1.Controls.Add(this.ValeurTauxRafraichissement);
            this.groupBox1.Controls.Add(this.CurseurTailleFenetre);
            this.groupBox1.Controls.Add(this.CurseurTauxRafraichissement);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paramètres temporels";
            // 
            // ValeurTailleFenetre
            // 
            this.ValeurTailleFenetre.AutoSize = true;
            this.ValeurTailleFenetre.Location = new System.Drawing.Point(351, 79);
            this.ValeurTailleFenetre.Name = "ValeurTailleFenetre";
            this.ValeurTailleFenetre.Size = new System.Drawing.Size(32, 13);
            this.ValeurTailleFenetre.TabIndex = 5;
            this.ValeurTailleFenetre.Text = "1 min";
            // 
            // ValeurTauxRafraichissement
            // 
            this.ValeurTauxRafraichissement.AutoSize = true;
            this.ValeurTauxRafraichissement.Location = new System.Drawing.Point(351, 28);
            this.ValeurTauxRafraichissement.Name = "ValeurTauxRafraichissement";
            this.ValeurTauxRafraichissement.Size = new System.Drawing.Size(21, 13);
            this.ValeurTauxRafraichissement.TabIndex = 4;
            this.ValeurTauxRafraichissement.Text = "1 s";
            // 
            // CurseurTailleFenetre
            // 
            this.CurseurTailleFenetre.Location = new System.Drawing.Point(155, 70);
            this.CurseurTailleFenetre.Maximum = 120;
            this.CurseurTailleFenetre.Minimum = 1;
            this.CurseurTailleFenetre.Name = "CurseurTailleFenetre";
            this.CurseurTailleFenetre.Size = new System.Drawing.Size(190, 45);
            this.CurseurTailleFenetre.TabIndex = 3;
            this.CurseurTailleFenetre.Value = 1;
            this.CurseurTailleFenetre.ValueChanged += new System.EventHandler(this.CurseurTailleFenetre_ValueChanged);
            // 
            // CurseurTauxRafraichissement
            // 
            this.CurseurTauxRafraichissement.Location = new System.Drawing.Point(155, 19);
            this.CurseurTauxRafraichissement.Maximum = 120;
            this.CurseurTauxRafraichissement.Minimum = 1;
            this.CurseurTauxRafraichissement.Name = "CurseurTauxRafraichissement";
            this.CurseurTauxRafraichissement.Size = new System.Drawing.Size(190, 45);
            this.CurseurTauxRafraichissement.TabIndex = 2;
            this.CurseurTauxRafraichissement.Value = 1;
            this.CurseurTauxRafraichissement.ValueChanged += new System.EventHandler(this.CurseurTauxRafraichissement_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Taille de la fenêtre :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Période de rafraichissement :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.CouleurFond1);
            this.groupBox2.Controls.Add(this.CouleurCourbe1);
            this.groupBox2.Controls.Add(this.CapteurGraphe1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(16, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 110);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Graphique 1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Couleur de fond :";
            // 
            // CouleurFond1
            // 
            this.CouleurFond1.FormattingEnabled = true;
            this.CouleurFond1.Items.AddRange(new object[] {
            "Noir",
            "Blanc"});
            this.CouleurFond1.Location = new System.Drawing.Point(143, 76);
            this.CouleurFond1.Name = "CouleurFond1";
            this.CouleurFond1.Size = new System.Drawing.Size(151, 21);
            this.CouleurFond1.TabIndex = 4;
            // 
            // CouleurCourbe1
            // 
            this.CouleurCourbe1.FormattingEnabled = true;
            this.CouleurCourbe1.Items.AddRange(new object[] {
            "Rouge",
            "Bleu",
            "Vert",
            "Blanc",
            "Noir"});
            this.CouleurCourbe1.Location = new System.Drawing.Point(143, 49);
            this.CouleurCourbe1.Name = "CouleurCourbe1";
            this.CouleurCourbe1.Size = new System.Drawing.Size(151, 21);
            this.CouleurCourbe1.TabIndex = 3;
            // 
            // CapteurGraphe1
            // 
            this.CapteurGraphe1.FormattingEnabled = true;
            this.CapteurGraphe1.Items.AddRange(new object[] {
            "Position du ballast avant",
            "Position du ballast arrière",
            "Vitesse du moteur 1",
            "Vitesse du moteur 2",
            "Profondeur",
            "Inclinaison axe X",
            "Inclinaison axe Y"});
            this.CapteurGraphe1.Location = new System.Drawing.Point(103, 22);
            this.CapteurGraphe1.Name = "CapteurGraphe1";
            this.CapteurGraphe1.Size = new System.Drawing.Size(191, 21);
            this.CapteurGraphe1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Couleur de la courbe :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Capteur :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.CouleurFond2);
            this.groupBox3.Controls.Add(this.CouleurCourbe2);
            this.groupBox3.Controls.Add(this.CapteurGraphe2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(16, 262);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(397, 108);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Graphique 2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Couleur de fond :";
            // 
            // CouleurFond2
            // 
            this.CouleurFond2.FormattingEnabled = true;
            this.CouleurFond2.Items.AddRange(new object[] {
            "Noir",
            "Blanc"});
            this.CouleurFond2.Location = new System.Drawing.Point(143, 73);
            this.CouleurFond2.Name = "CouleurFond2";
            this.CouleurFond2.Size = new System.Drawing.Size(151, 21);
            this.CouleurFond2.TabIndex = 4;
            // 
            // CouleurCourbe2
            // 
            this.CouleurCourbe2.FormattingEnabled = true;
            this.CouleurCourbe2.Items.AddRange(new object[] {
            "Rouge",
            "Bleu",
            "Vert",
            "Blanc",
            "Noir"});
            this.CouleurCourbe2.Location = new System.Drawing.Point(143, 46);
            this.CouleurCourbe2.Name = "CouleurCourbe2";
            this.CouleurCourbe2.Size = new System.Drawing.Size(151, 21);
            this.CouleurCourbe2.TabIndex = 3;
            // 
            // CapteurGraphe2
            // 
            this.CapteurGraphe2.FormattingEnabled = true;
            this.CapteurGraphe2.Items.AddRange(new object[] {
            "Position du ballast avant",
            "Position du ballast arrière",
            "Vitesse du moteur 1",
            "Vitesse du moteur 2",
            "Profondeur",
            "Inclinaison axe X",
            "Inclinaison axe Y"});
            this.CapteurGraphe2.Location = new System.Drawing.Point(103, 19);
            this.CapteurGraphe2.Name = "CapteurGraphe2";
            this.CapteurGraphe2.Size = new System.Drawing.Size(191, 21);
            this.CapteurGraphe2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Couleur de la courbe :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Capteur :";
            // 
            // FormParam_OngletGraphiques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 447);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormParam_OngletGraphiques";
            this.Text = "FormParam_OngletGraphiques";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurseurTailleFenetre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurseurTauxRafraichissement)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar CurseurTailleFenetre;
        private System.Windows.Forms.TrackBar CurseurTauxRafraichissement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CouleurCourbe1;
        private System.Windows.Forms.ComboBox CapteurGraphe1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CouleurCourbe2;
        private System.Windows.Forms.ComboBox CapteurGraphe2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ValeurTailleFenetre;
        private System.Windows.Forms.Label ValeurTauxRafraichissement;
        private System.Windows.Forms.ComboBox CouleurFond1;
        private System.Windows.Forms.ComboBox CouleurFond2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}