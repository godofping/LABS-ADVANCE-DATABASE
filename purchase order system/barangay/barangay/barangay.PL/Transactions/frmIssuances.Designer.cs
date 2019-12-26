namespace barangay.PL.Transactions
{
    partial class frmIssuances
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpYearAndMonth = new System.Windows.Forms.DateTimePicker();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCloseView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(233)))), ((int)(((byte)(149)))));
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Century Gothic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.SystemColors.Window;
            this.btnGenerate.Image = global::barangay.PL.Properties.Resources.printer;
            this.btnGenerate.Location = new System.Drawing.Point(426, 13);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(163, 73);
            this.btnGenerate.TabIndex = 100;
            this.btnGenerate.Text = "GENERATE";
            this.btnGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(10, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(174, 22);
            this.label20.TabIndex = 99;
            this.label20.Text = "Year and Month *";
            // 
            // dtpYearAndMonth
            // 
            this.dtpYearAndMonth.CustomFormat = "yyyy-MM";
            this.dtpYearAndMonth.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.dtpYearAndMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYearAndMonth.Location = new System.Drawing.Point(14, 52);
            this.dtpYearAndMonth.Name = "dtpYearAndMonth";
            this.dtpYearAndMonth.Size = new System.Drawing.Size(406, 27);
            this.dtpYearAndMonth.TabIndex = 98;
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv.Location = new System.Drawing.Point(14, 106);
            this.crv.Name = "crv";
            this.crv.Size = new System.Drawing.Size(1000, 402);
            this.crv.TabIndex = 97;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.lblTitle.Location = new System.Drawing.Point(670, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(344, 61);
            this.lblTitle.TabIndex = 96;
            this.lblTitle.Text = "Report for Issuance of Barangay Certifications";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCloseView
            // 
            this.btnCloseView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnCloseView.FlatAppearance.BorderSize = 0;
            this.btnCloseView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseView.Font = new System.Drawing.Font("Century Gothic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseView.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCloseView.Image = global::barangay.PL.Properties.Resources.delete_button;
            this.btnCloseView.Location = new System.Drawing.Point(901, 515);
            this.btnCloseView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCloseView.Name = "btnCloseView";
            this.btnCloseView.Size = new System.Drawing.Size(113, 73);
            this.btnCloseView.TabIndex = 95;
            this.btnCloseView.Text = "CLOSE";
            this.btnCloseView.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnCloseView.UseVisualStyleBackColor = false;
            this.btnCloseView.Click += new System.EventHandler(this.btnCloseView_Click);
            // 
            // frmIssuances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.dtpYearAndMonth);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCloseView);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmIssuances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIssuances";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpYearAndMonth;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCloseView;
    }
}