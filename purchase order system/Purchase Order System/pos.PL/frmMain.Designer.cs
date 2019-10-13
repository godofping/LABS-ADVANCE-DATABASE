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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.smiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPurchaseOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.smiProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.manageProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SuppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSuppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.smiManageCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.smiStaffs = new System.Windows.Forms.ToolStripMenuItem();
            this.smiManageStaffs = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.productsCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsSubcategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiFile,
            this.smiOrders,
            this.smiPurchaseOrders,
            this.smiProducts,
            this.SuppliersToolStripMenuItem,
            this.smiCustomers,
            this.smiStaffs});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1203, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // smiFile
            // 
            this.smiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.smiFile.Name = "smiFile";
            this.smiFile.Size = new System.Drawing.Size(37, 20);
            this.smiFile.Text = "File";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // smiOrders
            // 
            this.smiOrders.Name = "smiOrders";
            this.smiOrders.Size = new System.Drawing.Size(54, 20);
            this.smiOrders.Text = "Orders";
            // 
            // smiPurchaseOrders
            // 
            this.smiPurchaseOrders.Name = "smiPurchaseOrders";
            this.smiPurchaseOrders.Size = new System.Drawing.Size(105, 20);
            this.smiPurchaseOrders.Text = "Purchase Orders";
            // 
            // smiProducts
            // 
            this.smiProducts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageProductsToolStripMenuItem,
            this.productsCategoriesToolStripMenuItem,
            this.productsSubcategoriesToolStripMenuItem});
            this.smiProducts.Name = "smiProducts";
            this.smiProducts.Size = new System.Drawing.Size(66, 20);
            this.smiProducts.Text = "Products";
            // 
            // manageProductsToolStripMenuItem
            // 
            this.manageProductsToolStripMenuItem.Name = "manageProductsToolStripMenuItem";
            this.manageProductsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.manageProductsToolStripMenuItem.Text = "Manage Products";
            // 
            // SuppliersToolStripMenuItem
            // 
            this.SuppliersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageSuppliersToolStripMenuItem});
            this.SuppliersToolStripMenuItem.Name = "SuppliersToolStripMenuItem";
            this.SuppliersToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.SuppliersToolStripMenuItem.Text = "Suppliers";
            // 
            // manageSuppliersToolStripMenuItem
            // 
            this.manageSuppliersToolStripMenuItem.Name = "manageSuppliersToolStripMenuItem";
            this.manageSuppliersToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.manageSuppliersToolStripMenuItem.Text = "Manage Suppliers";
            this.manageSuppliersToolStripMenuItem.Click += new System.EventHandler(this.manageSuppliersToolStripMenuItem_Click);
            // 
            // smiCustomers
            // 
            this.smiCustomers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiManageCustomers});
            this.smiCustomers.Name = "smiCustomers";
            this.smiCustomers.Size = new System.Drawing.Size(76, 20);
            this.smiCustomers.Text = "Customers";
            // 
            // smiManageCustomers
            // 
            this.smiManageCustomers.Name = "smiManageCustomers";
            this.smiManageCustomers.Size = new System.Drawing.Size(177, 22);
            this.smiManageCustomers.Text = "Manage Customers";
            this.smiManageCustomers.Click += new System.EventHandler(this.smiManageCustomers_Click);
            // 
            // smiStaffs
            // 
            this.smiStaffs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiManageStaffs});
            this.smiStaffs.Name = "smiStaffs";
            this.smiStaffs.Size = new System.Drawing.Size(48, 20);
            this.smiStaffs.Text = "Staffs";
            // 
            // smiManageStaffs
            // 
            this.smiManageStaffs.Name = "smiManageStaffs";
            this.smiManageStaffs.Size = new System.Drawing.Size(149, 22);
            this.smiManageStaffs.Text = "Manage Staffs";
            this.smiManageStaffs.Click += new System.EventHandler(this.smiManageStaffs_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1203, 544);
            this.pnlMain.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblDateTime);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 566);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1203, 28);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(529, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rex Computer Store";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.Location = new System.Drawing.Point(865, 5);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(43, 18);
            this.lblDateTime.TabIndex = 1;
            this.lblDateTime.Text = "Date:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(304, 18);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Welcome, Rex Louis Paradero Roncesvalles";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // productsCategoriesToolStripMenuItem
            // 
            this.productsCategoriesToolStripMenuItem.Name = "productsCategoriesToolStripMenuItem";
            this.productsCategoriesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.productsCategoriesToolStripMenuItem.Text = "Products Categories";
            this.productsCategoriesToolStripMenuItem.Click += new System.EventHandler(this.productsCategoriesToolStripMenuItem_Click);
            // 
            // productsSubcategoriesToolStripMenuItem
            // 
            this.productsSubcategoriesToolStripMenuItem.Name = "productsSubcategoriesToolStripMenuItem";
            this.productsSubcategoriesToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.productsSubcategoriesToolStripMenuItem.Text = "Products Subcategories";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 594);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rex Computer Store";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem smiFile;
        private System.Windows.Forms.ToolStripMenuItem smiOrders;
        private System.Windows.Forms.ToolStripMenuItem smiPurchaseOrders;
        private System.Windows.Forms.ToolStripMenuItem smiProducts;
        private System.Windows.Forms.ToolStripMenuItem manageProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smiCustomers;
        private System.Windows.Forms.ToolStripMenuItem smiStaffs;
        private System.Windows.Forms.ToolStripMenuItem smiManageStaffs;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem smiManageCustomers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem SuppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageSuppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsCategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsSubcategoriesToolStripMenuItem;
    }
}