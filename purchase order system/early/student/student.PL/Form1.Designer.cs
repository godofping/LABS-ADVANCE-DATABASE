namespace student.PL
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
            this.rEGISTEREDSTUDENTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTRANDSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEPORTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lISTOFREGISTEREDSTUDENTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rEGISTEREDSTUDENTSToolStripMenuItem,
            this.sTRANDSToolStripMenuItem,
            this.rEPORTSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rEGISTEREDSTUDENTSToolStripMenuItem
            // 
            this.rEGISTEREDSTUDENTSToolStripMenuItem.Name = "rEGISTEREDSTUDENTSToolStripMenuItem";
            this.rEGISTEREDSTUDENTSToolStripMenuItem.Size = new System.Drawing.Size(140, 20);
            this.rEGISTEREDSTUDENTSToolStripMenuItem.Text = "REGISTERED STUDENTS";
            this.rEGISTEREDSTUDENTSToolStripMenuItem.Click += new System.EventHandler(this.rEGISTEREDSTUDENTSToolStripMenuItem_Click);
            // 
            // sTRANDSToolStripMenuItem
            // 
            this.sTRANDSToolStripMenuItem.Name = "sTRANDSToolStripMenuItem";
            this.sTRANDSToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.sTRANDSToolStripMenuItem.Text = "STRANDS";
            this.sTRANDSToolStripMenuItem.Click += new System.EventHandler(this.sTRANDSToolStripMenuItem_Click);
            // 
            // rEPORTSToolStripMenuItem
            // 
            this.rEPORTSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lISTOFREGISTEREDSTUDENTSToolStripMenuItem});
            this.rEPORTSToolStripMenuItem.Name = "rEPORTSToolStripMenuItem";
            this.rEPORTSToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.rEPORTSToolStripMenuItem.Text = "REPORTS";
            // 
            // lISTOFREGISTEREDSTUDENTSToolStripMenuItem
            // 
            this.lISTOFREGISTEREDSTUDENTSToolStripMenuItem.Name = "lISTOFREGISTEREDSTUDENTSToolStripMenuItem";
            this.lISTOFREGISTEREDSTUDENTSToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.lISTOFREGISTEREDSTUDENTSToolStripMenuItem.Text = "LIST OF REGISTERED STUDENTS";
            this.lISTOFREGISTEREDSTUDENTSToolStripMenuItem.Click += new System.EventHandler(this.lISTOFREGISTEREDSTUDENTSToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sTRANDSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEPORTSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEGISTEREDSTUDENTSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lISTOFREGISTEREDSTUDENTSToolStripMenuItem;
    }
}

