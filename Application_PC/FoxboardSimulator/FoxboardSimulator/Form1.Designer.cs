namespace FoxboardSimulator
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.CbPort = new System.Windows.Forms.ComboBox();
            this.CbBaud = new System.Windows.Forms.ComboBox();
            this.BtConnect = new System.Windows.Forms.Button();
            this.BtDisconnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RchTxtReceive = new System.Windows.Forms.RichTextBox();
            this.BtSend = new System.Windows.Forms.Button();
            this.TxtBValeur = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RbH = new System.Windows.Forms.RadioButton();
            this.RbADC4 = new System.Windows.Forms.RadioButton();
            this.RbADC3 = new System.Windows.Forms.RadioButton();
            this.RbADC2 = new System.Windows.Forms.RadioButton();
            this.RbADC1 = new System.Windows.Forms.RadioButton();
            this.RbT8 = new System.Windows.Forms.RadioButton();
            this.RbT7 = new System.Windows.Forms.RadioButton();
            this.RbT6 = new System.Windows.Forms.RadioButton();
            this.RbT5 = new System.Windows.Forms.RadioButton();
            this.RbT4 = new System.Windows.Forms.RadioButton();
            this.RbT3 = new System.Windows.Forms.RadioButton();
            this.RbT2 = new System.Windows.Forms.RadioButton();
            this.RbT1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CbPort
            // 
            this.CbPort.FormattingEnabled = true;
            this.CbPort.Location = new System.Drawing.Point(64, 24);
            this.CbPort.Name = "CbPort";
            this.CbPort.Size = new System.Drawing.Size(94, 21);
            this.CbPort.TabIndex = 0;
            this.CbPort.SelectedIndexChanged += new System.EventHandler(this.CbPort_SelectedIndexChanged);
            // 
            // CbBaud
            // 
            this.CbBaud.FormattingEnabled = true;
            this.CbBaud.Location = new System.Drawing.Point(64, 54);
            this.CbBaud.Name = "CbBaud";
            this.CbBaud.Size = new System.Drawing.Size(94, 21);
            this.CbBaud.TabIndex = 1;
            // 
            // BtConnect
            // 
            this.BtConnect.Location = new System.Drawing.Point(201, 22);
            this.BtConnect.Name = "BtConnect";
            this.BtConnect.Size = new System.Drawing.Size(75, 23);
            this.BtConnect.TabIndex = 2;
            this.BtConnect.Text = "Connect";
            this.BtConnect.UseVisualStyleBackColor = true;
            this.BtConnect.Click += new System.EventHandler(this.BtConnect_Click);
            // 
            // BtDisconnect
            // 
            this.BtDisconnect.Location = new System.Drawing.Point(201, 52);
            this.BtDisconnect.Name = "BtDisconnect";
            this.BtDisconnect.Size = new System.Drawing.Size(75, 23);
            this.BtDisconnect.TabIndex = 3;
            this.BtDisconnect.Text = "Disconnect";
            this.BtDisconnect.UseVisualStyleBackColor = true;
            this.BtDisconnect.Click += new System.EventHandler(this.BtDisconnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "COM port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baud rate";
            // 
            // RchTxtReceive
            // 
            this.RchTxtReceive.Location = new System.Drawing.Point(9, 56);
            this.RchTxtReceive.Name = "RchTxtReceive";
            this.RchTxtReceive.Size = new System.Drawing.Size(288, 77);
            this.RchTxtReceive.TabIndex = 6;
            this.RchTxtReceive.Text = "";
            // 
            // BtSend
            // 
            this.BtSend.Location = new System.Drawing.Point(222, 62);
            this.BtSend.Name = "BtSend";
            this.BtSend.Size = new System.Drawing.Size(75, 23);
            this.BtSend.TabIndex = 7;
            this.BtSend.Text = "Request";
            this.BtSend.UseVisualStyleBackColor = true;
            this.BtSend.Click += new System.EventHandler(this.BtSend_Click);
            // 
            // TxtBValeur
            // 
            this.TxtBValeur.Location = new System.Drawing.Point(9, 19);
            this.TxtBValeur.Name = "TxtBValeur";
            this.TxtBValeur.Size = new System.Drawing.Size(100, 20);
            this.TxtBValeur.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtConnect);
            this.groupBox1.Controls.Add(this.BtDisconnect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CbBaud);
            this.groupBox1.Controls.Add(this.CbPort);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 87);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtBValeur);
            this.groupBox2.Controls.Add(this.RchTxtReceive);
            this.groupBox2.Location = new System.Drawing.Point(12, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 146);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data In";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RbH);
            this.groupBox3.Controls.Add(this.RbADC4);
            this.groupBox3.Controls.Add(this.RbADC3);
            this.groupBox3.Controls.Add(this.RbADC2);
            this.groupBox3.Controls.Add(this.RbADC1);
            this.groupBox3.Controls.Add(this.RbT8);
            this.groupBox3.Controls.Add(this.RbT7);
            this.groupBox3.Controls.Add(this.RbT6);
            this.groupBox3.Controls.Add(this.RbT5);
            this.groupBox3.Controls.Add(this.RbT4);
            this.groupBox3.Controls.Add(this.RbT3);
            this.groupBox3.Controls.Add(this.RbT2);
            this.groupBox3.Controls.Add(this.RbT1);
            this.groupBox3.Controls.Add(this.BtSend);
            this.groupBox3.Location = new System.Drawing.Point(12, 105);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(307, 124);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sensor Request";
            // 
            // RbH
            // 
            this.RbH.AutoSize = true;
            this.RbH.Location = new System.Drawing.Point(222, 20);
            this.RbH.Name = "RbH";
            this.RbH.Size = new System.Drawing.Size(41, 17);
            this.RbH.TabIndex = 20;
            this.RbH.TabStop = true;
            this.RbH.Text = "H%";
            this.RbH.UseVisualStyleBackColor = true;
            // 
            // RbADC4
            // 
            this.RbADC4.AutoSize = true;
            this.RbADC4.Location = new System.Drawing.Point(142, 89);
            this.RbADC4.Name = "RbADC4";
            this.RbADC4.Size = new System.Drawing.Size(53, 17);
            this.RbADC4.TabIndex = 19;
            this.RbADC4.TabStop = true;
            this.RbADC4.Text = "ADC4";
            this.RbADC4.UseVisualStyleBackColor = true;
            // 
            // RbADC3
            // 
            this.RbADC3.AutoSize = true;
            this.RbADC3.Location = new System.Drawing.Point(142, 66);
            this.RbADC3.Name = "RbADC3";
            this.RbADC3.Size = new System.Drawing.Size(53, 17);
            this.RbADC3.TabIndex = 18;
            this.RbADC3.TabStop = true;
            this.RbADC3.Text = "ADC3";
            this.RbADC3.UseVisualStyleBackColor = true;
            // 
            // RbADC2
            // 
            this.RbADC2.AutoSize = true;
            this.RbADC2.Location = new System.Drawing.Point(142, 43);
            this.RbADC2.Name = "RbADC2";
            this.RbADC2.Size = new System.Drawing.Size(53, 17);
            this.RbADC2.TabIndex = 17;
            this.RbADC2.TabStop = true;
            this.RbADC2.Text = "ADC2";
            this.RbADC2.UseVisualStyleBackColor = true;
            // 
            // RbADC1
            // 
            this.RbADC1.AutoSize = true;
            this.RbADC1.Location = new System.Drawing.Point(142, 20);
            this.RbADC1.Name = "RbADC1";
            this.RbADC1.Size = new System.Drawing.Size(53, 17);
            this.RbADC1.TabIndex = 16;
            this.RbADC1.TabStop = true;
            this.RbADC1.Text = "ADC1";
            this.RbADC1.UseVisualStyleBackColor = true;
            // 
            // RbT8
            // 
            this.RbT8.AutoSize = true;
            this.RbT8.Location = new System.Drawing.Point(77, 89);
            this.RbT8.Name = "RbT8";
            this.RbT8.Size = new System.Drawing.Size(42, 17);
            this.RbT8.TabIndex = 15;
            this.RbT8.TabStop = true;
            this.RbT8.Text = "T°8";
            this.RbT8.UseVisualStyleBackColor = true;
            // 
            // RbT7
            // 
            this.RbT7.AutoSize = true;
            this.RbT7.Location = new System.Drawing.Point(77, 68);
            this.RbT7.Name = "RbT7";
            this.RbT7.Size = new System.Drawing.Size(42, 17);
            this.RbT7.TabIndex = 14;
            this.RbT7.TabStop = true;
            this.RbT7.Text = "T°7";
            this.RbT7.UseVisualStyleBackColor = true;
            // 
            // RbT6
            // 
            this.RbT6.AutoSize = true;
            this.RbT6.Location = new System.Drawing.Point(77, 43);
            this.RbT6.Name = "RbT6";
            this.RbT6.Size = new System.Drawing.Size(42, 17);
            this.RbT6.TabIndex = 13;
            this.RbT6.TabStop = true;
            this.RbT6.Text = "T°6";
            this.RbT6.UseVisualStyleBackColor = true;
            // 
            // RbT5
            // 
            this.RbT5.AutoSize = true;
            this.RbT5.Location = new System.Drawing.Point(77, 20);
            this.RbT5.Name = "RbT5";
            this.RbT5.Size = new System.Drawing.Size(42, 17);
            this.RbT5.TabIndex = 12;
            this.RbT5.TabStop = true;
            this.RbT5.Text = "T°5";
            this.RbT5.UseVisualStyleBackColor = true;
            // 
            // RbT4
            // 
            this.RbT4.AutoSize = true;
            this.RbT4.Location = new System.Drawing.Point(9, 89);
            this.RbT4.Name = "RbT4";
            this.RbT4.Size = new System.Drawing.Size(42, 17);
            this.RbT4.TabIndex = 11;
            this.RbT4.TabStop = true;
            this.RbT4.Text = "T°4";
            this.RbT4.UseVisualStyleBackColor = true;
            // 
            // RbT3
            // 
            this.RbT3.AutoSize = true;
            this.RbT3.Location = new System.Drawing.Point(9, 66);
            this.RbT3.Name = "RbT3";
            this.RbT3.Size = new System.Drawing.Size(42, 17);
            this.RbT3.TabIndex = 10;
            this.RbT3.TabStop = true;
            this.RbT3.Text = "T°3";
            this.RbT3.UseVisualStyleBackColor = true;
            // 
            // RbT2
            // 
            this.RbT2.AutoSize = true;
            this.RbT2.Location = new System.Drawing.Point(9, 43);
            this.RbT2.Name = "RbT2";
            this.RbT2.Size = new System.Drawing.Size(42, 17);
            this.RbT2.TabIndex = 9;
            this.RbT2.TabStop = true;
            this.RbT2.Text = "T°2";
            this.RbT2.UseVisualStyleBackColor = true;
            // 
            // RbT1
            // 
            this.RbT1.AutoSize = true;
            this.RbT1.Checked = true;
            this.RbT1.Location = new System.Drawing.Point(9, 20);
            this.RbT1.Name = "RbT1";
            this.RbT1.Size = new System.Drawing.Size(42, 17);
            this.RbT1.TabIndex = 8;
            this.RbT1.TabStop = true;
            this.RbT1.Text = "T°1";
            this.RbT1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 392);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "FoxboardSimulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CbPort;
        private System.Windows.Forms.ComboBox CbBaud;
        private System.Windows.Forms.Button BtConnect;
        private System.Windows.Forms.Button BtDisconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox RchTxtReceive;
        private System.Windows.Forms.Button BtSend;
        private System.Windows.Forms.TextBox TxtBValeur;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RbT5;
        private System.Windows.Forms.RadioButton RbT4;
        private System.Windows.Forms.RadioButton RbT3;
        private System.Windows.Forms.RadioButton RbT2;
        private System.Windows.Forms.RadioButton RbT1;
        private System.Windows.Forms.RadioButton RbT8;
        private System.Windows.Forms.RadioButton RbT7;
        private System.Windows.Forms.RadioButton RbT6;
        private System.Windows.Forms.RadioButton RbH;
        private System.Windows.Forms.RadioButton RbADC4;
        private System.Windows.Forms.RadioButton RbADC3;
        private System.Windows.Forms.RadioButton RbADC2;
        private System.Windows.Forms.RadioButton RbADC1;
    }
}

