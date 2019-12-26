namespace barangay.PL.Registrations
{
    partial class frmSettings
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
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.pnlChangePassword = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlChangePassword.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(102)))), ((int)(((byte)(166)))));
            this.pnlTitle.Controls.Add(this.pictureBox1);
            this.pnlTitle.Controls.Add(this.label2);
            this.pnlTitle.Location = new System.Drawing.Point(74, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(340, 74);
            this.pnlTitle.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::barangay.PL.Properties.Resources.settings;
            this.pictureBox1.Image = global::barangay.PL.Properties.Resources.settings;
            this.pictureBox1.Location = new System.Drawing.Point(13, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(84, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Settings";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.btnChangePassword);
            this.pnlMain.Location = new System.Drawing.Point(13, 85);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1082, 650);
            this.pnlMain.TabIndex = 18;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(19, 20);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(296, 73);
            this.btnChangePassword.TabIndex = 81;
            this.btnChangePassword.Text = "Chang Password";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // pnlChangePassword
            // 
            this.pnlChangePassword.BackColor = System.Drawing.Color.White;
            this.pnlChangePassword.Controls.Add(this.btnSave);
            this.pnlChangePassword.Controls.Add(this.btnClose);
            this.pnlChangePassword.Controls.Add(this.groupBox9);
            this.pnlChangePassword.Location = new System.Drawing.Point(13, 85);
            this.pnlChangePassword.Name = "pnlChangePassword";
            this.pnlChangePassword.Size = new System.Drawing.Size(1082, 650);
            this.pnlChangePassword.TabIndex = 82;
            this.pnlChangePassword.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(236)))), ((int)(((byte)(121)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSave.Image = global::barangay.PL.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(843, 570);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 73);
            this.btnSave.TabIndex = 69;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClose.Image = global::barangay.PL.Properties.Resources.delete_button;
            this.btnClose.Location = new System.Drawing.Point(962, 569);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 73);
            this.btnClose.TabIndex = 68;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label1);
            this.groupBox9.Controls.Add(this.txtConfirmNewPassword);
            this.groupBox9.Controls.Add(this.label3);
            this.groupBox9.Controls.Add(this.txtOldPassword);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.txtNewPassword);
            this.groupBox9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(34, 52);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(461, 294);
            this.groupBox9.TabIndex = 67;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Change Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 22);
            this.label3.TabIndex = 20;
            this.label3.Text = "Old Password *";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPassword.ForeColor = System.Drawing.Color.Black;
            this.txtOldPassword.Location = new System.Drawing.Point(27, 61);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(406, 27);
            this.txtOldPassword.TabIndex = 1;
            this.txtOldPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(23, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 22);
            this.label4.TabIndex = 13;
            this.label4.Text = "New Password *";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.ForeColor = System.Drawing.Color.Black;
            this.txtNewPassword.Location = new System.Drawing.Point(27, 143);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(406, 27);
            this.txtNewPassword.TabIndex = 2;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(23, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "Confirm New Password *";
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmNewPassword.ForeColor = System.Drawing.Color.Black;
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(27, 219);
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(406, 27);
            this.txtConfirmNewPassword.TabIndex = 3;
            this.txtConfirmNewPassword.UseSystemPasswordChar = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.lblTitle.Location = new System.Drawing.Point(433, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(672, 43);
            this.lblTitle.TabIndex = 83;
            this.lblTitle.Text = "Update Password";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1108, 745);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlChangePassword);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlTitle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlChangePassword.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Panel pnlChangePassword;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfirmNewPassword;
        private System.Windows.Forms.Label lblTitle;
    }
}