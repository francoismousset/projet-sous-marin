namespace ISIC_SUBMARINE2010
{
    partial class FormConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsole));
            this.envoiConsole = new System.Windows.Forms.TextBox();
            this.Console_BoutonEnvoyer = new System.Windows.Forms.Button();
            this.textConsole = new System.Windows.Forms.RichTextBox();
            this.EtatConnexion = new System.Windows.Forms.Label();
            this.LedConnexion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // envoiConsole
            // 
            this.envoiConsole.Location = new System.Drawing.Point(12, 279);
            this.envoiConsole.Name = "envoiConsole";
            this.envoiConsole.Size = new System.Drawing.Size(579, 20);
            this.envoiConsole.TabIndex = 0;
            // 
            // Console_BoutonEnvoyer
            // 
            this.Console_BoutonEnvoyer.Location = new System.Drawing.Point(597, 279);
            this.Console_BoutonEnvoyer.Name = "Console_BoutonEnvoyer";
            this.Console_BoutonEnvoyer.Size = new System.Drawing.Size(75, 23);
            this.Console_BoutonEnvoyer.TabIndex = 1;
            this.Console_BoutonEnvoyer.Text = "Envoyer";
            this.Console_BoutonEnvoyer.UseVisualStyleBackColor = true;
            this.Console_BoutonEnvoyer.Click += new System.EventHandler(this.Console_BoutonEnvoyer_Click);
            // 
            // textConsole
            // 
            this.textConsole.BackColor = System.Drawing.SystemColors.WindowText;
            this.textConsole.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textConsole.ForeColor = System.Drawing.SystemColors.Window;
            this.textConsole.Location = new System.Drawing.Point(12, 25);
            this.textConsole.Name = "textConsole";
            this.textConsole.Size = new System.Drawing.Size(660, 246);
            this.textConsole.TabIndex = 2;
            this.textConsole.Text = "Emulation de la console\n\n> ";
            // 
            // EtatConnexion
            // 
            this.EtatConnexion.AutoSize = true;
            this.EtatConnexion.Location = new System.Drawing.Point(40, 9);
            this.EtatConnexion.Name = "EtatConnexion";
            this.EtatConnexion.Size = new System.Drawing.Size(81, 13);
            this.EtatConnexion.TabIndex = 3;
            this.EtatConnexion.Text = "Hors connexion";
            // 
            // LedConnexion
            // 
            this.LedConnexion.AutoSize = true;
            this.LedConnexion.BackColor = System.Drawing.Color.Red;
            this.LedConnexion.Location = new System.Drawing.Point(12, 9);
            this.LedConnexion.Name = "LedConnexion";
            this.LedConnexion.Size = new System.Drawing.Size(22, 13);
            this.LedConnexion.TabIndex = 4;
            this.LedConnexion.Text = "     ";
            // 
            // FormConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 316);
            this.ControlBox = false;
            this.Controls.Add(this.LedConnexion);
            this.Controls.Add(this.EtatConnexion);
            this.Controls.Add(this.textConsole);
            this.Controls.Add(this.Console_BoutonEnvoyer);
            this.Controls.Add(this.envoiConsole);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(700, 350);
            this.MinimumSize = new System.Drawing.Size(350, 100);
            this.Name = "FormConsole";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Console";
            this.SizeChanged += new System.EventHandler(this.FormConsole_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox envoiConsole;
        private System.Windows.Forms.Button Console_BoutonEnvoyer;
        private System.Windows.Forms.RichTextBox textConsole;
        private System.Windows.Forms.Label EtatConnexion;
        private System.Windows.Forms.Label LedConnexion;
    }
}