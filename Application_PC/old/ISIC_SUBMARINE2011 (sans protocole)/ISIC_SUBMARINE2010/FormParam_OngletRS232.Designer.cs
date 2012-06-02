namespace ISIC_SUBMARINE2010
{
    partial class FormParam_OngletRS232
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
            this.nb_bits_stop = new System.Windows.Forms.ComboBox();
            this.parity = new System.Windows.Forms.ComboBox();
            this.nb_bits = new System.Windows.Forms.ComboBox();
            this.baudrate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.timeOutSortie = new System.Windows.Forms.TextBox();
            this.bufferSortie = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timeOutEntree = new System.Windows.Forms.TextBox();
            this.bufferEntree = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nb_bits_stop);
            this.groupBox1.Controls.Add(this.parity);
            this.groupBox1.Controls.Add(this.nb_bits);
            this.groupBox1.Controls.Add(this.baudrate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paramètres de la communication série";
            // 
            // nb_bits_stop
            // 
            this.nb_bits_stop.FormattingEnabled = true;
            this.nb_bits_stop.Items.AddRange(new object[] {
            "NONE",
            "ONE",
            "TWO"});
            this.nb_bits_stop.Location = new System.Drawing.Point(183, 113);
            this.nb_bits_stop.Name = "nb_bits_stop";
            this.nb_bits_stop.Size = new System.Drawing.Size(121, 21);
            this.nb_bits_stop.TabIndex = 9;
            // 
            // parity
            // 
            this.parity.FormattingEnabled = true;
            this.parity.Items.AddRange(new object[] {
            "NONE",
            "ODD",
            "EVEN"});
            this.parity.Location = new System.Drawing.Point(183, 85);
            this.parity.Name = "parity";
            this.parity.Size = new System.Drawing.Size(121, 21);
            this.parity.TabIndex = 8;
            // 
            // nb_bits
            // 
            this.nb_bits.FormattingEnabled = true;
            this.nb_bits.Items.AddRange(new object[] {
            "8",
            "10"});
            this.nb_bits.Location = new System.Drawing.Point(183, 57);
            this.nb_bits.Name = "nb_bits";
            this.nb_bits.Size = new System.Drawing.Size(121, 21);
            this.nb_bits.TabIndex = 7;
            // 
            // baudrate
            // 
            this.baudrate.FormattingEnabled = true;
            this.baudrate.Items.AddRange(new object[] {
            "300",
            "9600"});
            this.baudrate.Location = new System.Drawing.Point(183, 29);
            this.baudrate.Name = "baudrate";
            this.baudrate.Size = new System.Drawing.Size(121, 21);
            this.baudrate.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nombre de bits de stop";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Parité";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre de bits";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vitesse de la communication";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(16, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 204);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paramètres d\'échange des données";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.timeOutSortie);
            this.groupBox4.Controls.Add(this.bufferSortie);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(206, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(189, 178);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Émission";
            // 
            // timeOutSortie
            // 
            this.timeOutSortie.Location = new System.Drawing.Point(22, 117);
            this.timeOutSortie.Name = "timeOutSortie";
            this.timeOutSortie.Size = new System.Drawing.Size(100, 20);
            this.timeOutSortie.TabIndex = 3;
            // 
            // bufferSortie
            // 
            this.bufferSortie.Location = new System.Drawing.Point(22, 44);
            this.bufferSortie.Name = "bufferSortie";
            this.bufferSortie.Size = new System.Drawing.Size(100, 20);
            this.bufferSortie.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Time out";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Taille du buffer de sortie";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.timeOutEntree);
            this.groupBox3.Controls.Add(this.bufferEntree);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(7, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 178);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Réception";
            // 
            // timeOutEntree
            // 
            this.timeOutEntree.Location = new System.Drawing.Point(16, 117);
            this.timeOutEntree.Name = "timeOutEntree";
            this.timeOutEntree.Size = new System.Drawing.Size(100, 20);
            this.timeOutEntree.TabIndex = 3;
            // 
            // bufferEntree
            // 
            this.bufferEntree.Location = new System.Drawing.Point(16, 44);
            this.bufferEntree.Name = "bufferEntree";
            this.bufferEntree.Size = new System.Drawing.Size(100, 20);
            this.bufferEntree.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Time out";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Taille du buffer d\'entrée";
            // 
            // FormParam_OngletRS232
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 447);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormParam_OngletRS232";
            this.Text = "FormParam_OngletRS232";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox nb_bits_stop;
        private System.Windows.Forms.ComboBox parity;
        private System.Windows.Forms.ComboBox nb_bits;
        private System.Windows.Forms.ComboBox baudrate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox timeOutSortie;
        private System.Windows.Forms.TextBox bufferSortie;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox timeOutEntree;
        private System.Windows.Forms.TextBox bufferEntree;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;

    }
}