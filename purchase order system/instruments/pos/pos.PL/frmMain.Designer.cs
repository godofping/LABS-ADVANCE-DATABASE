namespace pos.PL
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tRANSACTIONSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cUSTOMERSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pRODUCTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cATEGORIESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEPORTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tRANSACTIONSToolStripMenuItem,
            this.cUSTOMERSToolStripMenuItem,
            this.pRODUCTSToolStripMenuItem,
            this.cATEGORIESToolStripMenuItem,
            this.rEPORTSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tRANSACTIONSToolStripMenuItem
            // 
            this.tRANSACTIONSToolStripMenuItem.Name = "tRANSACTIONSToolStripMenuItem";
            this.tRANSACTIONSToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.tRANSACTIONSToolStripMenuItem.Text = "TRANSACTIONS";
            this.tRANSACTIONSToolStripMenuItem.Click += new System.EventHandler(this.tRANSACTIONSToolStripMenuItem_Click);
            // 
            // cUSTOMERSToolStripMenuItem
            // 
            this.cUSTOMERSToolStripMenuItem.Name = "cUSTOMERSToolStripMenuItem";
            this.cUSTOMERSToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.cUSTOMERSToolStripMenuItem.Text = "CUSTOMERS";
            this.cUSTOMERSToolStripMenuItem.Click += new System.EventHandler(this.cUSTOMERSToolStripMenuItem_Click);
            // 
            // pRODUCTSToolStripMenuItem
            // 
            this.pRODUCTSToolStripMenuItem.Name = "pRODUCTSToolStripMenuItem";
            this.pRODUCTSToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.pRODUCTSToolStripMenuItem.Text = "PRODUCTS";
            this.pRODUCTSToolStripMenuItem.Click += new System.EventHandler(this.pRODUCTSToolStripMenuItem_Click);
            // 
            // cATEGORIESToolStripMenuItem
            // 
            this.cATEGORIESToolStripMenuItem.Name = "cATEGORIESToolStripMenuItem";
            this.cATEGORIESToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.cATEGORIESToolStripMenuItem.Text = "CATEGORIES";
            this.cATEGORIESToolStripMenuItem.Click += new System.EventHandler(this.cATEGORIESToolStripMenuItem_Click);
            // 
            // rEPORTSToolStripMenuItem
            // 
            this.rEPORTSToolStripMenuItem.Name = "rEPORTSToolStripMenuItem";
            this.rEPORTSToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.rEPORTSToolStripMenuItem.Text = "REPORTS";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAIN";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tRANSACTIONSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cUSTOMERSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pRODUCTSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cATEGORIESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEPORTSToolStripMenuItem;
    }
}

