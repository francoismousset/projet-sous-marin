namespace ISIC_SUBMARINE2010
{
    partial class FormMain
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
            this.Main_BarreMenu = new System.Windows.Forms.MenuStrip();
            this.Main_BarreMenu_SousMarin = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_BarreMenu_SousMarin_Nouveau = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_BarreMenu_SousMarin_Separateur1 = new System.Windows.Forms.ToolStripSeparator();
            this.Main_BarreMenu_SousMarin_Fermer = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_BarreMenu_SousMarin_Supprimer = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_BarreMenu_SousMarin_Separateur2 = new System.Windows.Forms.ToolStripSeparator();
            this.Main_BarreMenu_SousMarin_Quitter = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_BarreMenu_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_BarreMenu_Options_Config = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_BarreMenu_Options_Separateur = new System.Windows.Forms.ToolStripSeparator();
            this.Main_BarreMenu_Options_LancerProgrammeFB = new System.Windows.Forms.ToolStripMenuItem();
            this.arrêterLeProgrammeFoxBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_BarreMenu_Aide = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_BarreMenu_Aide_Afficher = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_BarreMenu_Aide_Apropos = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_BarreStatut = new System.Windows.Forms.StatusStrip();
            this.Main_BarreStatut_Texte1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Main_Dialogue_Nouveau = new System.Windows.Forms.OpenFileDialog();
            this.Main_BarreMenu.SuspendLayout();
            this.Main_BarreStatut.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_BarreMenu
            // 
            this.Main_BarreMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Main_BarreMenu_SousMarin,
            this.Main_BarreMenu_Options,
            this.Main_BarreMenu_Aide});
            this.Main_BarreMenu.Location = new System.Drawing.Point(0, 0);
            this.Main_BarreMenu.Name = "Main_BarreMenu";
            this.Main_BarreMenu.Size = new System.Drawing.Size(724, 24);
            this.Main_BarreMenu.TabIndex = 2;
            this.Main_BarreMenu.Text = "Main_BarreMenu";
            // 
            // Main_BarreMenu_SousMarin
            // 
            this.Main_BarreMenu_SousMarin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Main_BarreMenu_SousMarin_Nouveau,
            this.Main_BarreMenu_SousMarin_Separateur1,
            this.Main_BarreMenu_SousMarin_Fermer,
            this.Main_BarreMenu_SousMarin_Supprimer,
            this.Main_BarreMenu_SousMarin_Separateur2,
            this.Main_BarreMenu_SousMarin_Quitter});
            this.Main_BarreMenu_SousMarin.Name = "Main_BarreMenu_SousMarin";
            this.Main_BarreMenu_SousMarin.Size = new System.Drawing.Size(80, 20);
            this.Main_BarreMenu_SousMarin.Text = "Sous-Marin";
            // 
            // Main_BarreMenu_SousMarin_Nouveau
            // 
            this.Main_BarreMenu_SousMarin_Nouveau.Name = "Main_BarreMenu_SousMarin_Nouveau";
            this.Main_BarreMenu_SousMarin_Nouveau.Size = new System.Drawing.Size(129, 22);
            this.Main_BarreMenu_SousMarin_Nouveau.Text = "Nouveau";
            this.Main_BarreMenu_SousMarin_Nouveau.Click += new System.EventHandler(this.Main_BarreMenu_SousMarin_Nouveau_Click);
            // 
            // Main_BarreMenu_SousMarin_Separateur1
            // 
            this.Main_BarreMenu_SousMarin_Separateur1.Name = "Main_BarreMenu_SousMarin_Separateur1";
            this.Main_BarreMenu_SousMarin_Separateur1.Size = new System.Drawing.Size(126, 6);
            // 
            // Main_BarreMenu_SousMarin_Fermer
            // 
            this.Main_BarreMenu_SousMarin_Fermer.Enabled = false;
            this.Main_BarreMenu_SousMarin_Fermer.Name = "Main_BarreMenu_SousMarin_Fermer";
            this.Main_BarreMenu_SousMarin_Fermer.Size = new System.Drawing.Size(129, 22);
            this.Main_BarreMenu_SousMarin_Fermer.Text = "Fermer";
            this.Main_BarreMenu_SousMarin_Fermer.Click += new System.EventHandler(this.Main_BarreMenu_SousMarin_Fermer_Click);
            // 
            // Main_BarreMenu_SousMarin_Supprimer
            // 
            this.Main_BarreMenu_SousMarin_Supprimer.Enabled = false;
            this.Main_BarreMenu_SousMarin_Supprimer.Name = "Main_BarreMenu_SousMarin_Supprimer";
            this.Main_BarreMenu_SousMarin_Supprimer.Size = new System.Drawing.Size(129, 22);
            this.Main_BarreMenu_SousMarin_Supprimer.Text = "Supprimer";
            this.Main_BarreMenu_SousMarin_Supprimer.Click += new System.EventHandler(this.Main_BarreMenu_SousMarin_Supprimer_Click);
            // 
            // Main_BarreMenu_SousMarin_Separateur2
            // 
            this.Main_BarreMenu_SousMarin_Separateur2.Name = "Main_BarreMenu_SousMarin_Separateur2";
            this.Main_BarreMenu_SousMarin_Separateur2.Size = new System.Drawing.Size(126, 6);
            // 
            // Main_BarreMenu_SousMarin_Quitter
            // 
            this.Main_BarreMenu_SousMarin_Quitter.Name = "Main_BarreMenu_SousMarin_Quitter";
            this.Main_BarreMenu_SousMarin_Quitter.Size = new System.Drawing.Size(129, 22);
            this.Main_BarreMenu_SousMarin_Quitter.Text = "Quitter";
            this.Main_BarreMenu_SousMarin_Quitter.Click += new System.EventHandler(this.Main_BarreMenu_SousMarin_Quitter_Click);
            // 
            // Main_BarreMenu_Options
            // 
            this.Main_BarreMenu_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Main_BarreMenu_Options_Config,
            this.Main_BarreMenu_Options_Separateur,
            this.Main_BarreMenu_Options_LancerProgrammeFB,
            this.arrêterLeProgrammeFoxBoardToolStripMenuItem});
            this.Main_BarreMenu_Options.Enabled = false;
            this.Main_BarreMenu_Options.Name = "Main_BarreMenu_Options";
            this.Main_BarreMenu_Options.Size = new System.Drawing.Size(61, 20);
            this.Main_BarreMenu_Options.Text = "Options";
            // 
            // Main_BarreMenu_Options_Config
            // 
            this.Main_BarreMenu_Options_Config.Name = "Main_BarreMenu_Options_Config";
            this.Main_BarreMenu_Options_Config.Size = new System.Drawing.Size(240, 22);
            this.Main_BarreMenu_Options_Config.Text = "Configuration du Sous-Marin";
            this.Main_BarreMenu_Options_Config.Click += new System.EventHandler(this.Main_BarreMenu_Options_Config_Click);
            // 
            // Main_BarreMenu_Options_Separateur
            // 
            this.Main_BarreMenu_Options_Separateur.Name = "Main_BarreMenu_Options_Separateur";
            this.Main_BarreMenu_Options_Separateur.Size = new System.Drawing.Size(237, 6);
            // 
            // Main_BarreMenu_Options_LancerProgrammeFB
            // 
            this.Main_BarreMenu_Options_LancerProgrammeFB.Name = "Main_BarreMenu_Options_LancerProgrammeFB";
            this.Main_BarreMenu_Options_LancerProgrammeFB.Size = new System.Drawing.Size(240, 22);
            this.Main_BarreMenu_Options_LancerProgrammeFB.Text = "Lancer le programme FoxBoard";
            this.Main_BarreMenu_Options_LancerProgrammeFB.Click += new System.EventHandler(this.Main_BarreMenu_Options_LancerProgrammeFB_Click);
            // 
            // arrêterLeProgrammeFoxBoardToolStripMenuItem
            // 
            this.arrêterLeProgrammeFoxBoardToolStripMenuItem.Name = "arrêterLeProgrammeFoxBoardToolStripMenuItem";
            this.arrêterLeProgrammeFoxBoardToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.arrêterLeProgrammeFoxBoardToolStripMenuItem.Text = "Arrêter le programme FoxBoard";
            this.arrêterLeProgrammeFoxBoardToolStripMenuItem.Click += new System.EventHandler(this.arrêterLeProgrammeFoxBoardToolStripMenuItem_Click);
            // 
            // Main_BarreMenu_Aide
            // 
            this.Main_BarreMenu_Aide.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Main_BarreMenu_Aide_Afficher,
            this.Main_BarreMenu_Aide_Apropos});
            this.Main_BarreMenu_Aide.Name = "Main_BarreMenu_Aide";
            this.Main_BarreMenu_Aide.Size = new System.Drawing.Size(43, 20);
            this.Main_BarreMenu_Aide.Text = "Aide";
            // 
            // Main_BarreMenu_Aide_Afficher
            // 
            this.Main_BarreMenu_Aide_Afficher.Enabled = false;
            this.Main_BarreMenu_Aide_Afficher.Name = "Main_BarreMenu_Aide_Afficher";
            this.Main_BarreMenu_Aide_Afficher.Size = new System.Drawing.Size(182, 22);
            this.Main_BarreMenu_Aide_Afficher.Text = "Afficher l\'aide";
            this.Main_BarreMenu_Aide_Afficher.Click += new System.EventHandler(this.Main_BarreMenu_Aide_Afficher_Click);
            // 
            // Main_BarreMenu_Aide_Apropos
            // 
            this.Main_BarreMenu_Aide_Apropos.Name = "Main_BarreMenu_Aide_Apropos";
            this.Main_BarreMenu_Aide_Apropos.Size = new System.Drawing.Size(182, 22);
            this.Main_BarreMenu_Aide_Apropos.Text = "A propos du projet...";
            this.Main_BarreMenu_Aide_Apropos.Click += new System.EventHandler(this.Main_BarreMenu_Aide_Apropos_Click);
            // 
            // Main_BarreStatut
            // 
            this.Main_BarreStatut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Main_BarreStatut_Texte1});
            this.Main_BarreStatut.Location = new System.Drawing.Point(0, 543);
            this.Main_BarreStatut.Name = "Main_BarreStatut";
            this.Main_BarreStatut.Size = new System.Drawing.Size(724, 22);
            this.Main_BarreStatut.TabIndex = 3;
            this.Main_BarreStatut.Text = "statusStrip1";
            // 
            // Main_BarreStatut_Texte1
            // 
            this.Main_BarreStatut_Texte1.Name = "Main_BarreStatut_Texte1";
            this.Main_BarreStatut_Texte1.Size = new System.Drawing.Size(287, 17);
            this.Main_BarreStatut_Texte1.Text = "Cliquez sur \"Sous-Marin/Nouveau\" pour commencer";
            // 
            // Main_Dialogue_Nouveau
            // 
            this.Main_Dialogue_Nouveau.CheckFileExists = false;
            this.Main_Dialogue_Nouveau.DefaultExt = "xml";
            this.Main_Dialogue_Nouveau.FileName = "NomSousMarin";
            this.Main_Dialogue_Nouveau.Filter = "*.xml|";
            this.Main_Dialogue_Nouveau.InitialDirectory = "Application.StartupPath";
            this.Main_Dialogue_Nouveau.Title = "Nouveau Sous-Marin";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ISIC_SUBMARINE2010.Properties.Resources.SMtrans2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(724, 565);
            this.Controls.Add(this.Main_BarreStatut);
            this.Controls.Add(this.Main_BarreMenu);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.Main_BarreMenu;
            this.Name = "FormMain";
            this.Text = "Projet Sous-Marin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Main_BarreMenu.ResumeLayout(false);
            this.Main_BarreMenu.PerformLayout();
            this.Main_BarreStatut.ResumeLayout(false);
            this.Main_BarreStatut.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Main_BarreMenu;
        private System.Windows.Forms.ToolStripMenuItem Main_BarreMenu_SousMarin;
        private System.Windows.Forms.ToolStripMenuItem Main_BarreMenu_Aide;
        private System.Windows.Forms.ToolStripMenuItem Main_BarreMenu_Aide_Afficher;
        private System.Windows.Forms.ToolStripMenuItem Main_BarreMenu_SousMarin_Nouveau;
        private System.Windows.Forms.ToolStripMenuItem Main_BarreMenu_SousMarin_Supprimer;
        private System.Windows.Forms.ToolStripMenuItem Main_BarreMenu_SousMarin_Quitter;
        private System.Windows.Forms.ToolStripMenuItem Main_BarreMenu_Aide_Apropos;
        private System.Windows.Forms.StatusStrip Main_BarreStatut;
        private System.Windows.Forms.ToolStripStatusLabel Main_BarreStatut_Texte1;
        private System.Windows.Forms.ToolStripMenuItem Main_BarreMenu_Options;
        private System.Windows.Forms.ToolStripMenuItem Main_BarreMenu_Options_Config;
        private System.Windows.Forms.ToolStripSeparator Main_BarreMenu_SousMarin_Separateur1;
        private System.Windows.Forms.ToolStripSeparator Main_BarreMenu_SousMarin_Separateur2;
        private System.Windows.Forms.OpenFileDialog Main_Dialogue_Nouveau;
        private System.Windows.Forms.ToolStripMenuItem Main_BarreMenu_SousMarin_Fermer;
        private System.Windows.Forms.ToolStripMenuItem Main_BarreMenu_Options_LancerProgrammeFB;
        private System.Windows.Forms.ToolStripSeparator Main_BarreMenu_Options_Separateur;
        private System.Windows.Forms.ToolStripMenuItem arrêterLeProgrammeFoxBoardToolStripMenuItem;
    }
}

