namespace ISIC_SUBMARINE
{
    partial class UI_Remote
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
            this.tBarPosBallast = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnExePosBallast = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnImpulsPosBallast = new System.Windows.Forms.Button();
            this.numUpDwnImpulsPosBallast = new System.Windows.Forms.NumericUpDown();
            this.numUpDwnPosBallast = new System.Windows.Forms.NumericUpDown();
            this.rbtnArriere = new System.Windows.Forms.RadioButton();
            this.rbtnAvant = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtnVider = new System.Windows.Forms.RadioButton();
            this.rbtnRemplir = new System.Windows.Forms.RadioButton();
            this.btnExeBallast = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numUpDwnBallast = new System.Windows.Forms.NumericUpDown();
            this.tBarBallast = new System.Windows.Forms.TrackBar();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImpulsBallast = new System.Windows.Forms.Button();
            this.numUpDwnImpulsBallast = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.tBarPosBallast)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnImpulsPosBallast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnPosBallast)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnBallast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarBallast)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnImpulsBallast)).BeginInit();
            this.SuspendLayout();
            // 
            // tBarPosBallast
            // 
            this.tBarPosBallast.Location = new System.Drawing.Point(72, 13);
            this.tBarPosBallast.Maximum = 255;
            this.tBarPosBallast.Name = "tBarPosBallast";
            this.tBarPosBallast.Size = new System.Drawing.Size(280, 42);
            this.tBarPosBallast.TabIndex = 3;
            this.tBarPosBallast.TickFrequency = 4;
            this.tBarPosBallast.ValueChanged += new System.EventHandler(this.tBarPosBallast_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 334);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Commande moteurs";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnExePosBallast);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.numUpDwnPosBallast);
            this.groupBox4.Controls.Add(this.rbtnArriere);
            this.groupBox4.Controls.Add(this.rbtnAvant);
            this.groupBox4.Controls.Add(this.tBarPosBallast);
            this.groupBox4.Location = new System.Drawing.Point(11, 177);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(452, 147);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Déplacement du ballast";
            // 
            // btnExePosBallast
            // 
            this.btnExePosBallast.Location = new System.Drawing.Point(351, 49);
            this.btnExePosBallast.Name = "btnExePosBallast";
            this.btnExePosBallast.Size = new System.Drawing.Size(70, 21);
            this.btnExePosBallast.TabIndex = 34;
            this.btnExePosBallast.Text = "Executer";
            this.btnExePosBallast.UseVisualStyleBackColor = true;
            this.btnExePosBallast.Click += new System.EventHandler(this.btnExePosBallast_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Sens :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Vitesse :";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.btnImpulsPosBallast);
            this.groupBox6.Controls.Add(this.numUpDwnImpulsPosBallast);
            this.groupBox6.Location = new System.Drawing.Point(13, 72);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(424, 57);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Impulsion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Durée (ms) :";
            // 
            // btnImpulsPosBallast
            // 
            this.btnImpulsPosBallast.Location = new System.Drawing.Point(164, 21);
            this.btnImpulsPosBallast.Name = "btnImpulsPosBallast";
            this.btnImpulsPosBallast.Size = new System.Drawing.Size(100, 22);
            this.btnImpulsPosBallast.TabIndex = 12;
            this.btnImpulsPosBallast.Text = "Envoyer impulsion";
            this.btnImpulsPosBallast.UseVisualStyleBackColor = true;
            this.btnImpulsPosBallast.Click += new System.EventHandler(this.btnImpulsPosBallast_Click);
            // 
            // numUpDwnImpulsPosBallast
            // 
            this.numUpDwnImpulsPosBallast.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUpDwnImpulsPosBallast.Location = new System.Drawing.Point(88, 24);
            this.numUpDwnImpulsPosBallast.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numUpDwnImpulsPosBallast.Name = "numUpDwnImpulsPosBallast";
            this.numUpDwnImpulsPosBallast.Size = new System.Drawing.Size(56, 20);
            this.numUpDwnImpulsPosBallast.TabIndex = 0;
            // 
            // numUpDwnPosBallast
            // 
            this.numUpDwnPosBallast.Location = new System.Drawing.Point(351, 19);
            this.numUpDwnPosBallast.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numUpDwnPosBallast.Name = "numUpDwnPosBallast";
            this.numUpDwnPosBallast.Size = new System.Drawing.Size(57, 20);
            this.numUpDwnPosBallast.TabIndex = 4;
            this.numUpDwnPosBallast.ValueChanged += new System.EventHandler(this.numUpDwnPosBallast_ValueChanged);
            // 
            // rbtnArriere
            // 
            this.rbtnArriere.AutoSize = true;
            this.rbtnArriere.Location = new System.Drawing.Point(171, 49);
            this.rbtnArriere.Name = "rbtnArriere";
            this.rbtnArriere.Size = new System.Drawing.Size(55, 17);
            this.rbtnArriere.TabIndex = 1;
            this.rbtnArriere.TabStop = true;
            this.rbtnArriere.Text = "Arrière";
            this.rbtnArriere.UseVisualStyleBackColor = true;
            // 
            // rbtnAvant
            // 
            this.rbtnAvant.AutoSize = true;
            this.rbtnAvant.Location = new System.Drawing.Point(95, 49);
            this.rbtnAvant.Name = "rbtnAvant";
            this.rbtnAvant.Size = new System.Drawing.Size(53, 17);
            this.rbtnAvant.TabIndex = 0;
            this.rbtnAvant.TabStop = true;
            this.rbtnAvant.Text = "Avant";
            this.rbtnAvant.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.rbtnVider);
            this.groupBox3.Controls.Add(this.rbtnRemplir);
            this.groupBox3.Controls.Add(this.btnExeBallast);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.numUpDwnBallast);
            this.groupBox3.Controls.Add(this.tBarBallast);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Location = new System.Drawing.Point(11, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(452, 152);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ballast";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Sens :";
            // 
            // rbtnVider
            // 
            this.rbtnVider.AutoSize = true;
            this.rbtnVider.Location = new System.Drawing.Point(78, 56);
            this.rbtnVider.Name = "rbtnVider";
            this.rbtnVider.Size = new System.Drawing.Size(49, 17);
            this.rbtnVider.TabIndex = 29;
            this.rbtnVider.TabStop = true;
            this.rbtnVider.Text = "Vider";
            this.rbtnVider.UseVisualStyleBackColor = true;
            // 
            // rbtnRemplir
            // 
            this.rbtnRemplir.AutoSize = true;
            this.rbtnRemplir.Location = new System.Drawing.Point(133, 56);
            this.rbtnRemplir.Name = "rbtnRemplir";
            this.rbtnRemplir.Size = new System.Drawing.Size(60, 17);
            this.rbtnRemplir.TabIndex = 30;
            this.rbtnRemplir.TabStop = true;
            this.rbtnRemplir.Text = "Remplir";
            this.rbtnRemplir.UseVisualStyleBackColor = true;
            // 
            // btnExeBallast
            // 
            this.btnExeBallast.Location = new System.Drawing.Point(351, 50);
            this.btnExeBallast.Name = "btnExeBallast";
            this.btnExeBallast.Size = new System.Drawing.Size(70, 21);
            this.btnExeBallast.TabIndex = 28;
            this.btnExeBallast.Text = "Executer";
            this.btnExeBallast.UseVisualStyleBackColor = true;
            this.btnExeBallast.Click += new System.EventHandler(this.btnExeBallast_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Vitesse :";
            // 
            // numUpDwnBallast
            // 
            this.numUpDwnBallast.Location = new System.Drawing.Point(351, 19);
            this.numUpDwnBallast.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numUpDwnBallast.Name = "numUpDwnBallast";
            this.numUpDwnBallast.Size = new System.Drawing.Size(55, 20);
            this.numUpDwnBallast.TabIndex = 26;
            this.numUpDwnBallast.ValueChanged += new System.EventHandler(this.numUpDwnBallast_ValueChanged);
            // 
            // tBarBallast
            // 
            this.tBarBallast.Location = new System.Drawing.Point(65, 14);
            this.tBarBallast.Maximum = 255;
            this.tBarBallast.Name = "tBarBallast";
            this.tBarBallast.Size = new System.Drawing.Size(280, 42);
            this.tBarBallast.TabIndex = 25;
            this.tBarBallast.TickFrequency = 4;
            this.tBarBallast.ValueChanged += new System.EventHandler(this.tBarBallast_ValueChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.btnImpulsBallast);
            this.groupBox7.Controls.Add(this.numUpDwnImpulsBallast);
            this.groupBox7.Location = new System.Drawing.Point(6, 79);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(424, 57);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Impulsion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Durée (ms) :";
            // 
            // btnImpulsBallast
            // 
            this.btnImpulsBallast.Location = new System.Drawing.Point(171, 22);
            this.btnImpulsBallast.Name = "btnImpulsBallast";
            this.btnImpulsBallast.Size = new System.Drawing.Size(100, 24);
            this.btnImpulsBallast.TabIndex = 12;
            this.btnImpulsBallast.Text = "Envoyer impulsion";
            this.btnImpulsBallast.UseVisualStyleBackColor = true;
            this.btnImpulsBallast.Click += new System.EventHandler(this.btnImpulsBallast_Click);
            // 
            // numUpDwnImpulsBallast
            // 
            this.numUpDwnImpulsBallast.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUpDwnImpulsBallast.Location = new System.Drawing.Point(95, 22);
            this.numUpDwnImpulsBallast.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numUpDwnImpulsBallast.Name = "numUpDwnImpulsBallast";
            this.numUpDwnImpulsBallast.Size = new System.Drawing.Size(56, 20);
            this.numUpDwnImpulsBallast.TabIndex = 0;
            // 
            // UI_Remote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 344);
            this.Controls.Add(this.groupBox1);
            this.Name = "UI_Remote";
            this.Text = "Télécommande";
            ((System.ComponentModel.ISupportInitialize)(this.tBarPosBallast)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnImpulsPosBallast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnPosBallast)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnBallast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBarBallast)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDwnImpulsBallast)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar tBarPosBallast;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbtnArriere;
        private System.Windows.Forms.RadioButton rbtnAvant;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numUpDwnPosBallast;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImpulsBallast;
        private System.Windows.Forms.NumericUpDown numUpDwnImpulsBallast;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtnVider;
        private System.Windows.Forms.RadioButton rbtnRemplir;
        private System.Windows.Forms.Button btnExeBallast;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numUpDwnBallast;
        private System.Windows.Forms.TrackBar tBarBallast;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnImpulsPosBallast;
        private System.Windows.Forms.NumericUpDown numUpDwnImpulsPosBallast;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExePosBallast;
    }
}