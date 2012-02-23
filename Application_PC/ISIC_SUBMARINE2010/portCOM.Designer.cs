namespace isic_submarine_com
{
    partial class FormPortCom
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
            this.PortCom = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelPortCom = new System.Windows.Forms.Label();
            this.timer0 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // PortCom
            // 
            this.PortCom.FormattingEnabled = true;
            this.PortCom.Location = new System.Drawing.Point(11, 36);
            this.PortCom.Name = "PortCom";
            this.PortCom.Size = new System.Drawing.Size(121, 21);
            this.PortCom.TabIndex = 0;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(180, 34);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connecter";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelPortCom
            // 
            this.labelPortCom.AutoSize = true;
            this.labelPortCom.Location = new System.Drawing.Point(12, 9);
            this.labelPortCom.Name = "labelPortCom";
            this.labelPortCom.Size = new System.Drawing.Size(161, 13);
            this.labelPortCom.TabIndex = 2;
            this.labelPortCom.Text = "Veuillez choisir un port COM libre";
            // 
            // timer0
            // 
            this.timer0.Enabled = true;
            this.timer0.Interval = 25;
            this.timer0.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormPortCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 69);
            this.Controls.Add(this.labelPortCom);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.PortCom);
            this.Name = "FormPortCom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demande du port Com";
            this.Load += new System.EventHandler(this.FormPortCom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PortCom;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelPortCom;
        private System.Windows.Forms.Timer timer0;
    }
}