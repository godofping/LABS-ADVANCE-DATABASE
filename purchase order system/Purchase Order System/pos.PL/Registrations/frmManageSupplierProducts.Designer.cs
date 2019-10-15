namespace pos.PL.Registrations
{
    partial class frmManageSupplierProducts
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
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbInformations = new System.Windows.Forms.GroupBox();
            this.cbSupplierName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbProductName = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSupplierProductID = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbInformations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.gbControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(413, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Product Name";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gbInformations
            // 
            this.gbInformations.Controls.Add(this.cbSupplierName);
            this.gbInformations.Controls.Add(this.label3);
            this.gbInformations.Controls.Add(this.cbProductName);
            this.gbInformations.Controls.Add(this.label4);
            this.gbInformations.Controls.Add(this.label14);
            this.gbInformations.Controls.Add(this.txtSupplierProductID);
            this.gbInformations.Controls.Add(this.btnCancel);
            this.gbInformations.Controls.Add(this.btnSave);
            this.gbInformations.Location = new System.Drawing.Point(14, 43);
            this.gbInformations.Name = "gbInformations";
            this.gbInformations.Size = new System.Drawing.Size(1031, 203);
            this.gbInformations.TabIndex = 77;
            this.gbInformations.TabStop = false;
            // 
            // cbSupplierName
            // 
            this.cbSupplierName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupplierName.FormattingEnabled = true;
            this.cbSupplierName.ItemHeight = 13;
            this.cbSupplierName.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbSupplierName.Location = new System.Drawing.Point(213, 40);
            this.cbSupplierName.Name = "cbSupplierName";
            this.cbSupplierName.Size = new System.Drawing.Size(172, 21);
            this.cbSupplierName.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 76;
            this.label3.Text = "Supplier Name";
            // 
            // cbProductName
            // 
            this.cbProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductName.FormattingEnabled = true;
            this.cbProductName.ItemHeight = 13;
            this.cbProductName.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbProductName.Location = new System.Drawing.Point(416, 40);
            this.cbProductName.Name = "cbProductName";
            this.cbProductName.Size = new System.Drawing.Size(172, 21);
            this.cbProductName.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 13);
            this.label14.TabIndex = 50;
            this.label14.Text = "Supplier Product ID";
            // 
            // txtSupplierProductID
            // 
            this.txtSupplierProductID.Enabled = false;
            this.txtSupplierProductID.Location = new System.Drawing.Point(9, 40);
            this.txtSupplierProductID.Name = "txtSupplierProductID";
            this.txtSupplierProductID.Size = new System.Drawing.Size(172, 20);
            this.txtSupplierProductID.TabIndex = 49;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(920, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(823, 165);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.Silver;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(14, 294);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1179, 240);
            this.dgv.TabIndex = 76;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 25);
            this.label1.TabIndex = 73;
            this.label1.Text = "Manage Supplier Products";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Search";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(36, 92);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 49;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // gbControls
            // 
            this.gbControls.Controls.Add(this.btnAdd);
            this.gbControls.Controls.Add(this.btnEdit);
            this.gbControls.Controls.Add(this.btnDelete);
            this.gbControls.Location = new System.Drawing.Point(1051, 45);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(142, 201);
            this.gbControls.TabIndex = 78;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Controls";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(36, 38);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(36, 142);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 50;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(62, 269);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(272, 20);
            this.txtSearch.TabIndex = 74;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // frmManageSupplierProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 544);
            this.Controls.Add(this.gbInformations);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbControls);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageSupplierProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManageSupplierProducts";
            this.Load += new System.EventHandler(this.frmManageStaffs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbInformations.ResumeLayout(false);
            this.gbInformations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.gbControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox gbInformations;
        private System.Windows.Forms.ComboBox cbProductName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSupplierProductID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSupplierName;
        private System.Windows.Forms.Label label3;
    }
}