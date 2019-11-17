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
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.smiPurchaseOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.smiManagePurchaseOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.smiProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.smiManageProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.smiSuppliers = new System.Windows.Forms.ToolStripMenuItem();
            this.smiManageSuppliers = new System.Windows.Forms.ToolStripMenuItem();
            this.smiManageSupplierProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.smiCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.smiManageCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.smiStaffs = new System.Windows.Forms.ToolStripMenuItem();
            this.smiManageStaffs = new System.Windows.Forms.ToolStripMenuItem();
            this.smiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.smiStoreInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.smiMyProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.smiProductCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.smiProductSubCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.smiLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.smiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.msMenu.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.BackColor = System.Drawing.Color.Silver;
            this.msMenu.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiPurchaseOrders,
            this.smiProducts,
            this.smiSuppliers,
            this.smiCustomers,
            this.smiStaffs,
            this.smiSettings,
            this.smiLogout,
            this.smiExit});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(1203, 24);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "menuStrip1";
            // 
            // smiPurchaseOrders
            // 
            this.smiPurchaseOrders.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiManagePurchaseOrders});
            this.smiPurchaseOrders.Name = "smiPurchaseOrders";
            this.smiPurchaseOrders.Size = new System.Drawing.Size(124, 20);
            this.smiPurchaseOrders.Text = "Purchase Orders";
            // 
            // smiManagePurchaseOrders
            // 
            this.smiManagePurchaseOrders.Name = "smiManagePurchaseOrders";
            this.smiManagePurchaseOrders.Size = new System.Drawing.Size(228, 22);
            this.smiManagePurchaseOrders.Text = "Manage Purchase Orders";
            this.smiManagePurchaseOrders.Click += new System.EventHandler(this.smiManagePurchaseOrders_Click);
            // 
            // smiProducts
            // 
            this.smiProducts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiManageProducts});
            this.smiProducts.Name = "smiProducts";
            this.smiProducts.Size = new System.Drawing.Size(75, 20);
            this.smiProducts.Text = "Products";
            // 
            // smiManageProducts
            // 
            this.smiManageProducts.Name = "smiManageProducts";
            this.smiManageProducts.Size = new System.Drawing.Size(179, 22);
            this.smiManageProducts.Text = "Manage Products";
            this.smiManageProducts.Click += new System.EventHandler(this.smiManageProducts_Click);
            // 
            // smiSuppliers
            // 
            this.smiSuppliers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiManageSuppliers,
            this.smiManageSupplierProducts});
            this.smiSuppliers.Name = "smiSuppliers";
            this.smiSuppliers.Size = new System.Drawing.Size(82, 20);
            this.smiSuppliers.Text = "Suppliers";
            // 
            // smiManageSuppliers
            // 
            this.smiManageSuppliers.Name = "smiManageSuppliers";
            this.smiManageSuppliers.Size = new System.Drawing.Size(242, 22);
            this.smiManageSuppliers.Text = "Manage Suppliers";
            this.smiManageSuppliers.Click += new System.EventHandler(this.smiManageSuppliers_Click);
            // 
            // smiManageSupplierProducts
            // 
            this.smiManageSupplierProducts.Name = "smiManageSupplierProducts";
            this.smiManageSupplierProducts.Size = new System.Drawing.Size(242, 22);
            this.smiManageSupplierProducts.Text = "Manage Supplier Products";
            this.smiManageSupplierProducts.Click += new System.EventHandler(this.smiManageSupplierProducts_Click);
            // 
            // smiCustomers
            // 
            this.smiCustomers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiManageCustomers});
            this.smiCustomers.Name = "smiCustomers";
            this.smiCustomers.Size = new System.Drawing.Size(82, 20);
            this.smiCustomers.Text = "Customers";
            // 
            // smiManageCustomers
            // 
            this.smiManageCustomers.Name = "smiManageCustomers";
            this.smiManageCustomers.Size = new System.Drawing.Size(186, 22);
            this.smiManageCustomers.Text = "Manage Customers";
            this.smiManageCustomers.Click += new System.EventHandler(this.smiManageCustomers_Click);
            // 
            // smiStaffs
            // 
            this.smiStaffs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiManageStaffs});
            this.smiStaffs.Name = "smiStaffs";
            this.smiStaffs.Size = new System.Drawing.Size(61, 20);
            this.smiStaffs.Text = "Staffs";
            // 
            // smiManageStaffs
            // 
            this.smiManageStaffs.Name = "smiManageStaffs";
            this.smiManageStaffs.Size = new System.Drawing.Size(180, 22);
            this.smiManageStaffs.Text = "Manage Staffs";
            this.smiManageStaffs.Click += new System.EventHandler(this.smiManageStaffs_Click);
            // 
            // smiSettings
            // 
            this.smiSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiStoreInformation,
            this.smiMyProfile,
            this.smiProductCategories,
            this.smiProductSubCategories});
            this.smiSettings.Name = "smiSettings";
            this.smiSettings.Size = new System.Drawing.Size(75, 20);
            this.smiSettings.Text = "Settings";
     
            // 
            // smiStoreInformation
            // 
            this.smiStoreInformation.Name = "smiStoreInformation";
            this.smiStoreInformation.Size = new System.Drawing.Size(228, 22);
            this.smiStoreInformation.Text = "Store Information";
            this.smiStoreInformation.Click += new System.EventHandler(this.storeInformationToolStripMenuItem_Click);
            // 
            // smiMyProfile
            // 
            this.smiMyProfile.Name = "smiMyProfile";
            this.smiMyProfile.Size = new System.Drawing.Size(228, 22);
            this.smiMyProfile.Text = "My Profile";
            this.smiMyProfile.Click += new System.EventHandler(this.smiMyProfile_Click);
            // 
            // smiProductCategories
            // 
            this.smiProductCategories.Name = "smiProductCategories";
            this.smiProductCategories.Size = new System.Drawing.Size(228, 22);
            this.smiProductCategories.Text = "Product Categories";
            this.smiProductCategories.Click += new System.EventHandler(this.smiProductCategories_Click);
            // 
            // smiProductSubCategories
            // 
            this.smiProductSubCategories.Name = "smiProductSubCategories";
            this.smiProductSubCategories.Size = new System.Drawing.Size(228, 22);
            this.smiProductSubCategories.Text = "Product Sub Categories";
            this.smiProductSubCategories.Click += new System.EventHandler(this.smiProductSubCategories_Click);
            // 
            // smiLogout
            // 
            this.smiLogout.Name = "smiLogout";
            this.smiLogout.Size = new System.Drawing.Size(61, 20);
            this.smiLogout.Text = "Logout";
            this.smiLogout.Click += new System.EventHandler(this.smiLogout_Click);
            // 
            // smiExit
            // 
            this.smiExit.Name = "smiExit";
            this.smiExit.Size = new System.Drawing.Size(47, 20);
            this.smiExit.Text = "Exit";
            this.smiExit.Click += new System.EventHandler(this.smiExit_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1203, 544);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.Silver;
            this.pnlBottom.Controls.Add(this.lblStoreName);
            this.pnlBottom.Controls.Add(this.lblDateTime);
            this.pnlBottom.Controls.Add(this.lblName);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 566);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1203, 28);
            this.pnlBottom.TabIndex = 2;
            // 
            // lblStoreName
            // 
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreName.Location = new System.Drawing.Point(529, 6);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(133, 14);
            this.lblStoreName.TabIndex = 2;
            this.lblStoreName.Text = "Rex Computer Store";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.Location = new System.Drawing.Point(865, 5);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(48, 18);
            this.lblDateTime.TabIndex = 1;
            this.lblDateTime.Text = "Date:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(328, 18);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Welcome, Rex Louis Paradero Roncesvalles";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 594);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.msMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.msMenu;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rex Computer Store";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem smiPurchaseOrders;
        private System.Windows.Forms.ToolStripMenuItem smiProducts;
        private System.Windows.Forms.ToolStripMenuItem smiManageProducts;
        private System.Windows.Forms.ToolStripMenuItem smiCustomers;
        private System.Windows.Forms.ToolStripMenuItem smiStaffs;
        private System.Windows.Forms.ToolStripMenuItem smiManageStaffs;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem smiManageCustomers;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.ToolStripMenuItem smiSuppliers;
        private System.Windows.Forms.ToolStripMenuItem smiManageSuppliers;
        private System.Windows.Forms.ToolStripMenuItem smiManageSupplierProducts;
        private System.Windows.Forms.ToolStripMenuItem smiSettings;
        private System.Windows.Forms.ToolStripMenuItem smiStoreInformation;
        private System.Windows.Forms.ToolStripMenuItem smiMyProfile;
        private System.Windows.Forms.ToolStripMenuItem smiManagePurchaseOrders;
        private System.Windows.Forms.ToolStripMenuItem smiProductCategories;
        private System.Windows.Forms.ToolStripMenuItem smiProductSubCategories;
        private System.Windows.Forms.ToolStripMenuItem smiLogout;
        private System.Windows.Forms.ToolStripMenuItem smiExit;
    }
}