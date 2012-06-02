namespace ISIC_SUBMARINE
{
    partial class UI_SerialPort
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numUpDwnTimeoutOut = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnOutputBuffer = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numUpDwnTimeoutIn = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnInputBuffer = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rbtnPhys = new System.Windows.Forms.RadioButton();
            this.rbtnBluetooth = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPortComNames = new System.Windows.Forms.ComboBox();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbDataBits = new System.Windows.Forms.ComboBox();
            this.cbBaudrate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDefault = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnTimeoutOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnOutputBuffer)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnTimeoutIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnInputBuffer)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(9, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 188);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paramètres d\'échange des données";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numUpDwnTimeoutOut);
            this.groupBox4.Controls.Add(this.numUpDwnOutputBuffer);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(6, 96);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(274, 77);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Émission";
            // 
            // numUpDwnTimeoutOut
            // 
            this.numUpDwnTimeoutOut.Location = new System.Drawing.Point(138, 44);
            this.numUpDwnTimeoutOut.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDwnTimeoutOut.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numUpDwnTimeoutOut.Name = "numUpDwnTimeoutOut";
            this.numUpDwnTimeoutOut.Size = new System.Drawing.Size(61, 20);
            this.numUpDwnTimeoutOut.TabIndex = 5;
            // 
            // numUpDwnOutputBuffer
            // 
            this.numUpDwnOutputBuffer.Location = new System.Drawing.Point(138, 18);
            this.numUpDwnOutputBuffer.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numUpDwnOutputBuffer.Minimum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.numUpDwnOutputBuffer.Name = "numUpDwnOutputBuffer";
            this.numUpDwnOutputBuffer.Size = new System.Drawing.Size(61, 20);
            this.numUpDwnOutputBuffer.TabIndex = 4;
            this.numUpDwnOutputBuffer.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(81, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Timeout :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Taille du buffer de sortie :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numUpDwnTimeoutIn);
            this.groupBox3.Controls.Add(this.numUpDwnInputBuffer);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(7, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 70);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Réception";
            // 
            // numUpDwnTimeoutIn
            // 
            this.numUpDwnTimeoutIn.Location = new System.Drawing.Point(137, 43);
            this.numUpDwnTimeoutIn.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDwnTimeoutIn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numUpDwnTimeoutIn.Name = "numUpDwnTimeoutIn";
            this.numUpDwnTimeoutIn.Size = new System.Drawing.Size(61, 20);
            this.numUpDwnTimeoutIn.TabIndex = 5;
            // 
            // numUpDwnInputBuffer
            // 
            this.numUpDwnInputBuffer.Location = new System.Drawing.Point(137, 17);
            this.numUpDwnInputBuffer.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.numUpDwnInputBuffer.Minimum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numUpDwnInputBuffer.Name = "numUpDwnInputBuffer";
            this.numUpDwnInputBuffer.Size = new System.Drawing.Size(61, 20);
            this.numUpDwnInputBuffer.TabIndex = 4;
            this.numUpDwnInputBuffer.Value = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Timeout :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Taille du buffer d\'entrée :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.rbtnPhys);
            this.groupBox1.Controls.Add(this.rbtnBluetooth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbPortComNames);
            this.groupBox1.Controls.Add(this.cbStopBits);
            this.groupBox1.Controls.Add(this.cbParity);
            this.groupBox1.Controls.Add(this.cbDataBits);
            this.groupBox1.Controls.Add(this.cbBaudrate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 182);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paramètres du port série";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(91, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Type :";
            // 
            // rbtnPhys
            // 
            this.rbtnPhys.AutoSize = true;
            this.rbtnPhys.Location = new System.Drawing.Point(137, 17);
            this.rbtnPhys.Name = "rbtnPhys";
            this.rbtnPhys.Size = new System.Drawing.Size(69, 17);
            this.rbtnPhys.TabIndex = 32;
            this.rbtnPhys.TabStop = true;
            this.rbtnPhys.Text = "Ultrasons";
            this.rbtnPhys.UseVisualStyleBackColor = true;
            this.rbtnPhys.CheckedChanged += new System.EventHandler(this.rbtnPhys_CheckedChanged);
            // 
            // rbtnBluetooth
            // 
            this.rbtnBluetooth.AutoSize = true;
            this.rbtnBluetooth.Location = new System.Drawing.Point(210, 17);
            this.rbtnBluetooth.Name = "rbtnBluetooth";
            this.rbtnBluetooth.Size = new System.Drawing.Size(70, 17);
            this.rbtnBluetooth.TabIndex = 33;
            this.rbtnBluetooth.TabStop = true;
            this.rbtnBluetooth.Text = "Bluetooth";
            this.rbtnBluetooth.UseVisualStyleBackColor = true;
            this.rbtnBluetooth.CheckedChanged += new System.EventHandler(this.rbtnBluetooth_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Port de communication :";
            // 
            // cbPortComNames
            // 
            this.cbPortComNames.FormattingEnabled = true;
            this.cbPortComNames.Location = new System.Drawing.Point(140, 40);
            this.cbPortComNames.Name = "cbPortComNames";
            this.cbPortComNames.Size = new System.Drawing.Size(121, 21);
            this.cbPortComNames.TabIndex = 10;
            // 
            // cbStopBits
            // 
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Items.AddRange(new object[] {
            "Aucun",
            "1",
            "1,5",
            "2"});
            this.cbStopBits.Location = new System.Drawing.Point(140, 148);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(121, 21);
            this.cbStopBits.TabIndex = 9;
            // 
            // cbParity
            // 
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Items.AddRange(new object[] {
            "Pair",
            "Impair",
            "Aucun",
            "Marque",
            "Espace"});
            this.cbParity.Location = new System.Drawing.Point(140, 121);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(121, 21);
            this.cbParity.TabIndex = 8;
            // 
            // cbDataBits
            // 
            this.cbDataBits.FormattingEnabled = true;
            this.cbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cbDataBits.Location = new System.Drawing.Point(140, 94);
            this.cbDataBits.Name = "cbDataBits";
            this.cbDataBits.Size = new System.Drawing.Size(121, 21);
            this.cbDataBits.TabIndex = 7;
            // 
            // cbBaudrate
            // 
            this.cbBaudrate.FormattingEnabled = true;
            this.cbBaudrate.Items.AddRange(new object[] {
            "110",
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600",
            ""});
            this.cbBaudrate.Location = new System.Drawing.Point(140, 67);
            this.cbBaudrate.Name = "cbBaudrate";
            this.cbBaudrate.Size = new System.Drawing.Size(121, 21);
            this.cbBaudrate.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Bits d\'arrêt :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Parité :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bits de données :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bits par seconde :";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(197, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(83, 21);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.Text = "Connecter";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDefault);
            this.groupBox5.Controls.Add(this.btnConnect);
            this.groupBox5.Location = new System.Drawing.Point(9, 387);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(290, 54);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(19, 19);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(119, 21);
            this.btnDefault.TabIndex = 12;
            this.btnDefault.Text = "Paramètres par défaut";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // UI_SerialPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 450);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UI_SerialPort";
            this.Text = "Port de communication";
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnTimeoutOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnOutputBuffer)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnTimeoutIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnInputBuffer)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbDataBits;
        private System.Windows.Forms.ComboBox cbBaudrate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPortComNames;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rbtnPhys;
        private System.Windows.Forms.RadioButton rbtnBluetooth;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.NumericUpDown numUpDwnTimeoutOut;
        private System.Windows.Forms.NumericUpDown numUpDwnOutputBuffer;
        private System.Windows.Forms.NumericUpDown numUpDwnTimeoutIn;
        private System.Windows.Forms.NumericUpDown numUpDwnInputBuffer;
    }
}