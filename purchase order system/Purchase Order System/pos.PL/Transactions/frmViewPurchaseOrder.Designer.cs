namespace pos.PL.Transactions
{
    partial class frmViewPurchaseOrder
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRecieve = new System.Windows.Forms.Button();
            this.printCancel = new System.Windows.Forms.Button();
            this.txtPurchaseOrderID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtPurchaseOrderName = new System.Windows.Forms.TextBox();
            this.txtPaymentMethod = new System.Windows.Forms.TextBox();
            this.txtShippingMethod = new System.Windows.Forms.TextBox();
            this.txtRequestDate = new System.Windows.Forms.TextBox();
            this.txtDeliveryDate = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPurchaseOrderBy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Purchase Order ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Supplier Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Purchase Order Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Payment Method";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(847, 507);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(218, 507);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 49;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnRecieve
            // 
            this.btnRecieve.Location = new System.Drawing.Point(27, 507);
            this.btnRecieve.Name = "btnRecieve";
            this.btnRecieve.Size = new System.Drawing.Size(75, 23);
            this.btnRecieve.TabIndex = 51;
            this.btnRecieve.Text = "Recieve";
            this.btnRecieve.UseVisualStyleBackColor = true;
            // 
            // printCancel
            // 
            this.printCancel.Location = new System.Drawing.Point(122, 507);
            this.printCancel.Name = "printCancel";
            this.printCancel.Size = new System.Drawing.Size(75, 23);
            this.printCancel.TabIndex = 52;
            this.printCancel.Text = "Cancel";
            this.printCancel.UseVisualStyleBackColor = true;
            // 
            // txtPurchaseOrderID
            // 
            this.txtPurchaseOrderID.Location = new System.Drawing.Point(123, 22);
            this.txtPurchaseOrderID.Name = "txtPurchaseOrderID";
            this.txtPurchaseOrderID.Size = new System.Drawing.Size(74, 20);
            this.txtPurchaseOrderID.TabIndex = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(475, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 101;
            this.label5.Text = "Shipping Method";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(491, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 102;
            this.label6.Text = "Delivery Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 103;
            this.label7.Text = "Request Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(69, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 104;
            this.label8.Text = "Comment";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(123, 62);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(300, 20);
            this.txtSupplierName.TabIndex = 105;
            // 
            // txtPurchaseOrderName
            // 
            this.txtPurchaseOrderName.Location = new System.Drawing.Point(568, 62);
            this.txtPurchaseOrderName.Name = "txtPurchaseOrderName";
            this.txtPurchaseOrderName.Size = new System.Drawing.Size(354, 20);
            this.txtPurchaseOrderName.TabIndex = 106;
            // 
            // txtPaymentMethod
            // 
            this.txtPaymentMethod.Location = new System.Drawing.Point(123, 102);
            this.txtPaymentMethod.Name = "txtPaymentMethod";
            this.txtPaymentMethod.Size = new System.Drawing.Size(300, 20);
            this.txtPaymentMethod.TabIndex = 107;
            // 
            // txtShippingMethod
            // 
            this.txtShippingMethod.Location = new System.Drawing.Point(568, 102);
            this.txtShippingMethod.Name = "txtShippingMethod";
            this.txtShippingMethod.Size = new System.Drawing.Size(354, 20);
            this.txtShippingMethod.TabIndex = 108;
            // 
            // txtRequestDate
            // 
            this.txtRequestDate.Location = new System.Drawing.Point(123, 147);
            this.txtRequestDate.Name = "txtRequestDate";
            this.txtRequestDate.Size = new System.Drawing.Size(300, 20);
            this.txtRequestDate.TabIndex = 109;
            // 
            // txtDeliveryDate
            // 
            this.txtDeliveryDate.Location = new System.Drawing.Point(568, 143);
            this.txtDeliveryDate.Name = "txtDeliveryDate";
            this.txtDeliveryDate.Size = new System.Drawing.Size(354, 20);
            this.txtDeliveryDate.TabIndex = 110;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(123, 189);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(799, 73);
            this.txtComment.TabIndex = 111;
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
            this.dgv.Location = new System.Drawing.Point(28, 281);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(894, 209);
            this.dgv.TabIndex = 112;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(322, 22);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(101, 20);
            this.txtTotalAmount.TabIndex = 114;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(246, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 113;
            this.label9.Text = "Total Amount";
            // 
            // txtPurchaseOrderBy
            // 
            this.txtPurchaseOrderBy.Location = new System.Drawing.Point(568, 22);
            this.txtPurchaseOrderBy.Name = "txtPurchaseOrderBy";
            this.txtPurchaseOrderBy.Size = new System.Drawing.Size(354, 20);
            this.txtPurchaseOrderBy.TabIndex = 116;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(466, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 115;
            this.label10.Text = "Purchase Order By";
            // 
            // frmViewPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 544);
            this.Controls.Add(this.txtPurchaseOrderBy);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtDeliveryDate);
            this.Controls.Add(this.txtRequestDate);
            this.Controls.Add(this.txtShippingMethod);
            this.Controls.Add(this.txtPaymentMethod);
            this.Controls.Add(this.txtPurchaseOrderName);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPurchaseOrderID);
            this.Controls.Add(this.printCancel);
            this.Controls.Add(this.btnRecieve);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmViewPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "v";
            this.Load += new System.EventHandler(this.frmViewPurchaseOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnRecieve;
        private System.Windows.Forms.Button printCancel;
        private System.Windows.Forms.TextBox txtPurchaseOrderID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtPurchaseOrderName;
        private System.Windows.Forms.TextBox txtPaymentMethod;
        private System.Windows.Forms.TextBox txtShippingMethod;
        private System.Windows.Forms.TextBox txtRequestDate;
        private System.Windows.Forms.TextBox txtDeliveryDate;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPurchaseOrderBy;
        private System.Windows.Forms.Label label10;
    }
}