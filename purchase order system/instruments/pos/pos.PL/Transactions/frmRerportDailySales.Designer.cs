namespace pos.PL.Transactions
{
    partial class frmRerportDailySales
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
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.pbGenerateReport = new System.Windows.Forms.PictureBox();
            this.crvDailySales = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.pbGenerateReport)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "DATE ";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(12, 44);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(306, 29);
            this.dtpDate.TabIndex = 6;
            // 
            // pbGenerateReport
            // 
            this.pbGenerateReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbGenerateReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbGenerateReport.Image = global::pos.PL.Properties.Resources.report__1_;
            this.pbGenerateReport.Location = new System.Drawing.Point(912, 23);
            this.pbGenerateReport.Name = "pbGenerateReport";
            this.pbGenerateReport.Size = new System.Drawing.Size(84, 60);
            this.pbGenerateReport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGenerateReport.TabIndex = 20;
            this.pbGenerateReport.TabStop = false;
            this.pbGenerateReport.Click += new System.EventHandler(this.pbGenerateReport_Click);
            // 
            // crvDailySales
            // 
            this.crvDailySales.ActiveViewIndex = -1;
            this.crvDailySales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crvDailySales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDailySales.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvDailySales.Location = new System.Drawing.Point(12, 97);
            this.crvDailySales.Name = "crvDailySales";
            this.crvDailySales.Size = new System.Drawing.Size(984, 452);
            this.crvDailySales.TabIndex = 21;
            // 
            // frmRerportDailySales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.crvDailySales);
            this.Controls.Add(this.pbGenerateReport);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "frmRerportDailySales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DAILY REPORTS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRerportDailySales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbGenerateReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.PictureBox pbGenerateReport;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDailySales;
    }
}