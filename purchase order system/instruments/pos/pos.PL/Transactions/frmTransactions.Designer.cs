namespace pos.PL.Transactions
{
    partial class frmTransactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransactions));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlView = new System.Windows.Forms.Panel();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvCartDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCustomerNameAndContactNumber = new System.Windows.Forms.Label();
            this.lblTransactionDate = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblAmountTendered = new System.Windows.Forms.Label();
            this.lblChangeAmount = new System.Windows.Forms.Label();
            this.pnlVoid = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlView.SuspendLayout();
            this.pnlSeparator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartDetails)).BeginInit();
            this.pnlVoid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.pbSearch);
            this.pnlMain.Controls.Add(this.dgv);
            this.pnlMain.Controls.Add(this.txtSearch);
            this.pnlMain.Location = new System.Drawing.Point(12, 12);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(984, 537);
            this.pnlMain.TabIndex = 2;
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(3, 69);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(978, 465);
            this.dgv.TabIndex = 3;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(50, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(314, 29);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // pnlView
            // 
            this.pnlView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlView.Controls.Add(this.pictureBox5);
            this.pnlView.Controls.Add(this.pictureBox4);
            this.pnlView.Controls.Add(this.pictureBox3);
            this.pnlView.Controls.Add(this.pictureBox2);
            this.pnlView.Controls.Add(this.pictureBox1);
            this.pnlView.Controls.Add(this.pnlVoid);
            this.pnlView.Controls.Add(this.lblChangeAmount);
            this.pnlView.Controls.Add(this.lblAmountTendered);
            this.pnlView.Controls.Add(this.lblTotalAmount);
            this.pnlView.Controls.Add(this.lblTransactionDate);
            this.pnlView.Controls.Add(this.lblCustomerNameAndContactNumber);
            this.pnlView.Controls.Add(this.label6);
            this.pnlView.Controls.Add(this.label5);
            this.pnlView.Controls.Add(this.label4);
            this.pnlView.Controls.Add(this.label3);
            this.pnlView.Controls.Add(this.label1);
            this.pnlView.Controls.Add(this.dgvCartDetails);
            this.pnlView.Controls.Add(this.pbBack);
            this.pnlView.Controls.Add(this.pnlSeparator);
            this.pnlView.Location = new System.Drawing.Point(12, 12);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(984, 537);
            this.pnlView.TabIndex = 3;
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(97)))), ((int)(((byte)(183)))));
            this.pnlSeparator.Controls.Add(this.lblTitle);
            this.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparator.Location = new System.Drawing.Point(0, 0);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(984, 53);
            this.pnlSeparator.TabIndex = 5;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(49, 30);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "< >";
            // 
            // dgvCartDetails
            // 
            this.dgvCartDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartDetails.Location = new System.Drawing.Point(504, 125);
            this.dgvCartDetails.Name = "dgvCartDetails";
            this.dgvCartDetails.Size = new System.Drawing.Size(480, 409);
            this.dgvCartDetails.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "CUSTOMER";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 21);
            this.label3.TabIndex = 23;
            this.label3.Text = "TRANSACTION DATE AND TIME";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 21);
            this.label4.TabIndex = 24;
            this.label4.Text = "TOTAL AMOUNT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(80, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 21);
            this.label5.TabIndex = 25;
            this.label5.Text = "AMOUNT TENDERED";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(80, 460);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 21);
            this.label6.TabIndex = 26;
            this.label6.Text = "CHANGE AMOUNT";
            // 
            // lblCustomerNameAndContactNumber
            // 
            this.lblCustomerNameAndContactNumber.AutoSize = true;
            this.lblCustomerNameAndContactNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNameAndContactNumber.Location = new System.Drawing.Point(121, 101);
            this.lblCustomerNameAndContactNumber.Name = "lblCustomerNameAndContactNumber";
            this.lblCustomerNameAndContactNumber.Size = new System.Drawing.Size(38, 25);
            this.lblCustomerNameAndContactNumber.TabIndex = 30;
            this.lblCustomerNameAndContactNumber.Text = "<>";
            // 
            // lblTransactionDate
            // 
            this.lblTransactionDate.AutoSize = true;
            this.lblTransactionDate.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionDate.Location = new System.Drawing.Point(121, 204);
            this.lblTransactionDate.Name = "lblTransactionDate";
            this.lblTransactionDate.Size = new System.Drawing.Size(38, 25);
            this.lblTransactionDate.TabIndex = 32;
            this.lblTransactionDate.Text = "<>";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(121, 292);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(38, 25);
            this.lblTotalAmount.TabIndex = 33;
            this.lblTotalAmount.Text = "<>";
            // 
            // lblAmountTendered
            // 
            this.lblAmountTendered.AutoSize = true;
            this.lblAmountTendered.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountTendered.Location = new System.Drawing.Point(121, 386);
            this.lblAmountTendered.Name = "lblAmountTendered";
            this.lblAmountTendered.Size = new System.Drawing.Size(38, 25);
            this.lblAmountTendered.TabIndex = 34;
            this.lblAmountTendered.Text = "<>";
            // 
            // lblChangeAmount
            // 
            this.lblChangeAmount.AutoSize = true;
            this.lblChangeAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeAmount.Location = new System.Drawing.Point(121, 491);
            this.lblChangeAmount.Name = "lblChangeAmount";
            this.lblChangeAmount.Size = new System.Drawing.Size(38, 25);
            this.lblChangeAmount.TabIndex = 35;
            this.lblChangeAmount.Text = "<>";
            // 
            // pnlVoid
            // 
            this.pnlVoid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(102)))), ((int)(((byte)(76)))));
            this.pnlVoid.Controls.Add(this.label7);
            this.pnlVoid.Location = new System.Drawing.Point(327, 462);
            this.pnlVoid.Name = "pnlVoid";
            this.pnlVoid.Size = new System.Drawing.Size(171, 72);
            this.pnlVoid.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(27, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 51);
            this.label7.TabIndex = 32;
            this.label7.Text = "VOID";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::pos.PL.Properties.Resources.euro;
            this.pictureBox5.Location = new System.Drawing.Point(13, 452);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(61, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 41;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::pos.PL.Properties.Resources.save_money;
            this.pictureBox4.Location = new System.Drawing.Point(13, 353);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(61, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 40;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::pos.PL.Properties.Resources.money_bag;
            this.pictureBox3.Location = new System.Drawing.Point(13, 252);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(61, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 39;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::pos.PL.Properties.Resources.calendar;
            this.pictureBox2.Location = new System.Drawing.Point(13, 158);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(61, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::pos.PL.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(13, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // pbBack
            // 
            this.pbBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBack.Image = global::pos.PL.Properties.Resources.left_arrow;
            this.pbBack.Location = new System.Drawing.Point(897, 59);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(84, 60);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBack.TabIndex = 19;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // pbSearch
            // 
            this.pbSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbSearch.Image = global::pos.PL.Properties.Resources.search;
            this.pbSearch.Location = new System.Drawing.Point(7, 14);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(37, 41);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSearch.TabIndex = 5;
            this.pbSearch.TabStop = false;
            // 
            // frmTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.pnlView);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "frmTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRANSACTIONS";
            this.Load += new System.EventHandler(this.frmTransactions_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlView.ResumeLayout(false);
            this.pnlView.PerformLayout();
            this.pnlSeparator.ResumeLayout(false);
            this.pnlSeparator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartDetails)).EndInit();
            this.pnlVoid.ResumeLayout(false);
            this.pnlVoid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlView;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvCartDetails;
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblChangeAmount;
        private System.Windows.Forms.Label lblAmountTendered;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTransactionDate;
        private System.Windows.Forms.Label lblCustomerNameAndContactNumber;
        private System.Windows.Forms.Panel pnlVoid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}