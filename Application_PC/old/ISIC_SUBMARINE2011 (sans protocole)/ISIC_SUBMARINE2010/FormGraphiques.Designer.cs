namespace ISIC_SUBMARINE2010
{
    partial class FormGraphiques
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraphiques));
            this.zedGraphe1 = new ZedGraph.ZedGraphControl();
            this.zedGraphe2 = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zedGraphe1
            // 
            this.zedGraphe1.Location = new System.Drawing.Point(10, 10);
            this.zedGraphe1.Name = "zedGraphe1";
            this.zedGraphe1.ScrollGrace = 0D;
            this.zedGraphe1.ScrollMaxX = 0D;
            this.zedGraphe1.ScrollMaxY = 0D;
            this.zedGraphe1.ScrollMaxY2 = 0D;
            this.zedGraphe1.ScrollMinX = 0D;
            this.zedGraphe1.ScrollMinY = 0D;
            this.zedGraphe1.ScrollMinY2 = 0D;
            this.zedGraphe1.Size = new System.Drawing.Size(705, 174);
            this.zedGraphe1.TabIndex = 0;
            // 
            // zedGraphe2
            // 
            this.zedGraphe2.Location = new System.Drawing.Point(10, 194);
            this.zedGraphe2.Name = "zedGraphe2";
            this.zedGraphe2.ScrollGrace = 0D;
            this.zedGraphe2.ScrollMaxX = 0D;
            this.zedGraphe2.ScrollMaxY = 0D;
            this.zedGraphe2.ScrollMaxY2 = 0D;
            this.zedGraphe2.ScrollMinX = 0D;
            this.zedGraphe2.ScrollMinY = 0D;
            this.zedGraphe2.ScrollMinY2 = 0D;
            this.zedGraphe2.Size = new System.Drawing.Size(705, 174);
            this.zedGraphe2.TabIndex = 1;
            // 
            // FormGraphiques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 378);
            this.ControlBox = false;
            this.Controls.Add(this.zedGraphe2);
            this.Controls.Add(this.zedGraphe1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(700, 0);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "FormGraphiques";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Graphiques";
            this.SizeChanged += new System.EventHandler(this.FormGraphiques_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphe1;
        private ZedGraph.ZedGraphControl zedGraphe2;
    }
}