namespace barangay.PL
{
    partial class frmMenu
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRedSide = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnAccomplishments = new System.Windows.Forms.Button();
            this.btnHouseholds = new System.Windows.Forms.Button();
            this.btnResidents = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(102)))), ((int)(((byte)(166)))));
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(258, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1108, 13);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(258, 758);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1108, 10);
            this.pnlBottom.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.pnlLeft.Controls.Add(this.btnSettings);
            this.pnlLeft.Controls.Add(this.pnlRedSide);
            this.pnlLeft.Controls.Add(this.btnLogout);
            this.pnlLeft.Controls.Add(this.btnReports);
            this.pnlLeft.Controls.Add(this.btnAccomplishments);
            this.pnlLeft.Controls.Add(this.btnHouseholds);
            this.pnlLeft.Controls.Add(this.btnResidents);
            this.pnlLeft.Controls.Add(this.btnHome);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(258, 768);
            this.pnlLeft.TabIndex = 2;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(258, 13);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1108, 745);
            this.pnlMain.TabIndex = 3;
            // 
            // pnlRedSide
            // 
            this.pnlRedSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(102)))), ((int)(((byte)(166)))));
            this.pnlRedSide.Location = new System.Drawing.Point(0, 93);
            this.pnlRedSide.Name = "pnlRedSide";
            this.pnlRedSide.Size = new System.Drawing.Size(10, 73);
            this.pnlRedSide.TabIndex = 7;
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = global::barangay.PL.Properties.Resources.settings__1_;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(12, 498);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(246, 73);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "          Settings";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::barangay.PL.Properties.Resources.logout__3_;
            this.btnLogout.Location = new System.Drawing.Point(108, 715);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(35, 32);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Image = global::barangay.PL.Properties.Resources.analysis;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(12, 417);
            this.btnReports.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(246, 73);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "          Reports";
            this.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnAccomplishments
            // 
            this.btnAccomplishments.FlatAppearance.BorderSize = 0;
            this.btnAccomplishments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccomplishments.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccomplishments.ForeColor = System.Drawing.Color.White;
            this.btnAccomplishments.Image = global::barangay.PL.Properties.Resources.market_positioning;
            this.btnAccomplishments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccomplishments.Location = new System.Drawing.Point(12, 336);
            this.btnAccomplishments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAccomplishments.Name = "btnAccomplishments";
            this.btnAccomplishments.Size = new System.Drawing.Size(246, 73);
            this.btnAccomplishments.TabIndex = 4;
            this.btnAccomplishments.Text = "          Accomplishments";
            this.btnAccomplishments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccomplishments.UseVisualStyleBackColor = true;
            this.btnAccomplishments.Click += new System.EventHandler(this.btnAccomplishments_Click);
            // 
            // btnHouseholds
            // 
            this.btnHouseholds.FlatAppearance.BorderSize = 0;
            this.btnHouseholds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHouseholds.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHouseholds.ForeColor = System.Drawing.Color.White;
            this.btnHouseholds.Image = global::barangay.PL.Properties.Resources.family;
            this.btnHouseholds.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHouseholds.Location = new System.Drawing.Point(12, 255);
            this.btnHouseholds.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHouseholds.Name = "btnHouseholds";
            this.btnHouseholds.Size = new System.Drawing.Size(246, 73);
            this.btnHouseholds.TabIndex = 3;
            this.btnHouseholds.Text = "          Households";
            this.btnHouseholds.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHouseholds.UseVisualStyleBackColor = true;
            this.btnHouseholds.Click += new System.EventHandler(this.btnHouseholds_Click);
            // 
            // btnResidents
            // 
            this.btnResidents.FlatAppearance.BorderSize = 0;
            this.btnResidents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResidents.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResidents.ForeColor = System.Drawing.Color.White;
            this.btnResidents.Image = global::barangay.PL.Properties.Resources.employee;
            this.btnResidents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResidents.Location = new System.Drawing.Point(12, 174);
            this.btnResidents.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnResidents.Name = "btnResidents";
            this.btnResidents.Size = new System.Drawing.Size(246, 73);
            this.btnResidents.TabIndex = 2;
            this.btnResidents.Text = "          Residents";
            this.btnResidents.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResidents.UseVisualStyleBackColor = true;
            this.btnResidents.Click += new System.EventHandler(this.btnResidents_Click);
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = global::barangay.PL.Properties.Resources.home__4_;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(12, 93);
            this.btnHome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(246, 73);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "          Home";
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.pnlLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnAccomplishments;
        private System.Windows.Forms.Button btnHouseholds;
        private System.Windows.Forms.Button btnResidents;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlRedSide;
        private System.Windows.Forms.Button btnSettings;
    }
}

