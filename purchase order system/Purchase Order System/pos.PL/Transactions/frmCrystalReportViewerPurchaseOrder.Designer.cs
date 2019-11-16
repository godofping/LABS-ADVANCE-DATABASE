namespace pos.PL.Transactions
{
    partial class frmCrystalReportViewerPurchaseOrder
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
            this.crvPurchaseOrder = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crPurchaseOrder1 = new pos.PL.Transactions.crPurchaseOrder();
            this.SuspendLayout();
            // 
            // crvPurchaseOrder
            // 
            this.crvPurchaseOrder.ActiveViewIndex = -1;
            this.crvPurchaseOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPurchaseOrder.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvPurchaseOrder.DisplayStatusBar = false;
            this.crvPurchaseOrder.DisplayToolbar = false;
            this.crvPurchaseOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPurchaseOrder.Location = new System.Drawing.Point(0, 0);
            this.crvPurchaseOrder.Name = "crvPurchaseOrder";
            this.crvPurchaseOrder.Size = new System.Drawing.Size(1008, 729);
            this.crvPurchaseOrder.TabIndex = 0;
            this.crvPurchaseOrder.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmCrystalReportViewerPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.crvPurchaseOrder);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "frmCrystalReportViewerPurchaseOrder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order";
            this.Load += new System.EventHandler(this.frmCrystalReportViewerPurchaseOrder_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPurchaseOrder;
        private crPurchaseOrder crPurchaseOrder1;
    }
}