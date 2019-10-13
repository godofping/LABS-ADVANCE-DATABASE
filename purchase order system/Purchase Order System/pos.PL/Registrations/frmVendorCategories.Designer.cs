namespace pos.PL.Registrations
{
    partial class frmVendorCategories
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtVendorCategoryID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVendorCategory = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbCustomerInformation = new System.Windows.Forms.GroupBox();
            this.dgvManageVendorCategories = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbControls.SuspendLayout();
            this.gbCustomerInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageVendorCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            // gbControls
            // 
            this.gbControls.Controls.Add(this.btnAdd);
            this.gbControls.Controls.Add(this.btnEdit);
            this.gbControls.Controls.Add(this.btnDelete);
            this.gbControls.Location = new System.Drawing.Point(1051, 48);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(142, 201);
            this.gbControls.TabIndex = 66;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Controls";
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 13);
            this.label14.TabIndex = 50;
            this.label14.Text = "Vendor Category ID";
            // 
            // txtVendorCategoryID
            // 
            this.txtVendorCategoryID.Enabled = false;
            this.txtVendorCategoryID.Location = new System.Drawing.Point(9, 40);
            this.txtVendorCategoryID.Name = "txtVendorCategoryID";
            this.txtVendorCategoryID.Size = new System.Drawing.Size(172, 20);
            this.txtVendorCategoryID.TabIndex = 49;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(210, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Vendor Category";
            // 
            // txtVendorCategory
            // 
            this.txtVendorCategory.Location = new System.Drawing.Point(213, 40);
            this.txtVendorCategory.Name = "txtVendorCategory";
            this.txtVendorCategory.Size = new System.Drawing.Size(172, 20);
            this.txtVendorCategory.TabIndex = 25;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(920, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 48;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(823, 165);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(59, 265);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(272, 20);
            this.txtSearch.TabIndex = 62;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 25);
            this.label1.TabIndex = 61;
            this.label1.Text = "Manage Vendor Categories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Search";
            // 
            // gbCustomerInformation
            // 
            this.gbCustomerInformation.Controls.Add(this.label14);
            this.gbCustomerInformation.Controls.Add(this.txtVendorCategoryID);
            this.gbCustomerInformation.Controls.Add(this.label13);
            this.gbCustomerInformation.Controls.Add(this.txtVendorCategory);
            this.gbCustomerInformation.Controls.Add(this.btnCancel);
            this.gbCustomerInformation.Controls.Add(this.btnSave);
            this.gbCustomerInformation.Location = new System.Drawing.Point(14, 46);
            this.gbCustomerInformation.Name = "gbCustomerInformation";
            this.gbCustomerInformation.Size = new System.Drawing.Size(1031, 203);
            this.gbCustomerInformation.TabIndex = 65;
            this.gbCustomerInformation.TabStop = false;
            this.gbCustomerInformation.Text = "Vendor Category Information";
            // 
            // dgvManageVendorCategories
            // 
            this.dgvManageVendorCategories.AllowUserToAddRows = false;
            this.dgvManageVendorCategories.AllowUserToDeleteRows = false;
            this.dgvManageVendorCategories.AllowUserToResizeColumns = false;
            this.dgvManageVendorCategories.AllowUserToResizeRows = false;
            this.dgvManageVendorCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvManageVendorCategories.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvManageVendorCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManageVendorCategories.Location = new System.Drawing.Point(14, 291);
            this.dgvManageVendorCategories.Name = "dgvManageVendorCategories";
            this.dgvManageVendorCategories.ReadOnly = true;
            this.dgvManageVendorCategories.RowHeadersVisible = false;
            this.dgvManageVendorCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManageVendorCategories.Size = new System.Drawing.Size(1179, 240);
            this.dgvManageVendorCategories.TabIndex = 64;
            this.dgvManageVendorCategories.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManageVendorCategories_CellContentClick);
            this.dgvManageVendorCategories.SelectionChanged += new System.EventHandler(this.dgvManageVendorCategories_SelectionChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmVendorCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 544);
            this.Controls.Add(this.gbControls);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbCustomerInformation);
            this.Controls.Add(this.dgvManageVendorCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVendorCategories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVendorCategories";
            this.Load += new System.EventHandler(this.frmVendorCategories_Load);
            this.gbControls.ResumeLayout(false);
            this.gbCustomerInformation.ResumeLayout(false);
            this.gbCustomerInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageVendorCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtVendorCategoryID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtVendorCategory;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbCustomerInformation;
        private System.Windows.Forms.DataGridView dgvManageVendorCategories;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}