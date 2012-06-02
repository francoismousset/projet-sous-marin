namespace ISIC_SUBMARINE2010
{
    partial class FormTelecommande
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
            this.GroupBoxInfo = new System.Windows.Forms.GroupBox();
            this.Vue_donnees_transit = new System.Windows.Forms.TextBox();
            this.Debut_acq = new System.Windows.Forms.Button();
            this.ImageSousMarin = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupBoxBallasts = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ValeurPositionBallastArriere = new System.Windows.Forms.Label();
            this.ValeurConsigneBallastArriere = new System.Windows.Forms.Label();
            this.ValeurPositionBallastAvant = new System.Windows.Forms.Label();
            this.ValeurConsigneBallastAvant = new System.Windows.Forms.Label();
            this.CurseurBallastArriere = new System.Windows.Forms.TrackBar();
            this.CurseurBallastAvant = new System.Windows.Forms.TrackBar();
            this.LierBallast = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BarreBallastArriere = new System.Windows.Forms.ProgressBar();
            this.BarreBallastAvant = new System.Windows.Forms.ProgressBar();
            this.GroupBoxPropulsion = new System.Windows.Forms.GroupBox();
            this.BoutonSTOP = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ValeurConsignePropulsion = new System.Windows.Forms.Label();
            this.LabelVitesseMoteur2 = new System.Windows.Forms.Label();
            this.LabelVitesseMoteur1 = new System.Windows.Forms.Label();
            this.CurseurPropulsion = new System.Windows.Forms.TrackBar();
            this.GroupBoxPosition = new System.Windows.Forms.GroupBox();
            this.LabelInclinaisonAxeY = new System.Windows.Forms.Label();
            this.LabelInclinaisonAxeX = new System.Windows.Forms.Label();
            this.LabelProfondeur = new System.Windows.Forms.Label();
            this.GroupBoxSecurite = new System.Windows.Forms.GroupBox();
            this.LabelHumidite = new System.Windows.Forms.Label();
            this.LabelTemperature = new System.Windows.Forms.Label();
            this.LabelCourantBatterie2 = new System.Windows.Forms.Label();
            this.LabelCourantBatterie1 = new System.Windows.Forms.Label();
            this.LabelTensionBatterie2 = new System.Windows.Forms.Label();
            this.LabelTensionBatterie1 = new System.Windows.Forms.Label();
            this.Timer_acquisition = new System.Windows.Forms.Timer(this.components);
            this.GroupBoxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSousMarin)).BeginInit();
            this.GroupBoxBallasts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurseurBallastArriere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurseurBallastAvant)).BeginInit();
            this.GroupBoxPropulsion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurseurPropulsion)).BeginInit();
            this.GroupBoxPosition.SuspendLayout();
            this.GroupBoxSecurite.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxInfo
            // 
            this.GroupBoxInfo.Controls.Add(this.Vue_donnees_transit);
            this.GroupBoxInfo.Controls.Add(this.Debut_acq);
            this.GroupBoxInfo.Controls.Add(this.ImageSousMarin);
            this.GroupBoxInfo.Controls.Add(this.label5);
            this.GroupBoxInfo.Controls.Add(this.label4);
            this.GroupBoxInfo.Controls.Add(this.label3);
            this.GroupBoxInfo.Controls.Add(this.label2);
            this.GroupBoxInfo.Controls.Add(this.label1);
            this.GroupBoxInfo.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxInfo.Name = "GroupBoxInfo";
            this.GroupBoxInfo.Size = new System.Drawing.Size(660, 139);
            this.GroupBoxInfo.TabIndex = 0;
            this.GroupBoxInfo.TabStop = false;
            this.GroupBoxInfo.Text = "Informations générales";
            // 
            // Vue_donnees_transit
            // 
            this.Vue_donnees_transit.Location = new System.Drawing.Point(115, 92);
            this.Vue_donnees_transit.Multiline = true;
            this.Vue_donnees_transit.Name = "Vue_donnees_transit";
            this.Vue_donnees_transit.Size = new System.Drawing.Size(112, 35);
            this.Vue_donnees_transit.TabIndex = 15;
            this.Vue_donnees_transit.TextChanged += new System.EventHandler(this.Vue_donnees_transit_TextChanged);
            // 
            // Debut_acq
            // 
            this.Debut_acq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Debut_acq.Location = new System.Drawing.Point(115, 47);
            this.Debut_acq.Name = "Debut_acq";
            this.Debut_acq.Size = new System.Drawing.Size(112, 45);
            this.Debut_acq.TabIndex = 7;
            this.Debut_acq.Text = "Commencer l\'acquisition";
            this.Debut_acq.UseVisualStyleBackColor = true;
            this.Debut_acq.Click += new System.EventHandler(this.Debut_acq_Click_1);
            // 
            // ImageSousMarin
            // 
            this.ImageSousMarin.Image = global::ISIC_SUBMARINE2010.Properties.Resources.SMtranspetit;
            this.ImageSousMarin.InitialImage = null;
            this.ImageSousMarin.Location = new System.Drawing.Point(225, 19);
            this.ImageSousMarin.Name = "ImageSousMarin";
            this.ImageSousMarin.Size = new System.Drawing.Size(429, 108);
            this.ImageSousMarin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageSousMarin.TabIndex = 5;
            this.ImageSousMarin.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Hauteur : xxx mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Largeur : xxx mm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Longueur : xxxx mm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Poids : xx,x kg";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom : XXXXXXXX";
            // 
            // GroupBoxBallasts
            // 
            this.GroupBoxBallasts.Controls.Add(this.label14);
            this.GroupBoxBallasts.Controls.Add(this.label13);
            this.GroupBoxBallasts.Controls.Add(this.label12);
            this.GroupBoxBallasts.Controls.Add(this.label11);
            this.GroupBoxBallasts.Controls.Add(this.ValeurPositionBallastArriere);
            this.GroupBoxBallasts.Controls.Add(this.ValeurConsigneBallastArriere);
            this.GroupBoxBallasts.Controls.Add(this.ValeurPositionBallastAvant);
            this.GroupBoxBallasts.Controls.Add(this.ValeurConsigneBallastAvant);
            this.GroupBoxBallasts.Controls.Add(this.CurseurBallastArriere);
            this.GroupBoxBallasts.Controls.Add(this.CurseurBallastAvant);
            this.GroupBoxBallasts.Controls.Add(this.LierBallast);
            this.GroupBoxBallasts.Controls.Add(this.label7);
            this.GroupBoxBallasts.Controls.Add(this.label6);
            this.GroupBoxBallasts.Controls.Add(this.BarreBallastArriere);
            this.GroupBoxBallasts.Controls.Add(this.BarreBallastAvant);
            this.GroupBoxBallasts.Location = new System.Drawing.Point(12, 157);
            this.GroupBoxBallasts.Name = "GroupBoxBallasts";
            this.GroupBoxBallasts.Size = new System.Drawing.Size(660, 147);
            this.GroupBoxBallasts.TabIndex = 1;
            this.GroupBoxBallasts.TabStop = false;
            this.GroupBoxBallasts.Text = "Ballasts";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(615, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Max";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(405, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Min";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(216, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Max";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Min";
            // 
            // ValeurPositionBallastArriere
            // 
            this.ValeurPositionBallastArriere.AutoSize = true;
            this.ValeurPositionBallastArriere.Location = new System.Drawing.Point(344, 106);
            this.ValeurPositionBallastArriere.Name = "ValeurPositionBallastArriere";
            this.ValeurPositionBallastArriere.Size = new System.Drawing.Size(13, 13);
            this.ValeurPositionBallastArriere.TabIndex = 10;
            this.ValeurPositionBallastArriere.Text = "0";
            // 
            // ValeurConsigneBallastArriere
            // 
            this.ValeurConsigneBallastArriere.AutoSize = true;
            this.ValeurConsigneBallastArriere.Location = new System.Drawing.Point(344, 66);
            this.ValeurConsigneBallastArriere.Name = "ValeurConsigneBallastArriere";
            this.ValeurConsigneBallastArriere.Size = new System.Drawing.Size(13, 13);
            this.ValeurConsigneBallastArriere.TabIndex = 9;
            this.ValeurConsigneBallastArriere.Text = "0";
            // 
            // ValeurPositionBallastAvant
            // 
            this.ValeurPositionBallastAvant.AutoSize = true;
            this.ValeurPositionBallastAvant.Location = new System.Drawing.Point(266, 106);
            this.ValeurPositionBallastAvant.Name = "ValeurPositionBallastAvant";
            this.ValeurPositionBallastAvant.Size = new System.Drawing.Size(13, 13);
            this.ValeurPositionBallastAvant.TabIndex = 8;
            this.ValeurPositionBallastAvant.Text = "0";
            // 
            // ValeurConsigneBallastAvant
            // 
            this.ValeurConsigneBallastAvant.AutoSize = true;
            this.ValeurConsigneBallastAvant.Location = new System.Drawing.Point(266, 66);
            this.ValeurConsigneBallastAvant.Name = "ValeurConsigneBallastAvant";
            this.ValeurConsigneBallastAvant.Size = new System.Drawing.Size(13, 13);
            this.ValeurConsigneBallastAvant.TabIndex = 7;
            this.ValeurConsigneBallastAvant.Text = "0";
            // 
            // CurseurBallastArriere
            // 
            this.CurseurBallastArriere.Location = new System.Drawing.Point(408, 55);
            this.CurseurBallastArriere.Maximum = 1023;
            this.CurseurBallastArriere.Name = "CurseurBallastArriere";
            this.CurseurBallastArriere.Size = new System.Drawing.Size(234, 45);
            this.CurseurBallastArriere.TabIndex = 6;
            this.CurseurBallastArriere.ValueChanged += new System.EventHandler(this.CurseurBallastArriere_ValueChanged);
            this.CurseurBallastArriere.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CurseurBallastArriere_KeyUp);
            this.CurseurBallastArriere.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CurseurBallastArriere_MouseUp);
            // 
            // CurseurBallastAvant
            // 
            this.CurseurBallastAvant.Location = new System.Drawing.Point(9, 55);
            this.CurseurBallastAvant.Maximum = 1023;
            this.CurseurBallastAvant.Name = "CurseurBallastAvant";
            this.CurseurBallastAvant.Size = new System.Drawing.Size(234, 45);
            this.CurseurBallastAvant.TabIndex = 5;
            this.CurseurBallastAvant.ValueChanged += new System.EventHandler(this.CurseurBallastAvant_ValueChanged);
            this.CurseurBallastAvant.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CurseurBallastAvant_KeyUp);
            this.CurseurBallastAvant.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CurseurBallastAvant_MouseUp);
            // 
            // LierBallast
            // 
            this.LierBallast.AutoSize = true;
            this.LierBallast.Location = new System.Drawing.Point(276, 19);
            this.LierBallast.Name = "LierBallast";
            this.LierBallast.Size = new System.Drawing.Size(97, 17);
            this.LierBallast.TabIndex = 4;
            this.LierBallast.Text = "Lier les ballasts";
            this.LierBallast.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(506, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Arrière";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Avant";
            // 
            // BarreBallastArriere
            // 
            this.BarreBallastArriere.Location = new System.Drawing.Point(408, 106);
            this.BarreBallastArriere.Maximum = 1023;
            this.BarreBallastArriere.Name = "BarreBallastArriere";
            this.BarreBallastArriere.Size = new System.Drawing.Size(234, 23);
            this.BarreBallastArriere.TabIndex = 1;
            // 
            // BarreBallastAvant
            // 
            this.BarreBallastAvant.Location = new System.Drawing.Point(9, 106);
            this.BarreBallastAvant.Maximum = 1023;
            this.BarreBallastAvant.Name = "BarreBallastAvant";
            this.BarreBallastAvant.Size = new System.Drawing.Size(234, 23);
            this.BarreBallastAvant.TabIndex = 0;
            // 
            // GroupBoxPropulsion
            // 
            this.GroupBoxPropulsion.Controls.Add(this.BoutonSTOP);
            this.GroupBoxPropulsion.Controls.Add(this.label10);
            this.GroupBoxPropulsion.Controls.Add(this.label9);
            this.GroupBoxPropulsion.Controls.Add(this.label8);
            this.GroupBoxPropulsion.Controls.Add(this.ValeurConsignePropulsion);
            this.GroupBoxPropulsion.Controls.Add(this.LabelVitesseMoteur2);
            this.GroupBoxPropulsion.Controls.Add(this.LabelVitesseMoteur1);
            this.GroupBoxPropulsion.Controls.Add(this.CurseurPropulsion);
            this.GroupBoxPropulsion.Enabled = false;
            this.GroupBoxPropulsion.Location = new System.Drawing.Point(12, 310);
            this.GroupBoxPropulsion.Name = "GroupBoxPropulsion";
            this.GroupBoxPropulsion.Size = new System.Drawing.Size(660, 113);
            this.GroupBoxPropulsion.TabIndex = 2;
            this.GroupBoxPropulsion.TabStop = false;
            this.GroupBoxPropulsion.Text = "Propulsion";
            // 
            // BoutonSTOP
            // 
            this.BoutonSTOP.Location = new System.Drawing.Point(142, 80);
            this.BoutonSTOP.Name = "BoutonSTOP";
            this.BoutonSTOP.Size = new System.Drawing.Size(75, 23);
            this.BoutonSTOP.TabIndex = 7;
            this.BoutonSTOP.Text = "STOP";
            this.BoutonSTOP.UseVisualStyleBackColor = true;
            this.BoutonSTOP.Click += new System.EventHandler(this.BoutonSTOP_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Arrière";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(322, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Avant";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(162, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Arrêt";
            // 
            // ValeurConsignePropulsion
            // 
            this.ValeurConsignePropulsion.AutoSize = true;
            this.ValeurConsignePropulsion.Location = new System.Drawing.Point(348, 53);
            this.ValeurConsignePropulsion.Name = "ValeurConsignePropulsion";
            this.ValeurConsignePropulsion.Size = new System.Drawing.Size(25, 13);
            this.ValeurConsignePropulsion.TabIndex = 3;
            this.ValeurConsignePropulsion.Text = "128";
            // 
            // LabelVitesseMoteur2
            // 
            this.LabelVitesseMoteur2.AutoSize = true;
            this.LabelVitesseMoteur2.Location = new System.Drawing.Point(455, 60);
            this.LabelVitesseMoteur2.Name = "LabelVitesseMoteur2";
            this.LabelVitesseMoteur2.Size = new System.Drawing.Size(139, 13);
            this.LabelVitesseMoteur2.TabIndex = 2;
            this.LabelVitesseMoteur2.Text = "Vitesse moteur 2 : xxx tr/min";
            // 
            // LabelVitesseMoteur1
            // 
            this.LabelVitesseMoteur1.AutoSize = true;
            this.LabelVitesseMoteur1.Location = new System.Drawing.Point(455, 28);
            this.LabelVitesseMoteur1.Name = "LabelVitesseMoteur1";
            this.LabelVitesseMoteur1.Size = new System.Drawing.Size(139, 13);
            this.LabelVitesseMoteur1.TabIndex = 1;
            this.LabelVitesseMoteur1.Text = "Vitesse moteur 1 : xxx tr/min";
            // 
            // CurseurPropulsion
            // 
            this.CurseurPropulsion.Location = new System.Drawing.Point(9, 44);
            this.CurseurPropulsion.Maximum = 1023;
            this.CurseurPropulsion.Name = "CurseurPropulsion";
            this.CurseurPropulsion.Size = new System.Drawing.Size(333, 45);
            this.CurseurPropulsion.TabIndex = 0;
            this.CurseurPropulsion.Value = 512;
            this.CurseurPropulsion.ValueChanged += new System.EventHandler(this.CurseurPropulsion_ValueChanged);
            this.CurseurPropulsion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CurseurPropulsion_KeyUp);
            this.CurseurPropulsion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CurseurPropulsion_MouseUp);
            // 
            // GroupBoxPosition
            // 
            this.GroupBoxPosition.Controls.Add(this.LabelInclinaisonAxeY);
            this.GroupBoxPosition.Controls.Add(this.LabelInclinaisonAxeX);
            this.GroupBoxPosition.Controls.Add(this.LabelProfondeur);
            this.GroupBoxPosition.Location = new System.Drawing.Point(12, 429);
            this.GroupBoxPosition.Name = "GroupBoxPosition";
            this.GroupBoxPosition.Size = new System.Drawing.Size(660, 78);
            this.GroupBoxPosition.TabIndex = 3;
            this.GroupBoxPosition.TabStop = false;
            this.GroupBoxPosition.Text = "Position";
            // 
            // LabelInclinaisonAxeY
            // 
            this.LabelInclinaisonAxeY.AutoSize = true;
            this.LabelInclinaisonAxeY.Location = new System.Drawing.Point(391, 47);
            this.LabelInclinaisonAxeY.Name = "LabelInclinaisonAxeY";
            this.LabelInclinaisonAxeY.Size = new System.Drawing.Size(118, 13);
            this.LabelInclinaisonAxeY.TabIndex = 2;
            this.LabelInclinaisonAxeY.Text = "Inclinaison axe Y : xxx °";
            // 
            // LabelInclinaisonAxeX
            // 
            this.LabelInclinaisonAxeX.AutoSize = true;
            this.LabelInclinaisonAxeX.Location = new System.Drawing.Point(391, 25);
            this.LabelInclinaisonAxeX.Name = "LabelInclinaisonAxeX";
            this.LabelInclinaisonAxeX.Size = new System.Drawing.Size(118, 13);
            this.LabelInclinaisonAxeX.TabIndex = 1;
            this.LabelInclinaisonAxeX.Text = "Inclinaison axe X : xxx °";
            // 
            // LabelProfondeur
            // 
            this.LabelProfondeur.AutoSize = true;
            this.LabelProfondeur.Location = new System.Drawing.Point(130, 36);
            this.LabelProfondeur.Name = "LabelProfondeur";
            this.LabelProfondeur.Size = new System.Drawing.Size(102, 13);
            this.LabelProfondeur.TabIndex = 0;
            this.LabelProfondeur.Text = "Profondeur : xxx mm";
            // 
            // GroupBoxSecurite
            // 
            this.GroupBoxSecurite.Controls.Add(this.LabelHumidite);
            this.GroupBoxSecurite.Controls.Add(this.LabelTemperature);
            this.GroupBoxSecurite.Controls.Add(this.LabelCourantBatterie2);
            this.GroupBoxSecurite.Controls.Add(this.LabelCourantBatterie1);
            this.GroupBoxSecurite.Controls.Add(this.LabelTensionBatterie2);
            this.GroupBoxSecurite.Controls.Add(this.LabelTensionBatterie1);
            this.GroupBoxSecurite.Enabled = false;
            this.GroupBoxSecurite.Location = new System.Drawing.Point(12, 513);
            this.GroupBoxSecurite.Name = "GroupBoxSecurite";
            this.GroupBoxSecurite.Size = new System.Drawing.Size(660, 80);
            this.GroupBoxSecurite.TabIndex = 4;
            this.GroupBoxSecurite.TabStop = false;
            this.GroupBoxSecurite.Text = "Sécurité";
            // 
            // LabelHumidite
            // 
            this.LabelHumidite.AutoSize = true;
            this.LabelHumidite.Location = new System.Drawing.Point(506, 47);
            this.LabelHumidite.Name = "LabelHumidite";
            this.LabelHumidite.Size = new System.Drawing.Size(111, 13);
            this.LabelHumidite.TabIndex = 5;
            this.LabelHumidite.Text = "Taux d\'humidité : xx %";
            // 
            // LabelTemperature
            // 
            this.LabelTemperature.AutoSize = true;
            this.LabelTemperature.Location = new System.Drawing.Point(506, 25);
            this.LabelTemperature.Name = "LabelTemperature";
            this.LabelTemperature.Size = new System.Drawing.Size(108, 13);
            this.LabelTemperature.TabIndex = 4;
            this.LabelTemperature.Text = "Température : xx,x °C";
            // 
            // LabelCourantBatterie2
            // 
            this.LabelCourantBatterie2.AutoSize = true;
            this.LabelCourantBatterie2.Location = new System.Drawing.Point(266, 47);
            this.LabelCourantBatterie2.Name = "LabelCourantBatterie2";
            this.LabelCourantBatterie2.Size = new System.Drawing.Size(128, 13);
            this.LabelCourantBatterie2.TabIndex = 3;
            this.LabelCourantBatterie2.Text = "Courant batterie 2 : x,xx A";
            // 
            // LabelCourantBatterie1
            // 
            this.LabelCourantBatterie1.AutoSize = true;
            this.LabelCourantBatterie1.Location = new System.Drawing.Point(266, 25);
            this.LabelCourantBatterie1.Name = "LabelCourantBatterie1";
            this.LabelCourantBatterie1.Size = new System.Drawing.Size(128, 13);
            this.LabelCourantBatterie1.TabIndex = 2;
            this.LabelCourantBatterie1.Text = "Courant batterie 1 : x,xx A";
            // 
            // LabelTensionBatterie2
            // 
            this.LabelTensionBatterie2.AutoSize = true;
            this.LabelTensionBatterie2.Location = new System.Drawing.Point(6, 47);
            this.LabelTensionBatterie2.Name = "LabelTensionBatterie2";
            this.LabelTensionBatterie2.Size = new System.Drawing.Size(129, 13);
            this.LabelTensionBatterie2.TabIndex = 1;
            this.LabelTensionBatterie2.Text = "Tension batterie 2 : x,xx V";
            // 
            // LabelTensionBatterie1
            // 
            this.LabelTensionBatterie1.AutoSize = true;
            this.LabelTensionBatterie1.Location = new System.Drawing.Point(6, 25);
            this.LabelTensionBatterie1.Name = "LabelTensionBatterie1";
            this.LabelTensionBatterie1.Size = new System.Drawing.Size(129, 13);
            this.LabelTensionBatterie1.TabIndex = 0;
            this.LabelTensionBatterie1.Text = "Tension batterie 1 : x,xx V";
            // 
            // Timer_acquisition
            // 
            this.Timer_acquisition.Enabled = true;
            this.Timer_acquisition.Interval = 3000;
            // 
            // FormTelecommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 582);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBoxSecurite);
            this.Controls.Add(this.GroupBoxPosition);
            this.Controls.Add(this.GroupBoxPropulsion);
            this.Controls.Add(this.GroupBoxBallasts);
            this.Controls.Add(this.GroupBoxInfo);
            this.MaximumSize = new System.Drawing.Size(700, 640);
            this.MinimumSize = new System.Drawing.Size(700, 568);
            this.Name = "FormTelecommande";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Télécommande";
            this.Load += new System.EventHandler(this.FormTelecommande_Load);
            this.GroupBoxInfo.ResumeLayout(false);
            this.GroupBoxInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageSousMarin)).EndInit();
            this.GroupBoxBallasts.ResumeLayout(false);
            this.GroupBoxBallasts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurseurBallastArriere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurseurBallastAvant)).EndInit();
            this.GroupBoxPropulsion.ResumeLayout(false);
            this.GroupBoxPropulsion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurseurPropulsion)).EndInit();
            this.GroupBoxPosition.ResumeLayout(false);
            this.GroupBoxPosition.PerformLayout();
            this.GroupBoxSecurite.ResumeLayout(false);
            this.GroupBoxSecurite.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxInfo;
        private System.Windows.Forms.GroupBox GroupBoxBallasts;
        private System.Windows.Forms.GroupBox GroupBoxPropulsion;
        private System.Windows.Forms.GroupBox GroupBoxPosition;
        private System.Windows.Forms.GroupBox GroupBoxSecurite;
        private System.Windows.Forms.TrackBar CurseurBallastArriere;
        private System.Windows.Forms.TrackBar CurseurBallastAvant;
        private System.Windows.Forms.CheckBox LierBallast;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar BarreBallastArriere;
        private System.Windows.Forms.ProgressBar BarreBallastAvant;
        private System.Windows.Forms.Label LabelVitesseMoteur2;
        private System.Windows.Forms.Label LabelVitesseMoteur1;
        private System.Windows.Forms.TrackBar CurseurPropulsion;
        private System.Windows.Forms.Label LabelInclinaisonAxeY;
        private System.Windows.Forms.Label LabelInclinaisonAxeX;
        private System.Windows.Forms.Label LabelProfondeur;
        private System.Windows.Forms.Label LabelHumidite;
        private System.Windows.Forms.Label LabelTemperature;
        private System.Windows.Forms.Label LabelCourantBatterie2;
        private System.Windows.Forms.Label LabelCourantBatterie1;
        private System.Windows.Forms.Label LabelTensionBatterie2;
        private System.Windows.Forms.Label LabelTensionBatterie1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ValeurPositionBallastArriere;
        private System.Windows.Forms.Label ValeurConsigneBallastArriere;
        private System.Windows.Forms.Label ValeurPositionBallastAvant;
        private System.Windows.Forms.Label ValeurConsigneBallastAvant;
        private System.Windows.Forms.Label ValeurConsignePropulsion;
        private System.Windows.Forms.Button BoutonSTOP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox ImageSousMarin;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Debut_acq;
        private System.Windows.Forms.Timer Timer_acquisition;
        private System.Windows.Forms.TextBox Vue_donnees_transit;
    }
}