namespace WATER_REFILLING_STATION.PL.OTHERS
{
    partial class MENU_CASHIER
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
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.cUSTOMERSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mANAGECUSTOMERSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEPORTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nEWTRANSACTIONSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lISTOFORDERSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.AutoSize = false;
            this.msMenu.BackColor = System.Drawing.Color.Teal;
            this.msMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.msMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msMenu.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMenu.ImageScalingSize = new System.Drawing.Size(200, 200);
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nEWTRANSACTIONSToolStripMenuItem,
            this.cUSTOMERSToolStripMenuItem,
            this.rEPORTSToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.msMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.msMenu.Size = new System.Drawing.Size(1008, 87);
            this.msMenu.Stretch = false;
            this.msMenu.TabIndex = 1;
            // 
            // cUSTOMERSToolStripMenuItem
            // 
            this.cUSTOMERSToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cUSTOMERSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mANAGECUSTOMERSToolStripMenuItem});
            this.cUSTOMERSToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.cUSTOMERSToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cUSTOMERSToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cUSTOMERSToolStripMenuItem.Name = "cUSTOMERSToolStripMenuItem";
            this.cUSTOMERSToolStripMenuItem.Size = new System.Drawing.Size(189, 83);
            this.cUSTOMERSToolStripMenuItem.Text = "CUSTOMERS";
            // 
            // mANAGECUSTOMERSToolStripMenuItem
            // 
            this.mANAGECUSTOMERSToolStripMenuItem.Name = "mANAGECUSTOMERSToolStripMenuItem";
            this.mANAGECUSTOMERSToolStripMenuItem.Size = new System.Drawing.Size(379, 42);
            this.mANAGECUSTOMERSToolStripMenuItem.Text = "MANAGE CUSTOMERS";
            // 
            // rEPORTSToolStripMenuItem
            // 
            this.rEPORTSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lISTOFORDERSToolStripMenuItem});
            this.rEPORTSToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.rEPORTSToolStripMenuItem.Name = "rEPORTSToolStripMenuItem";
            this.rEPORTSToolStripMenuItem.Size = new System.Drawing.Size(134, 83);
            this.rEPORTSToolStripMenuItem.Text = "ORDERS";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(137, 83);
            this.logoutToolStripMenuItem.Text = "LOGOUT";
            // 
            // nEWTRANSACTIONSToolStripMenuItem
            // 
            this.nEWTRANSACTIONSToolStripMenuItem.Name = "nEWTRANSACTIONSToolStripMenuItem";
            this.nEWTRANSACTIONSToolStripMenuItem.Size = new System.Drawing.Size(189, 83);
            this.nEWTRANSACTIONSToolStripMenuItem.Text = "NEW ORDER";
            // 
            // lISTOFORDERSToolStripMenuItem
            // 
            this.lISTOFORDERSToolStripMenuItem.Name = "lISTOFORDERSToolStripMenuItem";
            this.lISTOFORDERSToolStripMenuItem.Size = new System.Drawing.Size(301, 42);
            this.lISTOFORDERSToolStripMenuItem.Text = "LIST OF ORDERS";
            // 
            // MENU_CASHIER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 87);
            this.Controls.Add(this.msMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MENU_CASHIER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU_CASHIER";
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem cUSTOMERSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mANAGECUSTOMERSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEPORTSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nEWTRANSACTIONSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lISTOFORDERSToolStripMenuItem;
    }
}