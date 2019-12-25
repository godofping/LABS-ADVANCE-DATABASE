namespace barangay.PL.Transactions
{
    partial class frmBarangayCertifications
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
            this.btnResidency = new System.Windows.Forms.Button();
            this.btnCedula = new System.Windows.Forms.Button();
            this.btnCloseView = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // btnResidency
            // 
            this.btnResidency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnResidency.FlatAppearance.BorderSize = 0;
            this.btnResidency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResidency.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResidency.ForeColor = System.Drawing.Color.White;
            this.btnResidency.Location = new System.Drawing.Point(12, 12);
            this.btnResidency.Name = "btnResidency";
            this.btnResidency.Size = new System.Drawing.Size(149, 73);
            this.btnResidency.TabIndex = 79;
            this.btnResidency.Text = "Residency";
            this.btnResidency.UseVisualStyleBackColor = false;
            this.btnResidency.Click += new System.EventHandler(this.btnResidency_Click);
            // 
            // btnCedula
            // 
            this.btnCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCedula.FlatAppearance.BorderSize = 0;
            this.btnCedula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCedula.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCedula.ForeColor = System.Drawing.Color.White;
            this.btnCedula.Location = new System.Drawing.Point(167, 12);
            this.btnCedula.Name = "btnCedula";
            this.btnCedula.Size = new System.Drawing.Size(149, 73);
            this.btnCedula.TabIndex = 80;
            this.btnCedula.Text = "Cedula";
            this.btnCedula.UseVisualStyleBackColor = false;
            this.btnCedula.Click += new System.EventHandler(this.btnCedula_Click);
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
            this.btnCloseView.Location = new System.Drawing.Point(899, 514);
            this.btnCloseView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCloseView.Name = "btnCloseView";
            this.btnCloseView.Size = new System.Drawing.Size(113, 73);
            this.btnCloseView.TabIndex = 84;
            this.btnCloseView.Text = "CLOSE";
            this.btnCloseView.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnCloseView.UseVisualStyleBackColor = false;
            this.btnCloseView.Click += new System.EventHandler(this.btnCloseView_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.lblTitle.Location = new System.Drawing.Point(340, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(672, 43);
            this.lblTitle.TabIndex = 85;
            this.lblTitle.Text = "Barangay Certification for IVY LAUREL MORALES";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // crv
            // 
            this.crv.ActiveViewIndex = -1;
            this.crv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv.Location = new System.Drawing.Point(12, 105);
            this.crv.Name = "crv";
            this.crv.Size = new System.Drawing.Size(1000, 402);
            this.crv.TabIndex = 86;
            // 
            // frmBarangayCertifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCloseView);
            this.Controls.Add(this.btnCedula);
            this.Controls.Add(this.btnResidency);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBarangayCertifications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barangay Certifications";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBarangayCertifications_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnResidency;
        private System.Windows.Forms.Button btnCedula;
        private System.Windows.Forms.Button btnCloseView;
        private System.Windows.Forms.Label lblTitle;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
    }
}