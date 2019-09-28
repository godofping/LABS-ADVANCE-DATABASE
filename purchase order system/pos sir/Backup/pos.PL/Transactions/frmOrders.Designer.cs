namespace pos.PL.Transactions
{
    partial class frmOrders
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
            this.lblorderID = new System.Windows.Forms.Label();
            this.txtOrderid = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblorderID
            // 
            this.lblorderID.AutoSize = true;
            this.lblorderID.Location = new System.Drawing.Point(32, 30);
            this.lblorderID.Name = "lblorderID";
            this.lblorderID.Size = new System.Drawing.Size(47, 13);
            this.lblorderID.TabIndex = 0;
            this.lblorderID.Text = "Order ID";
            // 
            // txtOrderid
            // 
            this.txtOrderid.Location = new System.Drawing.Point(35, 47);
            this.txtOrderid.Name = "txtOrderid";
            this.txtOrderid.Size = new System.Drawing.Size(201, 20);
            this.txtOrderid.TabIndex = 1;
            // 
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 262);
            this.Controls.Add(this.txtOrderid);
            this.Controls.Add(this.lblorderID);
            this.Name = "frmOrders";
            this.Text = "frmOrders";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblorderID;
        private System.Windows.Forms.TextBox txtOrderid;
    }
}